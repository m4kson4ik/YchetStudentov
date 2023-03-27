﻿using System;
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
using System.Windows.Shapes;
using YchetStudentov.Page;

namespace YchetStudentov
{
    /// <summary>
    /// Логика взаимодействия для PageGlavForm.xaml
    /// </summary>
    public partial class PageGlavForm : Window
    {
        public PageGlavForm()
        {
            InitializeComponent();
            SelectedCmb();
            lbFIOPrepod.Content = GetFIOPrepod();
        }
        
        public string GetFIOPrepod()
        {
            //DataTable name = DateBase.Select($"Select family, name, otchestvo, login_prepodovatela from Prepodovateli where login_prepodovatela = '{MainWindow.idUser}'");
            //string fio = $"{name.Rows[0][0]} {name.Rows[0][1]} {name.Rows[0][2]}";
            return "ffdsf";
        }
        public void SelectedCmb()
        {
            if (MainWindow.roles == "admin")
            {
                //CmbSelect.ItemsSource = "Отделение №1";
                //FrameAllInfo.Content = new PageStatisticColledge();

            }
            if (MainWindow.roles == "zaved")
            {
                FrameAllInfo.Content = new PageZaved();
            }
            else
            {
               // CmbSelect.Visibility = Visibility.Hidden;
            }
        }
        private void ZavOtdel_Click(object sender, RoutedEventArgs e)
        {
            FrameAllInfo.Content = new PagePrepodovateli();
        }

        private void Studenti_Click(object sender, RoutedEventArgs e)
        {
            FrameAllInfo.Content = new PageInfoStudent();
        }

        private void Raspisanie_Click(object sender, RoutedEventArgs e)
        {
            FrameAllInfo.Content = new PageUchebPlan();
        }

        private void Prikazi_Click(object sender, RoutedEventArgs e)
        {
            FrameAllInfo.Content = new PagePoseshaemost();
        }

        private void Disceplini(object sender, RoutedEventArgs e)
        {
            FrameAllInfo.Content = new PageUchebPlan();
        }

        private void Disceplini_Click(object sender, RoutedEventArgs e)
        {
            FrameAllInfo.Content = new PageDistceplini();
        }

        private void Exit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow exit = new MainWindow();
            this.Close();
            exit.Show();
        }

        private void Group_Click(object sender, RoutedEventArgs e)
        {
            FrameAllInfo.Content = new PageGroup();
        }

        private void itog_ozenki_Click(object sender, RoutedEventArgs e)
        {
            FrameAllInfo.Content = new PageitogOzenki();
        }
    }
}
