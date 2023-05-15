using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YchetStudentov.Infostraction.Commands;

namespace YchetStudentov.VM.ViewModelStudents
{
    public class VMEditingStudent : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public Class.Student? SelectedStudent { get; set; }
        public ObservableCollection<Class.Group> CollectionGroup { get; set; }
        public VMEditingStudent()
        {
            SelectedStudent = VMStudents.SelectedStudent;
            CollectionGroup = new ObservableCollection<Class.Group>(DateBase.Context().GetAllInfoGroup());
            EditingStudentCommand = new LambdaCommand(OnEditingStudentCommand, CanEditingStudentCommand);
            Budget = new ObservableCollection<string>(new string[] { "Да", "Нет" });
            Gragdanstvo = new ObservableCollection<string>(new string[] {"Российское",  });
            YearPostup = new ObservableCollection<string>(new string[] {"2017", "2018", "2019", "2020", "2021", "2022", "2023" });
        }

        public ObservableCollection<string> Budget { get; set; }
        public ObservableCollection<string> Gragdanstvo { get; set; }
        public ObservableCollection<string> YearPostup { get; set; }
        public ICommand EditingStudentCommand { get; set; }
        private bool CanEditingStudentCommand(object obj)
        {
            return true;
        }
        private void OnEditingStudentCommand(object obj)
        {

        }
    }
}
