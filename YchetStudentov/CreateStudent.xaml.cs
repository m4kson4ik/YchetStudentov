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
            //tbNumberZach.IsReadOnly = true;
            cmbNumberGroup.Items.Add("ИСП-308");
            cmbGragdanstvo.Items.Add("Российское");
            cmbBudget.Items.Add("Нет");
        }

        public void GetGroup()
        {

        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            DateBase.AddItemStudent(tbNumberZach, tbName, tbFamily, tbOtchestvo, dtDataRog);
            MessageBox.Show(tbNumberZach.Text);
        }
    }
}
