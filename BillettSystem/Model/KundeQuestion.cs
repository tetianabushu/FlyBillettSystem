using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class KundeQuestion
    {
        public int Id { get; set; }
        public string Kategori { get; set; }
        public string QuestionTittel { get; set; }
        public string Epost { get; set; }
        public string QuestionText { get; set; }
        public int Behandlet { get; set; }
        public string DatoSendt { get; set; }
        public string Brukernavn { get; set; }

    }
}
