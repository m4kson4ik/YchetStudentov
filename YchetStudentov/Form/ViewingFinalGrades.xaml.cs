using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace YchetStudentov.Form
{
    /// <summary>
    /// Логика взаимодействия для ViewingFinalGrades.xaml
    /// </summary>
    public partial class ViewingFinalGrades : Window
    {
        public ViewingFinalGrades()
        {
            InitializeComponent();
          //  cmbGroup.ItemsSource = DateBase.Context().GetAllInfoGroup();
        }

        private void cmbStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // if (cmbStudent.SelectedItem != null)
           // {
             //   dtStudentandItogOzenki.ItemsSource = DateBase.Context().GetRatingAndSrPoseshaemost((Class.Student)cmbStudent.SelectedItem);
           // }
           // else
           // {
           //     dtStudentandItogOzenki.ItemsSource = null;
           // }
        }

        private void cmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //cmbStudent.Items.Clear();
           // cmbStudent.ItemsSource = DateBase.Context().GetInfoStudents(cmbGroup.SelectedItem.ToString() ?? " ");
        }

        private void btExport_Click(object sender, RoutedEventArgs e)
        {
           // Class.Files files = new Class.Files();
           // files.ExportAllOzenkiStudent(6);
        }
    }
}
