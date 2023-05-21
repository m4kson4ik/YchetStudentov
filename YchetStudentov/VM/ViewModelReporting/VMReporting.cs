using MaterialDesignColors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YchetStudentov.Class;
using YchetStudentov.VM.ViewModelGroups;
using YchetStudentov.VM.ViewModelStudents;

namespace YchetStudentov.VM.ViewModelReporting
{
    public class VMReporting : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChange(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }
        private Class.Group SelectedGroup { get; set; }
        public ObservableCollection<Student> CollectionStudent { get; set; }
        public VMReporting()
        {
            SelectedGroup = VMGroups.SelectedGroup;
            CollectionStudent = new ObservableCollection<Student>(DateBase.Context().GetInfoStudents(SelectedGroup));
            ReportingGroup();
        }

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
            }
        }
        public string propuskipobolezniGroup { get; set; }
        public string propuskiGroup { get; set; }
        public string poseshaemostGroup { get; set; }
        private void ReportingGroup()
        {
            var obj = DateBase.Context().GetRatingGroup(SelectedGroup);
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
            propuskipobolezniGroup = $"Пропущенные пары по болезни: "+(propuskiBolezn / zanyatie) * 100 + "%";
            propuskiGroup = $"Пропущенные пары: "+ ((int)(((propuski + propuskiBolezn) / zanyatie) * 100)).ToString() +"%";
            poseshaemostGroup =  $"Посещаемость группы: " + (100 - ((int)(((propuski + propuskiBolezn) / zanyatie) * 100))) +"%";
        }
    }
}
