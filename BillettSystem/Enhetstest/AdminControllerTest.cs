using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillettSystem.Controllers;
using BLL;
using DAL.DALModels;
using System.Web.Mvc;

namespace Enhetstest
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void FlyRuteAdmin_GetFlyRuteMedId()
        {
            // Arrange
            //var controller = new AdminController(new AdminBL(new FlyruteDALStub(), null));

            //var forventetResultat = new BillettSysModel.Flyrute()
            //{
            //    Id = 5,
            //    Fra = "Oslo",
            //    Til = "London"
            //};
            
            //// Act
            //var actionResult = (ViewResult)controller.FlyRuteEdit(5);
            //var resultat = (BillettSysModel.Flyrute)actionResult.Model;
            //// Assert

            //Assert.AreEqual(actionResult.ViewName, "");
            
            //Assert.AreEqual(forventetResultat.Id, resultat.Id);
            //Assert.AreEqual(forventetResultat.Fra, resultat.Fra);
            //Assert.AreEqual(forventetResultat.Til, resultat.Til);
        }
    }
}
