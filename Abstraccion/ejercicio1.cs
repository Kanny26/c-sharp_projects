using System;

namespace Ejercicio1
{
    public class Dispositivo()
    {
        public bool encendido;
        public int bateria;
        public void encender()
        {
            encendido = true;
            Console.WriteLine("El dispositivo está encendido");
        }
        public void apagar() 
        { 
            encendido = false;
            Console.WriteLine("El dispositivo está apagado");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dispositivo encendido1 = new Dispositivo();
            Console.WriteLine("Ingresa el porcentaje de bateria del dispositivo: ");
            encendido1.bateria = Convert.ToInt32(Console.ReadLine());
            if (encendido1.bateria > 1 && encendido1.bateria  < 101  )
            {
                encendido1.encender();
            }
            else if (encendido1.bateria <= 0)
            {
                encendido1.apagar();
            }
       
        }
    }
}
