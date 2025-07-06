using System;

namespace PresionArterial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"¿A cuántos pacientes les medirá la presión?: ");
            int pacientes = int.Parse(Console.ReadLine());

            int[] pres_sistolica = new int[pacientes];
            int[] pres_diastolica = new int[pacientes];

            for (int i = 0; i < pacientes; i++)
            {
                Console.WriteLine($"Ingrese la presión arterial sistólica del paciente {i + 1}:");
                pres_sistolica[i] = int.Parse(Console.ReadLine());

                Console.WriteLine($"Ingrese la presión arterial diastólica del paciente {i + 1}:");
                pres_diastolica[i] = int.Parse(Console.ReadLine());
            }

            // Inicializar con los valores del primer paciente
            int pres_sis_min = pres_sistolica[0], pres_sis_max = pres_sistolica[0];
            int pres_dis_min = pres_diastolica[0], pres_dis_max = pres_diastolica[0];
            int suma_sis = 0, suma_dis = 0;

            for (int i = 0; i < pacientes; i++)
            {
                // Actualizar mínimos y máximos
                if (pres_sistolica[i] < pres_sis_min) pres_sis_min = pres_sistolica[i];
                if (pres_sistolica[i] > pres_sis_max) pres_sis_max = pres_sistolica[i];
                if (pres_diastolica[i] < pres_dis_min) pres_dis_min = pres_diastolica[i];
                if (pres_diastolica[i] > pres_dis_max) pres_dis_max = pres_diastolica[i];

                // Sumar para calcular el promedio
                suma_sis += pres_sistolica[i];
                suma_dis += pres_diastolica[i];
            }

            decimal promedio_sistolica = (decimal)suma_sis / pacientes;
            decimal promedio_diastolica = (decimal)suma_dis / pacientes;

            Console.WriteLine($"\nResultados:");
            Console.WriteLine($"Presión sistólica más baja: {pres_sis_min}");
            Console.WriteLine($"Presión sistólica más alta: {pres_sis_max}");
            Console.WriteLine($"Presión diastólica más baja: {pres_dis_min}");
            Console.WriteLine($"Presión diastólica más alta: {pres_dis_max}");
            Console.WriteLine($"Promedio presión sistólica: {promedio_sistolica:F2}");
            Console.WriteLine($"Promedio presión diastólica: {promedio_diastolica:F2}");

            // Clasificar a los pacientes
            Console.WriteLine("\nClasificación de los pacientes:");
            for (int i = 0; i < pacientes; i++)
            {
                string categoria = ClasificarPresion(pres_sistolica[i], pres_diastolica[i]);
                Console.WriteLine($"Paciente {i + 1}: {pres_sistolica[i]}/{pres_diastolica[i]} mmHg - {categoria}");
            }
        }

        static string ClasificarPresion(int sistolica, int diastolica)
        {
            if (sistolica < 90 || diastolica < 60) return "Hipotensión";
            if (sistolica < 120 && diastolica < 80) return "Normal";
            if (sistolica < 130 && diastolica < 80) return "Elevada";
            if (sistolica < 140 || diastolica < 90) return "Hipertensión Etapa 1";
            return "Hipertensión Etapa 2";
        }
    }
}
