using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using YchetStudentov.Models;

namespace YchetStudentov.Form
{
    public partial class EditStudent : Window
    {
        public Class.Student student;
        public EditStudent(Class.Student student)
        {
            this.student = student;
            InitializeComponent();
            GetInfo();
        }
        public void GetInfo()
        {
            DateBase dt = new DateBase();
            cmbYearPostup.Items.Add("2023");
            cmbYearPostup.Items.Add("2022");
            cmbYearPostup.Items.Add("2021");
            cmbYearPostup.Items.Add("2020");
            cmbYearPostup.Items.Add("2019");
            cmbYearPostup.SelectedItem = student.GodPostuplenie.ToString();
            cmbBudget.Items.Add("Да");
            cmbBudget.Items.Add("Нет");
            cmbBudget.SelectedItem = student.Budget;
            lb_Numberzachet.Content = student.NumberZachetki;
            //cmbGroup.ItemsSource = dt.GetInfoGroup();
            cmbGroup.SelectedItem = student.NumberGroup;
            dtYear.SelectedDate = student.DataRoj;
            tbName.Text = student.Name;
            tbFamily.Text = student.Family;
            tbOtchestvo.Text = student.Otchestvo;
            tbAdress.Text = student.Adress;
            tbPocta.Text = student.Email;
            cmbGragdanstvo.Items.Add(student.Gragdanstvo);
            cmbGragdanstvo.SelectedItem = student.Gragdanstvo;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Correctness cor = new Correctness();
            if (cor.CheckingForEmptyValuesTextBox(btUpdateInfo, tbName, tbFamily, tbOtchestvo, tbAdress, tbPocta))
            {
                cor.CheckingForALargeLetter(tbName, tbFamily, tbOtchestvo, tbAdress);
                if (MessageBox.Show($"Вы уверены что хотите изменить данные студента?", "Редактирование данных пользователя",
                   MessageBoxButton.YesNo,
                   MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                        if (MessageBox.Show("Подтверждая изменение вы потеряете данные об оценках студента, вы уверены?", "Данные об оценках будут утеряны!", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                        {
                            DateBase.Context().EditingInfoStudent(student, cmbGroup.SelectedItem.ToString() ?? "", tbName.Text, tbFamily.Text, tbOtchestvo.Text, tbAdress.Text, tbPocta.Text, cmbGragdanstvo.SelectedItem.ToString() ?? "", Convert.ToInt32(cmbYearPostup.SelectedItem), cmbBudget.SelectedItem.ToString() ?? "");
                        }
                        else
                        {
                            return;
                        }
                }
                else
                {

                }
            }
        }
        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            Correctness cor = new Correctness();
            //cor.CheckingForRussianLetters(tbName, tbFamily, tbOtchestvo, tbAdress);
            cor.CheckingForNumbers(tbName, tbFamily, tbOtchestvo);
            cor.CheckingForASpace(tbName, tbFamily, tbOtchestvo, tbPocta);
        }
    }
    
}
