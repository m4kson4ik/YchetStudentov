using MaterialDesignThemes.Wpf;
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
        public void OnPropertyChange(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }
        public Class.Student NewItemStudent { get; set; }
        public ObservableCollection<string> Budget { get; set; }
        public ObservableCollection<string> Gragdanstvo { get; set; }
        public ObservableCollection<string> YearPostup { get; set; }
        public VMCreateStudent()
        {
            NewItemStudent = new Class.Student();
            CollectionGroup = new ObservableCollection<Class.Group>(DateBase.Context().GetAllInfoGroup());
            CreateStudentCommand = new LambdaCommand(OnCreateStudentCommand, CanCreateStudentCommand);
            Budget = new ObservableCollection<string>(new string[] { "Да", "Нет" });
            Gragdanstvo = new ObservableCollection<string>(new string[] { "Российское", });
            YearPostup = new ObservableCollection<string>(new string[] { "2017", "2018", "2019", "2020", "2021", "2022", "2023" });
        }
        public ObservableCollection<Class.Group> CollectionGroup { get; set; }
        public ICommand CreateStudentCommand { get; set; }
        
        private bool CanCreateStudentCommand(object obj)
        {
            if (!string.IsNullOrEmpty(NewItemStudent.Name) && !string.IsNullOrEmpty(NewItemStudent.Family) && !string.IsNullOrEmpty(NewItemStudent.Email) && !string.IsNullOrEmpty(NewItemStudent.Adress) && !string.IsNullOrEmpty(NewItemStudent.Budget) && !string.IsNullOrEmpty(NewItemStudent.GodPostuplenie.ToString()) && !string.IsNullOrEmpty(NewItemStudent.NumberGroup) && !string.IsNullOrEmpty(NewItemStudent.NumberZachetki.ToString()))
            {
                return true;
            }
            return false;
        }
        public delegate void ShowMessage(string message);
        public event ShowMessage? ShowMessageEvent;
        private void OnCreateStudentCommand(object obj)
        {
            if(DateBase.Context().AddItemStudent(NewItemStudent))
            {
                ShowMessageEvent?.Invoke($"Преподаватель {NewItemStudent.fio} был успешно создан!");
            }
            else
            {
                ShowMessageEvent?.Invoke($"Ошибка при создании преподавателя!");
            }
        }
    }
}
