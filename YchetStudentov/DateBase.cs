using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using YchetStudentov.Class;
using YchetStudentov.Form;
using YchetStudentov.Models;
using YchetStudentov.Page;

namespace YchetStudentov
{
    interface IDatabase
    {
        public bool CheckingCorrectPasswordAndLogin(string login, string password);
        public string GetAllInfoStudentInString(Class.Student student);
        public void SelectedItemStudent(int numberZachet);
        public List<Class.Student> GetInfoStudents(string groups);
        public void EditingInfoStudent(Class.Student student, string group, string name, string family, string otchestvo, string adress,
            string email, string gragdanstvo, int year_postyp, string budget);
        public void DeletedItemStudent(Class.Student Itemstudent);
        public void AddItemStudent(int num_zac, string group, string name, string family, string otchestvo, DateTime dataRog, string adress,
            string email, string gragdanstvo, int year_postyp, string budget);
        public Class.Prepodovateli[] FillingInTheTeachersTable();
        //public List<Class.Prepodovateli> SearchForTeachers(string text);
        public bool CreateTeacher(Class.Prepodovateli prepodovateli);
        public bool DeleteTeacher(Class.Prepodovateli prepodovateli);
        public bool EditTeacher(Class.Prepodovateli prepodovateli);
        public List<Class.UchebPlan> DataGridGetCurriculum(string group);
        public void CreateCurriculum(string number_group, Class.Distceplini distceplin);
        public void DeleteCurriculum(Class.UchebPlan uchebPlan);
        public Class.Distceplini[] GetDataGridDiscipline();
        public List<string> GetSelectedDiscipline(string group);
        public void CreateDiscipline(string namePredmet, string formaAttest, Class.Prepodovateli prepodovatel);
        public void DeleteDiscipline(Class.Distceplini distceplini);
        public void EditDiscipline(Class.Distceplini distceplini, string name, string attest, Class.Prepodovateli prepodovateli);
        public List<string> GetInfoGroup();
        public List<Class.Group> GetAllInfoGroup();
        public void CreateGroup(string nameSpec, string numberGroup, string numberSpec);
        public bool EditingGroup(Class.Group group, string nameSpec, string numberGroup, string numberSpec);
        public bool DeletedGroup(Class.Group group);
        public List<Class.Student.StudentsOzenki> GetOzenki(Class.Student? student, string selectedDisciplin);
        public void DeletedPoseshaemost(Class.Student.StudentsOzenki ozenki);
        public void EditingPoseshaemost(Class.Student.StudentsOzenki ozenki, ComboBox poses);
        public void CreatePoseshaemost(Class.Student student, Class.UchebPlan disciplins, string ozenka, DateTime? datazanyatie);
        public List<Class.FinalGrades> GetRatingAndSrPoseshaemost(Class.Student student);
        public void CreateARating(Class.Student student, int semestr, string grades, Class.UchebPlan distceplini);
    }

    class DateBase:IDatabase
    {
        public static IDatabase Context()
        {
            DateBase dt = new DateBase();
            return dt;
        }

