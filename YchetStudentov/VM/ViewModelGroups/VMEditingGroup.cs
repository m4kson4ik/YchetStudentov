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
        public VMEditingGroup()
        {
            SelectedItem = VMGroups.SelectedGroup;
            EditingAGroupCommand = new LambdaCommand(CanEditingAGroupCommand, OnEditingAGroupCommand);
        }

        public Group SelectedItem { get; set; }

        public ICommand EditingAGroupCommand { get; set; }
        private bool OnEditingAGroupCommand(object? parametres) => true;
        private void CanEditingAGroupCommand(object? parametres)
        {
            MessageBox.Show(SelectedItem.NameSpec);
        }
    }
}
