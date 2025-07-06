using System;

class AcademiaIdiomas
{
    static void Main()
    {
        // El usuario define el número máximo de estudiantes
        Console.Write("Ingrese el número máximo de estudiantes por curso: ");
        int maxEstudiantes = int.Parse(Console.ReadLine());

        string[] ingles = new string[maxEstudiantes];
        string[] frances = new string[maxEstudiantes];
        string[] aleman = new string[maxEstudiantes];

        int countIngles = 0, countFrances = 0, countAleman = 0;
        string opcion;

        do
        {
            Console.WriteLine("\n--- Academia de Idiomas ---");
            Console.WriteLine("1. Inscribir estudiante");
            Console.WriteLine("2. Mostrar inscritos");
            Console.WriteLine("3. Buscar estudiante");
            Console.WriteLine("4. Eliminar estudiante");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Console.ReadLine();

            if (opcion == "1") // Inscribir estudiante
            {
                Console.Write("Ingrese el nombre del estudiante: ");
                string nombre = Console.ReadLine();
                Console.WriteLine("Seleccione el curso (1-Inglés, 2-Francés, 3-Alemán): ");
                int curso = int.Parse(Console.ReadLine());

                string cursoNombre = "";
                if (curso == 1)
                    cursoNombre = "Inglés";
                else if (curso == 2)
                    cursoNombre = "Francés";
                else if (curso == 3)
                    cursoNombre = "Alemán";
                else
                    cursoNombre = "Inválido";

                if (cursoNombre == "Inválido")
                {
                    Console.WriteLine("Opción inválida.");
                }
                else
                {
                    if (curso == 1 && countIngles < maxEstudiantes)
                        ingles[countIngles++] = nombre;
                    else if (curso == 2 && countFrances < maxEstudiantes)
                        frances[countFrances++] = nombre;
                    else if (curso == 3 && countAleman < maxEstudiantes)
                        aleman[countAleman++] = nombre;
                    else
                        Console.WriteLine($"El curso de {cursoNombre} está lleno.");
                }
            }
            else if (opcion == "2") // Mostrar inscritos
            {
                Console.WriteLine("\nEstudiantes en Inglés:");
                MostrarEstudiantes(ingles, countIngles);

                Console.WriteLine("\nEstudiantes en Francés:");
                MostrarEstudiantes(frances, countFrances);

                Console.WriteLine("\nEstudiantes en Alemán:");
                MostrarEstudiantes(aleman, countAleman);
            }
            else if (opcion == "3") // Buscar estudiante
            {
                Console.Write("Ingrese el nombre del estudiante a buscar: ");
                string buscar = Console.ReadLine();
                bool encontrado = false;

                encontrado |= BuscarEnCurso(ingles, countIngles, buscar, "Inglés");
                encontrado |= BuscarEnCurso(frances, countFrances, buscar, "Francés");
                encontrado |= BuscarEnCurso(aleman, countAleman, buscar, "Alemán");

                if (!encontrado)
                    Console.WriteLine($"{buscar} no está inscrito en ningún curso.");
            }
            else if (opcion == "4") // Eliminar estudiante
            {
                Console.Write("Ingrese el nombre del estudiante a eliminar: ");
                string eliminar = Console.ReadLine();
                bool eliminado = false;

                eliminado |= EliminarEstudiante(ref ingles, ref countIngles, eliminar);
                eliminado |= EliminarEstudiante(ref frances, ref countFrances, eliminar);
                eliminado |= EliminarEstudiante(ref aleman, ref countAleman, eliminar);

                if (eliminado)
                    Console.WriteLine($"{eliminar} fue eliminado.");
                else
                    Console.WriteLine($"{eliminar} no estaba inscrito en ningún curso.");
            }
            else if (opcion == "5") // Salir
            {
                Console.WriteLine("Saliendo del programa...");
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }

        } while (opcion != "5");
    }

    // Función para mostrar estudiantes inscritos
    static void MostrarEstudiantes(string[] curso, int count)
    {
        if (count == 0)
            Console.WriteLine("No hay estudiantes inscritos.");
        else
            for (int i = 0; i < count; i++)
                Console.WriteLine($"- {curso[i]}");
    }

    // Función para buscar un estudiante en un curso
    static bool BuscarEnCurso(string[] curso, int count, string nombre, string nombreCurso)
    {
        for (int i = 0; i < count; i++)
        {
            if (curso[i] == nombre)
            {
                Console.WriteLine($"{nombre} está inscrito en {nombreCurso}.");
                return true;
            }
        }
        return false;
    }

    // Función para eliminar un estudiante de un curso
    static bool EliminarEstudiante(ref string[] curso, ref int count, string nombre)
    {
        for (int i = 0; i < count; i++)
        {
            if (curso[i] == nombre)
            {
                for (int est = i; est < count - 1; est++)
                    curso[est] = curso[est + 1];

                curso[count - 1] = null;
                count--;
                return true;
            }
        }
        return false;
    }
}
