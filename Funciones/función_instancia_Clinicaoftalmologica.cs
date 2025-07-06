using System;

public class Consultas//clase para representar lo que hara el programa
{
    // declarar la variables para los diferentes factores
    public string TipoConsulta;
    public int EdadPaciente;
    public bool SeguroMedico;

    // Constructor de la clase Consultas
    public Consultas(string tipoConsulta, int edadPaciente, bool seguroMedico)
    {
        // Inicializa la propiedad TipoConsulta con el valor proporcionado
        TipoConsulta = tipoConsulta;

        // Inicializa la propiedad EdadPaciente con el valor proporcionado
        EdadPaciente = edadPaciente;

        // Inicializa la propiedad SeguroMedico con el valor proporcionado
        SeguroMedico = seguroMedico;
    }

    // Método para calcular el costo de la consulta con descuentos
    public float CalcularCosto()
    {
        float costoBase = 0;//inicializar el valor de la consulta
        bool consultaValida = false;//calcular que el valor ingresado sea correcto

        //ciclo para validar el tipo de consulta y su precio
        while (!consultaValida)
        {
            if (TipoConsulta == "1")
            {
                costoBase = 50000f; // General
                consultaValida = true;
            }
            else if (TipoConsulta == "2")
            {
                costoBase = 80000f; // Examen de Vista
                consultaValida = true;
            }
            else if (TipoConsulta == "3")
            {
                costoBase = 300000f; // Cirugía
                consultaValida = true;
            }
            else
            {
                Console.WriteLine("Tipo de consulta inválido. Intente nuevamente.");
                Console.Write("Ingrese el tipo de consulta (1: General, 2: Examen de Vista, 3: Cirugía): ");
                TipoConsulta = Console.ReadLine();
            }
        }

        // Aplicar descuentos segun la edad
        if (EdadPaciente < 18 || EdadPaciente >= 65)
            costoBase *= 0.80f; // 20% de descuento

        // Aplicar descuentos por seguro medico
        if (SeguroMedico)
            costoBase *= 0.75f; // 25% de descuento adicional

        return costoBase;
    }
}

public class MenuConsultas
{
    public void Seleccion()

    {
        string tipoConsulta;
        //Ciclo para seleccionar el tipo de consulta
        do
        {
            Console.WriteLine("===== Clínica Oftalmológica =====");
            Console.WriteLine("Seleccione el tipo de consulta: ");
            Console.WriteLine("1. Consulta General");
            Console.WriteLine("2. Examen de Vista");
            Console.WriteLine("3. Cirugía");
            Console.Write("Opción: ");
            tipoConsulta = Console.ReadLine();
        } while (tipoConsulta != "1" && tipoConsulta != "2" && tipoConsulta != "3");//validar si el numero ingresado esta dentro del rango

        //ciclo para ingresar la edady validar un numero correcto
        int edad;
        while (true)
        {
            Console.Write("Ingrese la edad del paciente: ");
            if (int.TryParse(Console.ReadLine(), out edad) && edad >= 0)
                break;
            Console.WriteLine("Por favor, ingrese una edad válida.");
        }

        //ciclo para validar si tiene o no seguro
        bool tieneSeguro;
        while (true)
        {
            Console.WriteLine("¿El paciente tiene seguro médico?");
            Console.WriteLine("1. Sí");
            Console.WriteLine("2. No");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();
            if (opcion == "1")
            {
                tieneSeguro = true;
                break;
            }
            else if (opcion == "2")
            {
                tieneSeguro = false;
                break;
            }
            else
            {
                Console.WriteLine("Opción inválida, intente de nuevo.");
            }
        }

        // Crear una instancia de la consulta
        Consultas consulta = new Consultas(tipoConsulta, edad, tieneSeguro);

        // Mostrar el costo final
        Console.WriteLine($"\nEl costo total de la consulta es: ${consulta.CalcularCosto()}");
    }
}
//clase para ejecutar el menu
class Program
{
    static void Main()
    {
        MenuConsultas menu = new MenuConsultas();//llama a la clase MenuConsultas
        menu.Seleccion();
    }
}
