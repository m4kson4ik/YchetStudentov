using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
using YchetStudentov.Infostraction.Commands.Base;

namespace YchetStudentov.VM.ViewModelTeachers
{
    public class VMTeachers : INotifyPropertyChanged
    {
        public delegate void ShowWindow();
        public VMTeachers()
        {
            DeletedTeacherCommand = new LambdaCommand(OnDeletedTeacherCommand, CanDeletedTeacherCommand);
            NewItemTeachers = new LambdaCommand(OnNewItemTeachers, CanNewItemTeachers);
            EditingTeachersCommand = new LambdaCommand(OnEditingTeachersCommand, CanEditingTeachersCommand);
            ArrayPrepodovateli = new ObservableCollection<Prepodovateli>(DateBase.Context().FillingInTheTeachersTable());
            ExportAllTeachers = new LambdaCommand(OnExportAllTeachers, CanExportAllTeachers);
        }
        public delegate void ShowMessage(string message);

        public ObservableCollection<Prepodovateli> ArrayPrepodovateli { get;}

        private static Prepodovateli? prepodovatelisSelectedItem;
        public static Prepodovateli? PrepodovatelisSelectedItem
        {
            get { return prepodovatelisSelectedItem; }
            set
            {
                prepodovatelisSelectedItem = value;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnProperyChanged(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }

        #region Кнопка Создания Нового Преподователя
        public ICommand NewItemTeachers { get; }
        public event ShowWindow? ShowWindowCreateTeacherEvent;
        private bool CanNewItemTeachers(object p) => true;

        private void OnNewItemTeachers(object p)
        {
            ShowWindowCreateTeacherEvent?.Invoke();
        }
        #endregion
        public ICommand ExportAllTeachers { get; }
        private bool CanExportAllTeachers(object p) => true;

        private void OnExportAllTeachers(object p)
        {
            Files.Context().ExportAllTeachers();
        }
        #region Меню
        #region Кнопка Удаление Преподователя
        public event ShowMessage? ShowMessageEvent;

        public ICommand ShowMessageCommand { get; }
        public ICommand DeletedTeacherCommand { get; }

        private bool CanDeletedTeacherCommand(object p)
        {
            if (PrepodovatelisSelectedItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OnDeletedTeacherCommand(object p)
        {           
                if (PrepodovatelisSelectedItem != null)
                {
                    if (DateBase.Context().DeleteTeacher(PrepodovatelisSelectedItem))
                    {
                        this.ShowMessageEvent?.Invoke($"Удаление преподавателя {PrepodovatelisSelectedItem.Name} {PrepodovatelisSelectedItem.Family} {PrepodovatelisSelectedItem.Otchestvo}");
                        ArrayPrepodovateli.Remove(PrepodovatelisSelectedItem);
                    }
                    else
                    {
                        this.ShowMessageEvent?.Invoke($"Произошла ошибка при удалении преподавателя!");
                    }
                }
        }
        #endregion

        #region Меню редактирования преподователя
        public ICommand EditingTeachersCommand { get; }
        public event ShowWindow? ShowWindowEditingEvent;
        private bool CanEditingTeachersCommand(object p)
        {
            if (PrepodovatelisSelectedItem != null)
            {
                return true;
            }
            return false;
        }
        private void OnEditingTeachersCommand(object p)
        {
            ShowWindowEditingEvent?.Invoke();
        }
        #endregion
        #endregion
    }
}
