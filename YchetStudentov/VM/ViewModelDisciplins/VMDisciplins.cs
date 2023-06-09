﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YchetStudentov.Class;
using YchetStudentov.Form;
using YchetStudentov.Infostraction.Commands;

namespace YchetStudentov.VM.ViewModelDisciplins
{
    public class VMDisciplins : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        #region Открытие формы
        public delegate void ShowWindow();
        public event ShowWindow? ShowWindowEvent;
        public event ShowWindow? ShowWindowEditingEvent;

        public ICommand ShowWindowEditingCommand { get; } // Команда открытия формы Редактирования дисциплины
        public bool CanShowWindowCommand(object? parameter) => true;
        public void OnShowWindowCommand(object? parameter)
        {
            ShowWindowEditingEvent?.Invoke();
        }

        public ICommand ShowWindowCreateCommand { get; } // Команда открытия формы Создание Дисциплины
        public bool CanShowWindowCreateCommand(object? parameter) => true;
        public void OnShowWindowCreateCommand(object? parameter)
        {
            ShowWindowEvent?.Invoke();
        }
        #endregion

        public VMDisciplins()
        {
            Distceplinis = new ObservableCollection<Distceplini>(DateBase.Context().GetDataGridDiscipline());
            ShowWindowEditingCommand = new LambdaCommand(OnShowWindowCommand, CanShowWindowCommand);
            ShowWindowCreateCommand = new LambdaCommand(OnShowWindowCreateCommand, CanShowWindowCreateCommand);
            DeletedDisceplinsCommand = new LambdaCommand(OnDeletedDisceplinsCommand, CanDeletedDisceplinsCommand);
            ExportAllDisciplins = new LambdaCommand(OnExportAllDisciplins, CanExportAllDisciplins);
        }

        public void OnPropertyChange(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }

        public ObservableCollection<Distceplini>? Distceplinis { get; private set; }

        private static Distceplini? _selectedDistcilins;
        public static Distceplini? SelectedDistcilins
        {
            get => _selectedDistcilins;
            set
            {
                _selectedDistcilins = value;
            }
        }
        public delegate void ShowMessage(string message);

        public event ShowMessage? ShowMessageEvent;
        public ICommand DeletedDisceplinsCommand { get; set; }
        public bool CanDeletedDisceplinsCommand(object? parameter)
        {
            if (SelectedDistcilins != null)
            {
                return true;
            }
            return false;
        }
        public void OnDeletedDisceplinsCommand(object? parameter)
        {
            if (SelectedDistcilins != null && Distceplinis != null)
            {
                DateBase.Context().DeleteDiscipline(SelectedDistcilins);
                ShowMessageEvent?.Invoke($"Дисциплина {SelectedDistcilins.NameDisciplini} успешно удалена!");
                Distceplinis.Remove(SelectedDistcilins);
            }
        }
        public ICommand ExportAllDisciplins { get; set; }
        public bool CanExportAllDisciplins(object? parameter)
        {
            return true;
        }
        public void OnExportAllDisciplins(object? parameter)
        {
            
        }
    }
}
