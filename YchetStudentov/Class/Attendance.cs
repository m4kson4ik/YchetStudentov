using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace YchetStudentov.Class
{
    public class Attendance : INotifyPropertyChanged
    {
        private string? _nameDisceplini;
        private int _numberZachetki;
        private string? _attendanceStatus;
        private DateTime? _dataZanyatie;
        private string? _nameTeacher;
        private string? _familyTeacher;
        private int? _numberUspevaemosti;

        public string? NameDisceplini
        {
            get { return _nameDisceplini; }
            set
            {
                _nameDisceplini = value;
                 OnPropertyChanged("NameDisceplini");
            }
        }
        public int Number_Zachetki
        {
            get { return _numberZachetki; }
            set
            {
                _numberZachetki = value;
                OnPropertyChanged("NumberZachetki");
            }
        }
        public string? AttendanceStatus
        {
            get { return _attendanceStatus; }
            set
            {
                _attendanceStatus = value;
                OnPropertyChanged("AttendanceStatus");
            }
        }
        public DateTime? DataZanyatie
        {
            get { return _dataZanyatie; }
            set
            {
                _dataZanyatie = value;
                OnPropertyChanged("DataZanyatie");
            }
        }
        public string? NameTeacher
        {
            get { return _nameTeacher; }
            set
            {
                _nameTeacher = value;
                OnPropertyChanged("NameTeacher");
            }
        }
        public string? FamilyTeacher
        {
            get { return _familyTeacher; }
            set
            {
                _familyTeacher = value;
                OnPropertyChanged("FamilyTeacher");
            }
        }
        public int? NumberUspevaemosti
        {
            get { return _numberUspevaemosti; }
            set
            {
                _numberUspevaemosti = value;
                OnPropertyChanged("NumberUspevaemosti");
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
