using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YchetStudentov.Form;
using YchetStudentov.Infostraction.Commands;

namespace YchetStudentov.VM
{
    internal class VMEditingTeacher : INotifyPropertyChanged
    {
        public VMEditingTeacher()
        {
            SaveChanged = new LambdaCommand(OnSaveChanged, CanSaveChanged);
        }

        public ICommand SaveChanged { get; }

        private bool CanSaveChanged(object p) => true;

        private void OnSaveChanged(object p)
        {
            OnPropertyChange("SaveChanged");
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChange(string names)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(names));
        }
    }
}
