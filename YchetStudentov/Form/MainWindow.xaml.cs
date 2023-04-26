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
using YchetStudentov.Models;

namespace YchetStudentov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void bt_Go_Click(object sender, RoutedEventArgs e)
        {
            tbCheck.Text = HashPassword.HashPassword.Hash().HashinPassword(tbPassword.Text);
            if (DateBase.Context().CheckingCorrectPasswordAndLogin(tbLogin.Text, tbPassword.Text))
            {
                PageGlavForm pageGlavForm = new PageGlavForm();
                pageGlavForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }
    }
}
