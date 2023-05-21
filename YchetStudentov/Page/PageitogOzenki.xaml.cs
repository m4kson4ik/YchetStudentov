using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using YchetStudentov.Class;
using YchetStudentov.Form;
using YchetStudentov.VM.ViewModelGrades;
using YchetStudentov.VM.ViewModelStudents;

namespace YchetStudentov.Page
{
    /// <summary>
    /// Логика взаимодействия для PageitogOzenki.xaml
    /// </summary>
    public partial class PageitogOzenki
    {
        public PageitogOzenki()
        {
            InitializeComponent();
            ((VMCreateGrades)DataContext).ShowWindowViewGrades += MainWindow_ShowWindowViewGrades;
        }
        private void MainWindow_ShowWindowViewGrades()
        {
            (new ViewingFinalGrades()).ShowDialog();
        }
    }
}
