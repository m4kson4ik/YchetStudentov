using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YchetStudentov.Models;

namespace YchetStudentov.Class
{
    public class Distceplini : INotifyPropertyChanged
    {
        private int number_disceplini;
        private string? _nameDisceplini { get; set; }
        private string? _formaAttest { get; set; }

        protected int _login;
        private string? _namePrepod { get; set; }
        private string? _familyPrepod { get; set; }


       

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChange(string names)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(names));
            }
        }

        public int NumberDisciplini
        {
            get { return number_disceplini; }
            set
            {
                number_disceplini = value;
                OnPropertyChange("Номер дисциплины");
            }
        }
        public string? NameDisciplini
        {
            get => _nameDisceplini;
            set
            {
                _nameDisceplini = value;
                OnPropertyChange("Название дисциплины");
            }
        }

        public string? FormaAttest
        {
            get { return _formaAttest; }
            set
            {
                _formaAttest = value;
                OnPropertyChange("FormaAttest");
            }
        }
        public int Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChange("Login");
            }
        }

        public string? NamePrepod
        {
            get
            {
                using (var context = new YcotStudentContext())
                {
                    var item = context.Prepodovatelis.SingleOrDefault(s => s.LoginPrepodovatela == _login);
                    return item?.Name ?? "";
                }
            }
            set { _namePrepod = value; }
        }

        public string? FamilyPrepod
        {
            get
            {
                using (var context = new YcotStudentContext())
                {
                    var item = context.Prepodovatelis.SingleOrDefault(s => s.LoginPrepodovatela == _login);
                    if (item != null)
                    {
                        return item.Family;
                    }
                }
                return null;        
            }
            set { _familyPrepod = value; }
        }
        public string? nameDiscepliniandFIO { private get => $"{NameDisciplini} ({FamilyPrepod} {NamePrepod})"; set => nameDiscepliniandFIO = value; }
        //   public Distceplini(int number_disceplini, string _nameDisceplini,string _formaAttest, int login)
        //   {
        //       this.number_disceplini = number_disceplini;
        //       this._nameDisceplini = _nameDisceplini;
        //       this._formaAttest = _formaAttest;
        //       this.login = login;
        //   }
    }
}
