using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using YchetStudentov.Class;
using YchetStudentov.Models;

namespace YchetStudentov
{
    class DateBase
    {
        public static DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении                                                                            // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection("server=LAPTOP-BK5MRL0G\\STP;Trusted_Connection=Yes;DataBase=ycot_student;");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом
            sqlConnection.Close();
            return dataTable;
        }

        public static List<string> GetInfoGroup()
        {
            List<string> list = new List<string>();
            using (var context = new YcotStudentContext())
            {
                context.Groups.Load();
                var groups = context.Groups.Local.ToObservableCollection().Select(p => p.NumberGroup);
                list = groups.ToList();
            }
            return list;
        }

        public List<Class.Student> UpdateInfo(string groups)
        {
            List < Class.Student > students = new List<Class.Student>(0);
            using (var context = new YcotStudentContext())
            {
                context.Students.Load();
                var items = context.Students.Local.ToObservableCollection().Where(x => x.NumberGroup == groups);
                foreach (var item in items)
                {
                    students.Add(new Class.Student(item.NumberZacKnig, item.NumberGroup ?? "", item.Name ?? "", item.Family ?? "", item.Otchesto ?? "", Convert.ToDateTime(item.DataRoj), item.AdressProj ?? "", item.Gragdanstvo ?? "", item.Email ?? "", Convert.ToInt32(item.GodPostuplenya), item.Budget ?? ""));
                }
            }
            return students;
        }

        public static void SelectedItemStudent(int numberZachet)
        {
            using (var context = new YcotStudentContext())
            {
                context.Students.Load();
                var num = from p in context.Students where p.NumberZacKnig == numberZachet select p;
                foreach(var items in num)
                {
                    MessageBox.Show(items.Name + "" +items.Family);               
                }
            }
        }

        public static void DeletedItemStudent(int? numberZachet)
        {
            Files file = new Files();
            using (var context = new YcotStudentContext())
            {
                context.Students.Load();
                var student = context.Students.SingleOrDefault(s => s.NumberZacKnig == numberZachet);
                if (student != null)
                {
                    var poseshaemost = context.Poseshaemosts.Where(s => s.NumberZacKnig == numberZachet);
                    foreach (var pos in poseshaemost)
                    {
                        context.Poseshaemosts.Remove(pos);
                        file.DeleteAttendance(pos);
                    }
                    context.Students.Remove(student);
                    file.DeleteStudent(student);
                }
                context.SaveChanges();
            }
        }

        public static void AddItemStudent(TextBox num_zac, ComboBox group, TextBox name, TextBox family, TextBox otchestvo, DatePicker dataRog, TextBox adress, 
            TextBox email, ComboBox gragdanstvo, ComboBox year_postyp, ComboBox budget)
        {
            using (var context = new YcotStudentContext())
            {
                context.Students.Load();
                CreateStudent createStudent = new CreateStudent();
                var student = new Models.Student();
                student.NumberZacKnig = Convert.ToInt32(num_zac.Text);
                student.NumberGroup = group.SelectedItem.ToString();
                student.Name = name.Text;
                student.Family = family.Text;
                student.Otchesto = otchestvo.Text;
                student.DataRoj = dataRog.SelectedDate;
                student.AdressProj = adress.Text;
                student.Email = email.Text;
                student.Gragdanstvo = gragdanstvo.SelectedItem.ToString();
                student.GodPostuplenya = Convert.ToInt32(year_postyp.SelectedItem);
                student.Budget = budget.SelectedItem.ToString();
                context.Students.Add(student);
                context.SaveChanges();
                Files files = new Files();
                files.CreateStudent(student);
            }
            MessageBox.Show($"Студент {name.Text} {family.Text} был успешно добавлен!", $"{num_zac}");
        }
        public List<Class.Prepodovateli> FillingInTheTeachersTable()
        {
            List<Class.Prepodovateli> prepodovatelis = new List<Class.Prepodovateli>();
            using (var context = new YcotStudentContext())
            {
                context.Prepodovatelis.Load();
                var items = context.Prepodovatelis.ToList();
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        prepodovatelis.Add(new Class.Prepodovateli(item.Name ?? " ", item.Family ?? " ", item.Otchestvo ?? " ", item.LoginPrepodovatela, item.Password ?? " "));
                    }
                }
                else
                {
                    MessageBox.Show("Преподователей не существует!");
                }
            }
            return prepodovatelis;
        }
        public List<Class.Prepodovateli> SearchForTeachers(string text)
        {
            List<Class.Prepodovateli> list = FillingInTheTeachersTable();
                try
                {
                int i = 0;
                foreach (char c in text)
                {
                    var result = list.First(s => s.family[i] == c);
                    i++;
                    list.Clear();
                    list.Add(new Class.Prepodovateli(result.name ?? " ", result.family ?? " ", result.otchestvo ?? " ", result.login, result.password ?? " "));
                }
                }
                catch
                {
                    list.Clear();
                }
                return list;
        }
    }

}
