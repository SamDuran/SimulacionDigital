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

using SDT_TareaModeloNegocio;

Preguntas[] SociosEstrategicos = new Preguntas[3];
Preguntas ActividadesClaves = new Preguntas();
Preguntas RecusosClaves = new Preguntas();
Preguntas[] PropuestaDeValor = new Preguntas[3];
Preguntas[] AdministracionDeLaRelacion = new Preguntas[2];
Preguntas[] CanalesDeDistribucion  = new Preguntas[2];
Preguntas[] SegmentoDeMercado  = new Preguntas[3];
Preguntas[] EstructuraDeCosto  = new Preguntas[2];
Preguntas[] IngresosPrecios  = new Preguntas[3];


string segmentoMercado = ObtenerEntrada("Segmento de Mercado");
string estructuraCosto = ObtenerEntrada("Estructura de Costo");
string ingresosPrecios = ObtenerEntrada("Ingresos / Precios");

double ingresosAnuales = CalcularIngresos(ingresosPrecios);
double costoAnual = CalcularCosto(estructuraCosto);
double margenUtilidad = CalcularMargenUtilidad(ingresosAnuales, costoAnual);
string resultado = EvaluarExito(margenUtilidad);



Console.WriteLine("Simulación de éxito de la empresa:");
Console.WriteLine("=================================");
Console.WriteLine("- Segmento de Mercado: " + segmentoMercado);
Console.WriteLine("- Estructura de Costo: " + estructuraCosto);
Console.WriteLine("- Ingresos / Precios: " + ingresosPrecios);
Console.WriteLine("- Ingresos Anuales: $" + ingresosAnuales);
Console.WriteLine("- Costo Anual: $" + costoAnual);
Console.WriteLine("- Margen de Utilidad: " + margenUtilidad.ToString("P"));
Console.WriteLine("- Resultado: " + resultado);


static string ObtenerEntrada(string nombreCampo)
{
    Console.Write("Ingrese " + nombreCampo + ": ");
    return Utilities.ObtenerValorString();
}

static double CalcularIngresos(string ingresosPrecios)
{
    // Implementar lógica para calcular los ingresos anuales
    // basados en la estructura de precios y ventas proyectadas
    // usar fórmulas, algoritmos o datos históricos
    // supongamos que ingresosPrecios es el ingreso anual proyectado.

    return Convert.ToDouble(ingresosPrecios);
}

static double CalcularCosto(string estructuraCosto)
{
    // Implementar lógica para calcular el costo anual
    // basado en la estructura de costos de la empresa
    // considerar costos fijos, costos variables y otros factores
    // supongamos que estructuraCosto es el costo anual proyectado
    return Convert.ToDouble(estructuraCosto);
}

static double CalcularMargenUtilidad(double ingresosAnuales, double costoAnual)
{
    // Calcular el margen de utilidad como un porcentaje
    if (ingresosAnuales > 0)
    {
        return (ingresosAnuales - costoAnual) / ingresosAnuales;
    }
    else
    {
        return 0;
    }
}

static string EvaluarExito(double margenUtilidad)
{
    // Evaluar el éxito de la empresa en función del margen de utilidad
    // Quizas establecer criterios de éxito según métricas y objetivos.
    if (margenUtilidad >= 0.2) // 20% de margen de utilidad como criterio de éxito
    {
        return "Éxito";
    }
    else
    {
        return "Fracaso";
    }
}