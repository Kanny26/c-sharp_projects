using System;

class Program
{
    static void Main()
    {
        // Nombres de productos y días
        string[] productos = { "Pan Francés", "Pan Dulce", "Croissant", "Empanadas", "Galletas" };
        string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };

        // Declaramos la matriz para guardar la cantidad producida [producto, día]
        int[,] produccion = new int[5, 7]; // 5 filas (productos), 7 columnas (días)

        // Llenar la matriz con datos que el usuario ingresa
        for (int i = 0; i < productos.Length; i++) // Recorremos productos
        {
            Console.WriteLine($"\n--- {productos[i]} ---");

            for (int j = 0; j < dias.Length; j++) // Recorremos días
            {
                Console.Write($"Cantidad producida el {dias[j]}: ");
                produccion[i, j] = int.Parse(Console.ReadLine()); // Guardamos el valor en la matriz
            }
        }

        // Mostrar la tabla de producción
        Console.WriteLine("\n----- Resumen de Producción -----\n");

        // Imprimir los nombres de los días (encabezado de columnas)
        Console.Write("\t");
        for (int j = 0; j < dias.Length; j++)
        {
            Console.Write(dias[j] + "\t");
        }
        Console.WriteLine();

        // Imprimir los valores de la matriz
        for (int i = 0; i < productos.Length; i++)
        {
            Console.Write(productos[i] + "\t"); // Nombre del producto

            for (int j = 0; j < dias.Length; j++)
            {
                Console.Write(produccion[i, j] + "\t\t"); // Valor producido por día
            }

            Console.WriteLine(); 
        }
    }
}
