using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace YchetStudentov.Class
{
    public class Group : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChange(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }
        private string? _nameSpec;
        private string? _numberGroup;
        private string? _numberSpec;
        public string? NameSpec
        {
            get { return _nameSpec; }
            set { _nameSpec = value; OnPropertyChange("NameSpec"); }
        }
        public string? NumberGroup
        {
            get { return _numberGroup; }
            set { _numberGroup = value; OnPropertyChange("NumberGroup"); }
        }
        public string? NumberSpec
        {
            get { return _numberSpec; }
            set { _numberSpec = value; OnPropertyChange("NumberSpec"); }
        }
    }
}
