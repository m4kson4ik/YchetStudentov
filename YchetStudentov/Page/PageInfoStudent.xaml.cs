using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
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
using YchetStudentov.Models;
using YchetStudentov.Page;
using YchetStudentov.VM.ViewModelDisciplins;
using YchetStudentov.VM.ViewModelStudents;
using YchetStudentov.VM.ViewModelTeachers;

namespace YchetStudentov
{
    /// <summary>
    /// Логика взаимодействия для PageInfoStudent.xaml
    /// </summary>
    public partial class PageInfoStudent
    {
        public PageInfoStudent()
        {
            InitializeComponent();
            ((VMStudents)DataContext).ShowWindowCreateStudent += MainWindow_ShowWindowCreateStudent;
            ((VMStudents)DataContext).ShowWindowEditingStudent += MainWindow_ShowWindowEditingStudent;
            ((VMStudents)DataContext).ShowWindowAttendaceStudent += MainWindow_ShowWindowAttendaceStudent;
            ((VMStudents)DataContext).ShowMessageDeletedEvent += MainWindow_ShowMessageDeletedEvent;
            ((VMStudents)DataContext).ShowMessageInfoStudentEvent += MainWindow_ShowMessageInfoEvent;

        }
        private void MainWindow_ShowMessageDeletedEvent(string content)
        {
            MessageBox.Show(content);
        }

        private void MainWindow_ShowMessageInfoEvent(string content)
        {
            MessageBox.Show(content);
        }
        private void MainWindow_ShowWindowCreateStudent()
        {
            (new CreateStudent()).ShowDialog();
        }
        private void MainWindow_ShowWindowEditingStudent()
        {
            (new EditStudent()).ShowDialog();
        }
        private void MainWindow_ShowWindowAttendaceStudent()
        {
            (new Form.StudentOzenki()).ShowDialog();
        }
        private void Menu_pechat_Click(object sender, RoutedEventArgs e)
        {
          //  List<Class.Student> students = new List<Class.Student>();
          //  foreach(var item in dataGridStudent.SelectedItems)
          //  {
          //      students.Add((Class.Student)item);
          //  }
          //  Files files = new Files();
          //  files.ImportInWord(students);
        }

        private void btImprot_Click(object sender, RoutedEventArgs e)
        {
           // Files files = new Files();
           // files.ImportAllStudentInWord();
        }
    }
}
