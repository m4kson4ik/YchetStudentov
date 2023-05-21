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
using YchetStudentov.VM.ViewModelDisciplins;

namespace YchetStudentov.Form
{
    /// <summary>
    /// Логика взаимодействия для EditingADiscipline.xaml
    /// </summary>
    public partial class EditingADiscipline : Window
    {
        public EditingADiscipline()
        {
            InitializeComponent();
            ((VMEditDisceplins)DataContext).ShowMessageEvent += MainWindow_ShowMessageEvent;
        }
        private void MainWindow_ShowMessageEvent(string content)
        {
            MessageBox.Show(content);
        }
    }
}