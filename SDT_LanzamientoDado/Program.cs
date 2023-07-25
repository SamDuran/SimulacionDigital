using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamUtils;

namespace SDT_LanzamientoDado
{
    class Program
    {
        static void Main(string[] args)
        {
            var dado = new Dado();
            int opcionMenu;
            do
            {
                ImprimirMenu();
                opcionMenu = Utils.ReadIntInput("Opcion");

                switch (opcionMenu)
                {
                    case 1: //Lanzar dado
                        {
                            Console.Write("Digite la cantidad de veces que desea lanzar el dado: ");
                            var input = Utils.ReadIntInput("veces");
                            dado.SimularMuchosLanzamientos(input);
                            break;
                        }
                    case 2: //Cambiar probabilidades
                        {
                            Console.Write("Digite el numero del lado a modificar: (1 - 6): ");
                            var lado = Utils.ReadIntInput("numero");

                            while (lado < 1 || lado > 6)
                                lado = Utils.ReadIntInput("numero");

                            Console.Write($"Digite la nueva probabilidad a colocarle al lado {lado}: ");
                            var probabilidad = Utils.ReadIntInput("probabilidad");
                            dado.CambiarProbabilidad(lado, probabilidad);
                            break;
                        }
                    case 3: // Ver estadisticas
                        {
                            dado.MostrarEstadisticas();
                            break;
                        }
                    case 4: //Reiniciar Estadisticas
                        {
                            dado.ReiniciarEstadisticas();
                            break;
                        }
                    case 5: // Salir
                        {

                            break;
                        }
                    default:
                        {
                            Console.Write("Opcion invalida. \n" +
                                "Por favor revise la tabla de opciones y elija una de las opciones mencionadas.");
                            break;
                        }
                }
                Pause();
            } while (opcionMenu != 5);
        }
        static void ImprimirMenu()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════════════════════════╗\n" +
                                "║       1- Simular                2- Cambiar probabilidades                3- Ver estadisticas   ║\n" +
                                "║                  4- Reiniciar estadisticas                   5- Salir                          ║\n" +
                                "╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.Write("                                    Digite la opcion deseada: ");
        }
        static void Pause()
        {
            Console.Write("Presione enter para continuar...");
            Console.ReadKey();
        }
    }
}
