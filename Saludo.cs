using System;

namespace Ejercicio1
{
    class Saludo
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hola,ingresa tu nombre: ");
            string name= Console.ReadLine();
            Console.WriteLine("Hola " +name);
            Console.WriteLine("ingrese un pais");
            string country= Console.ReadLine();
            Console.WriteLine("Ingrese la capital del pais");
            string capital = Console.ReadLine();
            Console.WriteLine("El pais ingresado por: " +name +" fue " +country  +" cuya capital es " +capital);
        }
    }
}
