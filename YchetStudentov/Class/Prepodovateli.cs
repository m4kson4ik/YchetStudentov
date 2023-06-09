﻿using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YchetStudentov.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace YchetStudentov.Class
{
    public class Prepodovateli : INotifyPropertyChanged
    {
        private string? _family;
        private string? _name;
        private string? _otchestvo;
        private int login;
        private string? password;
        public string fio { get => $"{_family} {_name} {_otchestvo}"; set => fio = value; }
        public string? Family
        {
            get { return _family; }
            set
            {
                    _family = value;
                    OnPropertyChanged("Family");
            }
        }
        public string? Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string? Otchestvo
        {
            get { return _otchestvo; }
            set
            {
                _otchestvo = value;
                OnPropertyChanged("Otchestvo");
            }
        }

        public int Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        public string? Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
                
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
