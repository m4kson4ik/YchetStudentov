using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YchetStudentov.Class;

namespace YchetStudentov.VM
{
    public class VMPrepodovateli
    {
        private Prepodovateli[] prepodovateli;

        public Prepodovateli[] Prepodovateli
        {
            get { return prepodovateli; }
            set
            {
                prepodovateli = value;
            }
        }
    }
}
