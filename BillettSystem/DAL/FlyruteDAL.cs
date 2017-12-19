using BillettSysModel;
using DAL.DALModels;
using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using log4net;

namespace DAL
{
    public class FlyruteDAL : IFlyruteDAL
    {
        private static ILog log = LogManager.GetLogger("FlyruteDAL");

        public FlyruteListe GetRuterFraDB()
        {
            try
            {
                log.Info("Henter Alle Flyruter fra DB");
                using (var db = new BillettSys())
                {
                    FlyruteListe obj = new FlyruteListe();
                    
                    foreach (FlyRute r in db.FlyRute)
                    {
                        Flyrute flyRuteObjekt = GetFlyruteObjekt(r);
                        obj.Flyruter.Add(flyRuteObjekt);
                    }
                    return obj;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }            
        }
        
        public Flyrute GetFlyRuteFraDB(int flyRuteId)
        {
            try
            {
                log.Info("Henter Flyrute fra DB med Id: "+ flyRuteId);
                using (var db = new BillettSys())
                {
                    var r = db.FlyRute.SingleOrDefault(x => x.Id == flyRuteId);
                    if (r == null) return null;

                    Flyrute flyRuteObjekt = GetFlyruteObjekt(r);

                    return flyRuteObjekt;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }            
        }

        private static Flyrute GetFlyruteObjekt(FlyRute r)
        {          
                var prisObjekt = r.FlyRutePris.FirstOrDefault();
                return new Flyrute
                {
                    Id = r.Id,
                    Fra = r.Fra,
                    Til = r.Til,
                    AvreiseDag = r.AvreiseTid.Date.ToString("dd/MM/yyyy"),
                    AvreiseTid = r.AvreiseTid.TimeOfDay.ToString(),
                    AnkomstDag = r.AnkomstTid.Date.ToString("dd/MM/yyyy"),
                    AnkomstTid = r.AnkomstTid.TimeOfDay.ToString(),
                    BillettprisVoksen = prisObjekt == null ? -1 : prisObjekt.prisEconClass_voksen,
                    BillettprisBarn = prisObjekt == null ? -1 : prisObjekt.prisEconClass_barn,
                    FlySelskap = r.Flyselskap,
                    AntallLedigePlasser = r.LedigPlassEcon,
                    KanEndre = r.AvreiseTid > DateTime.Now
                };
        }

        public bool UpdateFlyrute(Flyrute model)
        {
            try
            {
                log.Info("Oppdaterer Flyrute med Id: " + model.Id);
                using (var db = new BillettSys())
                {
                    var avreisetid = DateTime.ParseExact(model.AvreiseDag + model.AvreiseTid, "dd/MM/yyyyHH:mm", CultureInfo.InvariantCulture);
                    var ankomsttid = DateTime.ParseExact(model.AnkomstDag + model.AnkomstTid, "dd/MM/yyyyHH:mm", CultureInfo.InvariantCulture);

                    var r = db.FlyRute.SingleOrDefault(x => x.Id == model.Id);
                    r.Fra = model.Fra;
                    r.Til = model.Til;
                    r.AvreiseTid = avreisetid;
                    r.AnkomstTid = ankomsttid;
                    r.LedigPlassEcon = model.AntallLedigePlasser;
                    r.Flyselskap = model.FlySelskap;
                    r.FlyRutePris.First().prisEconClass_voksen = model.BillettprisVoksen;
                    r.FlyRutePris.First().prisEconClass_barn = model.BillettprisBarn;

                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return false;               
            }            
        }

        public List<Flyrute> FinnTilgjengeligeFly(string fra, string til, int passasjererCount)
        {
            try
            {
                var currentTime = DateTime.Now;
                currentTime.AddHours(1);

                log.Info("Henter alle Tilgjengelige Flyruter fra: " + fra + " til: " + til);
                using (var db = new BillettSys())
                {
                    var flyruterFraDb = db.FlyRute.Where(x => x.Fra == fra && x.Til == til && 
                    x.LedigPlassEcon >= passasjererCount).ToList();

                    flyruterFraDb = flyruterFraDb.Where(x => 
                        (x.AvreiseTid.Date == currentTime.Date && x.AvreiseTid.TimeOfDay > currentTime.TimeOfDay) ||
                        (x.AvreiseTid.Date > currentTime.Date)).ToList();

                    var resultToReturn = new List<Flyrute>();

                    foreach (var item in flyruterFraDb)
                    {
                        var flyrute = new Flyrute
                        {
                            Id = item.Id,
                            Fra = item.Fra,
                            Til = item.Til,
                            AvreiseDag = item.AvreiseTid.ToString("dd/MM/yyyy"),
                            AvreiseTid = item.AvreiseTid.ToString("HH:mm"),
                            AnkomstDag = item.AnkomstTid.ToString("dd/MM/yyyy"),
                            AnkomstTid = item.AnkomstTid.ToString("HH:mm"),
                            AntallLedigePlasser = item.LedigPlassEcon,
                            BillettprisVoksen = item.FlyRutePris.First().prisEconClass_voksen,
                            BillettprisBarn = item.FlyRutePris.First().prisEconClass_barn,
                            FlySelskap = item.Flyselskap                            
                        };
                        resultToReturn.Add(flyrute);
                    }

                    return resultToReturn;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }

        public bool CreateFlyrute(Flyrute model)
        {
            try
            {
                log.Info("Oppretter ny Flyrute fra:" + model.Fra + " og til: " + model.Til);
                using (var db = new BillettSys())
                {
                    var avreisetid = DateTime.ParseExact(model.AvreiseDag + model.AvreiseTid, "dd/MM/yyyyHH:mm", CultureInfo.InvariantCulture);
                    var ankomsttid = DateTime.ParseExact(model.AnkomstDag + model.AnkomstTid, "dd/MM/yyyyHH:mm", CultureInfo.InvariantCulture);

                    var newFlyrute = new FlyRute
                    {
                        Fra = model.Fra,
                        Til = model.Til,
                        AvreiseTid = avreisetid,
                        AnkomstTid = ankomsttid,
                        LedigPlassEcon = model.AntallLedigePlasser,
                        Flyselskap = model.FlySelskap
                    };
                    
                    var newFlyrutePris = new FlyRutePris
                    {
                        prisEconClass_voksen = model.BillettprisVoksen,
                        prisEconClass_barn = model.BillettprisBarn,                        
                    };

                    newFlyrute.FlyRutePris.Add(newFlyrutePris); // kobler Flyrute til flyrutepris slik at EF vet at de må opprettes samtidig med Foreignkeys
                    db.FlyRute.Add(newFlyrute);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return false;
            }
        }

        public bool DeleteFlyRute(int flyruteId)
        {
            try
            {
                log.Info("Sletter flyrute med Id:" + flyruteId);
                using (var db = new BillettSys())
                {
                    var flyruteToDelete = db.FlyRute.SingleOrDefault(x => x.Id == flyruteId);
                    if (flyruteToDelete.FlyRute_i_Ordre.Any()) return false;

                    if (flyruteToDelete != null)
                    {
                        db.FlyRute.Remove(flyruteToDelete);
                        db.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return false;
            }
        }
    }
}
