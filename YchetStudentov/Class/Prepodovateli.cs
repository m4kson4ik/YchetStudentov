using Azure;
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
        private string _family;
        private string _name;
        private string _otchestvo;
        public int login;
        public string password;
        public string fio { private get => $"{_family} {_name} {_otchestvo}"; set => fio = value; }

        public string Family
        {
            get { return _family; }
            set
            {
                _family = value;
                OnPropertyChanged("Family");
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Поле не может быть пустым!");
                }
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Поле не может быть пустым!");
                }
            }
        }
        public string Otchestvo
        {
            get { return _otchestvo; }
            set
            {
                _otchestvo = value;
                OnPropertyChanged("Otchestvo");
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Поле не может быть пустым!");
                }
            }
        }
        public Prepodovateli(string name, string family, string otchestvo, int login, string password)
        {
            _name = name;
            _family = family;
            _otchestvo = otchestvo;
            this.login = login;
            this.password = password;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

  // public string this[string columnName]
  // {
  //     get
  //     {
  //         string result = String.Empty;
  //         switch (columnName)
  //         {
  //             case "Name":
  //                 if (String.IsNullOrEmpty(_name))
  //                 {
  //                     result = "Возраст должен быть больше 0 и меньше 100";
  //                 }
  //                 break;
  //             case "Family":
  //                 //Обработка ошибок для свойства Name
  //                 break;
  //             case "Otchestvo":
  //                 //Обработка ошибок для свойства Position
  //                 break;
  //         }
  //         return result;
  //     }
  // }
  // public string Error
  // {
  //     get { throw new NotImplementedException(); }
  // }
    }
}
