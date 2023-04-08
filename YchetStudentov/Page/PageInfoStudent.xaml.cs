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
            Class.Group.GetAllGroup(CmbGroup);
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateBase dt = new DateBase();
            dataGridStudent.ItemsSource = dt.UpdateInfo(CmbGroup.SelectedItem?.ToString() ?? CmbGroup.Text);
            dataGridStudent.SelectedItem = null;    
        }

        public void UpdateInfo()
        {
            string group = CmbGroup.SelectedItem?.ToString() ?? CmbGroup.Text;
            using (var context = new YcotStudentContext())
            {
                context.Students.Load();
                dataGridStudent.ItemsSource = context.Students.Local.ToObservableCollection().Where(x => x.NumberGroup == group);
            }
        }
        private void Menu_Create_Click(object sender, RoutedEventArgs e)
        {
            var cellInfo = dataGridStudent.SelectedCells[0];
            var content = ((TextBlock)cellInfo.Column.GetCellContent(cellInfo.Item)).Text;
            EditStudent edit = new EditStudent(content);
            edit.Show();
        }

        private void Menu_pechat_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Печать");
        }

        private void Menu_Info_Click(object sender, RoutedEventArgs e)
        {
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
            CreateStudent createStudent = new CreateStudent();
            createStudent.Show();
        }

        private void Menu_Ozenki_Click(object sender, RoutedEventArgs e)
        {
           var cellInfo = dataGridStudent.SelectedCells[0];
           var cellInfoGroup = dataGridStudent.SelectedCells[1];
           var group = ((TextBlock)cellInfoGroup.Column.GetCellContent(cellInfoGroup.Item)).Text;
           var num_zac_king = Convert.ToInt32(((TextBlock)cellInfo.Column.GetCellContent(cellInfo.Item)).Text);  
           Form.StudentOzenki student = new Form.StudentOzenki(group, num_zac_king);
           student.Show();
        }

        private void CmbGroup_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            CmbGroup.Foreground = Brushes.White;
        }

        private void CmbGroup_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            CmbGroup.Foreground = Brushes.Black;
        }
    }
}
