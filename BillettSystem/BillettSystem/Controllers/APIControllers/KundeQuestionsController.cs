using System.Collections.Generic;
using System.Web.Http;
using Model;
using BLL;

namespace BillettSystem.Controllers.APIControllers
{
    public class KundeQuestionsController : ApiController
    {
        // GET api/<controller> for å hente
        public List<KundeQuestion> Get()
        {
            var blObjekt = new HelpBL();
            var listeFraSkjema = blObjekt.henteQuestionsFraSkjema();

            return listeFraSkjema;
        }        

        // POST api/<controller> for å opprette
        public void Post([FromBody]KundeQuestion questioninn)
        {
            if (ModelState.IsValid)
            {
                var obj = new HelpBL();
                obj.LagreKundeQuestion(questioninn);
            }
        }
    }
}