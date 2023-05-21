using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using YchetStudentov.Class;
using YchetStudentov.Infostraction.Commands;

namespace YchetStudentov.VM.ViewModelGrades
{
    public class VMViewGrades : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Class.Group> CollectionGroup { get; private set; }
        public ObservableCollection<Class.Student> CollectionStudent { get; private set; } = new ObservableCollection<Class.Student>();
        public ObservableCollection<Class.FinalGrades> CollectionFinalGrades { get; private set; } = new ObservableCollection<Class.FinalGrades>();
        public VMViewGrades()
        {
            CollectionGroup = new ObservableCollection<Class.Group>(DateBase.Context().GetAllInfoGroup());
            ExportGradesGroup = new LambdaCommand(OnExportGradesGroup, CanExportGradesGroup);
            ExportGradesStudent = new LambdaCommand(OnExportGradesStudent, CanExportGradesStudent);
        }

        private Class.Group _selectedGroup;
        public Class.Group SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                    _selectedGroup = value;
                    CollectionStudent.Clear();
                    CollectionFinalGrades.Clear();
                    var items = DateBase.Context().GetInfoStudents(_selectedGroup);
                    foreach(var item in items)
                    {
                        CollectionStudent.Add(item);
                    }
            }
        }

        private Class.Student _selectedStudent;
        public Class.Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                    _selectedStudent = value;
                    CollectionFinalGrades.Clear();
                if (_selectedStudent != null)
                {
                    var items = DateBase.Context().GetRatingAndSrPoseshaemost(_selectedStudent);
                    foreach(var item in items)
                    {
                        CollectionFinalGrades.Add(item);
                    }
                }
            }
        }


        public ICommand ExportGradesGroup { get; set; }
        private bool CanExportGradesGroup(object obj)
        {
            if (SelectedGroup != null)
            {
                return true;
            }
            return false;
        }
        private void OnExportGradesGroup(object obj)
        {
            Files.Context().ExportAllItogOzenkiGroup(SelectedGroup);
        }

        public ICommand ExportGradesStudent { get; set; }
        private bool CanExportGradesStudent(object obj)
        {
            if (SelectedStudent != null)
            {
                return true;
            }
            return false;
        }
        private void OnExportGradesStudent(object obj)
        {
            Files.Context().ExportAllItogOzenkiStudent(SelectedStudent);
        }
    }
}
