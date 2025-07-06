using System;

namespace EvaluacionUniversitaria
{
    internal class Program
    {
        static string[] facultades = {
            "Facultad de Ingeniería",
            "Facultad de Ciencias",
            "Facultad de Humanidades",
            "Facultad de Economía",
            "Facultad de Salud"
        };

        static string[] carreras = { "Carrera 1", "Carrera 2", "Carrera 3", "Carrera 4" };
        static string[] cursos = { "Curso A", "Curso B", "Curso C", "Curso D", "Curso E" };

        static double[,,] calificaciones = new double[facultades.Length, carreras.Length, cursos.Length];

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Sistema de Evaluación Universitaria ---");
                Console.WriteLine("1. Ingresar calificaciones");
                Console.WriteLine("2. Ver análisis por facultad");
                Console.WriteLine("3. Salir");
                Console.Write("Selecciona una opción: ");

                string entrada = Console.ReadLine();
                int opcion;

                if (!int.TryParse(entrada, out opcion))
                {
                    Console.WriteLine(" Entrada inválida.");
                    continue;
                }

                if (opcion == 1)
                    IngresarCalificaciones();
                else if (opcion == 2)
                    MostrarAnalisisFacultad();
                else if (opcion == 3)
                    break;
                else
                    Console.WriteLine(" Opción no válida.");
            }
        }

        static void IngresarCalificaciones()
        {
            Console.WriteLine("\n--- Selecciona la facultad para ingresar calificaciones ---");

            for (int i = 0; i < facultades.Length; i++)
                Console.WriteLine($"{i + 1}. {facultades[i]}");

            Console.Write("Opción: ");
            string entrada = Console.ReadLine();
            int indiceFacultad;

            if (!int.TryParse(entrada, out indiceFacultad) || indiceFacultad < 1 || indiceFacultad > facultades.Length)
            {
                Console.WriteLine(" Opción inválida.");
                return;
            }

            indiceFacultad -= 1;

            for (int indiceCarrera = 0; indiceCarrera < carreras.Length; indiceCarrera++)
            {
                Console.WriteLine($"\n{carreras[indiceCarrera]}:");

                for (int indiceCurso = 0; indiceCurso < cursos.Length; indiceCurso++)
                {
                    double valor;
                    bool valido = false;

                    while (!valido)
                    {
                        Console.Write($"  {cursos[indiceCurso]} (0.0 - 10.0): ");
                        string valorEntrada = Console.ReadLine();

                        if (double.TryParse(valorEntrada.Replace(",", "."), out valor) && valor >= 0 && valor <= 10)
                        {
                            calificaciones[indiceFacultad, indiceCarrera, indiceCurso] = valor;
                            valido = true;
                        }
                        else
                        {
                            Console.WriteLine("     Valor inválido. Intenta nuevamente.");
                        }
                    }
                }
            }

            Console.WriteLine("\n Calificaciones registradas correctamente.");
        }

        static void MostrarAnalisisFacultad()
        {
            Console.WriteLine("\n--- Selecciona la facultad para ver análisis ---");

            for (int i = 0; i < facultades.Length; i++)
                Console.WriteLine($"{i + 1}. {facultades[i]}");

            Console.Write("Opción: ");
            string entrada = Console.ReadLine();
            int indiceFacultad;

            if (!int.TryParse(entrada, out indiceFacultad) || indiceFacultad < 1 || indiceFacultad > facultades.Length)
            {
                Console.WriteLine(" Opción inválida.");
                return;
            }

            indiceFacultad -= 1;
            Console.WriteLine($"\n Análisis de {facultades[indiceFacultad]}:");

            double promedioFacultad = 0;
            double[] promediosCarreras = new double[carreras.Length];
            int totalCursos = cursos.Length * carreras.Length;

            for (int indiceCarrera = 0; indiceCarrera < carreras.Length; indiceCarrera++)
            {
                double sumaCarrera = 0;
                Console.WriteLine($"\n{carreras[indiceCarrera]}:");

                for (int indiceCurso = 0; indiceCurso < cursos.Length; indiceCurso++)
                {
                    double nota = calificaciones[indiceFacultad, indiceCarrera, indiceCurso];
                    Console.WriteLine($"  {cursos[indiceCurso]}: {nota}");
                    sumaCarrera += nota;
                }

                double promedioCarrera = sumaCarrera / cursos.Length;
                promediosCarreras[indiceCarrera] = promedioCarrera;
                promedioFacultad += sumaCarrera;
                Console.WriteLine($"  Promedio de carrera: {promedioCarrera.ToString("F2")}");
            }

            promedioFacultad /= totalCursos;
            Console.WriteLine($"\n Promedio general de la facultad: {promedioFacultad.ToString("F2")}");

            int mejor = 0, peor = 0;
            for (int i = 1; i < carreras.Length; i++)
            {
                if (promediosCarreras[i] > promediosCarreras[mejor]) mejor = i;
                if (promediosCarreras[i] < promediosCarreras[peor]) peor = i;
            }

            Console.WriteLine($" Carrera con mejor promedio: {carreras[mejor]} ({promediosCarreras[mejor]:F2})");
            Console.WriteLine($" Carrera con peor promedio: {carreras[peor]} ({promediosCarreras[peor]:F2})");
        }
    }
}
