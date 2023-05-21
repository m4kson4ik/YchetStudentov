using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace YchetStudentov.Class
{
    public class FinalGrades : INotifyPropertyChanged
    {
        private int _semestr;
        private string? _nameDisceplini;
        private string? _grades;
        private string? _namestudent;
        private string? _familystudent;
        private DateTime _date;
        private int _numberDisceplini;
        private int _numberGrades;
        private int _numberZacKnig;
        private string? _numberGroup;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public int Semestr
        {
            get{ return _semestr; }
            set
            {
                _semestr = value;
                OnPropertyChanged("Semestr");
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
        public string? Grades
        {
            get { return _grades; }
            set
            {
                _grades = value;
                OnPropertyChanged("Grades");
            }
        }
        public string? Namestudent
        {
            get { return _namestudent; }
            set
            {
                _namestudent = value;
                OnPropertyChanged("Namestudent");
            }
        }

        public string? FamilyStudent
        {
            get { return _familystudent; }
            set
            {
                _familystudent = value;
                OnPropertyChanged("FamilyStudent");
            }
        }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
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
        public int NumberGrades
        {
            get { return _numberGrades; }
            set
            {
                _numberGrades = value;
                OnPropertyChanged("NumberGrades");
            }
        }
        public int NumberZacKnig
        {
            get { return _numberZacKnig; }
            set
            {
                _numberZacKnig = value;
                OnPropertyChanged("NumberZacKnig");
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
    }
}
