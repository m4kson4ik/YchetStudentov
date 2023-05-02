using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace YchetStudentov
{
    internal class Correctness
    {

        public Correctness()
        {
            //CheckingForEmptyValues();
        }
        public char[] arr_ru = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'э', 'ю', 'я' };
        public char[] arr_RU = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Э', 'Ю', 'Я' };
        public int[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public string letters = "abcdefghijklmnopqrstuvwxyz";
        public string[] lastEmail = {".com", ".ru" };
        public void CheckingForRussianLetters(params string[] tb)
        {
           List<string> list = new List<string>();
          // var item = tb.Select(items => list.Add(item));
        }
        
        public void Create(string number)
        {
        }

        public void CheckingForTheETASymbol(TextBox tb)
        {
         //  int i = 0;
         //  foreach(var t in tb.Text)
         //  {
         //      if (t == ' ')
         //      {
         //          MessageBox.Show("");
         //      }
         //     if (tb.Text.EndsWith(lastEmail[i]))
         //     {
         //    
         //     }
         //  }
        }

        public void CheckingForALargeLetter(params TextBox[] tb)
        {
            foreach(var t in tb)
            {
                    char d = t.Text[0];
                    string ds = t.Text.Remove(0,1);
                    for (int i = 0; i < arr_RU.Length; i++)
                    {
                        if (d == arr_ru[i])
                        {                        
                            t.Text =  $"{arr_RU[i].ToString() + ds}";
                        }
                    }
            }
        }
        public void CheckingForASpace(params TextBox[] tb)
        {
            int i = 0;
            foreach(var t in tb)
            {
                foreach (var symvol in t.Text)
                {
                    if (symvol == ' ')
                    {
                        MessageBox.Show("Использование символа пробел невозможно!");
                        t.Text = t.Text.Remove(i, 1);
                        return;
                    }
                    i++;
                }
            }
        }
        public bool CheckingForEmptyValuesTextBox(Button create ,params TextBox[] tb)
        {
            foreach (var t in tb)
            {
                if (t.Text == "")
                {
                    MessageBox.Show("Одно из полей оказалось пустым!\n (Поля не могут быть пустыми)");
                    return false;
                }
            }
            return true;
        }

        public bool ChekingForEmptyValuesComboBox(Button create, params ComboBox[] cmb)
        {
            foreach(var t in cmb)
            {
                if (t.Text == "")
                {
                    MessageBox.Show("Одно из полей оказалось пустым!\n (Поля не могут быть пустыми)");
                    return false;
                }
            }
            return true;
        }

        public void CheckingForNumbers(params TextBox[] tb)
        {
            int lop = 0;
            foreach (var t in tb)
            {
                string text = t.Text;
                 lop = 0;
                foreach (var u in t.Text)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (t.Text[lop] == arr[i])
                        {
                            MessageBox.Show($"Символ {t.Text[lop]} введен некорректно!\n(Невозможно использование символов и цифр)");
                            t.Text = t.Text.Remove(lop, 1);
                            return;
                        }
                    }
                    lop++;
                }
            }
        }
    }
}
