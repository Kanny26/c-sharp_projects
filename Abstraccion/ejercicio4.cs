using System;

namespace Ejercicio3
{
    // Clase que gestiona los datos de un paciente
    public class Gestion_pacientes
    {
        // Atributos públicos del paciente: nombre, enfermedad y edad
        public string nombre, enfermedad;
        public int edad;

        // Método para mostrar los datos del paciente
        public void datos_paciente()
        {
            Console.WriteLine($"\nEl/La paciente {nombre}, con {edad} años, cuya enfermedad es {enfermedad}");
        }

        // Método para modificar la enfermedad del paciente
        public void modificar_enfermedad(string nueva_enfermedad)
        {
            enfermedad = nueva_enfermedad; // Se actualiza la enfermedad
            Console.WriteLine($"La enfermedad del paciente {nombre} fue actualizada con éxito.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Se crea una instancia de la clase Gestion_pacientes
            Gestion_pacientes pacientes = new Gestion_pacientes();

            // Solicita al usuario los datos del paciente
            Console.Write("Ingresa el nombre del paciente: ");
            pacientes.nombre = Console.ReadLine();

            Console.Write("Ingresa la edad del paciente: ");
            pacientes.edad = int.Parse(Console.ReadLine());

            Console.Write("Ingresa la enfermedad del paciente: ");
            pacientes.enfermedad = Console.ReadLine();

            // Muestra los datos del paciente ingresado
            pacientes.datos_paciente();

            // Pregunta al usuario si desea modificar la enfermedad del paciente
            Console.Write("\n¿Desea modificar la enfermedad del paciente? (1.Sí / 2.No): ");
            int respuesta = int.Parse(Console.ReadLine());

            if (respuesta == 1) // Si el usuario desea modificar la enfermedad
            {
                Console.Write("Ingrese la nueva enfermedad: ");
                string nueva_enfermedad = Console.ReadLine();

                pacientes.modificar_enfermedad(nueva_enfermedad); // Actualiza la enfermedad
                pacientes.datos_paciente(); // Muestra los datos actualizados
            }
        }
    }
}