        //Authorization        
        public bool CheckingCorrectPasswordAndLogin(string login, string password)
        {
            try
            {
                password = HashPassword.HashPassword.Hash().HashinPassword(password);
                using (var context = new YcotStudentContext())
                {
                    var item = context.Prepodovatelis.SingleOrDefault(s => s.LoginPrepodovatela == Convert.ToInt32(login) && s.Password == password);
                    if (item != null)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Students
        public string GetAllInfoStudentInString(Class.Student student)
        {
            string content = $"Номер зачетной нижки - {student.NumberZachetki}\nНомер группы - {student.NumberGroup}\n" +
                $"ФИО - {student.Family} {student.Name} {student.Otchestvo}\n" +
                $"Дата рождения - {student.DataRoj}\nАдрес проживания - {student.Adress}\nГражданство - {student.Gragdanstvo}\nПочта - {student.Email}\n" +
                $"Год поступления - {student.GodPostuplenie}\nБюджет - {student.Budget}";
            return content; 
        }
        public List<Class.Student> GetInfoStudents(string groups)
        {
            using (var context = new YcotStudentContext())
            {
                var items = context.Students.Where(x => x.NumberGroup == groups);
                var item =  items.Select(item => new Class.Student(item.NumberZacKnig, item.NumberGroup ?? "", item.Name ?? "", item.Family ?? "", item.Otchesto ?? "", Convert.ToDateTime(item.DataRoj), item.AdressProj ?? "", item.Gragdanstvo ?? "", item.Email ?? "", Convert.ToInt32(item.GodPostuplenya), item.Budget ?? ""));
                return item.ToList();
            }
        }
        public List<Class.Student> GetAllStudentsInWord()
        {
            using (var context = new YcotStudentContext())
            {
                var item = context.Students.Select(item => new Class.Student(item.NumberZacKnig, item.NumberGroup ?? "", item.Name ?? "", item.Family ?? "", item.Otchesto ?? "", Convert.ToDateTime(item.DataRoj), item.AdressProj ?? "", item.Gragdanstvo ?? "", item.Email ?? "", Convert.ToInt32(item.GodPostuplenya), item.Budget ?? ""));
                return item.ToList();
            }
        }
        public void EditingInfoStudent(Class.Student student, string group, string name, string family, string otchestvo, string adress,
            string email, string gragdanstvo, int year_postyp, string budget)
        {
            using var context = new YcotStudentContext();
            context.Students.Load();
            var items = context.Students.SingleOrDefault(p => p.NumberZacKnig == student.NumberZachetki);
            if (items != null)
            {
                items.NumberGroup = group;
                items.Name = name;
                items.Family = family;
                items.Otchesto = otchestvo;
                items.AdressProj = adress;
                items.Email = email;
                items.GodPostuplenya = year_postyp;
                items.Budget = budget;
                items.Gragdanstvo = gragdanstvo;
                context.SaveChanges();
                Files files = new Files();
                files.EditStudent(student, items);
            }
        }
        public void SelectedItemStudent(int numberZachet)
        {
            using var context = new YcotStudentContext();
            context.Students.Load();
            var num = from p in context.Students where p.NumberZacKnig == numberZachet select p;
            foreach (var items in num)
            {
                MessageBox.Show(items.Name + "" + items.Family);
            }
        }
        public void DeletedItemStudent(Class.Student Itemstudent)
        {
            Files file = new Files();
            using (var context = new YcotStudentContext())
            {
                context.Students.Load();
                var student = context.Students.SingleOrDefault(s => s.NumberZacKnig == Itemstudent.NumberZachetki);
                if (student != null)
                {
                    var poseshaemost = context.Poseshaemosts.Where(s => s.NumberZacKnig == Itemstudent.NumberZachetki);
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

        public void AddItemStudent(int num_zac, string group, string name, string family, string otchestvo, DateTime dataRog, string adress,
            string email, string gragdanstvo, int year_postyp, string budget)
        {
            using (var context = new YcotStudentContext())
            {
                context.Students.Load();
                CreateStudent createStudent = new CreateStudent();
                var student = new Models.Student()
                {
                    NumberZacKnig = num_zac,
                    NumberGroup = group,
                    Name = name,
                    Family = family,
                    Otchesto = otchestvo,
                    DataRoj = dataRog,
                    AdressProj = adress,
                    Email = email,
                    Gragdanstvo = gragdanstvo,
                    GodPostuplenya = year_postyp,
                    Budget = budget,
                };
                context.Students.Add(student);
                context.SaveChanges();
                Files files = new Files();
                files.CreateStudent(student);
            }
        }

        // Teachers
        public Class.Prepodovateli[] FillingInTheTeachersTable()
        {
            using (var context = new YcotStudentContext())
            {
                var items = context.Prepodovatelis.Select(s => new Class.Prepodovateli { Family = s.Family, Name = s.Name, Otchestvo = s.Otchestvo, Login = s.LoginPrepodovatela, Password = s.Password });
                return items.ToArray();
            }
        }

   //   public List<Class.Prepodovateli> SearchForTeachers(string text)
   //   {
   //   //    //List<Class.Prepodovateli> list = FillingInTheTeachersTable();
   //   //    try
   //   //    {
   //   //        int i = 0;
   //   //        foreach (char c in text)
   //   //        {
   //   //                var result = list.First(s => s.Family[i] == c);
   //   //                i++;
   //   //                list.Clear();
   //   //                list.Add(new Class.Prepodovateli(result.Name ?? " ", result.Family ?? " ", result.Otchestvo ?? " ", result.login, result.password ?? " "));
   //   //        }
   //   //    }
   //   //    catch
   //   //    {
   //   //        list.Clear();
   //   //    }
   //   //    return list;
   //   }///
        public bool CreateTeacher(Class.Prepodovateli prepodovateli )
        {
            try
            {
                using (var context = new YcotStudentContext())
                {
                    var s = context.Prepodovatelis.Find(prepodovateli.Login);
                    if (s != null)
                    {
                        return false;
                    }
                    var teacher = new Models.Prepodovateli()
                    {
                        Family = prepodovateli.Family,
                        Name = prepodovateli.Name,
                        Otchestvo = prepodovateli.Otchestvo,
                        LoginPrepodovatela = prepodovateli.Login,
                        Password = prepodovateli.Password,
                    };
                    context.Prepodovatelis.Add(teacher);
                    context.SaveChanges();
                    Files files = new Files();
                    files.CreateTeacher(teacher);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteTeacher(Class.Prepodovateli prepodovateli)
        {
            try
            {
                using (var context = new YcotStudentContext())
                {
                    var item = context.Prepodovatelis.SingleOrDefault(s => s.LoginPrepodovatela == prepodovateli.Login);
                    if (item != null)
                    {
                        var itemsdisciplins = context.Distceplinis.Where(s => s.LoginPrepodovatela == prepodovateli.Login);
                        foreach(var itemdis in itemsdisciplins)
                        {
                            itemdis.LoginPrepodovatela = null;
                        }
                        context.Prepodovatelis.Remove(item);
                        context.SaveChanges();
                        Files files = new Files();
                        files.DeleteTeacher(item);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditTeacher(Class.Prepodovateli prepodovateli)
        {
            try
            {
                using (var context = new YcotStudentContext())
                {
                    var item = context.Prepodovatelis.SingleOrDefault(s => s.LoginPrepodovatela == prepodovateli.Login);
                    if (item != null)
                    {
                        item.Family = prepodovateli.Family;
                        item.Name = prepodovateli.Name;
                        item.Otchestvo = prepodovateli.Otchestvo;
                        context.SaveChanges();
                        Files files = new Files();
                        files.EditingTeacher(prepodovateli, item);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Curriculum
        public List<Class.UchebPlan> DataGridGetCurriculum(string group)
        {
            using (var context = new YcotStudentContext())
            {
                var item = context.DataGridUchebs.FirstOrDefault();
                var items = context.DataGridUchebs.Where(s => s.NumberGroup == group).Select(items => new Class.UchebPlan(Convert.ToInt32(items.NumberUchebplan), items.NumberGroup, items.NameDisceplini ?? " ", items.Family ?? " ", items.Name ?? " ", items.Otchestvo ?? " ", items.FormaAttest ?? " ", Convert.ToInt32(items.NumberDisceplinis)));
                return items.ToList();
            }
        }
        public void CreateCurriculum(string number_group, Class.Distceplini distceplin)
        {
            using var context = new YcotStudentContext();
            var newitem = new Models.UchebPlan()
            {
                NumberGroup = number_group,
                NumberDisceplini = distceplin.NumberDisciplini,
            };
            context.UchebPlans.Add(newitem);
            context.SaveChanges();
        }
        public void DeleteCurriculum(Class.UchebPlan uchebPlan)
        {
            using (var context = new YcotStudentContext())
            {
                var item = context.UchebPlans.SingleOrDefault(s => s.NumberUchebPlan == uchebPlan.number_curriculum);
                if (item != null)
                {
                    context.UchebPlans.Remove(item);
                    context.SaveChanges();
                }
            }

        }


        // Discipline
        public Class.Distceplini[] GetDataGridDiscipline()
        {
            try
            {
                using (var context = new YcotStudentContext())
                {
                    var items = context.Distceplinis.ToList();
                    var item = items.Select(items => new Class.Distceplini { NumberDisciplini = items.NumberDisceplini, NameDisciplini = items.NameDisceplini ?? " ", FormaAttest = items.FormaAttest ?? " ", Login = Convert.ToInt32(items.LoginPrepodovatela) } );
                    return item.ToArray();
                }
            }
            catch
            {
                return null;
            }
        }
        public List<string> GetSelectedDiscipline(string group) /////
        {
            List<string> predmets = new();
            using (var context = new YcotStudentContext())
            {
                var items = context.GetPredmets.Where(s=> s.NumberGroup == group);
                foreach(var item in items)
                {
                    if (items != null)
                    {
                        predmets.Add(item.NameDisceplini ?? " ");
                    }
                }
                return predmets;

            }
        }
        public void CreateDiscipline(string namePredmet, string formaAttest, Class.Prepodovateli prepodovatel)
        {
            using (var context = new YcotStudentContext())
            {
                var newitem = new Models.Distceplini()
                {
                    NameDisceplini = namePredmet,
                    FormaAttest = formaAttest,
                    LoginPrepodovatela = prepodovatel.Login,
                };
                context.Distceplinis.Add(newitem);
                context.SaveChanges();
            }
        }
        public void DeleteDiscipline(Class.Distceplini distceplini)
        {
            using (var context = new YcotStudentContext())
            {
                var item = context.Distceplinis.SingleOrDefault(s => s.NumberDisceplini == distceplini.NumberDisciplini);
                if (item != null)
                {
                    var items = context.UchebPlans.Where(s => s.NumberDisceplini == distceplini.NumberDisciplini);
                    foreach(var itemucheb in items)
                    {
                        context.UchebPlans.Remove(itemucheb);
                    }
                    context.Distceplinis.Remove(item);
                    context.SaveChanges();
                }
            }
        }
        public void EditDiscipline(Class.Distceplini distceplini, string name, string attest, Class.Prepodovateli prepodovateli)
        {
            using (var context = new YcotStudentContext())
            {
                var item = context.Distceplinis.SingleOrDefault(s => s.NumberDisceplini == distceplini.NumberDisciplini);
                if (item != null)
                {
                    item.NameDisceplini = name;
                    item.FormaAttest = attest;
                    item.LoginPrepodovatela = prepodovateli.Login;
                    context.SaveChanges();
                }
            }
        }

        // Group
        public List<string> GetInfoGroup()
        {
            using (var context = new YcotStudentContext())
            {
                var groups = context.Groups.Select(p => p.NumberGroup);
                return groups.ToList();
            }       
        }
        public List<Class.Group> GetAllInfoGroup()
        {
            using (var context = new YcotStudentContext())
            {
                var item = context.Groups.Select(items => new Class.Group(items.NumberGroup, items.PolnNameSpec, items.NumberSpecialnosti ?? " "));
                return item.ToList();
            }
        }
        public void CreateGroup(string nameSpec, string numberGroup, string numberSpec)
        {
            using (var context = new YcotStudentContext())
            {
                var items = new Models.Group()
                {
                    PolnNameSpec = nameSpec,
                    NumberGroup = numberGroup,
                    NumberSpecialnosti = numberSpec,
                };
                context.Groups.Add(items);
                context.SaveChanges();
                Files files = new Files();
                files.CreateGroups(items);
            }
        }

        public bool EditingGroup(Class.Group group, string nameSpec, string numberGroup, string numberSpec)
        {
            try
            {
                using (var context = new YcotStudentContext())
                {
                    var item = context.Groups.SingleOrDefault(s => s.NumberGroup == group.NumberGroup);
                    if (item != null)
                    {
                        item.PolnNameSpec = nameSpec;
                        item.NumberGroup = numberGroup;
                        item.NumberSpecialnosti = numberSpec;
                        context.SaveChanges();
                        Files files = new Files();
                        files.EditingGroups(group, item);
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeletedGroup(Class.Group group)
        {
            try
            {
                using (var context = new YcotStudentContext())
                {
                    var item = context.Groups.SingleOrDefault(s => s.NumberGroup == group.NumberGroup);
                    if (item != null)
                    {
                        var items = context.Students.Where(s => s.NumberGroup == group.NumberGroup);
                        foreach (var itemstudent in items)
                        {
                            itemstudent.NumberGroup = "ИСП-308";
                        }
                        var itemsucheb = context.UchebPlans.Where(s => s.NumberGroup == group.NumberGroup);
                        foreach (var itemucheb in itemsucheb)
                        {
                            context.UchebPlans.Remove(itemucheb);
                        }
                        context.Groups.Remove(item);
                        context.SaveChanges();
                        Files files = new Files();
                        files.DeletedGroups(item);
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        //Poseshaemost
        public List<Class.Student.StudentsOzenki> GetOzenki(Class.Student? student, string selectedDisciplin)
        {
            using (var context = new YcotStudentContext())
            {
                var items = context.StudentOzenkis.Where(s => s.NumberZacKnig == student.NumberZachetki).Where(s => s.NameDisceplini == selectedDisciplin);
                var ozenkis = items.Select(item => new Class.Student.StudentsOzenki(item.NameDisceplini ?? " ", item.Ocenka ?? " ", Convert.ToDateTime(item.DataZanyatie), item.Name ?? " ", item.Family ?? " ", Convert.ToInt32(item.NumberUspevaemosti)));
                return ozenkis.ToList();
            }
        }
        public void DeletedPoseshaemost(Class.Student.StudentsOzenki ozenki)
        {
            using(var context = new YcotStudentContext())
            {
                var item = context.Poseshaemosts.SingleOrDefault(s=> s.NumberUspevaemosti == ozenki.NumberUspevaemosti);
                if (item != null)
                {
                    context.Poseshaemosts.Remove(item);
                    context.SaveChanges();
                    Files files = new Files();
                    files.DeleteAttendance(item);
                }
            }
        }
        public void EditingPoseshaemost(Class.Student.StudentsOzenki ozenki, ComboBox poses)
        {
            using (var context = new YcotStudentContext())
            {
                var item = context.Poseshaemosts.SingleOrDefault(s=> s.NumberUspevaemosti == ozenki.NumberUspevaemosti);
                if (item != null)
                {
                    item.Ocenka = poses.SelectedItem.ToString();
                    context.SaveChanges();
                }
            }
        }
        
        public void CreatePoseshaemost(Class.Student student ,Class.UchebPlan disciplins, string ozenka, DateTime? datazanyatie)
        {
            using (var context = new YcotStudentContext())
            {
                var item = new Models.Poseshaemost()
                {
                    NumberZacKnig = student.NumberZachetki,
                    NumberDistceplini = disciplins.number_curriculum,
                    Ocenka = ozenka,
                    DataZanyatie = datazanyatie,
                };
                context.Poseshaemosts.Add(item);
                context.SaveChanges();
            }
        }


        public void CreateARating(Class.Student student, int semestr, string grades, Class.UchebPlan distceplini)
        {
            using (var context = new YcotStudentContext())
            {
                var item = new Models.FinalGrades()
                {
                    semestr = semestr,
                    grades = grades,
                    date = DateTime.Now,
                    NumberDisceplini = distceplini.numberDisceplini,
                    NumberZacKnig = student.NumberZachetki,
                };
                context.FinalGrades.Add(item);
                context.SaveChanges();
            }
        }

        public void EditingARating(Class.FinalGrades final)
        {
            using (var context = new YcotStudentContext())
            {
                var item = context.FinalGrades.SingleOrDefault(s => s.NumberGrades == final.NumberGrades);
                if (item != null)
                {
                    
                }
            }
        }
        public List<Class.FinalGrades> GetRatingAndSrPoseshaemost(Class.Student student)
        {
            using (var context = new YcotStudentContext())
            {
                var s = context.GradesGetInfo.ToList().Where(s => s.number_zac_knig == student.NumberZachetki);
                var item = s.Select(s => new Class.FinalGrades(Convert.ToInt32(s.semestr), s.grades, Convert.ToDateTime(s.date), Convert.ToInt32(s.number_disceplini), s.name_disceplini ?? "", Convert.ToInt32(s.number_grades), s.name ?? "", s.family ?? "", Convert.ToInt32(s.number_zac_knig)));
                return item.ToList();
            }
        }

        public List<Class.FinalGrades> GetAllRating()
        {
            using(var context = new YcotStudentContext())
            {
                var s = context.GradesGetInfo.ToList();
                var items = s.Select(s => new Class.FinalGrades(Convert.ToInt32(s.semestr), s.grades, Convert.ToDateTime(s.date), Convert.ToInt32(s.number_disceplini), s.name_disceplini ?? "", Convert.ToInt32(s.number_grades), s.name ?? "", s.family ?? "", Convert.ToInt32(s.number_zac_knig)));
                return items.ToList();
            }
        }
    }
}
