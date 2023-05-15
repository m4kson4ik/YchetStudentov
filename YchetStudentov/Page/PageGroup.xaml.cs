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
        }

        private void MainWindow_ShowCreatingWindowEvent(Group group)
        {
            (new CreateGroup()).ShowDialog();
        }

        private void MainWindow_ShowEditingWindowEvent(Group group)
        {
            (new EditingAGroup(group)).ShowDialog();
        }

        private void Menu_Reporting_Click(object sender, RoutedEventArgs e)
        {
            GroupReporting groupReporting = new GroupReporting((Group)dataGridGroup.SelectedItem);
            groupReporting.Show();
        }
    }
}
