using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YchetStudentov.Models;

namespace YchetStudentov.Class
{
    class Prepodovateli
    { 
        public string family { get; }
        public string name { get; }
        public string otchestvo { get; }
        public int login;
        public string password;

        public Prepodovateli(string name, string family, string otchestvo, int login, string password)
        {
            this.name = name;
            this.family = family;
            this.otchestvo = otchestvo;
            this.login = login;
            this.password = password;
        }

        
    }
}
