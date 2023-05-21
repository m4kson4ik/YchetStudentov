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

namespace YchetStudentov.VM.ViewModelGroups
{
    internal class VMCreateGroup : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChange(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }
        public Group NewItemGroups { get; set; }
        public VMCreateGroup()
        {
            NewItemGroups = new Group();
            CreateGroupsCommand = new LambdaCommand(CanCreateGroupsCommand, OnCreateGroupsCommand);
        }
        public delegate void ShowMessage(string message);
        public event ShowMessage? ShowMessageEvent;
        public ICommand CreateGroupsCommand { get; set; }
        private bool OnCreateGroupsCommand(object? parametres)
        {
            if (NewItemGroups.NumberGroup != " " && NewItemGroups.NumberSpec != " " && NewItemGroups.NameSpec != " ")
            {
                return true;
            }
            return false;
        }
        private void CanCreateGroupsCommand(object? parametres)
        {
            DateBase.Context().CreateGroup(NewItemGroups);
            ShowMessageEvent?.Invoke($"Группа {NewItemGroups.NumberGroup} успешно создана!");
        }

    }
}
