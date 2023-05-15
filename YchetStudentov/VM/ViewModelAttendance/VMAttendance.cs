using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YchetStudentov.Class;

namespace YchetStudentov.VM.ViewModelAttendance
{
    public class VMAttendance : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Class.Group> CollectionGroup { get; set; }
        public ObservableCollection<Class.UchebPlan> CollectionDistceplini { get; set; }
        public ObservableCollection<Class.Student> CollectionStudent { get; set; }
        public VMAttendance()
        {
            CollectionGroup = new ObservableCollection<Group>(DateBase.Context().GetAllInfoGroup());
            CollectionDistceplini = new ObservableCollection<UchebPlan>();
            CollectionStudent = new ObservableCollection<Class.Student>();
        }
        private Distceplini _selectedDistceplini { get; set; }
        public Distceplini SelectedDisceplini
        {
            get { return _selectedDistceplini; }
            set
            {
                _selectedDistceplini = value;
            }
        }
        private Group _selectedGroup { get; set; }
        public Group SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                _selectedGroup = value;
                CollectionDistceplini.Clear();
                var items = DateBase.Context().DataGridGetCurriculum(value);
                foreach(var item in items)
                {
                    CollectionDistceplini.Add(item);
                }
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
