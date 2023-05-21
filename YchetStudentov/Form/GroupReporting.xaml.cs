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
    /// Логика взаимодействия для GroupReporting.xaml
    /// </summary>
    public partial class GroupReporting : Window
    {
        public GroupReporting()
        {
           InitializeComponent();
         //  SelectedGroup = group;
         //  AttendanceAccount();
         //  dtStudents.ItemsSource = DateBase.Context().GetInfoStudents(SelectedGroup.NumberGroup);
        }

        private void AttendanceAccount()
        {
         //  var obj = DateBase.Context().GetRating(SelectedGroup);
         //  double propuski = 0;
         //  double propuskiBolezn = 0;
         //  double zanyatie = 0;
         //  foreach(var item in obj)
         //  {
         //      zanyatie++;
         //      if (item.Ozenka == "Н")
         //      {
         //          propuski++;
         //      }
         //      else if (item.Ozenka == "Б")
         //      {
         //          propuskiBolezn++;
         //      }
         //  }
         //  lbPropushenniePariBolezn.Content = (propuskiBolezn / zanyatie) * 100+"%";
         //  lbPropushenniePari.Content = ((propuski + propuskiBolezn)/ zanyatie) * 100+"%";
         //  lbSrPosesGroup.Content = ((propuski + propuskiBolezn) / zanyatie)*100+"%";
        }

        private void dtStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        //   if (dtStudents.SelectedItem != null)
        //   {
        //       var student = (Student)dtStudents.SelectedItem;
        //       var obj = DateBase.Context().GetRating(SelectedGroup).Where(s=>s.Number_Zachetki == student.NumberZachetki);
        //       double propuski = 0;
        //       double propuskiBolezn = 0;
        //       double zanyatie = 0;
        //       foreach (var item in obj)
        //       {
        //           zanyatie++;
        //           if (item.Ozenka == "Н")
        //           {
        //               propuski++;
        //           }
        //           else if (item.Ozenka == "Б")
        //           {
        //               propuskiBolezn++;
        //           }
        //       }
        //       lbStudentPropuskiBolezn.Content = $"Пропущенные пары по болезни - {(propuskiBolezn / zanyatie) * 100}%";
        //       lbStudentPropuski.Content = $"Пропущенные пары {(propuski + propuskiBolezn / zanyatie) * 100}%";
        //       lbStudentSrPoseshaemost.Content = $"Средняя посещаемость - {((propuski + propuskiBolezn) / zanyatie) * 100}%";
        //   }
        }
    }
}
