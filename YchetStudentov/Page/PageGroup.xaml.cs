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
using YchetStudentov.VM.ViewModelDisciplins;
using YchetStudentov.VM.ViewModelGroups;
using YchetStudentov.VM.ViewModelStudents;

namespace YchetStudentov.Page
{
    /// <summary>
    /// Логика взаимодействия для PageGroup.xaml
    /// </summary>
    public partial class PageGroup
    {
        public PageGroup()
        {
            InitializeComponent();
            ((VMGroups)DataContext).ShowWindowCreateGroupEvent += MainWindow_ShowCreatingWindowEvent;
            ((VMGroups)DataContext).ShowWindowEditingGroupEvent += MainWindow_ShowEditingWindowEvent;
            ((VMGroups)DataContext).ShowWindowReportingGroupEvent += MainWindow_ShowReportingWindowEvent;
            ((VMGroups)DataContext).ShowMessageDeletedEvent += MainWindow_ShowMessageEvent;
        }
        private void MainWindow_ShowMessageEvent(string content)
        {
            MessageBox.Show(content);
        }
        private void MainWindow_ShowCreatingWindowEvent()
        {
            (new CreateGroup()).ShowDialog();
        }

        private void MainWindow_ShowEditingWindowEvent()
        {
            (new EditingAGroup()).ShowDialog();
        }
        private void MainWindow_ShowReportingWindowEvent()
        {
            (new GroupReporting()).ShowDialog();
        }
    }
}
