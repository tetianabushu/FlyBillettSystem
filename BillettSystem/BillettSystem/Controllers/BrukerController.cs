using BillettSysModel;
using BLL;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BillettSystem.Controllers
{
    public class BrukerController : Controller
    {
        // GET: Bruker
        public ActionResult LoggInn()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoggInn(BrukerModel innbruker)
        {
            var brukerBLObj = new BrukerBL();
            var result = brukerBLObj.VerifiserBrukerIdb(innbruker);
            if (result == true) {
                Session["Bruker"] = innbruker.Brukernavn;
                return RedirectToAction("FlyRuteAdmin","Admin");
            }
            return View();
            // lage popup feil brukernavn eller passord, validering
            
        }

        public string GetBrukerNavn()
        {
            var bruker = Session["Bruker"];
            if (bruker != null)
            {
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(bruker.ToString());
            }
            return null;
        }

        public string LoggUt() 
        {
            Session["Bruker"] = null;
            return new JavaScriptSerializer().Serialize(true);
        }
    }
}