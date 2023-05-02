using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YchetStudentov.Class;

namespace YchetStudentov.VM
{
    public class VMDisciplins : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChange(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }

        public ObservableCollection<Distceplini>? Distceplinis { get; private set; }

        private Distceplini? _selectedDistcilins;
        public Distceplini? SelectedDistcilins
        {
            get => _selectedDistcilins;
            set
            {
                _selectedDistcilins = value;
                MessageBox.Show(_selectedDistcilins?.FormaAttest);
                OnPropertyChange("SelectdeDisciplis");
            }
        }
        public VMDisciplins()
        {
            Distceplinis = new ObservableCollection<Distceplini>(DateBase.Context().GetDataGridDiscipline()); 
        }
    }
}
