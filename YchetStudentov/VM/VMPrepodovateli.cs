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

namespace YchetStudentov.VM
{
    public class VMPrepodovateli : INotifyPropertyChanged
    {
        public VMPrepodovateli()
        {
            DeletedTeacherCommand = new LambdaCommand(OnDeletedTeacherCommand, CanDeletedTeacherCommand);
            NewItemTeachers = new LambdaCommand(OnNewItemTeachers, CanNewItemTeachers);
            EditingTeachersCommand = new LambdaCommand(OnEditingTeachersCommand, CanEditingTeachersCommand);
            ArrayPrepodovateli = new ObservableCollection<Prepodovateli>(DateBase.Context().FillingInTheTeachersTable());
        }

        public ObservableCollection<Prepodovateli> ArrayPrepodovateli { get; private set; }
        private Prepodovateli? prepodovatelisSelectedItem;
        public Prepodovateli? PrepodovatelisSelectedItem
        {
            get { return prepodovatelisSelectedItem; }
            set 
            {
                prepodovatelisSelectedItem = value;
                OnProperyChanged("PrepodovatelisSelectedItem");
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

        #region Кнопка Удаление Преподователя
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
            if (MessageBox.Show($"Вы уверены что хотите удалить преподователя {prepodovatelisSelectedItem?.fio}?", "Удаление преподователя",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (PrepodovatelisSelectedItem != null)
                {
                    if (DateBase.Context().DeleteTeacher(PrepodovatelisSelectedItem))
                    {
                        ArrayPrepodovateli.Remove(PrepodovatelisSelectedItem);
                        OnProperyChanged("OnDeletedTeacherCommand");
                        MessageBox.Show("Преподователь был успешно удален!");
                    }
                    else
                    {
                        MessageBox.Show("Произошла ошибка при удаление преподователя!");
                    }
                }
            }
        }
        #endregion

        #region Кнопка Создания Нового Преподователя

        public ICommand NewItemTeachers { get; }
        private bool CanNewItemTeachers(object p) => true;

        private void OnNewItemTeachers(object p)
        {
            CreateTeacher createTeacher = new CreateTeacher(new Prepodovateli());
            if (createTeacher.ShowDialog() == true)
            {
                ArrayPrepodovateli.Add(createTeacher.prepodovateli);
                Random random = new Random();
                createTeacher.prepodovateli.Login = random.Next(1, 1000);
                createTeacher.prepodovateli.Password = random.Next(1, 1000000000).ToString();
                DateBase.Context().CreateTeacher(createTeacher.prepodovateli);
            }
        }
        #endregion


        #region Меню редактирования преподователя
        public ICommand EditingTeachersCommand { get; }

        private bool CanEditingTeachersCommand(object p)
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

        private void OnEditingTeachersCommand(object p)
        {
           if (prepodovatelisSelectedItem != null)
           {
               EditTeacher editTeacher = new EditTeacher(prepodovatelisSelectedItem);
               if (editTeacher.ShowDialog() == true)
               {
                   DateBase.Context().EditTeacher(PrepodovatelisSelectedItem);
               }
           }
        }
        #endregion
    }
}
