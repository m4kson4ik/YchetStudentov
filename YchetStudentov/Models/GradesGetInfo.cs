using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YchetStudentov.Models
{
    public partial class GradesGetInfo
    {
        public DateTime? date { get; set; }
        public int? semestr { get; set; }
        public string? name_disceplini { get; set; }
        public string? grades { get; set; }
        public string? name { get; set; }
        public string? family { get; set; }
        public int? number_zac_knig { get; set; }
        public int? number_grades { get; set; }
        public int? number_disceplini { get; set; }
    }
}
