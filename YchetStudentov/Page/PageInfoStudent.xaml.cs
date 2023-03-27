using Microsoft.EntityFrameworkCore;
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

namespace YchetStudentov
{
    /// <summary>
    /// Логика взаимодействия для PageInfoStudent.xaml
    /// </summary>
    public partial class PageInfoStudent
    {        
        public static int idStudent;
        public PageInfoStudent()
        {
            InitializeComponent();
            UpdateCmb();
            dataGridStudent.AutoGenerateColumns = true;
            //dataGridStudent.ItemsSource = Student.ListStudents(null);
            

        }
        private void UpdateCmb()
        {
            Class.Group.GetAllGroup(CmbGroup);
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var context = new YcotStudentContext())
            {
                context.Students.Load();
                dataGridStudent.ItemsSource = context.Students.Local.ToObservableCollection().Where(x => x.NumberGroup == CmbGroup.SelectedItem.ToString()); ;
            }
        }

        private void dataGridStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show((string)dataGridStudent.Items[0]);
        }

        private void dataGridStudent_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show(dataGridStudent.SelectedItem);
        }

        private void Menu_Create_Click(object sender, RoutedEventArgs e)
        {
            // if (dataGridStudent.SelectedItem != null)
            //{
            MessageBox.Show("Редактирование");
            var cellInfo = dataGridStudent.SelectedCells[0];
            var cellInfoGroup = dataGridStudent.SelectedCells[1];
            var content = ((TextBlock)cellInfo.Column.GetCellContent(cellInfo.Item)).Text;
            var contentGroup = ((TextBlock)cellInfo.Column.GetCellContent(cellInfo.Item)).Text;
            MessageBox.Show(content);
            // idStudent = Convert.ToInt32(content);
            EditStudent edit = new EditStudent();
            edit.lb_Numberzachet.Content = content;
            edit.GetInfo();
            edit.Show();
        }

        private void Menu_pechat_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Печать");
        }

        private void Menu_Info_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Информация");
            var cellInfo = dataGridStudent.SelectedCells[0];
            var content = ((TextBlock)cellInfo.Column.GetCellContent(cellInfo.Item)).Text ;
            MessageBox.Show(YchetStudentov.Class.Student.GetInfo(Convert.ToInt32(content)));
        }

        private void Menu_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены что хотите удалить пользователя?","Удаление пользователя",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var cellInfo = dataGridStudent.SelectedCells[0];
                var content = ((TextBlock)cellInfo.Column.GetCellContent(cellInfo.Item)).Text;
                DateBase.DeletedItemStudent(Convert.ToInt32(content));
            }
        }

        private void btCreateStudent_Click(object sender, RoutedEventArgs e)
        {
            CmbGroup.SelectedItem = null;
            //dataGridStudent.ItemsSource = Class.Student.ListStudents(null);
            CreateStudent createStudent = new CreateStudent();
            createStudent.Show();
        }

        private void Menu_Ozenki_Click(object sender, RoutedEventArgs e)
        {
            var cellInfo = dataGridStudent.SelectedCells[0];
            var cellInfoGroup = dataGridStudent.SelectedCells[1];
            Form.StudentOzenki student = new Form.StudentOzenki();
            student.num_zac_king = Convert.ToInt32(((TextBlock)cellInfo.Column.GetCellContent(cellInfo.Item)).Text);  
            student.group = ((TextBlock)cellInfoGroup.Column.GetCellContent(cellInfoGroup.Item)).Text;
            student.GetPredmeti(student.cmbPredmets);
            student.GetAllPoseshaemost();
            student.Show();
        }
    }
}
