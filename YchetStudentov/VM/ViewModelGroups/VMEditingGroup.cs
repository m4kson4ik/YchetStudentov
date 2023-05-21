using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YchetStudentov.Class;
using YchetStudentov.Infostraction.Commands;
using YchetStudentov.VM.ViewModelDisciplins;

namespace YchetStudentov.VM.ViewModelGroups
{
    internal class VMEditingGroup : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChange(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }
        public VMEditingGroup()
        {
            SelectedItem = VMGroups.SelectedGroup;
            EditingAGroupCommand = new LambdaCommand(CanEditingAGroupCommand, OnEditingAGroupCommand);
        }

        public Group? SelectedItem { get; set; }
        public delegate void ShowMessage(string message);
        public event ShowMessage? ShowMessageEvent;
        public ICommand EditingAGroupCommand { get; set; }
        private bool OnEditingAGroupCommand(object? parametres)
        {
            if (SelectedItem.NumberGroup != null && SelectedItem.NumberSpec != null && SelectedItem.NameSpec != null)
            {
                return true;
            }
            return false;
        }
        private void CanEditingAGroupCommand(object? parametres)
        {
            DateBase.Context().EditingGroup(SelectedItem);
            ShowMessageEvent?.Invoke("Группа успешно отредактирована!");
        }
    }
}
