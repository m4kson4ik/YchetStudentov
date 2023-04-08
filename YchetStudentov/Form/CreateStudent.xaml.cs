using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace YchetStudentov
{
    /// <summary>
    /// Логика взаимодействия для CreateStudent.xaml
    /// </summary>
    public partial class CreateStudent : Window
    {
        public CreateStudent()
        {
            InitializeComponent();
            tbNumberZach.IsReadOnly = true;
            cmbGragdanstvo.Items.Add("Российское");
            cmbYearPostup.Items.Add("2023");
            cmbYearPostup.Items.Add("2022");
            cmbYearPostup.Items.Add("2021");
            cmbYearPostup.Items.Add("2020");
            cmbYearPostup.Items.Add("2019");
            cmbBudget.Items.Add("Да");
            cmbBudget.Items.Add("Нет");
            cmbNumberGroup.ItemsSource = DateBase.GetInfoGroup();

        }

        public void GetGroup()
        {
            
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            Correctness cor = new Correctness();
            if (cor.CheckingForEmptyValues(btSave, tbNumberZach, tbName, tbFamily, tbOtchestvo, tbAdress, tbEmail))
            {
                cor.CheckingForALargeLetter(tbName, tbFamily, tbOtchestvo, tbAdress);
                DateBase.AddItemStudent(tbNumberZach, cmbNumberGroup, tbName, tbFamily, tbOtchestvo, dtDataRog, tbAdress, tbEmail, cmbGragdanstvo, cmbYearPostup, cmbBudget);
            }
        }
        private int Random()
        {
            Random random = new Random();
            int i = random.Next(0, 599999);
            return i;
        }

        private void lbGenerate_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbNumberZach.Text = Random().ToString();
        }

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            Correctness cor = new Correctness();
            cor.CheckingForRussianLetters(tbName, tbFamily, tbOtchestvo, tbAdress);
            cor.CheckingForNumbers(tbName, tbFamily, tbOtchestvo);
            cor.CheckingForASpace(tbName, tbFamily, tbOtchestvo, tbEmail);
        }
    }
}
