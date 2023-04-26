using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YchetStudentov.Class;
using YchetStudentov.Form;
using YchetStudentov.Models;

namespace YchetStudentov.Page
{
    /// <summary>
    /// Логика взаимодействия для PagePoseshaemost.xaml
    /// </summary>
    public partial class PagePoseshaemost
    {
        public PagePoseshaemost()
        {
            InitializeComponent();
            gridStudent.Visibility = Visibility.Hidden;
            CmbGroup.ItemsSource = DateBase.Context().GetAllInfoGroup().Select(s => s.NumberGroup);
            btCancelPar.Visibility = Visibility.Hidden;
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CmbNamePredmet.ItemsSource = DateBase.Context().DataGridGetCurriculum(CmbGroup.SelectedItem.ToString() ?? " ");
        }

        private void CreatePars_Click(object sender, RoutedEventArgs e)
        {
              gridStudent.Visibility = Visibility.Visible;
              gridStudent.ItemsSource = DateBase.Context().GetInfoStudents(CmbGroup.SelectedItem.ToString() ?? " ");
              CreatePars.Visibility = Visibility.Hidden;
              CmbGroup.IsEnabled = false;
              CmbNamePredmet.IsEnabled = false;
              dpDataPari.IsEnabled = false;
              btCancelPar.Visibility = Visibility;
        }
        

        private void btCancelPar_Click(object sender, RoutedEventArgs e)
        {
            btCancelPar.Visibility = Visibility.Hidden;
            CreatePars.Visibility = Visibility.Visible;
            gridStudent.Visibility = Visibility.Hidden;
            CmbGroup.IsEnabled = true;
            CmbNamePredmet.IsEnabled = true;
            dpDataPari.IsEnabled = true;
            listStudent.Items.Clear();
        }
        private void Menu_otsutstvuet_Click(object sender, RoutedEventArgs e)
        {
            DateBase.Context().CreatePoseshaemost((Class.Student)gridStudent.SelectedItem, (Class.UchebPlan)CmbNamePredmet.SelectedItem, "Н", dpDataPari.SelectedDate);
            MessageBox.Show($"Студент отсутствует");
        }

        private void Menu_bolezn_Click(object sender, RoutedEventArgs e)
        {
            DateBase.Context().CreatePoseshaemost((Class.Student)gridStudent.SelectedItem, (Class.UchebPlan)CmbNamePredmet.SelectedItem, "Б", dpDataPari.SelectedDate);
            MessageBox.Show($"Студент отсутствует по болезни");
        }

        private void Menu_napare_Click(object sender, RoutedEventArgs e)
        {
            DateBase.Context().CreatePoseshaemost((Class.Student)gridStudent.SelectedItem, (Class.UchebPlan)CmbNamePredmet.SelectedItem, "П", dpDataPari.SelectedDate);
            MessageBox.Show($"Студент на паре");
        }
    }
}
