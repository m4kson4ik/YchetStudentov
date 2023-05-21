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
using YchetStudentov.Form;
using YchetStudentov.VM.ViewModelDisciplins;
using YchetStudentov.VM.ViewModelTeachers;

namespace YchetStudentov.Page
{
    public partial class PagePrepodovateli
    {
        public PagePrepodovateli()
        {
            InitializeComponent();
            ((VMTeachers)DataContext).ShowWindowEditingEvent += ShowFormEditingTeacher;
            ((VMTeachers)DataContext).ShowWindowCreateTeacherEvent += ShowFormCreateTeacher;
            ((VMTeachers)DataContext).ShowMessageEvent += MainWindow_ShowMessageEvent;
        }
        private void MainWindow_ShowMessageEvent(string content)
        {
            MessageBox.Show(content);
        }
        private void ShowFormEditingTeacher()
        {
            (new EditTeacher()).ShowDialog();
        }
        private void ShowFormCreateTeacher()
        {
            (new CreateTeacher()).ShowDialog();
        }
    }
}
