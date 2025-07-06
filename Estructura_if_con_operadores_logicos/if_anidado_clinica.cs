using System;

class If_anidado_clinica
{
    static void Main(string[] args)
    {
        Console.WriteLine("------BIENVENID@ A LA CLÍNICA ARMANDO PAREDES-------");
        Console.WriteLine();
        Console.WriteLine("¿Desea consultar nuestros servicios de ecografías?");
        Console.WriteLine("1. Si");
        Console.WriteLine("2. No");
        Console.Write("Elija una opción: ");
        int servicios = int.Parse(Console.ReadLine());

        if (servicios == 1)
        {
            Console.WriteLine();
            Console.WriteLine("-*-*--SERVICIOS--*-*-");
            Console.WriteLine("\nEn nuestro consultorio contamos con los siguientes servicios:");
            Console.WriteLine("1. Ecografía Transvaginal. Valor $ 100.000");
            Console.WriteLine("2. Ecografía Pélvica. Valor $ 90.000");
            Console.WriteLine("3. Ecografía de Próstata. Valor $ 80.000");
            Console.WriteLine("4. Ecografía de abdomen. Valor $ 150.000");
            Console.WriteLine("5. Ecografía de tejidos. Valor $ 120.000");
            Console.Write("Elija una opción: ");
            int tipo_cita = int.Parse(Console.ReadLine());

            string servicio = "";
            if (tipo_cita == 1)
            {
                servicio = "Ecografía Transvaginal";
            }
            else if (tipo_cita == 2)
            {
                servicio = "Ecografía Pélvica";
            }
            else if (tipo_cita == 3)
            {
                servicio = "Ecografía de Próstata";
            }
            else if (tipo_cita == 4)
            {
                servicio = "Ecografía de abdomen";
            }
            else if (tipo_cita == 5)
            {
                servicio = "Ecografía de tejidos";
            }
            else
            {
                Console.WriteLine("Opción no válida.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("-*-*--DOCTOR@--*-*-");
            Console.Write("\n¿Desea que su ecografía sea realizada por un Doctor (1) o una Doctora (2)?: ");
            int Doctor = int.Parse(Console.ReadLine());
            string doctor;

            if (Doctor == 1)
            {
                doctor = "Dr. Sergio Rodriguez";
            }
            else if (Doctor == 2)
            {
                doctor = "Dra. Maria Gonzalez";
            }
            else
            {
                Console.WriteLine("Opción no válida.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("-*-*--DATOS PACIENTE--*-*-");
            Console.Write("\nIngrese el nombre del/la paciente: ");
            string nombrePaciente = Console.ReadLine();
            Console.Write("Ingrese el apellido del/la paciente: ");
            string apellidoPaciente = Console.ReadLine();
            Console.Write("Ingrese el teléfono del/la paciente: ");
            string telefono = Console.ReadLine();
            Console.Write("Ingrese la edad del/la paciente: ");
            int edad = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("-*-*--DATOS CITA--*-*-");
            Console.WriteLine("\nPor último indícanos la hora y fecha para agendar tu cita.");
            Console.WriteLine("Manejamos un Horario de 8 A.M a 12 P.M");
            Console.Write("Ingrese la hora a la que desea agendar su cita: ");
            int hora = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el día en el que desea agendar su cita (formato numérico): ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el mes en el que desea agendar su cita: ");
            int mes = int.Parse(Console.ReadLine());

            if (hora >= 8 && hora <= 12)
            {
                Console.WriteLine($"\nGracias por tu espera {nombrePaciente}, tu {servicio} quedó agendada para el día {dia} del mes {mes} a las {hora} del día");
                Console.WriteLine($"y será atendid@ por el {doctor}.");
            }
            else
            {
                Console.WriteLine("La hora ingresada no está dentro del horario de atención (8 A.M a 12 P.M).");
            }
        }
        else
        {
            Console.WriteLine("Gracias por su visita.");
        }
    }
}