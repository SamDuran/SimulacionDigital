using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDT_TareaModeloNegocio
{
    static class Utilities
    {
        public static string ObtenerValorString()
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                return "";

            return input;
        }
    }
}
