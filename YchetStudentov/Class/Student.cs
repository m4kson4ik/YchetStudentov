using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using YchetStudentov.Models;

namespace YchetStudentov.Class
{
    public class Student : INotifyPropertyChanged
    {
        private int _numberZachetki;
        private string? _numberGroup;
        private string? _name;
        private string? _family;
        private string? _otchestvo;
        private DateTime _dataRoj;

        private string? _adress;

        private string? _gragdanstvo;
        private string? _email;
        private int _yearPostuplenie;

        private string? _budget;
        public string fio { get => $"{Family} {Name} {Otchestvo}"; set => fio = value; }

        public int NumberZachetki
        {
            get { return _numberZachetki; }
            set { _numberZachetki = value; OnProperyChanged("NumberZachetki"); }
        }
        public string? NumberGroup
        {
            get { return _numberGroup; }
            set { _numberGroup = value; OnProperyChanged("NumberGroup"); }
        }
        public string? Name
        {
            get { return _name; }
            set { _name = value; OnProperyChanged("Name"); }
        }
        public string? Family
        {
            get { return _family; }
            set { _family = value; OnProperyChanged("Family"); }
        }
        public string? Otchestvo
        {
            get { return _otchestvo; }
            set { _otchestvo = value; OnProperyChanged("Otchestvo"); }
        }
        public DateTime DataRoj
        {
            get { return _dataRoj; }
            set { _dataRoj = value; OnProperyChanged("DataRoj"); }
        }

        public string? Adress
        {
            get { return _adress; }
            set { _adress = value; OnProperyChanged("Adress"); }
        }

        public string? Gragdanstvo
        {
            get { return _gragdanstvo; }
            set { _gragdanstvo = value; OnProperyChanged("Gragdanstvo"); }
        }
        public string? Email
        {
            get { return _email; }
            set { _email = value; OnProperyChanged("Email"); }
        }
        public int GodPostuplenie
        {
            get { return _yearPostuplenie; }
            set { _yearPostuplenie = value; OnProperyChanged("GodPostuplenie"); }
        }

        public string? Budget
        {
            get { return _budget; }
            set { _budget = value; OnProperyChanged("Budget"); }
        }
        public string ProposkiBolezn
        { 
            private get
            {
                var obj = DateBase.Context().GetRatingStudent(NumberZachetki);
                double propuski = 0;
                double propuskiBolezn = 0;
                double zanyatie = 0;
                foreach (var item in obj)
                {
                    zanyatie++;
                    if (item.AttendanceStatus == "Н")
                    {
                        propuski++;
                    }
                    else if (item.AttendanceStatus == "Б")
                    {
                        propuskiBolezn++;
                    }
                }
                return $"{((int)((propuskiBolezn / zanyatie) * 100))}%";
            }
            set
            {
                ProposkiBolezn = value;
            }
        }
        public string Proposki
        {
            private get
            {
                var obj = DateBase.Context().GetRatingStudent(NumberZachetki);
                double propuski = 0;
                double propuskiBolezn = 0;
                double zanyatie = 0;
                foreach (var item in obj)
                {
                    zanyatie++;
                    if (item.AttendanceStatus == "Н")
                    {
                        propuski++;
                    }
                    else if (item.AttendanceStatus == "Б")
                    {
                        propuskiBolezn++;
                    }
                }
                return $"{((int)(((propuski + propuskiBolezn) / zanyatie) * 100))}%";
            }
            set
            {
                Proposki = value;
            }
        }
        
        public string Poseshaemost
        {
            private get
            {
                var obj = DateBase.Context().GetRatingStudent(NumberZachetki);
                double propuski = 0;
                double propuskiBolezn = 0;
                double zanyatie = 0;
                foreach (var item in obj)
                {
                    zanyatie++;
                    if (item.AttendanceStatus == "Н")
                    {
                        propuski++;
                    }
                    else if (item.AttendanceStatus == "Б")
                    {
                        propuskiBolezn++;
                    }
                }
                return $"{(100 - ((int)(((propuski + propuskiBolezn) / zanyatie) * 100)))}%";
            }
            set
            {
                Poseshaemost = value;
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnProperyChanged(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }
    }
}
