using System;
using System.Threading.Tasks;

namespace SDT_LanzamientoDado
{
    class Dado
    {
        public Lado[] lados { get; set; }
        private const double MARGEN_DIFERENCIA = 0.0000000001;
        public Dado()
        {
            lados = new Lado[]
            {
                new Lado(1, 0, 16.6666666667),
                new Lado(2, 16.6666666668, 33.3333333334),
                new Lado(3, 33.3333333335, 50),
                new Lado(4, 50.0000000001, 66.666666667),
                new Lado(5, 66.666666668, 83.3333333334),
                new Lado(6, 83.3333333335, 100)
            };
        }
        public void CambiarProbabilidad(int numeroDado, int probabilidad)
        {
            double ProbabilidadRestante = (100 - probabilidad) / 6;
            for (int i = 0; i < lados.Length; i++)
            {
                if (lados[i].Numero == numeroDado && i == 0) //Si se selecciono el primero
                {
                    lados[i].LimSuperior = probabilidad;
                }
                else if (lados[i].Numero == numeroDado) //Si se selecciono en medio o ultimo
                {
                    lados[i].LimInferior = lados[i - 1].LimSuperior + MARGEN_DIFERENCIA;
                    lados[i].LimSuperior = lados[i].LimInferior + probabilidad;
                }
                else if (lados[i].Numero != numeroDado && i == 0) // si no se selecciono el primero
                {
                    lados[i].LimSuperior = ProbabilidadRestante;
                }
                else if (lados[i].Numero != numeroDado) //si no se selecciono el ultimo
                {
                    lados[i].LimInferior = lados[i - 1].LimSuperior + MARGEN_DIFERENCIA;
                    lados[i].LimSuperior = lados[i].LimInferior + ProbabilidadRestante;
                }
            }
        }
        private void SimularLanzamiento()
        {
            Random num = new Random();
            var numeroSacado = num.Next(0, 101);

            for (int i = 0; i < lados.Length; i++)
            {
                if (numeroSacado >= lados[i].LimInferior && numeroSacado <= lados[i].LimSuperior)
                {
                    lados[i].VecesSalido++;
                    Console.WriteLine($"Salio el numero {lados[i]}");
                }
            }
        }
        public void SimularMuchosLanzamientos(int veces)
        {
            for (int i = 0; i < veces; i++)
            {
                Task.Delay(200);
                SimularLanzamiento();
            }
        }
        public void ReiniciarEstadisticas()
        {
            for (int i = 0; i < lados.Length; i++)
                lados[i].VecesSalido = 0;
        }
        public void MostrarEstadisticas()
        {
            Console.WriteLine("ESTADISTICAS DEL DADO: ");
            for (int i = 0; i < lados.Length; i++)
                    Console.WriteLine($"Lado {i+1} salio {lados[i].VecesSalido} veces");
        }
    }
}
