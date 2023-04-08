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
        public EditStudent(string content)
        {
            InitializeComponent();
            GetInfo(content);
        }

        public string? SelectItem;
        public void GetInfo(string content)
        {
            lb_Numberzachet.Content = content;
            using (var context = new YcotStudentContext())
            {               
                context.Students.Load();
                var items1 = from p in context.Students where p.NumberZacKnig == (int)lb_Numberzachet.Content select p;
                var items = context.Students.SingleOrDefault(p => p.NumberZacKnig == Convert.ToInt32(content));
                context.Groups.Load();
                cmbGroup.ItemsSource = DateBase.GetInfoGroup();
                cmbGroup.SelectedItem = items.NumberGroup;
                SelectItem = cmbGroup.SelectedItem.ToString();
                tbName.Text = items.Name;
                tbFamily.Text = items.Family;
                tbOtchestvo.Text = items.Otchesto;
                tbAdress.Text = items.AdressProj;
                tbPocta.Text = items.Email;
                cmbGragdanstvo.Items.Add(items.Gragdanstvo);
                cmbGragdanstvo.SelectedItem = items.Gragdanstvo;
                cmbYearPostup.Items.Add("2023");
                cmbYearPostup.Items.Add("2022");
                cmbYearPostup.Items.Add("2021");
                cmbYearPostup.Items.Add("2020");
                cmbYearPostup.Items.Add("2019");
                cmbYearPostup.SelectedItem = items.GodPostuplenya.ToString();
                dtYear.Text = items.DataRoj.ToString();
                cmbBudget.Items.Add("Да");
                cmbBudget.Items.Add("Нет");
                cmbBudget.SelectedItem = items.Budget;
            }
        }

        public void UpdateInfo()
        {
            using (var context = new YcotStudentContext())
            {
                var items = context.Students.SingleOrDefault(p => p.NumberZacKnig == Convert.ToInt32(lb_Numberzachet.Content));
                context.Students.Load();
                items.NumberGroup = cmbGroup.SelectedItem.ToString();
                items.Name = tbName.Text.ToString();
                items.Family = tbFamily.Text.ToString();
                items.Otchesto = tbOtchestvo.Text.ToString();
                items.AdressProj = tbAdress.Text.ToString();
                items.Email = tbPocta.Text.ToString();
                items.GodPostuplenya = Convert.ToInt32(cmbYearPostup.SelectedItem);
                items.Budget = cmbBudget.SelectedItem.ToString();
                context.SaveChanges();
                MessageBox.Show("Данные успешно изменены!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Correctness cor = new Correctness();
            if (cor.CheckingForEmptyValues(btUpdateInfo, tbName, tbFamily, tbOtchestvo, tbAdress, tbPocta))
            {
                cor.CheckingForALargeLetter(tbName, tbFamily, tbOtchestvo, tbAdress);
                if (MessageBox.Show($"Вы уверены что хотите изменить данные студента?", "Редактирование данных пользователя",
                   MessageBoxButton.YesNo,
                   MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (SelectItem != cmbGroup.SelectedItem.ToString())
                    {
                        if (MessageBox.Show("Подтверждая изменение вы потеряете данные об оценках студента, вы уверены?", "Данные об оценках будут утеряны!", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                        {
                            UpdateInfo();
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                    UpdateInfo();
                }
                else
                {

                }
            }
        }

        
        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            Correctness cor = new Correctness();
            cor.CheckingForRussianLetters(tbName, tbFamily, tbOtchestvo, tbAdress);
            cor.CheckingForNumbers(tbName, tbFamily, tbOtchestvo);
            cor.CheckingForASpace(tbName, tbFamily, tbOtchestvo, tbPocta);
        }
    }
    
}
