using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace BillettSystem.Controllers.APIControllers
{
    public class KategorierController : ApiController
    {
        // GET api/<controller>
        public List<string> Get()
        {
            var henteKategorier = new HelpBL();
            List<string> allekategorier = henteKategorier.HentAlleKategorier();
            return allekategorier;
            //var Json = new JavaScriptSerializer();
            //return Json.Serialize(allekategorier);

            //return new HttpResponseMessage()
            //{
            //    Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
            //    StatusCode = HttpStatusCode.OK
            //};
        }

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}