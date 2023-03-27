using Microsoft.EntityFrameworkCore;
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
                context.Students.Load();
                var items1 = from p in context.Students where p.NumberZacKnig == (int)lb_Numberzachet.Content select p;
                var items = context.Students.SingleOrDefault(p => p.NumberZacKnig == Convert.ToInt32(lb_Numberzachet.Content));
            }
        }
    }
    
}
