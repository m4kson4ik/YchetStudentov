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
    /// <summary>
    /// Логика взаимодействия для PageDistceplini.xaml
    /// </summary>
    public partial class PageDistceplini
    {
        public PageDistceplini()
        {
            InitializeComponent();
            Update();
        }
        public void Update()
        {
            dtDisceplini.ItemsSource = DateBase.Context().GetDataGridDiscipline();
        }

        private void Menu_Delete_Click(object sender, RoutedEventArgs e)
        {
            DateBase.Context().DeleteDiscipline((Class.Distceplini)dtDisceplini.SelectedItem);
            MessageBox.Show("Дисциплина была успешно удалена!");
            Update();
        }

        private void Menu_Edit_Click(object sender, RoutedEventArgs e)
        {
            EditingADiscipline editing = new EditingADiscipline((Distceplini)dtDisceplini.SelectedItem);
            editing.ShowDialog();
            Update();
        }

        private void btCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateDiscipline create = new CreateDiscipline();
            create.ShowDialog();
            Update();
        }
    }
}
