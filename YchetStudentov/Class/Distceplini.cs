using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YchetStudentov.Models;

namespace YchetStudentov.Class
{
    public class Distceplini
    {
        public int number_disceplini;
        public string name_disceplini { get; }
        public string forma_attest { get; }

        protected int login;
        public string? namePrepod
        {
            get
            {
                using (var context = new YcotStudentContext())
                {
                    var item = context.Prepodovatelis.SingleOrDefault(s => s.LoginPrepodovatela == login);
                    if (item != null)
                    {
                        return namePrepod = item.Name;
                    }
                }
                return null;
            }
            private set
            {
                
            }
        }
        public string? familyPrepod
        {
            get
            {
                using (var context = new YcotStudentContext())
                {
                    var item = context.Prepodovatelis.SingleOrDefault(s => s.LoginPrepodovatela == login);
                    if (item != null)
                    {
                       return familyPrepod = item.Family;
                    }
                }
                return null;
                
            }
            private set
            {

            }
        }
        public string? nameDiscepliniandFIO { private get => $"{name_disceplini} ({familyPrepod} {namePrepod})"; set => nameDiscepliniandFIO = value; }
        public Distceplini(int number_disceplini, string name_disceplini,string forma_attest, int login)
        {
            this.number_disceplini = number_disceplini;
            this.name_disceplini = name_disceplini;
            this.forma_attest = forma_attest;
            this.login = login;
        }
    }
}
