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
        public delegate void ShowWindow();
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChange(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }
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
            ReportingGroupCommand = new LambdaCommand(OnReportingGroupCommand, CanReportingGroupCommand);
            ExportGroupCommand = new LambdaCommand(OnExportAllGroupCommand, CanExportAllGroupCommand);
        }

        #region Кнопка открытие формы Создания Группы
        public event ShowWindow? ShowWindowCreateGroupEvent;
        public ICommand CreateGroupWindowCommand { get; set; }
        private bool CanCreateGroupWindowCommand(object? parametr) => true;
        private void OnCreateGroupWindowCommand(object? parametr)
        {
            if(SelectedGroup != null)
            {
                ShowWindowCreateGroupEvent?.Invoke();
            }
        }
        #endregion

        #region Кнопка открытия формы Редактирование группы
        public event ShowWindow? ShowWindowEditingGroupEvent;
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
            if (SelectedGroup != null)
            {
                ShowWindowEditingGroupEvent?.Invoke();
            }
        }
        #endregion

        #region Кнопка удаления группы
        public delegate void ShowMessage(string message);
        public event ShowMessage? ShowMessageDeletedEvent;
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
            if (SelectedGroup != null)
            {
                ShowMessageDeletedEvent?.Invoke($"Группа {SelectedGroup.NumberGroup} успешно удалена!");
                DateBase.Context().DeletedGroup(SelectedGroup);
            }
        }

        #endregion
        public event ShowWindow? ShowWindowReportingGroupEvent;

        public ICommand ReportingGroupCommand { get; set; }
        private bool CanReportingGroupCommand(object? parametr)
        {
            if (SelectedGroup != null && SelectedGroup.KolvoStudent != 0)
            {
                return true;
            }
            return false;
        }
        private void OnReportingGroupCommand(object? parametr)
        {
            ShowWindowReportingGroupEvent?.Invoke();
        }

        public ICommand ExportGroupCommand { get; set; }
        private bool CanExportAllGroupCommand(object? parametr)
        {
            return true;
        }
        private void OnExportAllGroupCommand(object? parametr)
        {
            Files.Context().ExportAllGroup();
        }
    }
}
