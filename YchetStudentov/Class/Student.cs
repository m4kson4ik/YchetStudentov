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
        public string NumberGroup { get;}
        public string Name { get;}
        public string Family { get;}
        public string Otchestvo { get; }
        public DateTime DataRoj;

        public string Adress;

        public string Gragdanstvo;
        public string Email;
        public int GodPostuplenie;

        public string Budget;
        public string Bt;

        public Student(int number_zachetki, string number_group, string name, string family, string otchestvo, DateTime data_roj, string adress, string gragdanstvo, string email, int god_postuplenie, string budget, string bt)
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
            this.Bt = bt;
        }

        public Student(string name, string family, string otchestvo)
        {
            this.Name = name;
            this.Family = family;
            this.Otchestvo = otchestvo;
        }
        public class StudentsOzenki
        {
            private string _numberGroup { get; set; }
            public string Name { get; set; }
            public string Family { get; set; }
            public string Otchestvo { get; set; }
            public string Ozenka { get; set; } 
            public StudentsOzenki(string name, string family, string otchestvo)
            {
                this.Name = name;
                this.Family = family;
                this.Otchestvo = otchestvo;
                DateBase dateBase = new DateBase();
            }
            
            public StudentsOzenki(string name, string family, string otchestvo, string ozenka)
            {
                this.Name = name;
                this.Family = family;
                this.Otchestvo = otchestvo;
                this.Ozenka = ozenka;
            }

            public static List<StudentsOzenki> Students(string group)
            {                
                DateBase dateBase = new DateBase();
                List<StudentsOzenki> studenti = new List<StudentsOzenki>(0);
                List<string> ozenki = new List<string>();
                DataTable tableStudent = DateBase.Select("");
                // DataTable tableStudent1 = DateBase.Select("Select number_zac_knig, number_distceplini, ocenka FROM Poseshaemost");
                for (int i = 0; i < tableStudent.Rows.Count; i++)
                {
                    if ((string)tableStudent.Rows[i][1] == group)
                    {                                          
                               studenti.Add(new StudentsOzenki((string)tableStudent.Rows[i][2], (string)tableStudent.Rows[i][3], (string)tableStudent.Rows[i][4]));
                    }
                }
                return studenti;
            }
        }
        public static List<Student> ListStudents(string number_group = null)
        {
            DateBase student = new DateBase();
            DataTable tableStudent = DateBase.Select("");
            List<Student> students = new List<Student>(0);
            if (number_group == "Все студенты") // Вывод всех студентов
            {
                for (int i = 0; i < tableStudent.Rows.Count; i++)
                {
                    students.Add(new Student((int)tableStudent.Rows[i][0], (string)tableStudent.Rows[i][1], (string)tableStudent.Rows[i][2], (string)tableStudent.Rows[i][3], (string)tableStudent.Rows[i][4], (DateTime)tableStudent.Rows[i][5], (string)tableStudent.Rows[i][6], (string)tableStudent.Rows[i][7], (string)tableStudent.Rows[i][8], (int)tableStudent.Rows[i][9], (string)tableStudent.Rows[i][10], "Изменить"));
                }
            }
            else if (number_group == null) // Пустые значения для создания таблицы
            {
                
            }
            else // Заполнение данных таблицы по номеру группы
            {
                //LinQ
               // tableStudent.Rows.Where((t) => t[1]==numberGroup).
                for (int i = 0; i < tableStudent.Rows.Count; i++)
                {
                    if ((string)tableStudent.Rows[i][1] == number_group)
                    {
                        students.Add(new Student((int)tableStudent.Rows[i][0], (string)tableStudent.Rows[i][1], (string)tableStudent.Rows[i][2], (string)tableStudent.Rows[i][3], (string)tableStudent.Rows[i][4], (DateTime)tableStudent.Rows[i][5], (string)tableStudent.Rows[i][6], (string)tableStudent.Rows[i][7], (string)tableStudent.Rows[i][8], (int)tableStudent.Rows[i][9], (string)tableStudent.Rows[i][10], "Изменить"));
                    }
                }
                return students;
            }
            return students;         
        }

        public static string GetInfo(int num_knig)
        {
            DataTable student = DateBase.Select($"Select * FROM Student WHERE number_zac_knig = '{num_knig}'");
            string info;
            info = $"Номер зачетной нижки - {student.Rows[0][0].ToString()}\nНомер группы - {student.Rows[0][1].ToString()}\nФИО - {student.Rows[0][3]} {student.Rows[0][2]} {student.Rows[0][4]}\n" +
                $"Дата рождения - {student.Rows[0][5]}\nАдрес проживания - {student.Rows[0][6]}\nГражданство - {student.Rows[0][7]}\nПочта - {student.Rows[0][8]}\nГод поступления - {student.Rows[0][9]}\nБюджет - {student.Rows[0][10]}";
            return info;
        }
        public static int CreateStudent(string numberZach, string numberGroup, string name, string family)
        {                   
            if (numberZach != "" && numberGroup != "" && name != "" && family != "" && numberZach.Length >= 5)
            {
                if (CheckFUNC.CheckNumber(family))
                {
                    if (CheckFUNC.CheckNumber(name))
                    {
                        if (CheckFUNC.CheckSymbol(numberZach) != true)
                        {
                            MessageBox.Show("В поле 'Номер зачетной книжки' не может быть букв!");
                            return 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("В поле 'Фамилия' содержится цифра!");
                        return 0;
                    }                 
                }
                else
                {
                    MessageBox.Show("В поле 'Фамилия' содержится цифра!");
                    return 0;
                }
            }
            else
            {
               MessageBox.Show("Вы ввели не все данные!", "Повторить попытку");
               return 0;
            }
            DataTable dataTable = DateBase.Select($"insert into Student(number_zac_knig, number_group, name, family) values ('{numberZach}', '{numberGroup}', '{name}', '{family}')");
            MessageBox.Show("Данные успешно добавлены!");
            return 1;
        }
    }
}
