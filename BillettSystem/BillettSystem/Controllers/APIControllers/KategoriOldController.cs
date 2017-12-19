using BillettSystem.Models.DataModels;
using BillettSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BillettSysModel;
using BLL;
using System.Web.Script.Serialization;
using System.Text;

namespace BillettSystem.Controllers
{
    public class KategoriOldController : ApiController
    {
        public HttpResponseMessage GetHenteKategorier()
        {
            var henteKategorier = new HelpBL();
            List<string> allekategorier = henteKategorier.HentAlleKategorier();

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(allekategorier);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };

        }

        public List<QuestionAnswer> GetHenteAlleQAFraKategori(string kategori)
        {
            var henteQA = new HelpBL();
            List<QuestionAnswer> alleQAFraKategori = henteQA.HenteQA(kategori);
            return alleQAFraKategori;
        }
    }


}
