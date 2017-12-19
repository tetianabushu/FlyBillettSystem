using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BillettSysModel
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public string Kategori { get; set; }
        public string Question { get; set; }
        public string Svar { get; set; }
    }
}
