using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;
using YchetStudentov.Models;

namespace YchetStudentov.Form
{
    /// <summary>
    /// Логика взаимодействия для EditStudent.xaml
    /// </summary>
    public partial class EditStudent : Window
    {
        public EditStudent()
        {
            InitializeComponent();
        }
        public void GetInfo()
        {
            using (var context = new YcotStudentContext())
            {
                context.Students.Load();
                var items1 = from p in context.Students where p.NumberZacKnig == (int)lb_Numberzachet.Content select p;
                var items = context.Students.SingleOrDefault(p => p.NumberZacKnig == Convert.ToInt32(lb_Numberzachet.Content));

                tbName.Text = items.Name;
                tbFamily.Text = items.Family;
                tbOtchestvo.Text = items.Otchesto;
                tbAdress.Text = items.AdressProj;
                tbPocta.Text = items.Email;
                cmbGragdanstvo.Items.Add(items.Gragdanstvo);
                cmbYearPostup.Items.Add(items.GodPostuplenya);
                dtYear.Text = items.DataRoj.ToString();
            }
        }

        public void UpdateInfo()
        {

            using (var context = new YcotStudentContext())
            {
                var items = context.Students.SingleOrDefault(p => p.NumberZacKnig == Convert.ToInt32(lb_Numberzachet.Content));
                if (MessageBox.Show($"Вы уверены что хотите изенить данные студента?\nИзменение данных\n{items.Name} на {tbName.Text.ToString()}\n{items.Family} на {tbFamily.Text.ToString()} ", "Редактирование данных пользователя",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    context.Students.Load();
                    var items1 = from p in context.Students where p.NumberZacKnig == (int)lb_Numberzachet.Content select p;
                    items.Name = tbName.Text.ToString();
                    items.Family = tbFamily.Text.ToString();
                    items.Otchesto = tbOtchestvo.Text.ToString();
                    items.AdressProj = tbAdress.Text.ToString();
                    items.Email = tbPocta.Text.ToString();
                    items.GodPostuplenya = (int)cmbYearPostup.SelectedItem;
                    context.SaveChanges();
                    MessageBox.Show("Данные успешно изменены!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateInfo();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
