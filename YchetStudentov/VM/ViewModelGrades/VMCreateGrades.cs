using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YchetStudentov.Infostraction.Commands;

namespace YchetStudentov.VM.ViewModelGrades
{
    public class VMCreateGrades : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Class.Group> CollectionGroup { get; set; }
        public ObservableCollection<Class.Student> CollectionStudent { get; set; } = new ObservableCollection<Class.Student>();
        public ObservableCollection<Class.UchebPlan> CollectionUchebPlan { get; set; } = new ObservableCollection<Class.UchebPlan>();
        public ObservableCollection<string> Grades { get; set; }
        public VMCreateGrades()
        {
            Grades = new ObservableCollection<string>{ "5", "4", "3", "2", "н/я"};
            CollectionGroup = new ObservableCollection<Class.Group>(DateBase.Context().GetAllInfoGroup());
            CreateGradesCommand = new LambdaCommand(OnCreateGradesCommand, CanCreateGradesCommand);
            OpenWindowViewGrades = new LambdaCommand(OnOpenWindowViewGrades, CanOpenWindowViewGrades);
        }
        public void OnPropertyChange(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }
        private Class.Group? _selectedGroup;
        public Class.Group? SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                if (value != null)
                {
                    _selectedGroup = value;
                    OnPropertyChange("SelectedGroup");
                    var items = DateBase.Context().DataGridGetCurriculum(value);
                    CollectionUchebPlan.Clear();
                    foreach(var item in items)
                    {
                        CollectionUchebPlan.Add(item);
                    }
                }
            }
        }
        private Class.UchebPlan? _selectedUchebPlan;
        public Class.UchebPlan? SelectedUchebPlan
        {
            get { return _selectedUchebPlan; }
            set
            {
                    OnPropertyChange("SelectedUchebPlan");
                    _selectedUchebPlan = value;
                if(SelectedGroup != null)
                {
                    CollectionStudent.Clear();
                    var items = DateBase.Context().GetInfoStudents(SelectedGroup);
                    foreach(var item in items)
                    {
                        CollectionStudent.Add(item);
                    }

                }
            }
        }
        private Class.Student? _selectedStudent;
        public Class.Student? SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChange("SelectedStudent");
            }
        }
        private string? _selectedGrades;
        public string? SelectedGrades
        {
            get{ return _selectedGrades; }
            set
            {
                _selectedGrades = value;
            }
        }
        public ICommand CreateGradesCommand { get; set; }
        private bool CanCreateGradesCommand(object obj)
        {
            if (SelectedStudent != null && SelectedUchebPlan != null && SelectedGroup != null && SelectedGrades != null)
            {
                return true;
            }
            return false;
        }
        private void OnCreateGradesCommand(object obj)
        {
            if (SelectedUchebPlan != null && SelectedGrades != null && SelectedStudent != null)
            {
                DateBase.Context().CreateARating(SelectedStudent, GetSemestr(), SelectedGrades , SelectedUchebPlan);
            }
        }
        public int GetSemestr()
        {
          int[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
          if (SelectedStudent != null && SelectedStudent.NumberGroup != null)
          {
              string group = SelectedStudent.NumberGroup;
              foreach (char item in group)
              {
                  for (int i = 0; i < group.Length; i++)
                  {
                      if (item == arr[i])
                      {
                          int grou;
                          DateTime dateTime = new DateTime(2023, 01, 01);
                          if (DateTime.Today >= dateTime)
                          {
                              grou = i * 2;
                          }
                          else
                          {
                              grou = i * 2 - 1;
                          }
                          return grou;
                      }
                  }
              }
          }
          return 0;      
        }

        public delegate void ShowWindow();
        public event ShowWindow? ShowWindowViewGrades;
        public ICommand OpenWindowViewGrades { get; set; }
        private bool CanOpenWindowViewGrades(object obj) => true;
        private void OnOpenWindowViewGrades(object obj)
        {
            ShowWindowViewGrades?.Invoke();
        }
    }
}
