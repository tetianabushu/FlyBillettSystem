using BillettSysModel;
using DAL.DALModels;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HelpDAL
    {
        public List<string> hentAlleKategorierFraDb()
        {
            try
            {
                using (var db = new BillettSys())
                {
                    List<string> alleKategorier = db.QuestionAnswer.Select(q=>q.Kategori).Distinct().ToList();
                    return alleKategorier;

                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<BillettSysModel.QuestionAnswer> HenteAlleQAForKategori(string kategori)
        {
            try
            {
                using (var db = new BillettSys())
                {
                    var kategoriQAResult = new List<BillettSysModel.QuestionAnswer>();
                    var kategoriQAFraDb = db.QuestionAnswer.Where(q => q.Kategori == kategori).ToList();
                    foreach (var item in kategoriQAFraDb)
                    {
                        var qA = new BillettSysModel.QuestionAnswer();
                        qA.Id = item.Id;
                        qA.Kategori = item.Kategori;
                        qA.Question = item.Question;
                        qA.Svar = item.Answer;                        
                        kategoriQAResult.Add(qA);
                    }
                    return kategoriQAResult;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void LagreKundeQuestion(KundeQuestion questioninn)
        {
            try
            {
                using (var db = new BillettSys())
                {
                    var questionDb = new KundeQuestions();
                    
                    questionDb.Kategori = questioninn.Kategori;
                    questionDb.QuestionTittel = questioninn.QuestionTittel;
                    questionDb.QuestionText = questioninn.QuestionText;
                    questionDb.Epost = questioninn.Epost;
                    questionDb.Behandlet = questioninn.Behandlet;
                    questionDb.Navn = questioninn.Brukernavn;
                    questionDb.DatoSendt = DateTime.Now;
                    db.KundeQuestions.Add(questionDb);
                    db.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw;
            }            
        }

        public List<KundeQuestion> henteQuestionsFraSkjema()
        {
            try
            {
                using (var db = new BillettSys())
                {
                    var liste = new List<KundeQuestion>();
                    var listeFradb = db.KundeQuestions.OrderByDescending(d=>d.DatoSendt).ToList();
                    
                    foreach (var item in listeFradb)
                    {
                        var q = new KundeQuestion();
                        q.Kategori = item.Kategori;
                        q.Brukernavn = item.Navn;
                        q.Epost = item.Epost;
                        q.QuestionTittel = item.QuestionTittel;
                        q.QuestionText = item.QuestionText;
                        q.DatoSendt = item.DatoSendt.ToString();
                        liste.Add(q);
                    }
                    return liste;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }        
}


    

