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
using YchetStudentov.Form;

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
            Update();
        }
        public void Update()
        {
            cmbGroup.ItemsSource = DateBase.Context().GetInfoGroup();
            dataGridGroup.ItemsSource = DateBase.Context().GetAllInfoGroup();
        }

        private void Menu_edit_Click(object sender, RoutedEventArgs e)
        {
            EditingAGroup editing = new EditingAGroup((Group)dataGridGroup.SelectedItem);
            editing.Show();
        }

        private void Menu_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DateBase.Context().DeletedGroup((Group)dataGridGroup.SelectedItem))
            {
                Update();
            }
            else
            {
                MessageBox.Show("Произошла ошибка удаления группы!");
            }
        }

        private void Menu_pechat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateGroup create = new CreateGroup();
            create.Show();
        }
    }
}
