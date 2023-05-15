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
    /// Логика взаимодействия для EditAttendance.xaml
    /// </summary>
    public partial class EditAttendance : Window
    {
        public EditAttendance()
        {
            InitializeComponent();
          // Attendance = attendance;
          // cmbStatus.Items.Add("П");
          // cmbStatus.Items.Add("Н");
          // cmbStatus.Items.Add("Б");
          // cmbStatus.SelectedItem = studentsOzenki.Ozenka;
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
          //  DateBase.Context().EditingPoseshaemost(studentsOzenki, cmbStatus);
        }
    }
}
