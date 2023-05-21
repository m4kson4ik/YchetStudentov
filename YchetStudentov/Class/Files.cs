using ExcelDataReader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YchetStudentov.Models;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;
using Range = Microsoft.Office.Interop.Word.Range;
using System.Collections.ObjectModel;
using Microsoft.Office.Interop.Excel;

namespace YchetStudentov.Class
{
    interface IFiles
    {
        public void ExportUchebPlan(Group group);
        public void ExportAllItogOzenkiStudent(Class.Student student);
        public void ExportAllItogOzenkiGroup(Class.Group group);
        public void ExportAllTeachers();
        public void ExportAllGroup();
        public void ExportStudentSelectedGroup(Class.Group group);
    }
    internal class Files : IFiles
    {
        #region Files
        public static IFiles Context()
        {
            Files dt = new Files();
            return dt;
        }
        public string path = "C:\\Users\\Maksim Safonov\\source\\repos\\YchetStudentov\\YchetStudentov\\logs.txt";

        //Student
        public void CreateStudent(Models.Student student)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Today.ToString()} Добавление пользователя: {student.NumberZacKnig} {student.NumberGroup} {student.Name} {student.AdressProj} {student.DataRoj} {student.Email}");
                writer.Close();
            }
        }
        public void DeleteStudent(Models.Student student)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Today.ToString()} Удаление пользователя: {student.NumberZacKnig} {student.NumberGroup} {student.Name} {student.Family} {student.Otchesto} {student.AdressProj} {student.DataRoj} {student.Email}");
                writer.Close();
            }
        }

        public void EditStudent(Class.Student studentback, Models.Student student)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Today.ToString()} Изменение данных пользователя c {studentback.NumberZachetki} {studentback.NumberGroup} {studentback.Name} {studentback.Family} {studentback.Otchestvo} {studentback.Adress} {studentback.DataRoj} {studentback.Email}");
                writer.WriteLine($"{DateTime.Today.ToString()} Изменение данных пользователя на {student.NumberZacKnig} {student.NumberGroup} {student.Name} {student.Family} {student.Otchesto} {student.AdressProj} {student.DataRoj} {student.Email}");
                writer.Close();
            }
        }

        //Attendance
        public void DeleteAttendance(Models.Poseshaemost poses) 
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Today.ToString()} Удаление посещаемости: {poses.NumberZacKnig} {poses.DataZanyatie} {poses.Ocenka}");
                writer.Close();
            }
        }
        public void CreateAttendance(Models.Poseshaemost poses)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Today.ToString()} Создание посещаемости: {poses.NumberZacKnig} {poses.DataZanyatie} {poses.Ocenka}");
                writer.Close();
            }
        }

        //Teachers
        public void CreateTeacher(Models.Prepodovateli prepod)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Today.ToString()} Создание преподователя: {prepod.LoginPrepodovatela} {prepod.Name} {prepod.Family} {prepod.Otchestvo}");
                writer.Close();
            }
        }
        public void DeleteTeacher(Models.Prepodovateli prepod)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Today.ToString()} Удаление преподователя: {prepod.LoginPrepodovatela} {prepod.Name} {prepod.Family} {prepod.Otchestvo}");
                writer.Close();
            }
        }
        public void EditingTeacher(Class.Prepodovateli backprepod, Models.Prepodovateli prepod)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Today.ToString()} Изменение преподователя с {backprepod.Login} {backprepod.Name} {backprepod.Family} {backprepod.Otchestvo}");
                writer.WriteLine($"{DateTime.Today.ToString()} Изменение преподователя на {prepod.LoginPrepodovatela} {prepod.Name} {prepod.Family} {prepod.Otchestvo}");
                writer.Close();
            }
        }

        //Groups
        public void CreateGroups(Models.Group group)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Today.ToString()} Создание группы: {group.NumberGroup} {group.NumberSpecialnosti} {group.PolnNameSpec}");
                writer.Close();
            }
        }
        public void DeletedGroups(Models.Group group)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Today.ToString()} Удаление группы: {group.NumberGroup} {group.NumberSpecialnosti} {group.PolnNameSpec}");
                writer.Close();
            }
        }
        public void EditingGroups(Class.Group backgroup, Models.Group group)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Today.ToString()} Изменение группы с {backgroup.NumberGroup} {backgroup.NumberSpec} {backgroup.NameSpec}");
                writer.WriteLine($"{DateTime.Today.ToString()} на {group.NumberGroup} {group.NumberSpecialnosti} {group.PolnNameSpec}");
                writer.Close();
            }
        }
        public void GetFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "EXCEL Files (*.xlsx)|*.xlsx|EXCEL Files 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != true)
                return;

            //GridUchebPlan.ItemsSource = UchebniPlans.readFile(openFileDialog.FileName);
        }
        #endregion

        public void ImportInWord(List<Student> students)
        {
            Application app = new Application();
            Document doc = app.Documents.Add(Visible:true);
            Range range = doc.Range();
            range.Text = students[0].NumberGroup;
            var item = students.Select(item => range.Text += $"{item.Family} {item.Name} {item.Otchestvo}").ToList();
            doc.Save();
            doc.Close();
            app.Quit();
        }

        public void ExportUchebPlan(Group group)
        {
          try
          {
              DateBase dt = new DateBase();
              Application app = new Application();
              Document doc = app.Documents.Add(Visible: true);
              Range range = doc.Range();
              Table table = doc.Tables.Add(range, dt.DataGridGetCurriculum(group).Length+1, 5);
              table.Borders.Enable = 1;
       
              foreach (Row row in table.Rows)
              {
                  foreach (Cell cell in row.Cells)
                  {
                      if (cell.RowIndex == 1)
                      {
                          table.Cell(1, 1).Range.Text = "Название дисциплины";
                          table.Cell(1, 2).Range.Text = "Фамилия";
                          table.Cell(1, 3).Range.Text = "Имя";
                          table.Cell(1, 4).Range.Text = "Отчество";
                          table.Cell(1, 5).Range.Text = "Форма аттестации";
                          cell.Range.Bold = 1;
                          cell.Range.Font.Name = "Times New Roman";
                          cell.Range.Font.Size = 12;
                          cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                          cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                      }
                      else
                      {
                          int i = 2;
                          foreach (var item in dt.DataGridGetCurriculum(group))
                          {
                              table.Cell(i, 1).Range.Text = item.NameDisceplini;
                              table.Cell(i, 2).Range.Text = item.Family;
                              table.Cell(i, 3).Range.Text = item.Name;
                              table.Cell(i, 4).Range.Text = item.Otchesvo;
                              table.Cell(i, 5).Range.Text = item.FormaAttest;
                              i++;
                          }
                      }
                  }
              }
              doc.Save();
              doc.Close();
              app.Quit();
          }
          catch
          {
                
          }
        }

        public void ExportAllOzenkiStudent(int semestr)
        {
            try
            {
                DateBase dt = new DateBase();
                Application app = new Application();
                Document doc = app.Documents.Add(Visible: true);
                Range range = doc.Range();
                Table table = doc.Tables.Add(range, dt.GetAllRating().Where(s => s.Semestr == semestr).Count() + 1, 5);
                table.Borders.Enable = 1;

                foreach (Row row in table.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        if (cell.RowIndex == 1)
                        {
                            table.Cell(1, 1).Range.Text = "Оценка";
                            table.Cell(1, 2).Range.Text = "Фамилия";
                            table.Cell(1, 3).Range.Text = "Имя";
                            table.Cell(1, 4).Range.Text = "Семестр";
                            table.Cell(1, 5).Range.Text = "Название дисциплины";
                            cell.Range.Bold = 1;
                            cell.Range.Font.Name = "Times New Roman";
                            cell.Range.Font.Size = 12;
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        else
                        {
                            int i = 2;
                            foreach (var item in dt.GetAllRating().Where(s => s.Semestr == semestr))
                            {
                                table.Cell(i, 1).Range.Text = item.Grades;
                                table.Cell(i, 2).Range.Text = item.FamilyStudent;
                                table.Cell(i, 3).Range.Text = item.Namestudent;
                                table.Cell(i, 4).Range.Text = item.Semestr.ToString();
                                table.Cell(i, 5).Range.Text = item.NameDisceplini;
                                i++;
                            }
                        }
                    }
                }
                doc.Save();
                doc.Close();
                app.Quit();
            }
            catch
            {

            }
        }


        public void ExportAllItogOzenkiStudent(Class.Student student)
        {
            try
            {
                DateBase dt = new DateBase();
                Application app = new Application();
                Document doc = app.Documents.Add(Visible: true);
                Range range = doc.Range();
                Table table = doc.Tables.Add(range, dt.GetAllRating().Where(s=>s.NumberZacKnig == student.NumberZachetki).Count() + 1, 4);
                table.Borders.Enable = 1;

                foreach (Row row in table.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        if (cell.RowIndex == 1)
                        {
                            table.Cell(1, 1).Range.Text = "Семестр";
                            table.Cell(1, 2).Range.Text = "Ф.И.О";
                            table.Cell(1, 3).Range.Text = "Дисциплина";
                            table.Cell(1, 4).Range.Text = "Оценка";
                            cell.Range.Bold = 1;
                            cell.Range.Font.Name = "Times New Roman";
                            cell.Range.Font.Size = 12;
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        else
                        {
                            int i = 2;
                            foreach (var item in dt.GetAllRating().Where(s=>s.NumberZacKnig == student.NumberZachetki))
                            {
                                table.Cell(i, 1).Range.Text = item.Semestr.ToString();
                                table.Cell(i, 2).Range.Text = $"{item.FamilyStudent} {item.Namestudent}";
                                table.Cell(i, 3).Range.Text = item.NameDisceplini;
                                table.Cell(i, 4).Range.Text = item.Grades;
                                i++;
                            }
                        }
                    }
                }
                doc.Save();
                doc.Close();
                app.Quit();
            }
            catch
            {

            }
        }


        public void ExportAllItogOzenkiGroup(Class.Group group)
        {
            try
            {
                DateBase dt = new DateBase();
                Application app = new Application();
                Document doc = app.Documents.Add(Visible: true);
                Range range = doc.Range();
                MessageBox.Show(dt.GetAllRating().Where(s => s.NumberGroup == group.NumberGroup).Count().ToString());
                Table table = doc.Tables.Add(range, dt.GetAllRating().Where(s=> s.NumberGroup == group.NumberGroup).Count() + 1, 4);
                table.Borders.Enable = 1;

                foreach (Row row in table.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        if (cell.RowIndex == 1)
                        {
                            table.Cell(1, 1).Range.Text = "Семестр";
                            table.Cell(1, 2).Range.Text = "Ф.И.О";
                            table.Cell(1, 3).Range.Text = "Дисциплина";
                            table.Cell(1, 4).Range.Text = "Оценка";
                            cell.Range.Bold = 1;
                            cell.Range.Font.Name = "Times New Roman";
                            cell.Range.Font.Size = 12;
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        else
                        {
                            int i = 2;
                            foreach (var item in dt.GetAllRating().Where(s => s.NumberGroup == group.NumberGroup))
                            {
                                table.Cell(i, 1).Range.Text = item.Semestr.ToString();
                                table.Cell(i, 2).Range.Text = $"{item.FamilyStudent} {item.Namestudent}";
                                table.Cell(i, 3).Range.Text = item.NameDisceplini;
                                table.Cell(i, 4).Range.Text = item.Grades;
                                i++;
                            }
                        }
                    }
                }
                doc.Save();
                doc.Close();
                app.Quit();
            }
            catch
            {

            }
        }

        public void ExportAllTeachers()
        {
            try
            {
                DateBase dt = new DateBase();
                Application app = new Application();
                Document doc = app.Documents.Add(Visible: true);
                Range range = doc.Range();
                Table table = doc.Tables.Add(range, dt.FillingInTheTeachersTable().Count() + 1, 5);
                table.Borders.Enable = 1;

                foreach (Row row in table.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        if (cell.RowIndex == 1)
                        {
                            table.Cell(1, 1).Range.Text = "Фамилия";
                            table.Cell(1, 2).Range.Text = "Имя";
                            table.Cell(1, 3).Range.Text = "Отчество";
                            table.Cell(1, 4).Range.Text = "Логин";
                            table.Cell(1, 5).Range.Text = "Пароль";
                            cell.Range.Bold = 1;
                            cell.Range.Font.Name = "Times New Roman";
                            cell.Range.Font.Size = 12;
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        else
                        {
                            int i = 2;
                            foreach (var item in dt.FillingInTheTeachersTable())
                            {
                                table.Cell(i, 1).Range.Text = item.Family;
                                table.Cell(i, 2).Range.Text = item.Name;
                                table.Cell(i, 3).Range.Text = item.Otchestvo;
                                table.Cell(i, 4).Range.Text = item.Login.ToString();
                                table.Cell(i, 5).Range.Text = item.Password;
                                i++;
                            }
                        }
                    }
                }
                doc.Save();
                doc.Close();
                app.Quit();
            }
            catch
            {

            }
        }
        public void ExportAllGroup()
        {
            try
            {
                DateBase dt = new DateBase();
                Application app = new Application();
                Document doc = app.Documents.Add(Visible: true);
                Range range = doc.Range();
                Table table = doc.Tables.Add(range, dt.GetAllInfoGroup().Length + 1, 4);
                table.Borders.Enable = 1;

                foreach (Row row in table.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        if (cell.RowIndex == 1)
                        {
                            table.Cell(1, 1).Range.Text = "Номер группы";
                            table.Cell(1, 2).Range.Text = "Полное название группы";
                            table.Cell(1, 3).Range.Text = "Номер специальности";
                            table.Cell(1, 4).Range.Text = "Количество студентов";
                            cell.Range.Bold = 1;
                            cell.Range.Font.Name = "Times New Roman";
                            cell.Range.Font.Size = 12;
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        else
                        {
                            int i = 2;
                            foreach (var item in dt.GetAllInfoGroup())
                            {
                                table.Cell(i, 1).Range.Text = item.NumberGroup;
                                table.Cell(i, 2).Range.Text = item.NameSpec;
                                table.Cell(i, 3).Range.Text = item.NumberSpec;
                                table.Cell(i, 4).Range.Text = item.KolvoStudent.ToString();
                                i++;
                            }
                        }
                    }
                }
                doc.Save();
                doc.Close();
                app.Quit();
            }
            catch
            {

            }
        }

        public void ExportStudentSelectedGroup(Class.Group group)
        {
            try
            {
                DateBase dt = new DateBase();
                Application app = new Application();
                Document doc = app.Documents.Add(Visible: true);
                Range range = doc.Range();
                Table table = doc.Tables.Add(range, dt.GetInfoStudents(group).Length + 1, 2);
                table.Borders.Enable = 1;

                foreach (Row row in table.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        if (cell.RowIndex == 1)
                        {
                            table.Cell(1, 1).Range.Text = "Группа";
                            table.Cell(1, 2).Range.Text = "ФИО";
                            cell.Range.Bold = 1;
                            cell.Range.Font.Name = "Times New Roman";
                            cell.Range.Font.Size = 12;
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        else
                        {
                            int i = 2;
                            foreach (var item in dt.GetInfoStudents(group))
                            {
                                table.Cell(i, 1).Range.Text = item.NumberGroup;
                                table.Cell(i, 2).Range.Text = item.fio;
                                i++;
                            }
                        }
                    }
                }
                doc.Save();
                doc.Close();
                app.Quit();
            }
            catch
            {

            }
        }
    }
}
