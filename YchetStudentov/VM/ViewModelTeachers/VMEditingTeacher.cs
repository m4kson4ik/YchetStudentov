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
            
            if (SelectedTeacher != null && SelectedTeacher.Family != "" && SelectedTeacher.Name != "" && SelectedTeacher.Otchestvo != "")
            {
                return true;
            }
            return false;
        }
        public delegate void ShowMessage(string message);

        public event ShowMessage? ShowMessageEvent;

        private void OnSaveChanged(object p)
        {
            if (SelectedTeacher != null)
            {
                if(DateBase.Context().EditTeacher(SelectedTeacher))
                {
                    this.ShowMessageEvent?.Invoke("Изменения успешно внесены!");
                }
                else
                {
                    this.ShowMessageEvent?.Invoke("Произошла ошибка при изменение преподавателя!");
                }
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

    }
}
