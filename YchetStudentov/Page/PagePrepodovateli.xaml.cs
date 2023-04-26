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
using System.Windows.Navigation;
using System.Windows.Shapes;
using YchetStudentov.Class;
using YchetStudentov.Form;

namespace YchetStudentov.Page
{
    public partial class PagePrepodovateli
    {
        public PagePrepodovateli()
        {
            InitializeComponent();
            UpdateDataGrid();         
        }
        public void UpdateDataGrid()
        {
            dataGridPrepodovateli.ItemsSource = DateBase.Context().FillingInTheTeachersTable();
        }
        private void Menu_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены что хотите удалить преподователя?", "Удаление преподователя",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (DateBase.Context().DeleteTeacher((Class.Prepodovateli)dataGridPrepodovateli.SelectedItem))
                {
                    MessageBox.Show("Преподователь был успешно удален!");
                    UpdateDataGrid();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при удаление преподователя!");
                }
            }
        }

        private void Menu_Edit_Click(object sender, RoutedEventArgs e)
        {
            Form.EditTeacher editTeacher = new EditTeacher((Prepodovateli)dataGridPrepodovateli.SelectedItem);
            editTeacher.ShowDialog();
            UpdateDataGrid();
        }

        private void CreateTeacher_Click(object sender, RoutedEventArgs e)
        {
            Form.CreateTeacher cr = new CreateTeacher();
            //cr.DataContext = (Prepodovateli)dataGridPrepodovateli.DataContext;
            cr.ShowDialog();
            UpdateDataGrid();
        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridPrepodovateli.ItemsSource = DateBase.Context().SearchForTeachers(tbSearch.Text);
        }
    }
}
