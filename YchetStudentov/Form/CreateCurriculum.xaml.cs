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
    /// Логика взаимодействия для CreateCurriculum.xaml
    /// </summary>
    public partial class CreateCurriculum : Window
    {
        public CreateCurriculum()
        {
            InitializeComponent();
            cmbNumberGroup.ItemsSource = DateBase.Context().GetInfoGroup();
            cmb_Disceplini.ItemsSource = DateBase.Context().GetDataGridDiscipline();
        }

        private void btCreate_Click(object sender, RoutedEventArgs e)
        {
            DateBase.Context().CreateCurriculum(cmbNumberGroup.SelectedItem.ToString() ?? "", (Distceplini)cmb_Disceplini.SelectedItem);
            MessageBox.Show($"Предмет {cmb_Disceplini.SelectedItem} добавлен для группы {cmbNumberGroup.SelectedItem}");
        }
    }
}
