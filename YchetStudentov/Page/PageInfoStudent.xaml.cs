using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
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
using YchetStudentov.Form;
using YchetStudentov.Models;
using YchetStudentov.Page;

namespace YchetStudentov
{
    /// <summary>
    /// Логика взаимодействия для PageInfoStudent.xaml
    /// </summary>
    public partial class PageInfoStudent
    {
        public PageInfoStudent()
        {
            InitializeComponent();
            UpdateCmb();
        }

        private void UpdateCmb()
        {
            //CmbGroup.ItemsSource = DateBase.Context().GetInfoGroup();
        }
        
        private void UpdateDataGrid()
        {
            dataGridStudent.ItemsSource = DateBase.Context().GetInfoStudents(CmbGroup.SelectedItem?.ToString() ?? CmbGroup.Text);
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataGrid();
        }
        
        private void Menu_Create_Click(object sender, RoutedEventArgs e)
        {
            EditStudent edit = new EditStudent((Class.Student)dataGridStudent.SelectedItem);
            edit.ShowDialog();
            UpdateDataGrid();
        }

        private void Menu_pechat_Click(object sender, RoutedEventArgs e)
        {
            List<Class.Student> students = new List<Class.Student>();
            foreach(var item in dataGridStudent.SelectedItems)
            {
                students.Add((Class.Student)item);
            }
            Files files = new Files();
            files.ImportInWord(students);
        }

        private void Menu_Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DateBase.Context().GetAllInfoStudentInString((Class.Student)dataGridStudent.SelectedItem));
        }

        private void Menu_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены что хотите удалить студента?","Удаление студента",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DateBase.Context().DeletedItemStudent((Class.Student)dataGridStudent.SelectedItem);
                MessageBox.Show("Студент был успешно удален!");
                UpdateDataGrid();
            }
        }

        private void btCreateStudent_Click(object sender, RoutedEventArgs e)
        {
            CreateStudent createStudent = new CreateStudent();
            createStudent.ShowDialog();
            UpdateDataGrid();
        }

        private void Menu_Ozenki_Click(object sender, RoutedEventArgs e)
        {
           Form.StudentOzenki student = new Form.StudentOzenki((Class.Student)dataGridStudent.SelectedItem);
           student.Show();
        }

        private void btImprot_Click(object sender, RoutedEventArgs e)
        {
            Files files = new Files();
            files.ImportAllStudentInWord();
        }
    }
}
