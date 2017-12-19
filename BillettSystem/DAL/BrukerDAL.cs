using BillettSysModel;
using DAL.DALModels;
using log4net;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DAL
{
    public class BrukerDAL
    {
        //public void TestMethod2()
        //{
        //    using (var db = new BillettSys())
        //    {
        //        try
        //        {
        //            var nyBruker = new Bruker();
        //            string salt = lagSalt();
        //            var passordOgSalt = "Tanja1377" + salt;
        //            byte[] passordDB = lagHash(passordOgSalt);
        //            nyBruker.Brukernavn = "TanjaAdmin";
        //            nyBruker.Passord = passordDB;
        //            nyBruker.Fornavn = "Tanja";
        //            nyBruker.Etternavn = "Admin";
        //            nyBruker.Epost = "bruker@admin.com";
        //            nyBruker.Salt = salt;

        //            db.Bruker.Add(nyBruker);
        //            db.SaveChanges();
        //        }
        //        catch (Exception)
        //        {
        //        }
        //    }
        //}

        private static ILog log = LogManager.GetLogger("BrukerDAL");

        public bool VerifiserBrukerIdb(BrukerModel brukerFraView)
        {
            try
            {
                log.Info("Verifiserer bruker: " + brukerFraView.Brukernavn);
                using (var db = new BillettSys())
                {
                    var funnetBruker = db.Bruker.FirstOrDefault(b => b.Brukernavn.ToLower() == brukerFraView.Brukernavn.ToLower());
                    if (funnetBruker != null)
                    {
                        byte[] hashedPassord = lagHash(brukerFraView.Passord + funnetBruker.Salt);
                        bool riktigBruker = funnetBruker.Passord.SequenceEqual(hashedPassord);  // Sammenlign med lagret hass passord
                        return riktigBruker;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
           
        }

        private static string lagSalt()
        {
            byte[] randomArray = new byte[10];
            string randomString;

            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomArray);
            randomString = Convert.ToBase64String(randomArray);
            return randomString;
        }

        private static byte[] lagHash(string innStreng)
        {
            byte[] innData, utData;
            var algoritme = SHA256.Create();
            innData = Encoding.UTF8.GetBytes(innStreng);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }
    }
}
