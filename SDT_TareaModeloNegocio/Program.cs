/* MODELO DE NEGOCIO: 
 
 * - Socios Estrategicos           : (¿Quienes son? | ¿Quienes le ofrecen servicios y recursos estrategicos? | ¿Que actividades internas podrian subcontratarse para bajar costos y mejorar la calidad?)
 
 * - Actividades Claves            : (¿Cuales son las actividades y los procesos clave en su modelo de negocios?) 
 
 * - Recursos Claves               : (¿Cuales son los recursos claves y mas costosos en su BM?)
 
 * - Propuesta de Valor            : (¿Que ofrece a sus clientes en terminos de productos/servicios? | ¿Que es lo que pagan los clientes? | ¿Que lo diferencia de otros oferentes?) 
 
 * - Administracion de la relacion : (¿Que tipo de relacion contruye usted con sus clientes? | ¿Tiene usted alguna estrategia? ) 
 
 * - Canales de distribucion       : (¿Como hace el cliente para adquirir el producto? | ¿A travez de que medios?)
 
 * - Segmento de mercado           : (¿Quienes son sus clientes? | ¿Puede describir sus diferentes tipos clientes? | ¿Cual es la diferencia de cada segmento?)
 
 * - Estructura de costo           : (¿Como luce su estructura de costos? | ¿Cuales son los mas importantes costos al poner en funcionamiento su empresa?) 
 
 * - Ingresos / Precios            : (¿Cual es su estructura de ingresos? | ¿Como gana dinero? | ¿Que tipo de ingresos obtiene usted?{transacciones bancarias, facturacion directa, pago por credito, etc})*/

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Evaluación de Conveniencia de Modelo de Negocio");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Responde las siguientes preguntas con valores numéricos del 1 al 5 (1 = Mínimo, 5 = Máximo)");

        // Preguntas estratégicas
        int estrategico = Pregunta("¿Qué tan estratégico es el modelo de negocio?");
        int serviciosRecursos = Pregunta("¿Qué tan atractivos son los servicios y recursos ofrecidos?");

        // Preguntas de subcontratación
        int subcontratacion = Pregunta("¿Qué tan viable es la subcontratación de ciertas actividades internas?");

        // Preguntas de actividades claves
        int actividadesClaves = Pregunta("¿Qué tan cruciales son las actividades claves en el modelo de negocio?");
        int procesosClaves = Pregunta("¿Qué tan bien definidos están los procesos claves en tu modelo de negocio?");

        // Preguntas de administración de relación con clientes
        int relacionClientes = Pregunta("¿Qué tan eficiente es tu administración de relaciones con clientes?");
        int canalesDistribucion = Pregunta("¿Qué tan efectivos son tus canales de distribución?");

        // Preguntas de recursos claves y socios estratégicos
        int recursosClaves = Pregunta("¿Qué tan importantes son los recursos clave para tu negocio?");
        int sociosEstrategicos = Pregunta("¿Qué tan beneficiosos son tus socios estratégicos para el modelo de negocio?");

        // Preguntas de Innovación y Diferenciación
        int innovacion = Pregunta("¿Qué tan innovador es tu modelo de negocio en comparación con los competidores?");
        int diferenciacion = Pregunta("¿Qué tan bien te diferencias en el mercado con tus productos/servicios?");

        // Preguntas de Segmentos de Clientes
        int segmentosClientes = Pregunta("¿Qué tan claramente identificas y atiendes a los diferentes segmentos de clientes?");
        int personalizacionPropuesta = Pregunta("¿Qué tan personalizada es tu propuesta de valor para cada segmento de clientes?");

        // Preguntas de Gestión de Recursos Humanos
        int reclutamientoSeleccion = Pregunta("¿Cómo es tu proceso de reclutamiento y selección de personal?");
        int capacitacionDesarrollo = Pregunta("¿Qué enfoque tienes para capacitar y desarrollar las habilidades de tus empleados?");

        // Preguntas de Sostenibilidad y Responsabilidad Social
        int sostenibilidadAmbiental = Pregunta("¿Qué acciones implementas para minimizar el impacto ambiental de tu negocio?");
        int responsabilidadSocial = Pregunta("¿Qué iniciativas de responsabilidad social llevas a cabo para contribuir a la comunidad?");

        // Preguntas de Análisis Financiero
        int proyeccionFinanciera = Pregunta("¿Cuál es la proyección de ingresos y gastos para los próximos años?");
        int puntoEquilibrio = Pregunta("¿Cuál es el punto de equilibrio de tu modelo de negocio?");

        // Preguntas de Estrategia de Expansión y Penetración de Mercado
        int expansionNegocios = Pregunta("¿Cuáles son tus planes de expansión a nuevos mercados o regiones?");
        int adaptabilidadMercado = Pregunta("¿Cómo te aseguras de que tu modelo de negocio sea adaptable a diferentes mercados?");

        
        int puntajeTotal = estrategico + serviciosRecursos + subcontratacion + actividadesClaves + procesosClaves +
            relacionClientes + canalesDistribucion + recursosClaves + sociosEstrategicos +
            innovacion + diferenciacion + segmentosClientes + personalizacionPropuesta +
            reclutamientoSeleccion + capacitacionDesarrollo + sostenibilidadAmbiental + responsabilidadSocial +
            proyeccionFinanciera + puntoEquilibrio + expansionNegocios + adaptabilidadMercado;
        int puntajeMaximo = 20 * 5; // 20 preguntas con valores de 1 a 5
        double porcentaje = ((double)puntajeTotal / puntajeMaximo) * 100;

        Console.WriteLine("--------------------------------------------");
        Console.WriteLine($"Resultado de la evaluación: {porcentaje}%");

        if (porcentaje >= 70)
        {
            Console.WriteLine("El modelo de negocio parece ser conveniente.");
        }
        else
        {
            Console.WriteLine("El modelo de negocio necesita ser revisado y mejorado.");
        }

        Console.ReadKey();
    }

    static int Pregunta(string pregunta)
    {
        int respuesta;
        do
        {
            Console.Write($"{pregunta} (1-5): ");
        } while (!int.TryParse(Console.ReadLine(), out respuesta) || respuesta < 1 || respuesta > 5);

        return respuesta;
    }
}
