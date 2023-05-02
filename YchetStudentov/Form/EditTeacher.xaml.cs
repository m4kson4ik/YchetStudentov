using Azure;
using ExcelDataReader.Log;
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
using YchetStudentov.Page;

namespace YchetStudentov.Form
{
    /// <summary>
    /// Логика взаимодействия для EditTeacher.xaml
    /// </summary>
    /// 
    public partial class EditTeacher
    {
        Prepodovateli Prepodovateli;
        public EditTeacher(Prepodovateli Prepodovateli)
        {
            InitializeComponent();
            this.Prepodovateli = Prepodovateli;
            this.DataContext = Prepodovateli;
        }

        public int GenerateLoginAndPassword()
        {
            Random rand = new Random();
            return rand.Next();
        }

        private void btEditTeacher_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
