﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YchetStudentov.Class;
using YchetStudentov.Infostraction.Commands;

namespace YchetStudentov.VM.ViewModelTeachers
{
    public class VMCreateTeacher : INotifyPropertyChanged
    {
        public Prepodovateli NewPrepodovatel { get; set; }
        public delegate void ShowMessage(string message);
        private Prepodovateli _newPerpodovatel
        {
            get => _newPerpodovatel;
            set
            {
                _newPerpodovatel = value;
                OnPropertyChange("NewItemPrepodovatel");
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChange(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }
        public VMCreateTeacher()
        {
            NewPrepodovatel = new Prepodovateli();
            CreateTeacherCommand = new LambdaCommand(OnCreateTeacherCommnad, CanCreateTeacherCommand); 
        }
        public ICommand CreateTeacherCommand { get; }

        public bool CanCreateTeacherCommand(object? parameter)
        {
            if (!string.IsNullOrEmpty(NewPrepodovatel.Family) && !string.IsNullOrEmpty(NewPrepodovatel.Name) && !string.IsNullOrEmpty(NewPrepodovatel.Otchestvo))
            {
                return true;
            }
            return false;
        }
        public event ShowMessage? ShowMessageEvent;

        public void OnCreateTeacherCommnad(object? parameter)
        {

            if (DateBase.Context().CreateTeacher(NewPrepodovatel))
            {
                this.ShowMessageEvent?.Invoke($"Преподаватель {NewPrepodovatel.fio} успешно создан!");
            }
            else
            {
                this.ShowMessageEvent?.Invoke($"Произошла ошибка при создании преподавателя!");
            }
        }
    }
}
