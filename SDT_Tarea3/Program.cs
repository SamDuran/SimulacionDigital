/*------- SIMULACION PARA CONOCER LAS AULAS A CONSTRUIR Y ESTADISTICAS DE ESTUDIANTES QUE ABANDONAN, INSCRITOS, APROBADOS Y REPROBADOS --------
 
 * Los alumnos entran a primer año a razon de x por año
       * Del primer año, el a1% de los alumnos pasa a segundo, el b1% abandona y el c1% se queda repetido
       * Del i-esimo año, e ai% de los alumnos pasa a segundo, el bi% abandona y el ci% se queda repetido, la carrera dura 5 años
       * Se quiere saber cuantos alumnos hay por año para planificar las salas que se necesitan
       AL FINALIZAR debe presentar cuantas aulas se requieren para construir y las estadisticas de los estudiantes que abandonan,
       inscritos, aprobados, reprobados...
 */

#region Constantes
using SDT_Tarea3.Utils;

const float ProbabilidadReprobados = 37.4f;
const int   ProbabilidadAbandono   = 10;
const float ProbabilidadAprobados  = 52.6f;
#endregion

var random = new Random();
int opcion, TiempoSimular = 0;

int cantidadEstudiantes = 0;
do
{
    Console.Clear();
    ImprimirMenu();


    opcion = GetIntegerInput();

    switch (opcion)
    {
        case 1: /* SIMULAR */
            {
                Console.Write("Digite la cantidad de años a simular: ");
                TiempoSimular = GetIntegerInput();
                while(TiempoSimular<1)
                {
                    Console.Write("El tiempo digitado no es válido.\nPor favor digite un número mayor a cero: ");
                    TiempoSimular = GetIntegerInput();
                }
                for (int i = 1; i <= TiempoSimular; i++)
                {
                    Console.WriteLine($"\nSIMULACIÓN DEL AÑO #{i}");
                    cantidadEstudiantes = random.Next(50, 150);
                    Console.WriteLine($"Se inscribieron {cantidadEstudiantes} estudiantes.");

                }
                Console.WriteLine("Presione ENTER para continuar...");
                Console.ReadKey();
                Console.Beep();
                break;
            }
        case 2: /* ESTADISTICAS */
            {
                Console.WriteLine($"Años simulados    : {TiempoSimular}");
                Console.WriteLine($"Aulas previstas   : ");
                Console.WriteLine($"Alumnos inscritos : {cantidadEstudiantes}");
                Console.WriteLine($"Alumnos reprobados: ");
                Console.WriteLine($"Alumnos abandonos : ");
                Console.WriteLine($"Alumnos aprobados : ");

                Console.WriteLine("\nPresione ENTER para continuar...");
                Console.ReadKey();
                Console.Beep();
                break;
            }
        case 3: /* SALIR */
            {
                break;
            }
        default: /* INPUT INCORRECTO */
            {
                Console.WriteLine("Opcion incorrecta. Presione enter para volver a digitar una opción...");
                Console.ReadKey();
                break;
            }
    }
} while (opcion != 3);
Console.WriteLine("SALIENDO ...");

void ImprimirMenu()
{
    Console.WriteLine("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█");
    Console.WriteLine("█  1- SIMULAR                              2- VOLVER A MOSTRAR ESTADÍSTICAS             3- SALIR                       █");
    Console.WriteLine("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█");
    Console.WriteLine("             █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█");
    Console.Write(    "                                              Digite la opción deseada: ");
}

int GetIntegerInput()
{

    string? input = Console.ReadLine();
    Console.Beep();
    while (input is null || input.ToPossitiveInt() == -1)
    {
        Console.Write("Entrada invalida.\nPor favor digite nuevamente: ");
        input = Console.ReadLine();
        Console.Beep();
    }
    return input.ToPossitiveInt();
}