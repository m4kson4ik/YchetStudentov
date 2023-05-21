using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YchetStudentov.Class;
using YchetStudentov.Infostraction.Commands;

namespace YchetStudentov.VM.ViewModelSyllabus
{
    public class VMSyllabus : INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
        public delegate void ShowWindow();
        public ObservableCollection<UchebPlan> CollectionSyllabus { get; } = new ObservableCollection<UchebPlan>();
        public ObservableCollection<Group> CollectionGroupInComboBox { get; set; }

        public VMSyllabus()
        {
            CollectionGroupInComboBox = new ObservableCollection<Group>(DateBase.Context().GetAllInfoGroup());
            //CollectionSyllabus = new ObservableCollection<UchebPlan>();
            OpenWindowCreateSyllabusCommand = new LambdaCommand(OnOpenWindowCreateSyllabusCommand, CanOpenWindowCreateSyllabusCommand);
            PrintItemSyllabusCommand = new LambdaCommand(OnPrintItemSyllabusCommand, CanPrintItemSyllabusCommand);
            DeletedItemSyllabusCommand = new LambdaCommand(OnDeletedItemSyllabusCommandd, CanDeletedItemSyllabusCommand);
        }

        private Group? _selectedGroup { get; set; }
        public Group? SelectedGroup
        {
            get { return _selectedGroup; }
                set
                {
                if (value != null)
                {
                    _selectedGroup = value;
                    OnPropertyChanged("NumberGroup");
                    CollectionSyllabus.Clear();
                    var item = DateBase.Context().DataGridGetCurriculum(_selectedGroup);

                    foreach(var i in item)
                    {
                        CollectionSyllabus.Add(i);
                    }
                }
                }
        }

        private UchebPlan? _selectedSyllabus { get; set; }
        public UchebPlan? SelectedSyllabus
        {
            get { return _selectedSyllabus; }
            set
            {
                _selectedSyllabus = value;
                OnPropertyChanged("SelectedSyllabus");
            }
        }
        #region Команды
        public event ShowWindow? ShowWindowCreateSyllabusEvent;
        public ICommand OpenWindowCreateSyllabusCommand { get; set; }
        private bool CanOpenWindowCreateSyllabusCommand(object para) => true;
        private void OnOpenWindowCreateSyllabusCommand(object para)
        {
            ShowWindowCreateSyllabusEvent?.Invoke();
        }
        public delegate void ShowMessage(string message);

        public event ShowMessage? ShowMessageEvent;
        public ICommand DeletedItemSyllabusCommand { get; set; }
        private bool CanDeletedItemSyllabusCommand(object para)
        {
            if (SelectedSyllabus != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void OnDeletedItemSyllabusCommandd(object para)
        {
            if (SelectedSyllabus != null)
            {
                ShowMessageEvent?.Invoke("Учебный план успешно удален!");
                DateBase.Context().DeleteCurriculum(SelectedSyllabus);
                CollectionSyllabus.Remove(SelectedSyllabus);
            }
        }

        public ICommand PrintItemSyllabusCommand { get; set; }
        private bool CanPrintItemSyllabusCommand(object para)
        {
            if (SelectedGroup != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void OnPrintItemSyllabusCommand(object para)
        {
            Files.Context().ExportUchebPlan(SelectedGroup);
        }
        #endregion
    }
}
