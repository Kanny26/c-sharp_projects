using System;

namespace LaboratorioGenetico
{
    internal class Program
    {
        static string[] nombreLaboratorios = { "Lab Norte", "Lab Europa", "Lab Asia" };
        static string[] nombreEspecies = { "Especie A", "Especie B", "Especie C", "Especie D", "Especie E" };
        static string[] condicionesAmbientales = { "Temperatura", "Luz", "Humedad", "pH" };
        static string[] horariosSesion = { "00:00", "06:00", "12:00", "18:00" };
        static int cantidadDias = 10;

        static double[,,,,] reactividad = new double[
            nombreLaboratorios.Length,
            nombreEspecies.Length,
            condicionesAmbientales.Length,
            cantidadDias,
            horariosSesion.Length
        ];

        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        static void MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("\n--- Sistema de Evaluación Genética ---");
                Console.WriteLine("1. Ingresar datos experimentales");
                Console.WriteLine("2. Analizar datos por laboratorio");
                Console.WriteLine("3. Salir");
                Console.Write("Selecciona una opción: ");

                if (!int.TryParse(Console.ReadLine(), out int opcionMenu))
                {
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }

                if (opcionMenu == 1)
                    IngresarDatosReactividad();
                else if (opcionMenu == 2)
                    AnalizarDatosPorLaboratorio();
                else if (opcionMenu == 3)
                    break;
                else
                    Console.WriteLine("Opción inválida.");
            }
        }

        static void IngresarDatosReactividad()
        {
            Console.WriteLine("\n--- Selecciona el laboratorio ---");
            for (int indiceLab = 0; indiceLab < nombreLaboratorios.Length; indiceLab++)
                Console.WriteLine($"{indiceLab + 1}. {nombreLaboratorios[indiceLab]}");

            Console.Write("Opción: ");
            if (!int.TryParse(Console.ReadLine(), out int seleccionLab) || seleccionLab < 1 || seleccionLab > nombreLaboratorios.Length)
            {
                Console.WriteLine("Opción inválida.");
                return;
            }

            int indiceLaboratorio = seleccionLab - 1;

            for (int indiceEspecie = 0; indiceEspecie < nombreEspecies.Length; indiceEspecie++)
            {
                for (int indiceCondicion = 0; indiceCondicion < condicionesAmbientales.Length; indiceCondicion++)
                {
                    Console.WriteLine($"\n {nombreEspecies[indiceEspecie]} - {condicionesAmbientales[indiceCondicion]}");

                    for (int dia = 0; dia < cantidadDias; dia++)
                    {
                        Console.WriteLine($"  Día {dia + 1}:");

                        for (int indiceSesion = 0; indiceSesion < horariosSesion.Length; indiceSesion++)
                        {
                            double valorReactividad;
                            bool entradaValida = false;

                            while (!entradaValida)
                            {
                                Console.Write($"    Sesión {horariosSesion[indiceSesion]} → Índice (0.0 - 100.0): ");
                                string entrada = Console.ReadLine();

                                if (double.TryParse(entrada.Replace(",", "."), out valorReactividad) && valorReactividad >= 0 && valorReactividad <= 100)
                                {
                                    reactividad[indiceLaboratorio, indiceEspecie, indiceCondicion, dia, indiceSesion] = valorReactividad;
                                    entradaValida = true;
                                }
                                else
                                {
                                    Console.WriteLine("Valor inválido. Intenta nuevamente.");
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\n Datos ingresados exitosamente.");
        }

        static void AnalizarDatosPorLaboratorio()
        {
            Console.WriteLine("\n--- Selecciona el laboratorio para análisis ---");
            for (int indiceLab = 0; indiceLab < nombreLaboratorios.Length; indiceLab++)
                Console.WriteLine($"{indiceLab + 1}. {nombreLaboratorios[indiceLab]}");

            Console.Write("Opción: ");
            if (!int.TryParse(Console.ReadLine(), out int seleccionLab) || seleccionLab < 1 || seleccionLab > nombreLaboratorios.Length)
            {
                Console.WriteLine("Opción inválida.");
                return;
            }

            int indiceLaboratorio = seleccionLab - 1;
            Console.WriteLine($"\n Análisis de {nombreLaboratorios[indiceLaboratorio]}");

            for (int indiceEspecie = 0; indiceEspecie < nombreEspecies.Length; indiceEspecie++)
            {
                Console.WriteLine($"\n {nombreEspecies[indiceEspecie]}:");

                for (int indiceCondicion = 0; indiceCondicion < condicionesAmbientales.Length; indiceCondicion++)
                {
                    double suma = 0;
                    double maximo = double.MinValue;
                    double minimo = double.MaxValue;

                    for (int dia = 0; dia < cantidadDias; dia++)
                    {
                        for (int indiceSesion = 0; indiceSesion < horariosSesion.Length; indiceSesion++)
                        {
                            double valor = reactividad[indiceLaboratorio, indiceEspecie, indiceCondicion, dia, indiceSesion];
                            suma += valor;
                            if (valor > maximo) maximo = valor;
                            if (valor < minimo) minimo = valor;
                        }
                    }

                    double promedio = suma / (cantidadDias * horariosSesion.Length);
                    Console.WriteLine($" {condicionesAmbientales[indiceCondicion]}: Prom = {promedio:F2}, Máx = {maximo}, Mín = {minimo}");
                }
            }
        }
    }
}
