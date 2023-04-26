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
using YchetStudentov.Form;

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
            cmb_number_group.ItemsSource = DateBase.Context().GetInfoGroup();          
        }
        
        public void Update()
        {
            GridUchebPlan.ItemsSource = DateBase.Context().DataGridGetCurriculum(cmb_number_group.SelectedItem.ToString() ?? " ");
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateCurriculum create = new CreateCurriculum();
            create.ShowDialog();
            Update();
        }

        private void cmb_number_group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Menu_pechat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_Delete_Click(object sender, RoutedEventArgs e)
        {
            DateBase.Context().DeleteCurriculum((UchebPlan)GridUchebPlan.SelectedItem);
            MessageBox.Show("Предмет был успешно удален!");
            Update();
        }

        private void btExport_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_number_group.SelectedItem != null)
            {
                Files files = new Files();
                files.ExportUchebPlan(cmb_number_group.SelectedItem.ToString() ?? " ");
            }
            else
            {
                MessageBox.Show("Необходимо выбрать группу!");
            }
        }
    }
}
