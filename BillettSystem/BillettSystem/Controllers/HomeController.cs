using BillettSystem.Models;
using BillettSystem.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BillettSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new SearchParameters());
        }

        public ActionResult Error(string message)
        {
            return View(message);
        }

        public string hentAlleFraFlyplasser()
        {
            using (var db = new BillettSys())
            {
                List<FlyRute> alleFlyRuter = db.FlyRute.ToList();

                var alleFra = new List<string>();

                foreach (FlyRute f in alleFlyRuter)
                {
                    alleFra.Add(f.Fra);
                }
                var uniqueFra = alleFra.Distinct();
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(uniqueFra);
            }
        }

        public string hentTilFlyplasser(string valgtFra)
        {
            using (var db = new BillettSys())
            {
                List<FlyRute> alleTilFlyRuter = db.FlyRute.ToList();

                var alleTil = new List<string>();

                foreach (FlyRute f in alleTilFlyRuter)
                {
                    if (f.Fra == valgtFra)
                    {
                        alleTil.Add(f.Til);
                    }
                }
                var uniqueTil = alleTil.Distinct();
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(uniqueTil);
            }
                
        }

        // Henter flyruter basert på søk verdier. Bruker FlyRuteResutat model for konvertere til JSON.
        public string getSearchResultat(string fraFlyplass, string tilFlyPlass, bool envei, string fraDato, string returDato, 
            int antallVoksen, int antallBarn)
        {
            var alleReiser = new List<Reise>();
            using (var db = new BillettSys())
            {
                List<FlyRute> alleRuterFraDb = db.FlyRute.ToList();

                var fraDatoDatetime = DateTime.ParseExact(fraDato, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var fraDag = fraDatoDatetime.Date;
                foreach (FlyRute f in alleRuterFraDb)
                {
                    if (f.Fra.ToLower() == fraFlyplass.ToLower() && f.Til.ToLower() == tilFlyPlass.ToLower() && 
                        f.AvreiseTid.Date == fraDag &&
                        f.LedigPlassEcon - antallVoksen - antallBarn >= 0)
                    {
                        FlyRuteResultat fraFlyRute = CreateFlyRuteResultat(f);

                        if (envei == true)
                        {
                            var reise = new Reise
                            {
                                TotaltPris = (f.FlyRutePris.FirstOrDefault().prisEconClass_voksen * antallVoksen) +
                                             (f.FlyRutePris.FirstOrDefault().prisEconClass_barn * antallBarn),
                                AntallVoksen = antallVoksen,
                                AntallBarn = antallBarn                                
                            };

                            reise.AlleFlyRuter.Add(fraFlyRute);
                            alleReiser.Add(reise);
                        }
                        else // hvis retur
                        {
                            var returDatoDateTime = DateTime.ParseExact(returDato, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            FinnRetur(returDatoDateTime, alleReiser, alleRuterFraDb, f, fraFlyRute, antallVoksen, antallBarn);
                        }
                    }
                }

                alleReiser = alleReiser.OrderBy(X => X.TotaltPris).ToList();
            }
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(alleReiser);
        }

        private static void FinnRetur(DateTime? returDato, List<Reise> alleReiser, List<FlyRute> alleRuterFraDb, 
                                       FlyRute f, FlyRuteResultat fraFlyRute, int antallVoksen, int antallBarn)
        {
            var returDag = returDato.Value.Date;
            foreach (FlyRute r in alleRuterFraDb)
            {
                if (r.Fra.ToLower() == fraFlyRute.Til.ToLower() && r.Til.ToLower() == fraFlyRute.Fra.ToLower() &&
                    r.AvreiseTid.Date == returDag &&
                    r.LedigPlassEcon - antallVoksen - antallBarn >= 0) //vei tilbake 
                {
                    FlyRuteResultat returFlyRute = CreateFlyRuteResultat(r);

                    var reise = new Reise();
                    reise.AlleFlyRuter.Add(fraFlyRute);
                    reise.AlleFlyRuter.Add(returFlyRute);
                    reise.TotaltPris = (f.FlyRutePris.FirstOrDefault().prisEconClass_voksen * antallVoksen) +
                                        (f.FlyRutePris.FirstOrDefault().prisEconClass_barn * antallBarn) +
                                        (r.FlyRutePris.FirstOrDefault().prisEconClass_voksen * antallVoksen) +
                                        (r.FlyRutePris.FirstOrDefault().prisEconClass_barn * antallBarn);
                    reise.AntallVoksen = antallVoksen;
                    reise.AntallBarn = antallBarn;                    
                    alleReiser.Add(reise);
                }
            }
        }

        private static FlyRuteResultat CreateFlyRuteResultat(FlyRute f)
        {
            return new FlyRuteResultat
            {
                Id = f.Id,
                Fra = f.Fra,
                Til = f.Til,
                UtreiseDag = f.AvreiseTid.Date.ToString("d MMM yyyy"),
                InnreiseDag = f.AnkomstTid.Date.ToString("d MMM yyyy"),
                UtreiseTid = f.AvreiseTid.ToString("HH:mm tt"),
                InnreiseTid = f.AnkomstTid.ToString("HH:mm tt"),
                FlySelskap = f.Flyselskap
            };
        }

        public ActionResult ValgtFlyDetaljer()
        {
            var reise = (Reise)Session["Reise"];
            return View(reise);
        }

        public void SaveOrdreDetaljer(List<Passasjer> passasjerer)
        {
            var reise = (Reise)Session["Reise"];
            reise.BagasjePris = 0;
            foreach (var item in passasjerer)
            {
                reise.BagasjePris = reise.BagasjePris + item.AntallBagasje * 200;
            }
            Session["Reise"] = reise;
            Session["Passasjerer"] = passasjerer;
        }

        public void SaveValgtReise(Reise reise)
        {
            Session["Reise"] = reise;
        }

        public string getReiseDetaljer()
        {
            var reise = (Reise)Session["Reise"];
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(reise);            
        }

        public string getPassasjerDetaljer()
        {
            var passasjerer = Session["Passasjerer"] as List<Passasjer>;
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(passasjerer);
        }

        public ActionResult Betaling()
        {
            var reise = (Reise)Session["Reise"];
            return View(reise);
        }
        
        public ActionResult GodkjentBetaling()
        {
            try
            {
                var reise = (Reise)Session["Reise"];
                var passasjerer = Session["Passasjerer"] as List<Passasjer>;

                using (var db = new BillettSys())
                {
                    foreach (var rute in reise.AlleFlyRuter)
                    {
                        var ruteInDatabase = db.FlyRute.SingleOrDefault(x => x.Id == rute.Id);
                        if (ruteInDatabase.LedigPlassEcon - reise.AntallVoksen - reise.AntallBarn >= 0)
                            ruteInDatabase.LedigPlassEcon = ruteInDatabase.LedigPlassEcon - reise.AntallVoksen - reise.AntallBarn;
                        else
                        {
                            //warning
                            throw new Exception("Ingen ledige plasser lenger!");
                        }
                    }

                    Ordre ordre = CreateDatabaseOrdre(reise, passasjerer);
                    db.Ordre.Add(ordre);

                    // oppdatere database
                    db.SaveChanges();
                }

                return View(reise);

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", ex.Message);
            }
        }

        private static Ordre CreateDatabaseOrdre(Reise reise, List<Passasjer> passasjerer)
        {
            var ordre = new Ordre();
            ordre.datoBetaling = DateTime.Now;
            ordre.ordreStatus = "Betalt";
            ordre.pris = reise.TotaltPris + reise.BagasjePris;
            ordre.enVei = reise.AlleFlyRuter.Count == 1? 1 : 0;
            var count = 1;
            foreach (var i in reise.AlleFlyRuter)
            {
                var flyRuteIOrdre = new FlyRute_i_Ordre();
                flyRuteIOrdre.FlyRute_Id = i.Id; // flyrute id fra session, på vei dit og retur, hvis det er retur
                flyRuteIOrdre.rekkefølge = count;
                count++;

                ordre.FlyRute_i_Ordre.Add(flyRuteIOrdre);
            }
            
            foreach (var passasjer in passasjerer)
            {
                var ordreLinje = new OrdreLinje();
                if(passasjer.Voksen == true)
                    ordreLinje.ErVoksen = 1;
                else ordreLinje.ErVoksen = 0;
                ordreLinje.antallBagasjePerLinje = passasjer.AntallBagasje;

                ordre.OrdreLinje.Add(ordreLinje);

                var gjesteKunde = new GjestKundeTabell();
                gjesteKunde.Fornavn = passasjer.Name;
                gjesteKunde.Etternavn = passasjer.EtterNavn;
                gjesteKunde.epost = passasjer.Epost;
                gjesteKunde.Adresse = passasjer.Adresse;
                                
                ordre.GjestKundeTabell.Add(gjesteKunde);

                ordreLinje.GjestKundeTabell = gjesteKunde;
                gjesteKunde.OrdreLinje.Add(ordreLinje);
            }
            
            return ordre;
        }

        public void NullstilleSession()
        {
            Session["Reise"] = null;
            Session["Passasjerer"] = null;
        }
    }
}
