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
            using (var context = new YcotStudentContext())
            {
                context.Students.Load();
                var student = context.Students.SingleOrDefault(s => s.NumberZacKnig == numberZachet);
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }

        public static void AddItemStudent(TextBox num_zac, TextBox name, TextBox family, TextBox otchestvo, DatePicker dataRog)
        {
            using (var context = new YcotStudentContext())
            {
                context.Students.Load();
                CreateStudent createStudent = new CreateStudent();
                var student = new Models.Student();
                //student.NumberZacKnig = createStudent.tbNumberZach.Text;
                MessageBox.Show(createStudent.tbNumberZach.Text);
                student.NumberGroup = (string?)createStudent.cmbNumberGroup.SelectedItem;
                student.Name = createStudent.tbName.Text;
                student.Family = createStudent.tbFamily.Text;
                student.Otchesto = createStudent.tbOtchestvo.Text;
                //student.DataRoj = dataRog;
                student.AdressProj = createStudent.tbAdress.Text;
                student.Email = createStudent.tbEmail.Text;
                student.Gragdanstvo = createStudent.cmbGragdanstvo.Text;
                student.GodPostuplenya = (int?)createStudent.cmbYearPostup.SelectedItem;
                student.Budget = createStudent.cmbBudget.Text;
                context.Students.Add(student);
                context.SaveChanges();
            }
            //createStudent.cmbNumberGroup.Text;
        }
    }

}
