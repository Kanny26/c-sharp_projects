using System;

// Clase que representa a una persona con atributos relacionados al servicio (militar o civil)
class Persona
{
    // Atributos privados
    private string nombre;
    private int edad;
    private string tipoServicio;
    private bool servicioCumplido;

    // Métodos para asignar valores a los atributos
    public void AsignarNombre(string nom)
    {
        nombre = nom;
    }

    public void AsignarEdad(int Edad)
    {
        edad = Edad;
    }

    public void AsignarTipoServicio(string tipo)
    {
        tipoServicio = tipo;
    }

    public void AsignarEstadoServicio(bool estado)
    {
        servicioCumplido = estado;
    }

    // Métodos para obtener valores de los atributos
    public string ObtenerNombre()
    {
        return nombre;
    }

    public int ObtenerEdad()
    {
        return edad;
    }

    public string ObtenerTipoServicio()
    {
        return tipoServicio;
    }

    public bool ObtenerEstadoServicio()
    {
        return servicioCumplido;
    }
}

// Clase principal que ejecuta el programa
class Program
{
    static void Main()
    {
        // Arreglo para almacenar hasta 100 personas
        Persona[] personas = new Persona[100];
        int cantidadPersonas = 0; // Contador de personas registradas
        bool salir = false; // Bandera para salir del menú

        // Bucle principal del programa (menú interactivo)
        while (!salir)
        {
            // Mostrar opciones del menú
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Registrar persona");
            Console.WriteLine("2. Actualizar estado de servicio");
            Console.WriteLine("3. Consultar persona por número de libreta");
            Console.WriteLine("4. Mostrar totales");
            Console.WriteLine("5. Salir");
            Console.Write("Ingrese opción: ");
            string opcion = Console.ReadLine();

            // Opción 1: Registrar una nueva persona
            if (opcion == "1")
            {
                // Verificar si hay espacio en el arreglo
                if (cantidadPersonas < personas.Length)
                {
                    Persona p = new Persona(); // Crear nuevo objeto Persona

                    // Solicitar y asignar nombre
                    Console.Write("Nombre: ");
                    string nom = Console.ReadLine();
                    p.AsignarNombre(nom);

                    // Solicitar y validar edad (debe ser un número)
                    Console.Write("Edad: ");
                    int ed;
                    while (!int.TryParse(Console.ReadLine(), out ed))
                    {
                        Console.Write("Edad inválida. Ingrese un número: ");
                    }
                    p.AsignarEdad(ed);

                    // Solicitar y asignar tipo de servicio
                    Console.Write("Tipo de servicio (militar/civil): ");
                    string tipo = Console.ReadLine();
                    p.AsignarTipoServicio(tipo);

                    // Solicitar y asignar estado del servicio
                    Console.Write("¿Cumplió el servicio? (s/n): ");
                    string estado = Console.ReadLine();
                    if (estado.ToLower() == "s")
                        p.AsignarEstadoServicio(true);
                    else
                        p.AsignarEstadoServicio(false);

                    // Agregar persona al arreglo
                    personas[cantidadPersonas] = p;
                    cantidadPersonas++;

                    Console.WriteLine("Persona registrada correctamente.");
                }
                else
                {
                    Console.WriteLine("Capacidad máxima alcanzada.");
                }
            }

            // Opción 2: Actualizar el estado del servicio de una persona
            else if (opcion == "2")
            {
                Console.Write("Número de libreta a actualizar (0 a {0}): ", cantidadPersonas - 1);
                int num;
                while (!int.TryParse(Console.ReadLine(), out num) || num < 0 || num >= cantidadPersonas)
                {
                    Console.Write("Número inválido. Ingrese un número válido: ");
                }

                // Cambiar estado de servicio a cumplido o pendiente
                Console.Write("Marcar como cumplido (s) o pendiente (n): ");
                string estado = Console.ReadLine();
                if (estado.ToLower() == "s")
                    personas[num].AsignarEstadoServicio(true);
                else
                    personas[num].AsignarEstadoServicio(false);

                Console.WriteLine("Estado actualizado.");
            }

            // Opción 3: Consultar información de una persona
            else if (opcion == "3")
            {
                Console.Write("Número de libreta a consultar (0 a {0}): ", cantidadPersonas - 1);
                int num;
                while (!int.TryParse(Console.ReadLine(), out num) || num < 0 || num >= cantidadPersonas)
                {
                    Console.Write("Número inválido. Ingrese un número válido: ");
                }

                // Obtener persona y mostrar su información
                Persona p = personas[num];
                Console.WriteLine("Nombre: " + p.ObtenerNombre());
                Console.WriteLine("Edad: " + p.ObtenerEdad());
                Console.WriteLine("Tipo de servicio: " + p.ObtenerTipoServicio());
                Console.WriteLine("Estado del servicio: " + (p.ObtenerEstadoServicio() ? "Cumplido" : "Pendiente"));
            }

            // Opción 4: Mostrar totales de servicios cumplidos y pendientes
            else if (opcion == "4")
            {
                int i = 0;
                int cumplidos = 0;
                int pendientes = 0;

                // Recorrer el arreglo y contar cuántos han cumplido o no
                while (i < cantidadPersonas)
                {
                    if (personas[i].ObtenerEstadoServicio())
                        cumplidos++;
                    else
                        pendientes++;
                    i++;
                }

                Console.WriteLine("Total que cumplieron servicio: " + cumplidos);
                Console.WriteLine("Total pendientes: " + pendientes);
            }

            // Opción 5: Salir del programa
            else if (opcion == "5")
            {
                salir = true; // Cambia la bandera para salir del bucle
            }

            // Si se ingresa una opción no válida
            else
            {
                Console.WriteLine("Opción no válida.");
            }
        }

        Console.WriteLine("Programa finalizado.");
    }
}
