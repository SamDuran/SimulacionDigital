using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionEstado.Clases
{
    internal class Pueblo
    {
        public Contienda contienda { get; set; }


        public void ImprimirPueblo()
        {
            var contienda = (this.contienda == Contienda.ALTA) ? "Alta" : "Baja";
            Console.WriteLine("Contienda del pueblo: " +contienda);
        }
    }
    public enum Contienda
    {
        BAJA,
        ALTA
    }
}
