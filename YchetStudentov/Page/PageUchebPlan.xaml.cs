using Microsoft.Win32;
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
    /// Логика взаимодействия для PageUchebPlan.xaml
    /// </summary>
    public partial class PageUchebPlan
    {
        public PageUchebPlan()
        {
            InitializeComponent();
            Group.GetAllGroup(cmb_number_group);
            Return(cmbNameDisceplin);
            GridUchebPlan.AutoGenerateColumns = true;
        }

        private void Return(ComboBox cmb)
        {
            DataTable dataTable = DateBase.Select("SELECT number_disceplini, name_disceplini FROM Distceplini");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cmb.Items.Add(dataTable.Rows[i][1]);
            }
            
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (cmbNameDisceplin.SelectedItem != null && cmb_number_group.SelectedItem != null)
            {
                CreateUchebPlan();
                GridUchebPlan.ItemsSource = UchebPlan.DataGridUchebPlan((string)cmb_number_group.SelectedItem);
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void cmb_number_group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //cmb_number_group.Foreground.Transform = Brushes.White;
            GridUchebPlan.ItemsSource = UchebPlan.DataGridUchebPlan((string)cmb_number_group.SelectedItem);
            //UchebPlan.ADSA((string)cmb_number_group.SelectedItem);
        }

        //ПЕРЕДЕЛАТЬ
        private void CreateUchebPlan()
        {
            DataTable dataTable = DateBase.Select($"SELECT number_group, name_disceplini FROM GridReplayUchebPlan where number_group = '{cmb_number_group.SelectedItem}' and name_disceplini = '{cmbNameDisceplin.SelectedItem}'");
            //MessageBox.Show(dataTable.Rows.Count.ToString());
            int idDisceplini = 0;
            if (dataTable.Rows.Count == 0)
            {
                DataTable getidDisceplini = DateBase.Select("SELECT number_disceplini, name_disceplini FROM Distceplini"); // Возврат номера дисциплины
                for (int i = 0; i < getidDisceplini.Rows.Count; i++)
                {
                    if ((string)getidDisceplini.Rows[i][1] == (string)cmbNameDisceplin.SelectedItem)
                    {
                        idDisceplini = (int)getidDisceplini.Rows[i][0];
                    }
                }
                DataTable dataTable1 = DateBase.Select($"insert into UchebPlan(number_group, number_disceplini) values ('{(string)cmb_number_group.SelectedItem}', '{idDisceplini}')");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "EXCEL Files (*.xlsx)|*.xlsx|EXCEL Files 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != true)
                return;

            GridUchebPlan.ItemsSource = UchebniPlans.readFile(openFileDialog.FileName);
        }
    }
}
