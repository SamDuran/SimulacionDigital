using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionEstado.Clases
{
    internal class Gobierno
    {
        public Partido partido { get; set; }
        public Politica politica { get; set; }


        public Gobierno(int tipo)
        {
            if (tipo == 1)
            {
                partido = Partido.LIBERAL;
                politica = Politica.PERMISIVA;
            }
            else
            {
                partido = Partido.CONSERVADOR;
                politica = Politica.COERCITIVA;
            }
        }
        public Gobierno()
        {

        }
        public void ImprimirGobierno()
        {
            var partido = (this.partido == Partido.LIBERAL) ? "Liberal" : "Conservador";
            var politica = (this.politica == Politica.PERMISIVA) ? "Permisivo" : "Coercitivo";

            Console.WriteLine($"Partido: {partido}");
            Console.WriteLine($"Politica: {politica}");
        }


    }
    public enum Partido
    {
        LIBERAL,
        CONSERVADOR
    }
    public enum Politica
    {
        PERMISIVA,
        COERCITIVA
    }
}
