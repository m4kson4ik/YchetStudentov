using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

//

namespace YchetStudentov.Form
{
    /// <summary>
    /// Логика взаимодействия для StudentOzenki.xaml
    /// </summary>
    public partial class StudentOzenki : Window
    {

        
        public class Studentiss
        {
            [Description("Demonstrates DisplayNameAttribute.")]
            [DisplayName("RenamedProperty")]
            public string NameDisceplini { get; }
            public string Ozenka { get; }
            public DateTime DataZanyatie { get; }
            public string NamePrepod { get; }
            public string FamilyPrepod { get; }
            public Studentiss(string name_disceplini, string ozenka, DateTime data_zanyatie, string name_prepod, string family_prepod)
            {
                this.NameDisceplini = name_disceplini;
                this.Ozenka = ozenka;
                this.DataZanyatie = data_zanyatie;
                this.NamePrepod = name_prepod;
                this.FamilyPrepod = family_prepod;
            }
        }
        public string ? group { get; set; }
        public int ? num_zac_king { get; set; }

        public StudentOzenki()
        {
            InitializeComponent();
            // GetPredmeti(cmbPredmets);
            // GetAllPoseshaemost();
        }
      
        public void GetPredmeti(ComboBox cmb)
        {
            cmb.Items.Clear();
            DataTable predmeti = DateBase.Select($"Select number_group, name_disceplini from OzenkiSelectStudent where number_group = '{group}'");
            for (int i =0; i < predmeti.Rows.Count; i++)
            {
                cmb.Items.Add(predmeti.Rows[i][1]);
            }
        }

        public List<Studentiss> GetOzenki(string predmet)
        {
            int kolvo_propusk = 0;
            int kolvo_po_uv_prichine = 0;
            List<Studentiss> ozenki = new List<Studentiss>();
            DataTable getozenki = DateBase.Select($"Select number_zac_knig, number_group, name_disceplini, ocenka, data_zanyatie, name, family from StudentOzenki where number_zac_knig = '{num_zac_king}' and number_group = '{group}' and name_disceplini = '{cmbPredmets.SelectedItem}'");
            for (int i = 0; i < getozenki.Rows.Count; i++)
            {
                ozenki.Add(new Studentiss((string)getozenki.Rows[i][2], (string)getozenki.Rows[i][3], (DateTime)getozenki.Rows[i][4], (string)getozenki.Rows[i][5],(string)getozenki.Rows[i][6]));
                if (getozenki.Rows[i][3].ToString() == "Н" || getozenki.Rows[i][3].ToString() == "Б")
                {
                    kolvo_propusk++;
                }

                if (getozenki.Rows[i][3].ToString() == "Б")
                {
                    kolvo_po_uv_prichine++;
                }
            }
            lb_propuski.Content = Convert.ToInt32(kolvo_propusk);
            lbUvPrichin.Content = Convert.ToInt32(kolvo_po_uv_prichine);
            return ozenki;
        }

        public void GetAllPoseshaemost()
        {
            int obsh_kolvo_propuskov = 0;
            int obsh_kolvo_propuskowBolezn = 0;
            DataTable getposes = DateBase.Select($"Select number_zac_knig, ocenka from StudentOzenki where number_zac_knig = '{num_zac_king}'");
            for (int i =0; i < getposes.Rows.Count; i++)
            {
                if (getposes.Rows[i][1].ToString() == "Н" || getposes.Rows[i][1].ToString() == "Б")
                {
                    obsh_kolvo_propuskov++;
                }
                
                if (getposes.Rows[i][1].ToString() == "Б") 
                {
                    obsh_kolvo_propuskowBolezn++;
                }
            }
            lbAllPropusk.Content = Convert.ToInt32(obsh_kolvo_propuskov);
            lbAllPropuskBolezn.Content = Convert.ToInt32(obsh_kolvo_propuskowBolezn);
        }

        private void cmbPredmets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataGridOzenki.ItemsSource = GetOzenki(cmbPredmets?.SelectedItem.ToString() ?? " ");
            dataGridOzenki.Columns[0].Header = "Название предмета";
            dataGridOzenki.Columns[1].Header = "Статус";
            dataGridOzenki.Columns[2].Header = "Дата занятия";
            dataGridOzenki.Columns[3].Header = "Имя";
            dataGridOzenki.Columns[4].Header = "Фамилия";
        }
    }
}
