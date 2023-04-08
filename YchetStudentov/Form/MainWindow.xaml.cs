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
            try
            {
                DataTable dateTime = DateBase.Select($"Select * from Prepodovateli where login_prepodovatela = '{tbLogin.Text}'");
                if (dateTime != null && tbPassword.Text == (string)dateTime.Rows[0][4])
                { 
                     PageGlavForm glavForm = new PageGlavForm();
                     this.Close();
                     glavForm.Show();          
                }
                else
                {
                    MessageBox.Show("Неверный пароль!");
                }
            }
            catch
            {
                MessageBox.Show("Такого пользователя не существует!");
            }

        }
    }
}
