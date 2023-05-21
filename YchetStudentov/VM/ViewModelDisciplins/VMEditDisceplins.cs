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
using YchetStudentov.Models;
using Distceplini = YchetStudentov.Class.Distceplini;

namespace YchetStudentov.VM.ViewModelDisciplins
{
    internal class VMEditDisceplins : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChange(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }
        public ObservableCollection<Class.Prepodovateli> Prepodovatelis { get; private set; }
        public ObservableCollection<Distceplini> Distceplinis { get; private set; }
        public Distceplini? DisciplineInSelected { get; private set; }
        public ObservableCollection<string> CollectionFormaAttest { get; private set; }
        
        public VMEditDisceplins()
        {
            DisciplineInSelected = VMDisciplins.SelectedDistcilins;
            EditingDisceplinsCommand = new LambdaCommand(Execute, CanExecute);
            Prepodovatelis = new ObservableCollection<Class.Prepodovateli>(DateBase.Context().FillingInTheTeachersTable());
            Distceplinis = new ObservableCollection<Distceplini>(DateBase.Context().GetDataGridDiscipline());
            CollectionFormaAttest = new ObservableCollection<string> { "Экзамен", "Зачет", "Деффер.зачет", "Курсовой проект", "Курсовая работа", "Контрольная работа" };
        }
        public delegate void ShowMessage(string message);

        public event ShowMessage? ShowMessageEvent;
        public ICommand EditingDisceplinsCommand { get; set; }
        public bool CanExecute(object? parameter)
        {
            if (DisciplineInSelected.FormaAttest != "" && DisciplineInSelected.NameDisciplini != "" && DisciplineInSelected.Login != 0)
            {
                return true;
            }
            return false;
        }
        public void Execute(object? parameter)
        {
            if (DisciplineInSelected != null)
            {
                ShowMessageEvent?.Invoke("Дисциплина успешно отредактирована!");
                DateBase.Context().EditDiscipline(DisciplineInSelected);
            }
        }
    }
}
