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
        }
        private void ShowFormEditingTeacher(Prepodovateli prepodovateli)
        {
            (new EditTeacher(prepodovateli)).ShowDialog();
        }
        private void ShowFormCreateTeacher(Prepodovateli prepodovateli)
        {
            (new CreateTeacher()).ShowDialog();
        }
    }
}
