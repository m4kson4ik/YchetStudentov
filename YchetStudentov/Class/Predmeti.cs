using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace YchetStudentov.Class
{
    class Predmeti
    {
        public string name_disceplini;

        public Predmeti(string nameDisceplini)
        {
            name_disceplini = nameDisceplini;
        }
        public static void ReturnPredmet(ComboBox cmb)
        {
            // List<Predmeti> predmeti = new List<Predmeti>();
            cmb.Items.Clear();
            DataTable dataTable = DateBase.Select("SELECT number_disceplini, name_disceplini FROM Distceplini");
            for (int i =0; i < dataTable.Rows.Count; i++)
            {
                if ((int)dataTable.Rows[i][0] == UchebPlan.spec)
                {
                    cmb.Items.Add((string)dataTable.Rows[i][1]);
                }
            }
        }
    }

}
