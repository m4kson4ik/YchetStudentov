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
            this.group = group;
            tbNumberGroup.Text = group.NumberGroup;
            tbSpec.Text = group.NameSpec;
            cmbNumberSpecialty.Items.Add("09.02.07");
            cmbNumberSpecialty.SelectedItem = group.NumberSpec;
            cmbKurator.IsReadOnly = false;
        }

        private void btCreate_Click(object sender, RoutedEventArgs e)
        {
            if (DateBase.Context().EditingGroup(group,tbSpec.Text, tbNumberGroup.Text, cmbNumberSpecialty.SelectedItem.ToString() ?? " "))
            {
                MessageBox.Show($"Группа {tbNumberGroup.Text} была успешно изменена!");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
