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

namespace YchetStudentov.VM.ViewModelGroups
{
    public class VMGroups : INotifyPropertyChanged
    {
        public delegate void ShowWindow(Group group);
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Group> ItemsGroup { get; private set; }
        private static Group? _selectedGroup { get; set; }
        public static Group? SelectedGroup
        {
            get { return _selectedGroup; }
            set { _selectedGroup = value; }
        }
        public VMGroups()
        {
            ItemsGroup = new ObservableCollection<Group>(DateBase.Context().GetAllInfoGroup());
            CreateGroupWindowCommand = new LambdaCommand(OnCreateGroupWindowCommand, CanCreateGroupWindowCommand);
            EditingGroupWindowCommand = new LambdaCommand(OnEditingGroupWindowCommand, CanEditingGroupWindowCommand);
            DeletedGroupCommand = new LambdaCommand(OnDeletedGroupCommand, CanDeletedGroupCommand);
        }

        #region Кнопка открытие формы Создания Группы
        public event ShowWindow ShowWindowCreateGroupEvent;
        public ICommand CreateGroupWindowCommand { get; set; }
        private bool CanCreateGroupWindowCommand(object? parametr) => true;
        private void OnCreateGroupWindowCommand(object? parametr)
        {
            ShowWindowCreateGroupEvent?.Invoke(SelectedGroup);
        }
        #endregion

        #region Кнопка открытия формы Редактирование группы
        public event ShowWindow ShowWindowEditingGroupEvent;
        public ICommand EditingGroupWindowCommand { get; set; }
        private bool CanEditingGroupWindowCommand(object? parametr)
        {
            if (SelectedGroup != null)
            {
                return true;
            }
            return false;
        }
        private void OnEditingGroupWindowCommand(object? parametr)
        {
            ShowWindowEditingGroupEvent?.Invoke(SelectedGroup);
        }
        #endregion

        #region Кнопка удаления группы
        public ICommand DeletedGroupCommand { get; set; }
        private bool CanDeletedGroupCommand(object? parametr)
        {
            if (SelectedGroup != null)
            {
                return true;
            }
            return false;
        }
        private void OnDeletedGroupCommand(object? parametr)
        {
            DateBase.Context().DeletedGroup(SelectedGroup);
        }
        #endregion
    }
}
