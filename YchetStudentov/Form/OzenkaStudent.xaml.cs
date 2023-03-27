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

namespace YchetStudentov.Form
{
    /// <summary>
    /// Логика взаимодействия для OzenkaStudent.xaml
    /// </summary>
    public partial class OzenkaStudent : Window
    {
        public string number_group;
        public string name_predmet;
        public DatePicker data;
        public OzenkaStudent()
        {
            InitializeComponent();
        }

        public void CreateOzenka(string ozenka = "Н")
        {
            DataTable dataTable = DateBase.Select($"Select name_disceplini, number_disceplini, login_prepodovatela from Distceplini where name_disceplini = '{name_predmet}'");
            var number_disceplini = dataTable.Rows[0][1];
            DataTable dataTable1 = DateBase.Select($"Select number_zac_knig, name, family, number_group from Student where name = '{lbName.Content}' and family = '{lbFamily.Content}' and number_group = '{number_group}'");
            var number_zac_knig = dataTable1.Rows[0][0];

            DataTable createOzenka = DateBase.Select($"Insert Poseshaemost(number_zac_knig, number_distceplini, ocenka, data_zanyatie) values ('{number_zac_knig}', '{number_disceplini}', '{ozenka}', '{data}')");
        }
        private void btCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateOzenka((string)cmbOzenka.SelectedItem);
        }
    }
}
