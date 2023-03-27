using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YchetStudentov.Class
{
    class UchebPlan
    {
        public string number_group { get; set; }
        public string name_disceplini { get; set; }
        public string family { get; set; }
        public string name { get; set; }
        public string otchesvo { get; set; }
        public string forma_attest { get; set; }


        public UchebPlan(string number_group, string name_disceplini, string family, string name, string otchesvo, string forma_attest)
        {
            this.number_group = number_group;
            this.name_disceplini = name_disceplini;
            this.family = family;
            this.name = name;
            this.otchesvo = otchesvo;
            this.forma_attest = forma_attest;
        }
        public static int spec = 0;
        public static void ReturnNumberDisceplin(string name_spec)
        {
            DataTable dataTable = DateBase.Select("SELECT number_group, number_disceplini FROM UchebPlan");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if ((string)dataTable.Rows[i][0] == name_spec)
                {
                    spec = (int)dataTable.Rows[i][1];
                }
            }
        }

        public static List<UchebPlan> DataGridUchebPlan(string group)
        {
            List<UchebPlan> uchebPlans = new List<UchebPlan>(0);
            DataTable dataTable = DateBase.Select("SELECT * FROM DataGridUcheb");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (group == (string)dataTable.Rows[i][0])
                {
                    //MessageBox.Show((string)dataTable.Rows[i][1]);
                    uchebPlans.Add(new UchebPlan((string)dataTable.Rows[i][0], (string)dataTable.Rows[i][1], (string)dataTable.Rows[i][2], (string)dataTable.Rows[i][3], (string)dataTable.Rows[i][4], (string)dataTable.Rows[i][5]));
                }
            }
            return uchebPlans;
        }

        public static void ADSA(string group)
        {
            DataTable dataTable = DateBase.Select("SELECT number_group, number_disceplini FROM UchebPlan");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if ((string)dataTable.Rows[i][0] == group)
                {
                    for (int j = 0; j < dataTable.Rows.Count; j++)
                    {
                        if ((string)dataTable.Rows[i][0] == (string)dataTable.Rows[j][0])
                        {
                            for(int z = 0; i < dataTable.Rows.Count; i++)
                            {
                                if ((int)dataTable.Rows[i][1] == (int)dataTable.Rows[z][1])
                                {
                                    MessageBox.Show((string)dataTable.Rows[i][0]);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
