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
    /// Логика взаимодействия для CreateDiscipline.xaml
    /// </summary>
    public partial class CreateDiscipline : Window
    {
        public CreateDiscipline()
        {
            InitializeComponent();
            cmbPrepodovatel.ItemsSource = DateBase.Context().FillingInTheTeachersTable();
            cmbFormaAttest.Items.Add("Экзамен");
            cmbFormaAttest.Items.Add("Зачет");
            cmbFormaAttest.Items.Add("Деффер.зачет");
            cmbFormaAttest.Items.Add("Курсовой проект");
            cmbFormaAttest.Items.Add("Курсовая работа");
            cmbFormaAttest.Items.Add("Контрольная работа");
        }

        private void btCreate_Click(object sender, RoutedEventArgs e)
        {
            DateBase.Context().CreateDiscipline(tbNameD.Text, cmbFormaAttest.SelectedItem.ToString() ?? "", (Prepodovateli)cmbPrepodovatel.SelectedItem);
            MessageBox.Show($"Дисциплина {tbNameD.Text} успешно создана!");
            this.Close();
        }
    }
}
