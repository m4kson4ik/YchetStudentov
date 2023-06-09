﻿using System;
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
using YchetStudentov.VM.ViewModelGroups;
using YchetStudentov.VM.ViewModelStudents;

namespace YchetStudentov.Form
{
    /// <summary>
    /// Логика взаимодействия для CreateGroup.xaml
    /// </summary>
    public partial class CreateGroup : Window
    {
        public CreateGroup()
        {
            InitializeComponent();
            cmbNumberSpecialty.Items.Add("09.02.07");
            cmbKurator.IsReadOnly = false;
            ((VMCreateGroup)DataContext).ShowMessageEvent += MainWindow_ShowMessageEvent;
        }
        private void MainWindow_ShowMessageEvent(string content)
        {
            MessageBox.Show(content);
        }
    }
}
