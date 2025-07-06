using System;

class Program
{

    static void Main()//metodo de inicio 
    {
        CalcularCosto();
    }

    static void Menu()//metodo para mostrar el menu de tratamientos 
    {
        Console.WriteLine("Seleccione el tratamiento odontológico:");
        Console.WriteLine("1. Limpieza");
        Console.WriteLine("2. Ortodoncia");
        Console.WriteLine("3. Endodoncia");
        Console.WriteLine("4. Salir");
    }

    static void CalcularCosto()//metodo para definir el costo de cada tratamiento
    {
        const int costoLimpieza = 50000;
        const int costoOrtodoncia = 200000;
        const int costoEndodoncia = 150000;

        int totalCosto = 0;//inicializar el costo en 0 para poder calcular el precio final

        Menu();//llamar el menu 
        Console.Write("Ingrese la opción deseada: ");
        string opcion = Console.ReadLine();

        // Validar la opción ingresada
        if (opcion == "1")
        {
            Console.Write("Ingrese el número de sesiones de limpieza: ");
            int sesionesLimpieza = int.Parse(Console.ReadLine());
            totalCosto += sesionesLimpieza * costoLimpieza;//calcular el costo del tratamiento
            Console.WriteLine($"Costo total de limpieza: ${sesionesLimpieza * costoLimpieza}");//mostrar el nombre y costo del tratamiento
        }
        else if (opcion == "2")
        {
            Console.Write("Ingrese el número de sesiones de ortodoncia: ");
            int sesionesOrtodoncia = int.Parse(Console.ReadLine());
            totalCosto += sesionesOrtodoncia * costoOrtodoncia;
            Console.WriteLine($"Costo total de ortodoncia: ${sesionesOrtodoncia * costoOrtodoncia}");
        }
        else if (opcion == "3")
        {
            Console.Write("Ingrese el número de sesiones de endodoncia: ");
            int sesionesEndodoncia = int.Parse(Console.ReadLine());
            totalCosto += sesionesEndodoncia * costoEndodoncia;
            Console.WriteLine($"Costo total de endodoncia: ${sesionesEndodoncia * costoEndodoncia}");
        }
        else if (opcion == "4")
        {
            Console.WriteLine($"Costo total acumulado de todos los tratamientos: ${totalCosto}");
            return; // Salir del programa
        }
        else
        {
            Console.WriteLine("Opción no válida. Intente de nuevo.");
        }
    }
}