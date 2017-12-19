using BillettSysModel;
using BLL;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System;

namespace BillettSystem.Controllers
{
    public class AdminController : Controller
    {
        private IAdminBL _adminBL;

        public AdminController()
        {
            _adminBL = new AdminBL();
        }

        public AdminController(IAdminBL adminBL)
        {
            _adminBL = adminBL;
        }

        // GET: Admin
        public ActionResult FlyRuteAdmin()
        {
            if (!LogedIn())
                return RedirectToAction("LoggInn", "Bruker");

            var liste = _adminBL.GetFlyruteListe();
            return View(liste);
        }

        public ActionResult OrdrerAdmin()
        {
            if (!LogedIn())
                return RedirectToAction("LoggInn", "Bruker");
            var ordreliste = _adminBL.GetOrdreListe();
            return View(ordreliste);
        }

        public string GetOrdreDetaljer(int ordreId)
        {
            if (!LogedIn()) RedirectToAction("LoggInn", "Bruker");
            var ordreDetaljer= _adminBL.GetOrdreDetaljer(ordreId);

            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(ordreDetaljer);
        }    
        
        public ActionResult FlyRuteEdit(int flyruteId)
        {
            if (!LogedIn())
                return RedirectToAction("LoggInn", "Bruker");
            if (flyruteId == 0)
            {
                return View(new Flyrute());
            }
            
            var flyRuteModel = _adminBL.GetFlyrute(flyruteId);
            return View(flyRuteModel);
        }

        public bool KansellerOrdre(int ordreId)
        {            
            return _adminBL.KansellerOrdre(ordreId);
        }

        public bool DeleteFlyRute(int flyruteId)
        {            
            return _adminBL.DeleteFlyrute(flyruteId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FlyRuteEdit(Flyrute flyRuteModel)
        {
            if (!LogedIn())
                return RedirectToAction("LoggInn", "Bruker");
            
            bool result = _adminBL.SaveFlyrute(flyRuteModel);
            return RedirectToAction("FlyRuteAdmin");
        }

        //public ActionResult KundeEdit(int passasjerId)
        //{
        //    if (!LogedIn())
        //        return RedirectToAction("LoggInn", "Bruker");

        //    var adminBLObject = new AdminBL();
        //    var passasjer = adminBLObject.GetKunde(passasjerId);
        //    return View(passasjer);
        //}

        //public ActionResult KundeEdit(Passasjer kunde)
        //{
        //    if (!LogedIn())
        //        return RedirectToAction("LoggInn", "Bruker");

        //    var adminBLObject = new AdminBL();
        //    var passasjer = adminBLObject.SaveKundeEndringer(kunde);
        //    return View(passasjer);
        //}

        public ActionResult OrdreEdit(int ordreId)
        {
            if (!LogedIn())
                return RedirectToAction("LoggInn", "Bruker");
            
            var ordreDetaljer = _adminBL.GetOrdreDetaljer(ordreId);
            return View(ordreDetaljer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrdreEdit(OrdreDetaljer ordreDetaljer)
        {
            if (!LogedIn())
                return RedirectToAction("LoggInn", "Bruker");
            
            bool result = _adminBL.UpdateOrdreDetaljer(ordreDetaljer);
            return View(ordreDetaljer);
        }

        public string FinnTilgjengeligeFly(string fra, string til, int passasjerer)
        {
            var tilgjengeligeFly = _adminBL.FinnTilgjengeligeFly(fra, til, passasjerer);

            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(tilgjengeligeFly);
        }

        private bool LogedIn()
        {
            var bruker = Session["Bruker"];
            if (bruker != null)
                return true;
            return false;
        }
    }
}