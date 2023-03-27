using ExcelDataReader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace YchetStudentov.Class
{
    internal class UchebniPlans
    {
        public class ImportUchebPlan
        {
            public string name_predmet { get; set; }
            public string eczamen { get; set; }
            public string zachet { get; set; }
            public string def_zachet { get; set; }
            public string kursovoi_project { get; set; }
            public string kursovoi_rabot { get; set; }
            public string kontol_rabot { get; set; }
            
            public ImportUchebPlan(string name_predmet, string eczamen, string zachet, string def_zachet, string kursovoi_project, string kursovoi_rabot, string kontol_rabot)
            {
                this.name_predmet = name_predmet;
                this.eczamen = eczamen;
                this.zachet = zachet;
                this.def_zachet = def_zachet;
                this.kursovoi_project = kursovoi_project;
                this.kursovoi_rabot = kursovoi_rabot;
                this.kontol_rabot = kontol_rabot;
            }
        }
        public static List<ImportUchebPlan> readFile(string fileNames)
        {
            IExcelDataReader edr = null;
            var extension = fileNames.Substring(fileNames.LastIndexOf('.'));
            // Создаем поток для чтения.
            FileStream stream = File.Open(fileNames, FileMode.Open, FileAccess.Read);
            // В зависимости от расширения файла Excel, создаем тот или иной читатель.
            // Читатель для файлов с расширением *.xlsx.
            if (extension == ".xlsx")
                edr = ExcelReaderFactory.CreateOpenXmlReader(stream);
            // Читатель для файлов с расширением *.xls.
            else if (extension == ".xls")
                edr = ExcelReaderFactory.CreateBinaryReader(stream);

            //// reader.IsFirstRowAsColumnNames
            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };
            // Читаем, получаем DataView и работаем с ним как обычно.
            DataSet dataSet = edr.AsDataSet(conf);
            dataSet.Tables[0].Columns.Add("das");
            DataView dtView = dataSet.Tables[0].AsDataView();
            // После завершения чтения освобождаем ресурсы.
            edr.Close();
            DataView uchebplan = new DataView();
            //MessageBox.Show(dtView.Count.ToString());
            //MessageBox.Show(dtView.Table.Columns[2].ToString());
            //MessageBox.Show(dtView.Table.Rows[21][2].ToString());
            List <ImportUchebPlan> name = new List<ImportUchebPlan>();
            //for (int i = 0; i < dtView.Table.Columns.Count; i++)
            //{
            List<string> two = new List<string>();
            for (int j = 0; j < dtView.Table.Rows.Count; j++)
            {
                if (dtView.Table.Rows[j][2].ToString() != "")
                {
                    if (dtView.Table.Rows[j][3].ToString() != "" || dtView.Table.Rows[j][4].ToString() != "" || dtView.Table.Rows[j][5].ToString() != "" || dtView.Table.Rows[j][6].ToString() != "" || dtView.Table.Rows[j][7].ToString() != "" || dtView.Table.Rows[j][8].ToString() != "")
                    {
                        name.Add(new ImportUchebPlan(dtView.Table.Rows[j][2].ToString(), dtView.Table.Rows[j][3].ToString(), dtView.Table.Rows[j][4].ToString(), dtView.Table.Rows[j][5].ToString(), dtView.Table.Rows[j][6].ToString(), dtView.Table.Rows[j][7].ToString(), dtView.Table.Rows[j][8].ToString()));
                    }
                }

                if (dtView.Table.Rows[j][3].ToString() == "1" || dtView.Table.Rows[j][4].ToString() == "1" || dtView.Table.Rows[j][5].ToString() == "1" || dtView.Table.Rows[j][6].ToString() == "1" || dtView.Table.Rows[j][7].ToString() == "1" || dtView.Table.Rows[j][8].ToString() == "1")
                {
                    two.Add((string)dtView.Table.Rows[j][2]);
                }
            }
                MessageBox.Show(two.Count.ToString());
            // }
            //}
            return name;
        }
    }
}
