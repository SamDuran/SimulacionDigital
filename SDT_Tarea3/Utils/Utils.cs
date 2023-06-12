using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDT_Tarea3.Utils
{
    static class Utils
    {
        static public int ToPossitiveInt(this string input)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                return -1;

            var resultado = "";
            foreach (var caracter in input)
            {
                if (char.IsNumber(caracter))
                {
                    resultado += caracter;
                }
                else
                {
                    return -1;
                }
            }
            return Convert.ToInt32(resultado);
        }
    }
}
