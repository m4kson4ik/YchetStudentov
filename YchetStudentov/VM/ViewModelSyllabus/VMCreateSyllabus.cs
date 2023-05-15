using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YchetStudentov.Class;
using YchetStudentov.Infostraction.Commands;

namespace YchetStudentov.VM.ViewModelSyllabus
{
    public class VMCreateSyllabus : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private UchebPlan NewItemSyllabus { get; }
        public ObservableCollection<Class.Group> CollectionGroup {get;set;}
        public ObservableCollection<Class.Distceplini> CollectionDisceplini {get;set;}
        public VMCreateSyllabus()
        {
            CollectionGroup = new ObservableCollection<Class.Group>(DateBase.Context().GetAllInfoGroup());
            CollectionDisceplini = new ObservableCollection<Class.Distceplini>(DateBase.Context().GetDataGridDiscipline());
            CreateNewItemCommand = new LambdaCommand(OnCreateNewItemCommand, CanCreateNewItemCommand);
        }

        private Group _selectedGroup;
        public Group SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                _selectedGroup = value;
            }
        }
        private Distceplini _selectedDisciplini;
        public Distceplini SelectedDisciplini
        {
            get { return _selectedDisciplini; }
            set
            {
                _selectedDisciplini = value;
                //MessageBox.Show(_selectedDisciplini.NameDiscepliniAndFIO);
            }
        }

        public ICommand CreateNewItemCommand { get; set; }
        private bool CanCreateNewItemCommand(object p)
        {
            if (SelectedGroup != null && SelectedDisciplini != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void OnCreateNewItemCommand(object p)
        {
            DateBase.Context().CreateCurriculum(SelectedGroup, SelectedDisciplini);
        }
    }
}
