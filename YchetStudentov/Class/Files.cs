using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YchetStudentov.Models;

namespace YchetStudentov.Class
{
    internal class Files
    {
        public string path = "C:\\Users\\Maksim Safonov\\source\\repos\\YchetStudentov\\YchetStudentov\\logs.txt";
        public void CreateStudent(Models.Student student)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Today.ToString()} Добавление пользователя: {student.NumberZacKnig} {student.NumberGroup} {student.Name} {student.AdressProj} {student.DataRoj} {student.Email}");
                writer.Close();
            }
        }
        public void DeleteAttendance(Models.Poseshaemost poses) 
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Today.ToString()} Удаление посещаемости: {poses.NumberZacKnig} {poses.DataZanyatie} {poses.Ocenka}");
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
        public void EditStudent()
        {

        }
    }
}
