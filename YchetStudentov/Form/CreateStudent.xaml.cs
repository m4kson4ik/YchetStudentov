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
        }
    }
}
