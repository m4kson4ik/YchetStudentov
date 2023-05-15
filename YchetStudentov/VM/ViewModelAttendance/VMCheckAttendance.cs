using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YchetStudentov.VM.ViewModelStudents;

namespace YchetStudentov.VM.ViewModelAttendance
{
    public class VMCheckAttendance
    {
        public Class.Student? SelectedStudent { get; set; }
        public ObservableCollection<string> CollectionDisceplini { get; set; }
        public ObservableCollection<Class.Attendance> CollectionAttendance { get; set; }
        public VMCheckAttendance()
        {
            CollectionAttendance = new ObservableCollection<Class.Attendance>();
            SelectedStudent = VMStudents.SelectedStudent;
            CollectionDisceplini = new ObservableCollection<string>(DateBase.Context().GetSelectedDiscipline(SelectedStudent));
        }

        private string _selectedDisciplini;
        public string SelectedDisciplini
        {
            get { return _selectedDisciplini; }
            set
            {
                _selectedDisciplini = value;
                CollectionAttendance.Clear();
                var items = DateBase.Context().GetOzenki(SelectedStudent, value);
                foreach(var item in items)
                {
                    CollectionAttendance.Add(item);
                }
            }
        }
    }
}
