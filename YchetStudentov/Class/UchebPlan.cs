using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YchetStudentov.Class
{
    public class UchebPlan
    {
        public int number_curriculum;
        public string number_group;
        public string name_disceplini { get; }
        public string family { get; }
        public string name { get; }
        public string otchesvo { get; }
        public string forma_attest { get; }

        public int numberDisceplini;


        public UchebPlan(int number_curriculum, string number_group, string name_disceplini, string family, string name, string otchesvo, string forma_attest, int number_disceplini)
        {
            this.number_curriculum = number_curriculum;
            this.number_group = number_group;
            this.name_disceplini = name_disceplini;
            this.family = family;
            this.name = name;
            this.otchesvo = otchesvo;
            this.forma_attest = forma_attest;
            numberDisceplini = number_disceplini;
        }   
    }
}
