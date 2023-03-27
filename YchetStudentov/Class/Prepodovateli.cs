using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YchetStudentov.Class
{
    class Prepodovateli
    { 
        public string name { get; }
        public string family { get; }
        public string otchestvo { get; }
        public int login;
        public string password;

        public Prepodovateli(string name, string family, string otchestvo, int login, string password)
        {
            this.name = name;
            this.family = family;
            this.otchestvo = otchestvo;
            this.login = login;
            this.password = password;
        }

        public static List<Prepodovateli> GetAllPrepod()
        {
            List<Prepodovateli> prepodovatelis = new List<Prepodovateli>();  
                DataTable tableStudent = DateBase.Select("Select * FROM Prepodovateli");
            for (int i = 0; i < tableStudent.Rows.Count; i++)
            {
                prepodovatelis.Add(new Prepodovateli((string)tableStudent.Rows[i][0], (string)tableStudent.Rows[i][1], (string) tableStudent.Rows[i][2], (int)tableStudent.Rows[i][3], (string)tableStudent.Rows[i][4]));
            }
            return prepodovatelis;
        }
    }
}
