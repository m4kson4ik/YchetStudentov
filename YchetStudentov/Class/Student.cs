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
    class Student
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
            public string Name { get; }
            public string Family { get; }
            public string Otchestvo { get; }
            public StudentsOzenki(string name, string family, string otchestvo)
            {
                this.Name = name;
                this.Family = family;
                this.Otchestvo = otchestvo;
            }           
        }

        public static string GetInfo(int num_knig)
        {
            DataTable student = DateBase.Select($"Select * FROM Student WHERE number_zac_knig = '{num_knig}'");
            string info;
            info = $"Номер зачетной нижки - {student.Rows[0][0].ToString()}\nНомер группы - {student.Rows[0][1].ToString()}\nФИО - {student.Rows[0][3]} {student.Rows[0][2]} {student.Rows[0][4]}\n" +
                $"Дата рождения - {student.Rows[0][5]}\nАдрес проживания - {student.Rows[0][6]}\nГражданство - {student.Rows[0][7]}\nПочта - {student.Rows[0][8]}\nГод поступления - {student.Rows[0][9]}\nБюджет - {student.Rows[0][10]}";
            return info;
        }       
    }
}
