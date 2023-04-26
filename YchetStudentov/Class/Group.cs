using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace YchetStudentov.Class
{
    public class Group
    {
        public string NameSpec { get;}
        public string NumberGroup { get;}
        public string NumberSpec { get;}
        public Group(string number_group, string name_spec, string number_spec)
        {
            this.NumberGroup = number_group;
            this.NameSpec = name_spec;
            this.NumberSpec = number_spec;
        }
    }
}
