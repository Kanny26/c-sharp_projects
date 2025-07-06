using System;

namespace SatelitesClimaticos
{
    internal class Program
    {
        static string[] nombresSatelites = { "SAT-1", "SAT-2", "SAT-3", "SAT-4", "SAT-5", "SAT-6" };
        static string[] regionesPlanetarias = { "América", "Europa", "Asia", "África", "Oceanía" };
        static string[] tiposDatos = { "Temperatura", "Humedad", "Radiación Solar", "CO₂" };

        const int cantidadDias = 15;
        const int horasPorDia = 24;

        static double[,,,,] datosAmbientales = new double[
            nombresSatelites.Length,
            regionesPlanetarias.Length,
            tiposDatos.Length,
            cantidadDias,
            horasPorDia
        ];

        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        static void MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("\n--- SISTEMA SATELITAL DE OBSERVACIÓN ---");
                Console.WriteLine("1. Ingresar datos de un satélite");
                Console.WriteLine("2. Analizar datos por satélite y región");
                Console.WriteLine("3. Salir");
                Console.Write("Selecciona una opción: ");

                if (!int.TryParse(Console.ReadLine(), out int opcion))
                {
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }

                if (opcion == 1)
                    IngresarDatosAmbientales();
                else if (opcion == 2)
                    AnalizarDatos();
                else if (opcion == 3)
                    break;
                else
                    Console.WriteLine("Opción no válida.");
            }
        }

        static void IngresarDatosAmbientales()
        {
            Console.WriteLine("\n--- Selecciona un satélite ---");
            for (int i = 0; i < nombresSatelites.Length; i++)
                Console.WriteLine($"{i + 1}. {nombresSatelites[i]}");

            Console.Write("Opción: ");
            if (!int.TryParse(Console.ReadLine(), out int seleccionSat) || seleccionSat < 1 || seleccionSat > nombresSatelites.Length)
            {
                Console.WriteLine("Satélite inválido.");
                return;
            }

            int indiceSatelite = seleccionSat - 1;

            Console.WriteLine("\n--- Selecciona una región ---");
            for (int i = 0; i < regionesPlanetarias.Length; i++)
                Console.WriteLine($"{i + 1}. {regionesPlanetarias[i]}");

            Console.Write("Opción: ");
            if (!int.TryParse(Console.ReadLine(), out int seleccionRegion) || seleccionRegion < 1 || seleccionRegion > regionesPlanetarias.Length)
            {
                Console.WriteLine("Región inválida.");
                return;
            }

            int indiceRegion = seleccionRegion - 1;

            for (int tipoDato = 0; tipoDato < tiposDatos.Length; tipoDato++)
            {
                Console.WriteLine($"\n Registrando datos de {tiposDatos[tipoDato]}:");

                for (int dia = 0; dia < cantidadDias; dia++)
                {
                    for (int hora = 0; hora < horasPorDia; hora++)
                    {
                        double valor;
                        bool valido = false;

                        while (!valido)
                        {
                            Console.Write($"Día {dia + 1}, Hora {hora}: ");
                            string entrada = Console.ReadLine();

                            if (double.TryParse(entrada.Replace(",", "."), out valor))
                            {
                                datosAmbientales[indiceSatelite, indiceRegion, tipoDato, dia, hora] = valor;
                                valido = true;
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido. Intenta de nuevo.");
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\n Datos almacenados correctamente.");
        }

        static void AnalizarDatos()
        {
            Console.WriteLine("\n--- Selecciona un satélite para analizar ---");
            for (int i = 0; i < nombresSatelites.Length; i++)
                Console.WriteLine($"{i + 1}. {nombresSatelites[i]}");

            Console.Write("Opción: ");
            if (!int.TryParse(Console.ReadLine(), out int seleccionSat) || seleccionSat < 1 || seleccionSat > nombresSatelites.Length)
            {
                Console.WriteLine(" Satélite inválido.");
                return;
            }

            int indiceSatelite = seleccionSat - 1;

            Console.WriteLine("\n--- Selecciona una región ---");
            for (int i = 0; i < regionesPlanetarias.Length; i++)
                Console.WriteLine($"{i + 1}. {regionesPlanetarias[i]}");

            Console.Write("Opción: ");
            if (!int.TryParse(Console.ReadLine(), out int seleccionRegion) || seleccionRegion < 1 || seleccionRegion > regionesPlanetarias.Length)
            {
                Console.WriteLine(" Región inválida.");
                return;
            }

            int indiceRegion = seleccionRegion - 1;

            Console.WriteLine($"\n Análisis de {nombresSatelites[indiceSatelite]} en {regionesPlanetarias[indiceRegion]}");

            for (int tipoDato = 0; tipoDato < tiposDatos.Length; tipoDato++)
            {
                double suma = 0;
                double minimo = double.MaxValue;
                double maximo = double.MinValue;

                for (int dia = 0; dia < cantidadDias; dia++)
                {
                    for (int hora = 0; hora < horasPorDia; hora++)
                    {
                        double valor = datosAmbientales[indiceSatelite, indiceRegion, tipoDato, dia, hora];
                        suma += valor;
                        if (valor < minimo) minimo = valor;
                        if (valor > maximo) maximo = valor;
                    }
                }

                double promedio = suma / (cantidadDias * horasPorDia);
                Console.WriteLine($"🔹 {tiposDatos[tipoDato]} → Prom: {promedio:F2}, Máx: {maximo}, Mín: {minimo}");
            }
        }
    }
}
