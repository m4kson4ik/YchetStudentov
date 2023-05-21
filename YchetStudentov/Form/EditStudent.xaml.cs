using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using YchetStudentov.Models;
using YchetStudentov.VM.ViewModelStudents;
using YchetStudentov.VM.ViewModelTeachers;

namespace YchetStudentov.Form
{
    public partial class EditStudent : Window
    {
        public EditStudent()
        {
            InitializeComponent();
            ((VMEditingStudent)DataContext).ShowMessageEvent += MainWindow_ShowMessageEvent;
        }
        private void MainWindow_ShowMessageEvent(string content)
        {
            MessageBox.Show(content);
        }
    }
    
}
