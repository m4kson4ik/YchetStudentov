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
using YchetStudentov.Form;

namespace YchetStudentov.Page
{
    /// <summary>
    /// Логика взаимодействия для PageitogOzenki.xaml
    /// </summary>
    public partial class PageitogOzenki
    {
        public PageitogOzenki()
        {
            InitializeComponent();
            cmbGroup.ItemsSource = DateBase.Context().GetInfoGroup();
            lbStudent.Visibility = Visibility.Hidden;
            lbFamilyandName.Visibility = Visibility.Hidden;
            cmbOzenka.Items.Add("5");
            cmbOzenka.Items.Add("4");
            cmbOzenka.Items.Add("3");
            cmbOzenka.Items.Add("2");
            cmbOzenka.Items.Add("н/я");

        }

        private void cmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtStudentsAndOzenki.SelectedItem = null;
            cmbPredmet.ItemsSource = DateBase.Context().DataGridGetCurriculum(cmbGroup.SelectedItem.ToString() ?? "");
        }

        private void dtStudentsAndOzenki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                GetStudentName((Class.Student)dtStudentsAndOzenki.SelectedItem);
        }

        public void GetStudentName(Class.Student student)
        {
            if (dtStudentsAndOzenki.SelectedItem != null)
            {
                lbFamilyandName.Visibility = Visibility.Visible;
                lbStudent.Visibility = Visibility.Visible;
                lbFamilyandName.Content = $"{student.Family} {student.Name}";
            }
            else
            {
                lbFamilyandName.Visibility = Visibility.Hidden;
                lbStudent.Visibility = Visibility.Hidden;
            }
        }

        private void cmbPredmet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtStudentsAndOzenki.ItemsSource = DateBase.Context().GetInfoStudents(cmbGroup.SelectedItem.ToString() ?? "");
        }

        private void btCreate_Click(object sender, RoutedEventArgs e)
        {
            if (dtStudentsAndOzenki.SelectedItem != null)
            {
                DateBase.Context().CreateARating((Class.Student)dtStudentsAndOzenki.SelectedItem, GetSemestr(), cmbOzenka.SelectedItem.ToString() ?? "", (Class.UchebPlan)cmbPredmet.SelectedItem);
            }
            else
            {
                MessageBox.Show("Необходимо выбрать студента!");
            }
        }

        private void btOzenki_Click(object sender, RoutedEventArgs e)
        {
            ViewingFinalGrades viewingFinalGrades = new ViewingFinalGrades();
            viewingFinalGrades.Show();
        }


        public int GetSemestr()
        {
            int[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string group = cmbGroup.SelectedItem.ToString() ?? " ";
            foreach(char item in group)
            {
                for (int i = 0; i < group.Length; i++)
                {
                    if (item == arr[i])
                    {
                        int grou;
                        DateTime dateTime = new DateTime(2023, 01, 01);
                        if (DateTime.Today >= dateTime)
                        {
                            grou = i * 2;
                        }
                        else
                        {
                            grou = i * 2 - 1;
                        }
                        return grou;
                    }
                }
            }
            return 0;      
        }

    }
}
