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
using System.Windows.Navigation;
using System.Windows.Shapes;
using YchetStudentov.Class;

namespace YchetStudentov.Page
{
    /// <summary>
    /// Логика взаимодействия для PagePrepodovateli.xaml
    /// </summary>
    public partial class PagePrepodovateli
    {
        public PagePrepodovateli()
        {
            InitializeComponent();
            DateBase dt = new DateBase();
            dataGridPrepodovateli.ItemsSource = dt.FillingInTheTeachersTable();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            DateBase dt = new DateBase();
            dataGridPrepodovateli.ItemsSource = dt.SearchForTeachers(tbSearch.Text);
        }
    }
}
