using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YchetStudentov.Class;
using YchetStudentov.Infostraction.Commands;

namespace YchetStudentov.VM.ViewModelAttendance
{
    public class VMAttendance : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChange(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }

        public ObservableCollection<Class.Group> CollectionGroup { get; set; } 
        public ObservableCollection<Class.UchebPlan> CollectionDistceplini { get; set; } = new ObservableCollection<UchebPlan>();
        public ObservableCollection<Class.Student> CollectionStudent { get; set; } = new ObservableCollection<Class.Student>();
        public VMAttendance()
        {
            CollectionGroup = new ObservableCollection<Group>(DateBase.Context().GetAllInfoGroup());
            DeletedAttendancne = new LambdaCommand(OnDeletedAttendancne, CanDeletedAttendancne);
            ShowWindowEditingAttendance = new LambdaCommand(OnShowWindowEditingAttendance, CanShowWindowEditingAttendance);
            ShowStudent = new LambdaCommand(OnShowStudent, CanShowStudent);
            CreateAttendance = new LambdaCommand(OnCreateAttendance, CanCreateAttendance);
        }
        private UchebPlan? _selectedDistceplini { get; set; }
        public UchebPlan? SelectedDisceplini
        {
            get { return _selectedDistceplini; }
            set
            {
                _selectedDistceplini = value;
            }
        }
        private Group? _selectedGroup { get; set; }
        public Group? SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                if (value != null)
                {
                    _selectedGroup = value;
                    CollectionDistceplini.Clear();
                    var items = DateBase.Context().DataGridGetCurriculum(_selectedGroup);
                    foreach(var item in items)
                    {
                        CollectionDistceplini.Add(item);
                    }
                }
            }
        }

        private DateTime? _selectedDateTime;
        public DateTime? SelectedDateTime
        {
            get { return _selectedDateTime; }
            set
            {
                _selectedDateTime = value;
            }
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
        public ICommand ShowStudent { get; set; }
        private bool CanShowStudent(object obj)
        {
            if (SelectedDisceplini != null && SelectedGroup != null && SelectedDateTime != null)
            {
                //CollectionStudent.Clear();
                return true;
            }
            return false;
        }
        private void OnShowStudent(object obj)
        {
            var items = DateBase.Context().GetInfoStudents(SelectedGroup);
            foreach(var item in items)
            {
                CollectionStudent.Add(item);
            }
        }

        public ICommand CreateAttendance { get; set; }
        private bool CanCreateAttendance(object obj)
        {
            if (SelectedStudent != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void OnCreateAttendance(object obj)
        {
            if (SelectedDisceplini != null && SelectedStudent != null && SelectedDateTime != null)
            {
                DateBase.Context().CreatePoseshaemost(SelectedStudent, SelectedDisceplini, obj.ToString(), SelectedDateTime);
            }
        }

        public ICommand DeletedAttendancne { get; set; }
        private bool CanDeletedAttendancne(object obj) => true;
        private void OnDeletedAttendancne(object obj)
        {

        }

        public ICommand ShowWindowEditingAttendance { get; set; }
        private bool CanShowWindowEditingAttendance(object obj) => true;
        private void OnShowWindowEditingAttendance(object obj)
        {

        }
    }
}
