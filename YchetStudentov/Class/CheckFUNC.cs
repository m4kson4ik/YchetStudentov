using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YchetStudentov.Class
{
    internal class CheckFUNC
    {
        public static bool CheckNumber(string name)
        {
            char[] number = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (int i = 0; i < number.Length; i++)
            {
                for (int j = 0; j < name.Length; j++)
                {
                    if (number[i] == name[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool CheckSymbol(string stroka)
        {
            char[] mas = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л','М','О','П', 'С','Т', 'У', 'Ф',
                'a', 'б','в', 'г', 'д', 'е' };
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < stroka.Length; j++)
                {
                    if (mas[i] == stroka[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
