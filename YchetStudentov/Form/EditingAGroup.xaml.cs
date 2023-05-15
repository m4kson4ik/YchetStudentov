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
    /// Логика взаимодействия для EditingAGroup.xaml
    /// </summary>
    public partial class EditingAGroup : Window
    {
        Group group;
        public EditingAGroup(Group group)
        {
            InitializeComponent();
            cmbNumberSpecialty.Items.Add("09.02.07");
        }
    }
}
