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
using YchetStudentov.VM.ViewModelGroups;
using YchetStudentov.VM.ViewModelSyllabus;

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
            ((VMCreateSyllabus)DataContext).ShowMessageEvent += MainWindow_ShowMessageEvent;
        }
        private void MainWindow_ShowMessageEvent(string content)
        {
            MessageBox.Show(content);
        }
    }
}
