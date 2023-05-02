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
        private string? _namePrepod;
    //    {
    //     get
    //     {
    //         using (var context = new YcotStudentContext())
    //         {
    //             var item = context.Prepodovatelis.SingleOrDefault(s => s.LoginPrepodovatela == login);
    //             if (item != null)
    //             {
    //                 return namePrepod = item.Name;
    //             }
    //         }
    //         return null;
    //     }
    //     private set
    //     {
    //         
    //     }
    // }
        private string? _familyPrepod;
      //  {
      //      get
      //      {
      //          using (var context = new YcotStudentContext())
      //          {
      //              var item = context.Prepodovatelis.SingleOrDefault(s => s.LoginPrepodovatela == login);
      //              if (item != null)
      //              {
      //                 return familyPrepod = item.Family;
      //              }
      //          }
      //          return null;
      //          
      //      }
      //      private set
      //      {
      //    
      //      }
      //  }
        private string? nameDiscepliniandFIO;

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
        public string NameDisciplini
        {
            get => _nameDisceplini;
            set
            {
                _nameDisceplini = value;
                OnPropertyChange("Название дисциплины");
            }
        }

        public string FormaAttest
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


        //   public Distceplini(int number_disceplini, string name_disceplini,string forma_attest, int login)
        //   {
        //       this.number_disceplini = number_disceplini;
        //       this.name_disceplini = name_disceplini;
        //       this.forma_attest = forma_attest;
        //       this.login = login;
        //   }
    }
}
