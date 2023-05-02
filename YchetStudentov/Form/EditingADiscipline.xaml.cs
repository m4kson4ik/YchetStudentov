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
using YchetStudentov.Class;

namespace YchetStudentov.Form
{
    /// <summary>
    /// Логика взаимодействия для EditingADiscipline.xaml
    /// </summary>
    public partial class EditingADiscipline : Window
    {
        Distceplini distceplini;
        public EditingADiscipline(Distceplini distceplini)
        {
            InitializeComponent();
            this.distceplini = distceplini;
            //tbNameDisciplini.Text = distceplini.name_disceplini;
            cmbTeacher.ItemsSource = DateBase.Context().FillingInTheTeachersTable();
            cmbFormaAttest.Items.Add("Экзамен");
            cmbFormaAttest.Items.Add("Зачет");
            cmbFormaAttest.Items.Add("Деффер.зачет");
            cmbFormaAttest.Items.Add("Курсовой проект");
            cmbFormaAttest.Items.Add("Курсовая работа");
            cmbFormaAttest.Items.Add("Контрольная работа");
            //cmbFormaAttest.SelectedItem = distceplini.forma_attest;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateBase.Context().EditDiscipline(distceplini, tbNameDisciplini.Text, cmbFormaAttest.SelectedItem.ToString() ?? " ", (Prepodovateli)cmbTeacher.SelectedItem);
            MessageBox.Show($"Дисциплина {tbNameDisciplini.Text} успешно изменена!");
        }
    }
}