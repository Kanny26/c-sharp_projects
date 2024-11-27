using System;

namespace encuesta_Correcta { 
    class encuesta
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hola,ingresa tu nombre: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hola " + name);
            Console.WriteLine("¿Tinto o Latte?");
            string coffe = Console.ReadLine();
            Console.WriteLine("¿Color azul o verde?");
            string color = Console.ReadLine();
            Console.WriteLine("¿Dubai o Paris?");
            string city = Console.ReadLine();
            Console.WriteLine("Las elecciones de: " + name + " fueron para bebida " + coffe + " el color " +color + " la ciudad " + city);
        }
    }
}