using System;
using System.Collections.Generic;
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
using YchetStudentov.Class;

namespace YchetStudentov.Page
{
    /// <summary>
    /// Логика взаимодействия для PageGroup.xaml
    /// </summary>
    public partial class PageGroup
    {
        public PageGroup()
        {
            InitializeComponent();
            dataGridGroup.ItemsSource = Group.GetAll();
            GetGroup();
        }

        public void GetGroup()
        {
            DataTable group = DateBase.Select($"Select number_group from Groups");
            for (int i =0; i < group.Rows.Count; i++)
            {
                cmbGroup.Items.Add(group.Rows[i][0]);
            }
        }

        public void GetPoseseshaemost()
        {
            DataTable getkolvoStudent = DateBase.Select($"Select kolvo, number_group from GetKolvoStudent where number_group = '{cmbGroup.SelectedItem}'");
            int kolvoStudent = (int)getkolvoStudent.Rows[0][0];
            int poseshaemostAll = 0;
            int propuskiBolezn = 0;
            DataTable dataTable = DateBase.Select($"Select number_group, ocenka, data_zanyatie from StudentOzenki where number_group = '{cmbGroup.SelectedItem}'");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i][1].ToString() == "П")
                {
                    poseshaemostAll++;
                }
                else if (dataTable.Rows[i][1].ToString() == "Б")
                {
                    propuskiBolezn++;
                }
            }
            lbKolvoStudenovGroup.Content = kolvoStudent;
            lbPoseshaemostGroup.Content = Convert.ToDouble((poseshaemostAll / kolvoStudent)*100);
            lbBolezn.Content = Convert.ToInt32((poseshaemostAll/propuskiBolezn)*100);
        }

        private void cmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetPoseseshaemost();
        }
    }
}
