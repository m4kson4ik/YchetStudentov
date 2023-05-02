using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

namespace YchetStudentov.Form
{
    /// <summary>
    /// Логика взаимодействия для CreateTeacher.xaml
    /// </summary>
    public partial class CreateTeacher : Window
    {
        public Prepodovateli prepodovateli;
        public CreateTeacher(Prepodovateli prepodovateli)
        {
            InitializeComponent();
            this.prepodovateli = prepodovateli;
            DataContext = prepodovateli;
        }

        private void btCreateTeacher_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            //  Correctness correctness = new Correctness();
            //  if (correctness.CheckingForEmptyValuesTextBox(btCreateTeacher, tbFamily, tbName, tbOtchestvo))
            //  {
            //      if (MessageBox.Show($"Вы уверены что хотите добавить преподователя c данными:\nИмя - {tbName.Text}\nФамилия - {tbFamily.Text}\nОтчество - {tbOtchestvo.Text}", "Добавление преподователя",
            //             MessageBoxButton.YesNo,
            //             MessageBoxImage.Question) == MessageBoxResult.Yes)
            //      {
            //          GenerateLoginAndPassword();
            //          correctness.CheckingForALargeLetter(tbFamily, tbName, tbOtchestvo);
            //          DateBase.Context().CreateTeacher(tbFamily.Text, tbName.Text, tbOtchestvo.Text, login, password ?? " ");
            //          MessageBox.Show("Преподователь успешно создан!");
            //          this.Close();
            //      }
            //  }
        }
    }
}
