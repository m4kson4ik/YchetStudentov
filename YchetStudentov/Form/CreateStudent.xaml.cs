using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
            cmbNumberGroup.ItemsSource = DateBase.Context().GetInfoGroup();
        }

        public void GetGroup()
        {
            
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            Correctness cor = new Correctness();
            if (cor.CheckingForEmptyValuesTextBox(btSave, tbNumberZach, tbName, tbFamily, tbOtchestvo, tbAdress, tbEmail) && cor.ChekingForEmptyValuesComboBox(btSave, cmbBudget, cmbGragdanstvo, cmbNumberGroup, cmbYearPostup))
            {
                cor.CheckingForALargeLetter(tbName, tbFamily, tbOtchestvo, tbAdress);
                if (MessageBox.Show($"Вы уверены что хотите добавить студента c данными:\nИмя - {tbName.Text}\nФамилия - {tbFamily.Text}\nОтчество - {tbOtchestvo.Text}\nДата рождения - {dtDataRog.SelectedDate}\nПочта - {tbEmail.Text}\nБюджет - {cmbBudget.SelectedItem}\nГражданство - {cmbGragdanstvo.SelectedItem}", "Добавление студента",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DateBase.Context().AddItemStudent(Convert.ToInt32(tbNumberZach.Text), cmbNumberGroup.Text, tbName.Text, tbFamily.Text, tbOtchestvo.Text, Convert.ToDateTime(dtDataRog.SelectedDate), tbAdress.Text, tbEmail.Text, cmbGragdanstvo.SelectedItem.ToString() ?? " ", Convert.ToInt32(cmbYearPostup.Text), cmbBudget.SelectedItem.ToString() ?? "");
                    this.Close();
                }
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

        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            Correctness cor = new Correctness();
            //cor.CheckingForRussianLetters(tbName.Text, tbFamily.Text, tbOtchestvo, tbAdress);
            cor.CheckingForNumbers(tbName, tbFamily, tbOtchestvo);
            cor.CheckingForASpace(tbName, tbFamily, tbOtchestvo, tbEmail);
        }
    }
}
