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
    /// <summary>
    /// Логика взаимодействия для PageDistceplini.xaml
    /// </summary>
    public partial class PageDistceplini
    {
        public PageDistceplini()
        {
            InitializeComponent();
            ((VMDisciplins)DataContext).ShowWindowEvent += MainWindow_ShowWindowEvent;
            ((VMDisciplins)DataContext).ShowWindowEditingEvent += EditDisciplini_ShowWindowEvent;
            ((VMDisciplins)DataContext).ShowMessageEvent += MainWindow_ShowMessageEvent;
        }
        private void MainWindow_ShowMessageEvent(string content)
        {
            MessageBox.Show(content);
        }
        private void MainWindow_ShowWindowEvent()
        {
            (new CreateDiscipline()).ShowDialog();
        }

        private void EditDisciplini_ShowWindowEvent()
        {
            (new EditingADiscipline()).ShowDialog();
        }
    }
}
