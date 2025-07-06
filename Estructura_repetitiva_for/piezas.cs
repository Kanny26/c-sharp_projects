using System;

class Program
{
    static void Main()
    {
        // Saludo inicial
        Console.WriteLine("Bienvenido al programa de verificación tamaño de las piezas.");

        // Solicitar la cantidad de piezas a ingresar
        Console.Write("Ingrese la cantidad de piezas: ");
        int cantidadPiezas = int.Parse(Console.ReadLine());

        // Inicializar contador de piezas aptas
        int piezasAptas = 0;

        // Bucle para ingresar la longitud de cada pieza
        for (int i = 1; i <= cantidadPiezas; i++)
        {
            Console.Write($"Ingrese la longitud de la pieza {i} en cm: ");
            int longitud = int.Parse(Console.ReadLine());

            // Verificar si la pieza está dentro del rango apto
            if (longitud >= 120 && longitud <= 130)
            {
                piezasAptas++;
            }
        }

        // Mostrar el resultado
        Console.WriteLine($"Cantidad de piezas aptas: {piezasAptas}");

        // Despedida
        Console.WriteLine("Gracias por usar el programa. ¡Hasta luego!");
    }
}