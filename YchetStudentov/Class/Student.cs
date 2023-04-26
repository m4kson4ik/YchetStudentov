using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace YchetStudentov.Class
{
    public class Student
    {
        public int NumberZachetki { get; }
        public string? NumberGroup { get;}
        public string Name { get;}
        public string Family { get;}
        public string Otchestvo { get; }
        public DateTime DataRoj { get; }

        public string Adress { get; }

        public string Gragdanstvo { get; }
        public string Email { get; }
        public int GodPostuplenie { get; }

        public string Budget { get; }
        public string fio { private get => $"{Family} {Name} {Otchestvo}"; set => fio = value; }

        public Student(int number_zachetki, string number_group, string name, string family, string otchestvo, DateTime data_roj, string adress, string gragdanstvo, string email, int god_postuplenie, string budget)
        {
            this.NumberZachetki = number_zachetki;
            this.NumberGroup = number_group;
            this.Family = family;
            this.Name = name;
            this.Otchestvo = otchestvo;
            this.DataRoj = data_roj;
            this.Adress = adress;
            this.Gragdanstvo = gragdanstvo;
            this.Email = email;
            this.GodPostuplenie = god_postuplenie;
            this.Budget = budget;
        }

        public class StudentsOzenki
        {
            public string? NameDisceplini { get; }
            public string? Ozenka { get; }
            public DateTime? DataZanyatie { get; }
            public string? NamePrepod { get; }
            public string? FamilyPrepod { get; }
            public int? NumberUspevaemosti;

            Student? student;
            public StudentsOzenki(Class.Student student)
            {
                this.student = student;
            }

            public StudentsOzenki(string NameDisceplini, string Ozenka, DateTime DataZanyatie, string NamePrepod, string FamilyPrepod, int NumberUspevaemosti)
            {
                this.NameDisceplini = NameDisceplini;
                this.Ozenka = Ozenka;
                this.DataZanyatie = DataZanyatie;
                this.NamePrepod = NamePrepod;
                this.FamilyPrepod = FamilyPrepod;
                this.NumberUspevaemosti = NumberUspevaemosti;
            }
        } 
    }
}
