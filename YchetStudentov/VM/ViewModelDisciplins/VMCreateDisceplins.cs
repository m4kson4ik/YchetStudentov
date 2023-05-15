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

namespace YchetStudentov.VM.ViewModelDisciplins
{
    public class VMCreateDisceplins : INotifyPropertyChanged
    {
        public VMCreateDisceplins()
        {
            Prepodovatelis = new ObservableCollection<Prepodovateli>(DateBase.Context().FillingInTheTeachersTable());
            CreateADisciplinsCommand = new LambdaCommand(CanCreateADisciplinsCommand, OnCreateADisciplinsCommand);
            Distceplini = new Distceplini();
        }

        public Distceplini Distceplini { get; set; }
        public ObservableCollection<Prepodovateli> Prepodovatelis { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChange(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }

        private Prepodovateli? _selectedPrepodovatel;
        public Prepodovateli? SelectedPrepodovatel
        {
            get => _selectedPrepodovatel;
            set
            {
                _selectedPrepodovatel = value;
                OnPropertyChange("SelectedPrepod");
            }
        }

        public ICommand CreateADisciplinsCommand { get; }
        private bool OnCreateADisciplinsCommand(object p)
        {
            if (string.IsNullOrEmpty(Distceplini.NameDisciplini) || string.IsNullOrEmpty(Distceplini.FormaAttest) || SelectedPrepodovatel == null)
            {
                return false;
            }
            return true;
        }
        private void CanCreateADisciplinsCommand(object p)
        {
            DateBase.Context().CreateDiscipline(SelectedPrepodovatel, Distceplini);
        }

    }
}
