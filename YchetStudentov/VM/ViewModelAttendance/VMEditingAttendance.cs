using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YchetStudentov.Infostraction.Commands;

namespace YchetStudentov.VM.ViewModelAttendance
{
    public class VMEditingAttendance : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public VMEditingAttendance()
        {
            EditingAttendanceCommand = new LambdaCommand(CanEditingAttendanceCommand, OnEditingAttendanceCommand);
        }
        public ICommand EditingAttendanceCommand { get; set; }
        private bool OnEditingAttendanceCommand(object obj) => true;
        private void CanEditingAttendanceCommand(object obj)
        {

        }
    }
}
