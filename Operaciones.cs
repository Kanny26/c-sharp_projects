using System;

namespace Ejercicio2
{
    class Operations
    {
        static void Main(string[] args) 
            {
            int num1, num2,num3,suma,resta,multiplicacion,division;
            Console.WriteLine("Ingrese un valor");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese un valor");
            num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese un valor");
            num3 = int.Parse(Console.ReadLine());

            suma = num1 + num2;
            resta = num2 - num3;
            division = num1 / num3;
            multiplicacion = num1 * num2 * num3;

            Console.WriteLine("La suma de los numeros en la posicion 1 y 2 es: " +suma);
            Console.WriteLine("La suma de todos los numeros ingresados es: " + suma);
            Console.WriteLine("La resta de los numeros en la posicion 2 y 3: " + resta);
            Console.WriteLine("La resta de todos los numeros ingresados es: " + resta);
            Console.WriteLine("La división de los numeros en la posicion 1 y 3 es: " + division);
            Console.WriteLine("La división de todos los numeros ingresados es: " + division);
            Console.WriteLine("La multiplicacion de todos los numeros ingresados es: " + multiplicacion);
        }
    }
}