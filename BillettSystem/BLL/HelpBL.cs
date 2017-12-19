using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillettSysModel;
using DAL;
using Model;

namespace BLL
{
    public class HelpBL
    {
        public List<string> HentAlleKategorier()
        {
            var DALobjekt = new HelpDAL();

            List<string> alleKategorier = DALobjekt.hentAlleKategorierFraDb();
            return alleKategorier;
        }

        public List<QuestionAnswer> HenteQA(string kategori)
        {
            var DALobjekt = new HelpDAL();
            List<QuestionAnswer> katQA = DALobjekt.HenteAlleQAForKategori(kategori);
            return katQA;
        }
        public void LagreKundeQuestion(KundeQuestion question)
        {
            var DALObjekt = new HelpDAL();
            DALObjekt.LagreKundeQuestion(question);
        }
        public List<KundeQuestion> henteQuestionsFraSkjema()
        {
            var obj = new HelpDAL();
            var listefraSkjema = obj.henteQuestionsFraSkjema();
            return listefraSkjema;
        }
    }
}
