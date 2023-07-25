using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamUtils
{
    static class Utils
    {
        private static int ToPossitiveInt(this string value)
        {
            if(value.Is_A_ValidPossitiveInt())
                return Convert.ToInt32(value);

            return -1;
        }
        private static bool Is_A_ValidPossitiveInt(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            var onlyNumbers = true;

            foreach (var character in value)
            {
                if (!char.IsNumber(character))
                {
                    onlyNumbers = false;
                }
            }

            return onlyNumbers; 
        }
        public static int ReadIntInput(string fieldname)
        {
            var input = Console.ReadLine();

            while (!input.Is_A_ValidPossitiveInt())
            {
                Console.Write($"Digite el valor del campo \'{fieldname}\' nuevamente: ");
                input = Console.ReadLine();
            }

            return input.ToPossitiveInt();
        }
    }
}
