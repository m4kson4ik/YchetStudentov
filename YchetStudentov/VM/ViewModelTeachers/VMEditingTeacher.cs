using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YchetStudentov.Class;
using YchetStudentov.Form;
using YchetStudentov.Infostraction.Commands;

namespace YchetStudentov.VM.ViewModelTeachers
{
    internal class VMEditingTeacher : INotifyPropertyChanged
    {
        public Prepodovateli? SelectedTeacher { get; set; }
        public VMEditingTeacher()
        {
            SelectedTeacher = VMTeachers.PrepodovatelisSelectedItem;
            SaveChanged = new LambdaCommand(OnSaveChanged, CanSaveChanged);
        }

        public ICommand SaveChanged { get; }

        private bool CanSaveChanged(object p)
        {
            if (SelectedTeacher.Family != "" && SelectedTeacher.Name != "" && SelectedTeacher.Otchestvo != "")
            {
                return true;
            }
            return false;
        }

        private void OnSaveChanged(object p)
        {
            DateBase.Context().EditTeacher(SelectedTeacher);
            OnPropertyChange("SaveChanged");
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChange(string names)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(names));
        }
    }
}
