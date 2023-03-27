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
    class Group
    {
        public string NumberGroup { get;}
        public string NameGroup { get;}
        public string NumberSpec { get;}
        public Group(string number_group, string name_group, string number_spec)
        {
            this.NumberGroup = number_group;
            this.NameGroup = name_group;
            this.NumberSpec = number_spec;
        }

        public static void CreateGroup(string number_group, string name_group, string number_spec)
        {
            DataTable dataTable = DateBase.Select($"insert into Groups(number_group, name_group, number_spec) values ('{number_group}', '{name_group}', '{number_spec}')");
        }
        public static void GetAllGroup(ComboBox cmb) // Получение информации о группах в любой ComboBox
        {
            cmb.Items.Clear();
            DataTable dataTable = DateBase.Select("SELECT number_group FROM Groups");
            //cmb.Items.Add("Все студенты");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cmb.Items.Add(dataTable.Rows[i][0]);
            }
        }
        
        public static void ReturnPolnNameGroup(string selected)
        {
            //DataTable dataTable = DateBase.Select("SELECT poln_name_spec, number_group FROM Groups");
            //for (int i = 0; i < dataTable.Rows.Count; i++)
            //{
            //    if ((string)dataTable.Rows[i][1] == selected)
            //    {
            //       name = (string)dataTable.Rows[i][0];
            //    }
            //}
            //UchebPlan.ReturnNumberDisceplin(name);
            //MessageBox.Show(name);
        }
        public static List<Group> GetAll()
        {
            List<Group> groups = new List<Group>(0);
            DataTable dataTable = DateBase.Select("SELECT * FROM Groups");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                groups.Add(new Group(dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString(), dataTable.Rows[i][0].ToString()));
            }
            return groups;
        }
    }
}
