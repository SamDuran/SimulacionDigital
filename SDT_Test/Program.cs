namespace TestPsicologico
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> preguntasPorAspecto = new Dictionary<string, List<string>>
            {
                { "Creatividad", new List<string>
                    {
                        "1. ¿Disfrutas explorando nuevas ideas y enfoques?",
                        "2. ¿Te consideras una persona con mente abierta ante diferentes soluciones?",
                        "3. ¿Sueles proponer soluciones no convencionales para los problemas?",
                        "4. ¿Encuentras inspiración en situaciones inesperadas o fuera de lo común?",
                        "5. ¿Eres capaz de ver oportunidades donde otros no las ven?"
                    }
                },
                { "Innovacion", new List<string>
                    {
                        "6. ¿Has desarrollado alguna vez una solución innovadora para un problema?",
                        "7. ¿Te atraen los desafíos que requieren pensar de manera creativa?",
                        "8. ¿Eres capaz de conectar ideas de diferentes áreas para crear algo nuevo?",
                        "9. ¿Sueles buscar constantemente nuevas formas de hacer las cosas?",
                        "10. ¿Te sientes cómodo/a experimentando con nuevas ideas?"
                    }
                },
                { "Iniciativa", new List<string>
                    {
                        "11. ¿Sueles tomar la iniciativa en situaciones de grupo?",
                        "12. ¿Te sientes cómodo/a liderando proyectos y tomando decisiones?",
                        "13. ¿Eres proactivo/a al abordar tareas y responsabilidades?",
                        "14. ¿Buscas oportunidades para mejorar y crecer?",
                        "15. ¿Eres capaz de enfrentar desafíos sin esperar a que alguien más te diga qué hacer?"
                    }
                },
                { "Comunicacion", new List<string>
                    {
                        "16. ¿Te consideras una persona con habilidades efectivas de comunicación?",
                        "17. ¿Puedes expresar tus ideas de manera clara y persuasiva?",
                        "18. ¿Sueles escuchar activamente a los demás y comprender sus puntos de vista?",
                        "19. ¿Eres capaz de adaptar tu estilo de comunicación a diferentes audiencias?",
                        "20. ¿Disfrutas participando en conversaciones significativas y constructivas?"
                    }
                },
                { "Analisis", new List<string>
                    {
                        "21. ¿Eres capaz de analizar situaciones complejas y encontrar soluciones?",
                        "22. ¿Tienes habilidades analíticas que te permiten comprender patrones y tendencias?",
                        "23. ¿Disfrutas examinando datos y obteniendo información relevante?",
                        "24. ¿Sueles descomponer problemas complejos en partes más manejables?",
                        "25. ¿Eres capaz de evaluar las ventajas y desventajas antes de tomar decisiones?"
                    }
                },
                { "Riesgo", new List<string>
                    {
                        "26. ¿Estás dispuesto/a a asumir riesgos calculados en proyectos?",
                        "27. ¿Te sientes cómodo/a tomando decisiones arriesgadas con posibles recompensas?",
                        "28. ¿Eres capaz de enfrentar situaciones inciertas con confianza?",
                        "29. ¿Sueles aprender de los errores y fracasos para mejorar en el futuro?",
                        "30. ¿Te consideras una persona que sabe equilibrar la toma de riesgos con la cautela?"
                    }
                }
            };



            Dictionary<string, int> aspectosPuntuacion = new Dictionary<string, int>
            {
                { "Creatividad", 0 },
                { "Innovacion", 0 },
                { "Iniciativa", 0 },
                { "Comunicacion", 0 },
                { "Analisis", 0 },
                { "Riesgo", 0 }
            };



            Console.WriteLine("Por favor, responde las siguientes preguntas con una opción del 1 al 5, donde 1 es 'Totalmente en desacuerdo' y 5 es 'Totalmente de acuerdo':");
            Console.WriteLine("1) Totalmente en desacuerdo");
            Console.WriteLine("2) En desacuerdo");
            Console.WriteLine("3) Neutral");
            Console.WriteLine("4) De acuerdo");
            Console.WriteLine("5) Totalmente de acuerdo \n");
            foreach (var aspecto in preguntasPorAspecto)
            {
                foreach (var pregunta in aspecto.Value)
                {
                    Console.Write("\n" + pregunta + ": ");
                    int respuesta;
                    while (!int.TryParse(Console.ReadLine(), out respuesta) || respuesta < 1 || respuesta > 5)
                    {
                        Console.WriteLine("Respuesta inválida. Introduce un valor entre 1 y 5.");
                    }
                    aspectosPuntuacion[aspecto.Key] += respuesta;
                }
            }



            Console.WriteLine("\n\n=============================================");
            Console.WriteLine("Puntuación en cada aspecto:\n");



            foreach (var aspecto in aspectosPuntuacion)
            {
                double porcentajePuntuacion = ((double)aspecto.Value / (preguntasPorAspecto[aspecto.Key].Count * 5)) * 100;
                porcentajePuntuacion = Math.Round(porcentajePuntuacion, 2);
                Console.WriteLine($"\t{aspecto.Key}: {porcentajePuntuacion}%");
            }



            Console.WriteLine("=============================================");
        }
    }
}