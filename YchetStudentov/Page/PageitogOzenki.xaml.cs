using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YchetStudentov.Page
{
    /// <summary>
    /// Логика взаимодействия для PageitogOzenki.xaml
    /// </summary>
    public partial class PageitogOzenki
    {
        public class StudentsOzenki
        {
            public int number_zachetki;
            public string name { get; set; }
            public string family { get; set; }
            public double sr_poseshaemost { get; set; }
            
            public StudentsOzenki(int number_zachetki, string name, string family, double sr_poseshaemost)
            {
                this.number_zachetki = number_zachetki;
                this.name = name;
                this.family = family;
                this.sr_poseshaemost = sr_poseshaemost;
            }
        }
        public PageitogOzenki()
        {
            InitializeComponent();
            GetGroup();
        }

        public void GetGroup()
        {
            cmbGroup.Items.Clear();
            DataTable groups = DateBase.Select($"Select number_group from Groups");


            //DatabaseGeneratedAttribute.getGroups();

            

           // cmbGroup.ItemsSource = groups.Select(t => t[0].ToString());


            foreach (var row in groups.Rows)
            {
                cmbGroup.Items.Add(((DataRow)row)[0].ToString());
            }
        }

        public void GetPredemet()
        {
            cmbPredmet.Items.Clear();
            DataTable tableDistceplini = DateBase.Select($"Select * FROM GetPredmet where number_group = '{cmbGroup.SelectedItem}'");
            for (int i = 0; i < tableDistceplini.Rows.Count; i++)
            {
                cmbPredmet.Items.Add(tableDistceplini.Rows[i][2]);
            }
        }

        public List<StudentsOzenki> GetStudentandOzenka()
        {
            List<StudentsOzenki> studentiandOzenki = new List<StudentsOzenki>();
            int kolvoPar = 0;
            int kolvo_propusk = 0;
            double sr_poses = 0;
            DataTable students = DateBase.Select($"Select number_zac_knig, name, family, number_group from StudentsView where number_group = '{cmbGroup.SelectedItem}'");
            for (int i = 0; i < students.Rows.Count; i++)
            {
                    DataTable studentsozneki = DateBase.Select($"Select number_zac_knig, name_disceplini, ocenka from StudentOzenki where number_zac_knig = '{students.Rows[i][0]}' and name_disceplini = '{cmbPredmet.SelectedItem}'");
                    for (int j = 0; j < studentsozneki.Rows.Count; j++)
                    {
                        kolvoPar++;
                        if (studentsozneki.Rows[j][2].ToString() == "Н" || studentsozneki.Rows[j][2].ToString() == "Б")
                        {
                            kolvo_propusk++;
                        }
                    }
                if (kolvoPar == 0)
                {
                    sr_poses = 0;
                }
                else
                {
                    sr_poses = (kolvoPar - kolvo_propusk) * 100 / kolvoPar;
                }
                studentiandOzenki.Add(new StudentsOzenki(Convert.ToInt32(students.Rows[i][0]), students.Rows[i][1].ToString(), students.Rows[i][2].ToString(), sr_poses));
            }
            return studentiandOzenki;
        }

        private void cmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetPredemet();
        }

        private void cmbPredmet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtStudentsAndOzenki.ItemsSource = GetStudentandOzenka();
        }

        private void Getts()
        {
            //DateBase.GetGroupsInfo();
        }
    }
}
