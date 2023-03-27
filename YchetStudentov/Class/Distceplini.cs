using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YchetStudentov.Class
{
    class Distceplini
    {
        private int number_disceplini;
        public string name_disceplini { get; set; }
        public string forma_attest { get; set; }

        public string namePrepod { get; set; }
        public string familyPrepod { get; set; }
        public Distceplini(int number_disceplini, string name_disceplini,string forma_attest, string namePrepod, string familyPrepod)
        {
            this.number_disceplini = number_disceplini;
            this.name_disceplini = name_disceplini;
            this.forma_attest = forma_attest;
            this.namePrepod = namePrepod;
            this.familyPrepod = familyPrepod;
        }

        public static List<Distceplini> GetAllList()
        {
            List<Distceplini> distceplinis = new List<Distceplini>();
            DataTable tableStudent = DateBase.Select("Select * FROM Distceplini"); 
            DataTable tableStudent1 = DateBase.Select("Select * FROM Prepodovateli"); 
            for (int i = 0; i < tableStudent.Rows.Count; i++)
            {
                for (int j = 0; j < tableStudent1.Rows.Count;j++)
                {
                    if ((int)tableStudent.Rows[i][3] == (int)tableStudent1.Rows[j][3])
                    {
                       distceplinis.Add(new Distceplini((int)tableStudent.Rows[i][0], (string)tableStudent.Rows[i][1], (string)tableStudent.Rows[i][2], (string)tableStudent1.Rows[j][1], (string)tableStudent1.Rows[j][0]));                      
                    }
                }
            }
            return distceplinis;
        }

        
    }
}
