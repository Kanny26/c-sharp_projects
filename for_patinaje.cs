class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("*-*-*-*-*-*-*BIENVENID@ A LA ACADEMIA DE PATINAJE*-*-*-*-*-*-*");
        Console.WriteLine("Inscribiendo alumnos...");
            string nombre;
            string docente;
            int contador = 0;
        for (int i = 0; i < int.MaxValue; i++)
        {
            Console.WriteLine("A continuación escribe tu nombre y/o para finalizar el proceso ingrese la palabra 'salir'): ");
            Console.Write("Nombre: ");
            nombre = Console.ReadLine();
            if (nombre.Equals("salir", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            Console.WriteLine("Seleccione el rango de edad:");
            Console.WriteLine("1. 6 años a 8 años");
            Console.WriteLine("2. 9 años a 12 años");
            Console.WriteLine("3. 13 años a 18 años");
            Console.WriteLine("Digite 1, 2 o 3 según sea el rango de edad...");

            int opcion = int.Parse(Console.ReadLine());
            contador++;
            {
                if (opcion == 1)
                {
                    docente = "Profesora Ana";
                }
                else if (opcion == 2)
                {
                    docente = "Profesor Freddy";
                }
                else if (opcion == 3)
                {
                    docente = "Profesora Oscar";
                }
                else
                {
                    Console.WriteLine("Opción inválida.");
                    return;
                }
                if (contador > 0)
                {


                    Console.WriteLine("•——————---------------•°•*•°•------——————------------•");
                    Console.WriteLine($"************ Bienvenida,{nombre} ************");
                    Console.WriteLine($"--El entrenamiento lo tendras con la/el: {docente}--");
                    Console.WriteLine("");
                    Console.WriteLine("**** Horario de actividades a lo largo de la semana: ****");
                    Console.WriteLine("");
                    Console.WriteLine("**** Lunes: ****");
                    Console.WriteLine("7:00 AM - 8:30 AM: Técnica de patinaje");
                    Console.WriteLine("9:00 PM - 10:30 PM: Fuerza en el gimnasio");

                    Console.WriteLine("");
                    Console.WriteLine("**** Martes: ****");
                    Console.WriteLine("7:00 AM - 8:30 AM: Resistencia");
                    Console.WriteLine("9:00 PM - 10:30 PM: Flexibilidad y movilidad");

                    Console.WriteLine("");
                    Console.WriteLine("**** Miércoles: ****");
                    Console.WriteLine("7:00 AM - 8:30 AM: Velocidad y sprints");
                    Console.WriteLine("9:00 PM - 10:30 PM: Equilibrio y control");

                    Console.WriteLine("");
                    Console.WriteLine("**** Jueves: ****");
                    Console.WriteLine("7:00 AM - 8:30 AM: Fondo (resistencia larga)");
                    Console.WriteLine("9:00 PM - 10:30 PM: Estrategia y táctica");

                    Console.WriteLine("");
                    Console.WriteLine("**** Viernes: ****");
                    Console.WriteLine("7:00 AM - 8:30 AM: Técnica y sprints");
                    Console.WriteLine("9:00 PM - 10:30 PM: Fuerza en el gimnasio");

                    Console.WriteLine("");
                    Console.WriteLine("**** Sábado: ****");
                    Console.WriteLine("7:00 AM - 9:00 AM: Resistencia y técnica combinada");
                    Console.WriteLine("");
                    Console.WriteLine("***Espero que disfrutes tus entrenamientos!!***");
                    Console.WriteLine("");
                }
            }
        }
    }
}