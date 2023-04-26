using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YchetStudentov.Models
{
    public partial class FinalGrades
    {
        public int? semestr { get; set; }
        public string? grades { get; set; }
        public DateTime? date { get; set; }
        public int? NumberDisceplini { get; set; }
        public int NumberGrades { get; set; }
        public int? NumberZacKnig { get; set; }
    }
}
