using BillettSysModel;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillettSystem.Controllers.APIControllers
{
    public class QuestionAnswersController : ApiController
    {
        // GET api/<controller>
        public List<QuestionAnswer> Get(string kategori)
        {
            var henteQA = new HelpBL();
            List<QuestionAnswer> alleQAFraKategori = henteQA.HenteQA(kategori);
            return alleQAFraKategori;
           
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