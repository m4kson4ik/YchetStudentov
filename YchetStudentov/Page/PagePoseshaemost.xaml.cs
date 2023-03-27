using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YchetStudentov.Class;
using YchetStudentov.Form;

namespace YchetStudentov.Page
{
    /// <summary>
    /// Логика взаимодействия для PagePoseshaemost.xaml
    /// </summary>
    public partial class PagePoseshaemost
    {
        public PagePoseshaemost()
        {
            InitializeComponent();
            gridStudent.Visibility = Visibility.Hidden;
            //Group.GetAllGroup(CmbGroup);
            GetGroup(CmbGroup);
            btCancelPar.Visibility = Visibility.Hidden;
        }
        public static string name;
        public static string family;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
                   
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Group.ReturnPolnNameGroup((string)CmbGroup.SelectedItem);
            //Predmeti.ReturnPredmet(CmbNamePredmet, (string)CmbGroup.SelectedItem);
           
            //var asas = gridStudent.SelectedItem;            
            GetPredemet(CmbNamePredmet);
        }

        private void gridStudent_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void gridStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void gridStudent_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
        }

        private void CreatePars_Click(object sender, RoutedEventArgs e)
        {
            if (CmbGroup.Text != "" && CmbNamePredmet.Text != "" && dpDataPari.Text != "")
            {    
                gridStudent.Visibility = Visibility.Visible;
                gridStudent.ItemsSource = Student.StudentsOzenki.Students((string)CmbGroup.SelectedItem);
                CreatePars.Visibility = Visibility.Hidden;
                CmbTypeZanyatie.IsEnabled = false;
                CmbGroup.IsEnabled = false;
                CmbNamePredmet.IsEnabled = false;
                dpDataPari.IsEnabled = false;
                btCancelPar.Visibility = Visibility;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void GetGroup(ComboBox cmb)
        {
            DataTable tableDistceplini = DateBase.Select($"Select * FROM SelectPredmetAndGroup");        
            for (int i = 0; i < tableDistceplini.Rows.Count; i++)
            {
                cmb.Items.Add(tableDistceplini.Rows[i][0]);
            }
        }
        
        private void GetPredemet(ComboBox cmb)
        {
            cmb.Items.Clear();
            DataTable tableDistceplini = DateBase.Select($"Select * FROM GetPredmet where number_group = '{CmbGroup.SelectedItem}'");
            for (int i = 0; i < tableDistceplini.Rows.Count; i++)
            {
                cmb.Items.Add(tableDistceplini.Rows[i][2]);
            }
        }

        private void btCancelPar_Click(object sender, RoutedEventArgs e)
        {
            btCancelPar.Visibility = Visibility.Hidden;
            CreatePars.Visibility = Visibility.Visible;
            gridStudent.Visibility = Visibility.Hidden;
            CmbTypeZanyatie.IsEnabled = true;
            CmbGroup.IsEnabled = true;
            CmbNamePredmet.IsEnabled = true;
            dpDataPari.IsEnabled = true;
            listStudent.Items.Clear();
        }

        public void OzenkaStudents(string ozenka = "Н")
        {
            var cellInfo = gridStudent.SelectedCells[0];
            var cellInfo2 = gridStudent.SelectedCells[1];
            //var content = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;
            //content += $" {(cellInfo2.Column.GetCellContent(cellInfo2.Item) as TextBlock).Text}";
            OzenkaStudent ozenkaStudent = new OzenkaStudent();            
            ozenkaStudent.lbName.Content = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;
            ozenkaStudent.lbFamily.Content = (cellInfo2.Column.GetCellContent(cellInfo2.Item) as TextBlock).Text;
            ozenkaStudent.number_group = (string)CmbGroup.SelectedItem;
            ozenkaStudent.name_predmet = (string)CmbNamePredmet.SelectedItem;
            ozenkaStudent.data = dpDataPari;
            if (ozenka == "Н")
            {
                ozenkaStudent.CreateOzenka();
            }
            else if (ozenka == " ")
            {
                ozenkaStudent.CreateOzenka("П");
            }
            else
            {
                ozenkaStudent.CreateOzenka("Б");
            }

        }
            private void Menu_otsutstvuet_Click(object sender, RoutedEventArgs e)
        {
            OzenkaStudents();
            var cellInfo = gridStudent.SelectedCells[0];
            var cellInfo2 = gridStudent.SelectedCells[1];
            var content = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;
            content += $" {(cellInfo2.Column.GetCellContent(cellInfo2.Item) as TextBlock).Text}";
            listStudent.Items.Add(content);
        }

        private void Menu_bolezn_Click(object sender, RoutedEventArgs e)
        {
            OzenkaStudents("Б");
        }

        private void Menu_napare_Click(object sender, RoutedEventArgs e)
        {
            OzenkaStudents(" ");
        }
    }
}
