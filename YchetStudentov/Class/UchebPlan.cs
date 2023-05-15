using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YchetStudentov.Class
{
    public class UchebPlan : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private int _numberCurriculum;
        private string? _numberGroup;
        private string? _nameDisceplini;
        private string? _family;
        private string? _name;
        private string? _otchesvo;
        private string? _formaAttest;

        private int _numberDisceplini;

        public int NumberCurriculum
        {
            get { return _numberCurriculum; }
            set
            {
                _numberCurriculum = value;
                 OnPropertyChanged("NumberCurriculum");
            }
        }

        public int NumberDisceplini
        {
            get { return _numberDisceplini; }
            set
            {
                _numberDisceplini = value;
                OnPropertyChanged("NumberDisceplini");
            }
        }

        public string? NumberGroup
        {
            get { return _numberGroup; }
            set
            {
                _numberGroup = value;
                OnPropertyChanged("NumberGroup");
            }
        }

        public string? NameDisceplini
        {
            get { return _nameDisceplini; }
            set
            {
                _nameDisceplini = value;
                OnPropertyChanged("NameDisceplini");
            }
        }
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
        public string? Otchesvo
        {
            get { return _otchesvo; }
            set
            {
                _otchesvo = value;
                OnPropertyChanged("Otchesvo");
            }
        }
        public string? FormaAttest
        {
            get { return _formaAttest; }
            set
            {
                _formaAttest = value;
                OnPropertyChanged("FormaAttestStudent");
            }
        }
    }
}
