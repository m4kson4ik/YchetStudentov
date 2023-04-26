using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using YchetStudentov.Class;
using static YchetStudentov.Form.StudentOzenki;

//

namespace YchetStudentov.Form
{
    public partial class StudentOzenki : Window
    {  
        Student? student;
        public StudentOzenki(Class.Student student)
        {
            InitializeComponent();
            this.student = student;
            cmbPredmets.ItemsSource = DateBase.Context().GetSelectedDiscipline(student.NumberGroup ?? " ");
        }

        private void UpdateDataGrid()
        {
            dataGridOzenki.ItemsSource = DateBase.Context().GetOzenki(student, cmbPredmets.SelectedItem.ToString() ?? " ");
        }
        private void cmbPredmets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataGrid();       
        }

        private void Menu_Edit_Click(object sender, RoutedEventArgs e)
        {
            EditAttendance edit = new EditAttendance((Student.StudentsOzenki)dataGridOzenki.SelectedItem);
            edit.ShowDialog();
            UpdateDataGrid();
        }

        private void Menu_Delete_Click(object sender, RoutedEventArgs e)
        {
            DateBase.Context().DeletedPoseshaemost((Class.Student.StudentsOzenki)dataGridOzenki.SelectedItem);
            UpdateDataGrid();
        }
    }
}
