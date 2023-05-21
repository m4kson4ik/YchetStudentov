using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using YchetStudentov.Class;
using YchetStudentov.Form;
using YchetStudentov.VM.ViewModelSyllabus;
using YchetStudentov.VM.ViewModelTeachers;

namespace YchetStudentov.Page
{
    /// <summary>
    /// Логика взаимодействия для PageUchebPlan.xaml
    /// </summary>
    public partial class PageUchebPlan
    {
        public PageUchebPlan()
        {
            InitializeComponent();
            ((VMSyllabus)DataContext).ShowWindowCreateSyllabusEvent += ShowFormCreateSyllabus;
            ((VMSyllabus)DataContext).ShowMessageEvent += MainWindow_ShowMessageEvent;
        }
        private void MainWindow_ShowMessageEvent(string content)
        {
            MessageBox.Show(content);
        }
        private void ShowFormCreateSyllabus()
        {
            (new CreateCurriculum()).ShowDialog();
        }
    }
}
