using BillettSysModel;
using DAL.DALModels;
using System.Linq;
using System;
using log4net;

namespace DAL
{
    public class OrdreDAL : IOrdreDAL
    {
        private static ILog log = LogManager.GetLogger("OrdreDAL");

        public OrdreListe GetOrdrerFraDb()
        {
            try
            {
                log.Info("Henter alle ordrer fra DB.");
                using (var db = new BillettSys())
                {
                    OrdreListe objekt = new OrdreListe();
                    foreach (DALModels.Ordre o in db.Ordre)
                    {
                        BillettSysModel.Ordre ordreObjekt = GetOrdreObject(o);

                        objekt.Ordrer.Add(ordreObjekt);
                    }
                    return objekt;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        public OrdreDetaljer GetOrdreDetaljer(int ordreId)
        {
            try
            {
                log.Info("Henter detaljer for ordre med Id: " + ordreId);
                using (var db = new BillettSys())
                {
                    var ordreDetaljerObjekt = new OrdreDetaljer();

                    var o = db.Ordre.FirstOrDefault(x => x.Id == ordreId);
                    ordreDetaljerObjekt.Id = o.Id;
                    ordreDetaljerObjekt.Pris = o.pris;
                    ordreDetaljerObjekt.BestillingsDato = o.datoBetaling.ToString();
                    ordreDetaljerObjekt.Status = o.ordreStatus;
                    ordreDetaljerObjekt.KanRedigere = o.FlyRute_i_Ordre.First().FlyRute.AvreiseTid > DateTime.Now;

                    ordreDetaljerObjekt.Utreise = new BestiltFlyRute();
                    ordreDetaljerObjekt.Utreise.FlyruteId = o.FlyRute_i_Ordre.First().FlyRute.Id;
                    ordreDetaljerObjekt.Utreise.Fra = o.FlyRute_i_Ordre.First().FlyRute.Fra;
                    ordreDetaljerObjekt.Utreise.FraDato = o.FlyRute_i_Ordre.First().FlyRute.AvreiseTid.Date.ToString(format: "dd/MM/yyyy");
                    ordreDetaljerObjekt.Utreise.FraTid = o.FlyRute_i_Ordre.First().FlyRute.AvreiseTid.ToString(format: "HH:mm");

                    ordreDetaljerObjekt.Utreise.Til = o.FlyRute_i_Ordre.First().FlyRute.Til;
                    ordreDetaljerObjekt.Utreise.TilDato = o.FlyRute_i_Ordre.First().FlyRute.AnkomstTid.Date.ToString(format: "dd/MM/yyyy");
                    ordreDetaljerObjekt.Utreise.TilTid = o.FlyRute_i_Ordre.First().FlyRute.AnkomstTid.ToString(format: "HH:mm");
                    ordreDetaljerObjekt.Utreise.FlySelskap = o.FlyRute_i_Ordre.First().FlyRute.Flyselskap;
                    ordreDetaljerObjekt.Utreise.Type = o.enVei.ToString("En vei");

                    if (o.enVei != 1 )
                    {
                        ordreDetaljerObjekt.Retur = new BestiltFlyRute();
                        ordreDetaljerObjekt.Retur.FlyruteId = o.FlyRute_i_Ordre.Skip(1).First().FlyRute.Id;
                        ordreDetaljerObjekt.Retur.Fra = o.FlyRute_i_Ordre.Skip(1).First().FlyRute.Fra;
                        ordreDetaljerObjekt.Retur.FraDato = o.FlyRute_i_Ordre.Skip(1).First().FlyRute.AvreiseTid.Date.ToString(format: "dd/MM/yyyy");
                        ordreDetaljerObjekt.Retur.FraTid = o.FlyRute_i_Ordre.Skip(1).First().FlyRute.AvreiseTid.ToString(format: "HH:mm");

                        ordreDetaljerObjekt.Retur.Til = o.FlyRute_i_Ordre.Skip(1).First().FlyRute.Til;
                        ordreDetaljerObjekt.Retur.TilDato = o.FlyRute_i_Ordre.Skip(1).First().FlyRute.AnkomstTid.Date.ToString(format: "dd/MM/yyyy");
                        ordreDetaljerObjekt.Retur.TilTid = o.FlyRute_i_Ordre.Skip(1).First().FlyRute.AnkomstTid.ToString(format: "HH:mm");
                        ordreDetaljerObjekt.Retur.FlySelskap = o.FlyRute_i_Ordre.Skip(1).First().FlyRute.Flyselskap;
                        ordreDetaljerObjekt.Retur.Type = o.enVei.ToString("Tur retur");
                    }
                    foreach (var p in o.GjestKundeTabell)
                    {
                        var passasjer = new Passasjer();
                        passasjer.Id = p.Id;
                        passasjer.Fornavn = p.Fornavn;
                        passasjer.Etternavn = p.Etternavn;
                        passasjer.ErVoksen = p.OrdreLinje.First().ErVoksen == 1 ? "Voksen" : "Barn";
                        passasjer.Bagasje = p.OrdreLinje.First().antallBagasjePerLinje;
                        ordreDetaljerObjekt.Passasjerer.Add(passasjer);
                    }

                    return ordreDetaljerObjekt;
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        public bool KansellerOrdre(int ordreId)
        {
            try
            {
                log.Info("Kansellerer ordre med Id: " + ordreId);
                using (var db = new BillettSys())
                {
                    var ordre = db.Ordre.FirstOrDefault(x => x.Id == ordreId);
                    if(ordre != null)
                    {
                        ordre.ordreStatus = "Kansellert";
                    }
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        public bool UpdateOrdreDetaljer(OrdreDetaljer model)
        {
            try
            {
                log.Info("Oppdaterer ordre detaljer for Ordre med Id: " + model.Id);
                using (var db = new BillettSys())
                {
                    var dbOrdre = db.Ordre.FirstOrDefault(x => x.Id == model.Id);
                    if (dbOrdre == null) return false;

                    dbOrdre.pris = model.Pris;
                    dbOrdre.ordreStatus = model.Status;


                    // Oppdatere utreise
                    dbOrdre.FlyRute_i_Ordre.First().FlyRute.LedigPlassEcon += model.Passasjerer.Count;
                    dbOrdre.FlyRute_i_Ordre.First().FlyRute_Id = model.Utreise.FlyruteId;
                    var nyUtreise = db.FlyRute.SingleOrDefault(x => x.Id == model.Utreise.FlyruteId);
                    if (nyUtreise != null)
                        nyUtreise.LedigPlassEcon = nyUtreise.LedigPlassEcon - model.Passasjerer.Count;


                    // Oppdatere retur
                    if (model.Retur != null)
                    {
                        dbOrdre.FlyRute_i_Ordre.Skip(1).First().FlyRute.LedigPlassEcon += model.Passasjerer.Count;
                        dbOrdre.FlyRute_i_Ordre.Skip(1).First().FlyRute_Id = model.Retur.FlyruteId;

                        var nyRestur = db.FlyRute.SingleOrDefault(x => x.Id == model.Retur.FlyruteId);
                        if (nyRestur != null)
                            nyRestur.LedigPlassEcon = nyUtreise.LedigPlassEcon - model.Passasjerer.Count;
                    }

                    foreach (var p in model.Passasjerer)
                    {
                        var kundeToUpdate = dbOrdre.GjestKundeTabell.FirstOrDefault(k => k.Id == p.Id);
                        if (kundeToUpdate == null) return false;

                        kundeToUpdate.Fornavn = p.Fornavn;
                        kundeToUpdate.Etternavn = p.Etternavn;
                        kundeToUpdate.OrdreLinje.First().ErVoksen = p.ErVoksen == "Voksen" ? 1 : 0;
                        kundeToUpdate.OrdreLinje.First().antallBagasjePerLinje = p.Bagasje;
                    }

                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        public bool SaveKundeEndringer(Passasjer kunde)
        {
            try
            {
                log.Info("Lagrer kundeendringer");
                using (var db = new BillettSys())
                {
                    var p = db.GjestKundeTabell.FirstOrDefault(x => x.Id == kunde.Id);
                    if (p != null)
                    {
                        p.Fornavn = kunde.Fornavn;
                        p.Etternavn = kunde.Etternavn;
                        p.OrdreLinje.First().ErVoksen = kunde.ErVoksen == "Voksen" ? 1 : 0;
                        p.OrdreLinje.First().antallBagasjePerLinje = kunde.Bagasje;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }

            return false;
        }

        public Passasjer GetKunde(int passasjerId)
        {
            try
            {
                log.Info("Henter kunde med Id: " + passasjerId);
                using (var db = new BillettSys())
                {
                    var p = db.GjestKundeTabell.FirstOrDefault(x => x.Id == passasjerId);
                    if(p != null)
                    {
                        var passasjer = new Passasjer
                        {
                            Id = p.Id,
                            Fornavn = p.Fornavn,
                            Etternavn = p.Etternavn,
                            ErVoksen = p.OrdreLinje.First().ErVoksen == 1 ? "Voksen" : "Barn",
                            Bagasje = p.OrdreLinje.First().antallBagasjePerLinje                            
                        };
                        return passasjer;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }

            return null;
        }

        private static BillettSysModel.Ordre GetOrdreObject(DALModels.Ordre o)
        {
            var ordreObjekt = new BillettSysModel.Ordre();
            ordreObjekt.OrdreId = o.Id;
            ordreObjekt.DatoBetaling = o.datoBetaling.ToString();
            ordreObjekt.Type = o.enVei == 1 ? "Envei" : "Tur-retur";
            ordreObjekt.Fra = o.FlyRute_i_Ordre.First().FlyRute.Fra;
            ordreObjekt.Til = o.FlyRute_i_Ordre.First().FlyRute.Til;
            ordreObjekt.pris = o.pris;
            ordreObjekt.KanEndre = o.FlyRute_i_Ordre.First().FlyRute.AvreiseTid > DateTime.Now;
            ordreObjekt.Status = o.ordreStatus;
            
            return ordreObjekt;
        }

    }
}
