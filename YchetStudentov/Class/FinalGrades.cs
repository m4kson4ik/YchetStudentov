using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YchetStudentov.Class
{
    public class FinalGrades
    {
        public int semestr { get;}
        public string nameDisceplini { get;}
        public string? grades { get;}
        public string? namestudent { get; }
        public string? familystudent { get; }

        //public string? number_group;
        public DateTime date;
        public int NumberDisceplini;
        public int NumberGrades;
        public int NumberZacKnig;

        public FinalGrades(int semestr, string? grades, DateTime date, int numberDisceplini, string nameDisceplini, int numberGrades, string namestudent, string familystudent, int numberZacKnig)
        {
            this.semestr = semestr;
            this.grades = grades;
            this.date = date;
            NumberDisceplini = numberDisceplini;
            this.nameDisceplini = nameDisceplini;
            NumberGrades = numberGrades;
            this.namestudent = namestudent;
            this.familystudent = familystudent;
            NumberZacKnig = numberZacKnig;
            //this.number_group = number_group;
        }
    }
}
