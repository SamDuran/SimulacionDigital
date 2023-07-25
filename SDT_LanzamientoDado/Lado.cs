using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDT_LanzamientoDado
{
    class Lado
    {
        public int Numero { get; set; }
        public double LimInferior { get; set; }
        public double LimSuperior { get; set; }
        public int VecesSalido { get; set; }

        public Lado(int Num, double LimInf, double LimSup)
        {
            this.Numero = Num;
            this.LimInferior = LimInf;
            this.LimSuperior = LimSup;
            this.VecesSalido = 0;
        }
        public override string ToString()
        {
            return Numero.ToString();
        }
    }
}
