using SimulacionEstado.Clases;
using System;

Console.Write("Digite la cantidad de años a simular: ");
var cantidadAnios = int.Parse(Console.ReadLine());
var gobierno = new Gobierno();
var pueblo = new Pueblo();
var contadorGobierno = 0;

Console.Write("Desea simular un tipo de partido en especifico? (si = 1 / no = 0 ):");
var especifico = int.Parse(Console.ReadLine());
int tipoPoliticaAnterior = 0;
//simular
var random = new Random();

for (int anio = 1; anio <= cantidadAnios; anio++)
{
    Console.WriteLine("\n\nAÑO " + anio);
    if (anio == 1 && especifico == 1)
    {
        Console.WriteLine("\n1- Permisivo\n2- Coercitivo");
        Console.Write("Digite la opcion deseada: ");
        var politica = int.Parse(Console.ReadLine());
        tipoPoliticaAnterior = politica;
        gobierno = new Gobierno(politica);
    }else if( anio == 1 && especifico == 0)
    {
        int tipoGobierno = random.Next(1, 3);
        var partido = (tipoGobierno == 1) ? "Permisivo" : "Coercitivo";
        Console.WriteLine("Se genero un partido " + partido);
        gobierno = new Gobierno(tipoGobierno);
    }
    else if(contadorGobierno % 4 == 0 || pueblo.contienda == Contienda.ALTA)
    {
        contadorGobierno = 0; 
        if(pueblo.contienda == Contienda.ALTA)
        {
            Console.WriteLine("Se cambiará el partido por motivos de contienda alta.");
        }
        else if (contadorGobierno % 4 == 0)
        {
            Console.WriteLine("Se generara un partido por motivos de constitucion");
        }
        
        int tipoGobierno = random.Next(1,3);
        var partido = (tipoGobierno == 1) ? "Liberal" : "Conservador";
        Console.WriteLine("Se genero un partido " +partido);
        if(tipoGobierno != 1)//si es conservador
        {
            gobierno = new Gobierno(tipoPoliticaAnterior);
        }
        else
        {
            gobierno = new Gobierno(tipoGobierno);

        }
        tipoPoliticaAnterior = tipoGobierno;
    }

    if (gobierno.politica == Politica.COERCITIVA)
    {
        pueblo.contienda = Contienda.ALTA;
        
    }
    else
    {
        pueblo.contienda = Contienda.BAJA;
    }

    //mitad de año
    Console.WriteLine("\nA MITAD DEL AÑO");
    if(pueblo.contienda == Contienda.ALTA)
    {
        Console.WriteLine("El pueblo se regó");
        var posibilidad = random.Next(1, 3);
        if(posibilidad == 1)
        {
            Console.WriteLine("El gobierno cambio su politica al ver la reaccion del pueblo");
            gobierno.politica = Politica.PERMISIVA;
            pueblo.contienda = Contienda.BAJA;
        }
        else
        {
            Console.WriteLine("El gobierno mantuvo su politica");
        }
    }
    else
    {
        Console.WriteLine("La contienda esta baja");
    }


    Console.WriteLine("\nAL TERMINAR EL AÑO");
    contadorGobierno++; 
    
    gobierno.ImprimirGobierno();
    pueblo.ImprimirPueblo();
}