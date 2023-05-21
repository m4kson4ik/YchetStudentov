using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YchetStudentov.Class;
using YchetStudentov.Infostraction.Commands;

namespace YchetStudentov.VM.ViewModelStudents
{
    public class VMStudents : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnProperyChanged(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }

        public ObservableCollection<Class.Group> CollectionGroup { get; set; }
        public ObservableCollection<Class.Student> CollectionStudent { get; set; }
        public VMStudents()
        {
            CollectionGroup = new ObservableCollection<Class.Group>(DateBase.Context().GetAllInfoGroup());
            CollectionStudent = new ObservableCollection<Student>();
            CreateStudentCommand = new LambdaCommand(OnCreateStudentCommand, CanCreateStudentCommand);
            EditingStudentCommand = new LambdaCommand(OnEditingStudentCommand, CanEditingStudentCommand);
            DeletedStudentCommand = new LambdaCommand(OnDeletedStudentCommand, CanDeletedStudentCommand);
            PoseshaemostStudentCommand = new LambdaCommand(OnPoseshaemostStudentCommand, CanPoseshaemostStudentCommand);
            ExportSelectedGroupStudentCommand = new LambdaCommand(OnExportSelectedGroupStudentCommand, CanExportSelectedGroupStudentCommand);
            MessageInfoStudentCommand = new LambdaCommand(OnMessageInfoStudentCommand, CanMessageInfoStudentCommand);
        }

        private static Student? _selectedStudent;
        public static Student? SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
            }
        }

        private Group? _selectedGroup;
        public Group? SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                if (value != null)
                {
                    _selectedGroup = value;
                    CollectionStudent.Clear();
                    var items = DateBase.Context().GetInfoStudents(_selectedGroup);
                    foreach (var item in items)
                    {
                        CollectionStudent.Add(item);
                    }
                }
            }
        }

        #region Команды
        public delegate void ShowWindow();
        public event ShowWindow? ShowWindowCreateStudent;
        public event ShowWindow? ShowWindowEditingStudent;
        public event ShowWindow? ShowWindowAttendaceStudent;

        public ICommand CreateStudentCommand { get; set; }
        private bool CanCreateStudentCommand(object obj) => true;
        private void OnCreateStudentCommand(object obj)
        {
            ShowWindowCreateStudent?.Invoke();
        }
        public ICommand ExportSelectedGroupStudentCommand { get; set; }
        private bool CanExportSelectedGroupStudentCommand(object obj)
        {
            if (SelectedGroup != null)
            {
                return true;
            }
            return false;
        }
        private void OnExportSelectedGroupStudentCommand(object obj)
        {
            Files.Context().ExportStudentSelectedGroup(SelectedGroup);
        }
        public ICommand EditingStudentCommand { get; set; }
        private bool CanEditingStudentCommand(object obj)
        {
            if (SelectedStudent != null)
            {
                return true;
            }
            return false;
        }
        private void OnEditingStudentCommand(object obj)
        {
            ShowWindowEditingStudent?.Invoke();
        }
        public delegate void ShowMessage(string message);
        public event ShowMessage? ShowMessageDeletedEvent;

        public ICommand DeletedStudentCommand { get; set; }
        private bool CanDeletedStudentCommand(object obj)
        {
            if (SelectedStudent != null)
            {
                return true;
            }
            return false;
        }
        private void OnDeletedStudentCommand(object obj)
        {
            if (SelectedStudent != null)
            {
                ShowMessageDeletedEvent?.Invoke($"Студент {SelectedStudent.fio} успешно удален!");
                DateBase.Context().DeletedItemStudent(SelectedStudent);
            }
        }
        public event ShowMessage? ShowMessageInfoStudentEvent;

        public ICommand MessageInfoStudentCommand { get; set; }
        private bool CanMessageInfoStudentCommand(object obj)
        {
            if (SelectedStudent != null)
            {
                return true;
            }
            return false;
        }
        private void OnMessageInfoStudentCommand(object obj)
        {
            ShowMessageInfoStudentEvent?.Invoke(DateBase.Context().GetAllInfoStudentInString(SelectedStudent));
        }
        public ICommand PoseshaemostStudentCommand { get; set; }
        private bool CanPoseshaemostStudentCommand(object obj)
        {
            if (SelectedStudent != null)
            {
                return true;
            }
            return false;
        }
        private void OnPoseshaemostStudentCommand(object obj)
        {
            ShowWindowAttendaceStudent?.Invoke();
        }
        #endregion
    }
}
