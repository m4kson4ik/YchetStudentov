using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YchetStudentov.Infostraction.Commands;

namespace YchetStudentov.VM.ViewModelStudents
{
    public class VMCreateStudent : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public Class.Student NewItemStudent { get; set; }
        public VMCreateStudent()
        {
            NewItemStudent = new Class.Student();
            CollectionGroup = new ObservableCollection<Class.Group>(DateBase.Context().GetAllInfoGroup());
            CreateStudentCommand = new LambdaCommand(OnCreateStudentCommand, CanCreateStudentCommand);
        }
        public ObservableCollection<Class.Group> CollectionGroup { get; set; }
        public ICommand CreateStudentCommand { get; set; }
        
        private bool CanCreateStudentCommand(object obj)
        {
            if (!string.IsNullOrEmpty(NewItemStudent.Name) && !string.IsNullOrEmpty(NewItemStudent.Family) && !string.IsNullOrEmpty(NewItemStudent.Email) && !string.IsNullOrEmpty(NewItemStudent.Adress))
            {
                return true;
            }
            return false;
        }

        private void OnCreateStudentCommand(object obj)
        {
            NewItemStudent.NumberZachetki = 1212121;
            DateBase.Context().AddItemStudent(NewItemStudent);
        }
    }
}
