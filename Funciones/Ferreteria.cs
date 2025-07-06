using System;

namespace ferreteria
{
    internal class Program
    {
        // Método principal que se ejecuta al iniciar el programa
        static void Main(string[] args)
        {
            // Llama al método TotalCompra para iniciar el proceso de compra
            TotalCompra();
        }

        // Método que muestra el menú de productos disponibles en la ferretería
        static void Menu()
        {
            Console.WriteLine("Bienvenido a nuestra ferretería");
            Console.WriteLine("Listado de materiales:");
            Console.WriteLine("1. Martillos - $20,000");
            Console.WriteLine("2. Destornilladores - $15,000");
            Console.WriteLine("3. Llaves ajustables - $12,000");
            Console.WriteLine("4. Tornillos y clavos - $500");
            Console.WriteLine("5. Tuercas y arandelas - $800");
            Console.WriteLine("6. Lijas - $1,200");
            Console.WriteLine("7. Pinturas para interiores y exteriores - $30,000");
            Console.WriteLine("8. Cemento - $50,000");
            Console.WriteLine("\nIngresa el número del material que desea comprar: ");
        }

        // Método que gestiona la compra de productos
        static void TotalCompra()
        {
            // Vector de precios de los productos
            int[] precios = { 20000, 15000, 12000, 500, 800, 1200, 30000, 50000 };
            // Vector de nombres de los productos
            string[] nombres = { "Martillos", "Destornilladores", "Llaves ajustables", "Tornillos y clavos", "Tuercas y arandelas", "Lijas", "Pinturas", "Cemento" };

            int totalCompra = 0; // Variable para almacenar el total de la compra
            int cantidad; // Variable para almacenar la cantidad de productos a comprar
            int opcion; // Variable para almacenar la opción seleccionada por el usuario

            // Muestra el menú de productos
            Menu();
            // Lee la opción seleccionada por el usuario
            opcion = Convert.ToInt32(Console.ReadLine());

            // Validar que la opción esté dentro del rango de productos disponibles
            if (opcion < 1 || opcion > 8) // empieza desde 1 hasta 8 
            {
                Console.WriteLine("Opción no válida."); // Mensaje de error si la opción es inválida
                // No se usa return, simplemente se continúa
            }
            else
            {
                Console.WriteLine("\nIngrese la cantidad que desea comprar: ");
                // Lee la cantidad de productos a comprar
                cantidad = Convert.ToInt32(Console.ReadLine());

                // Calcular el total de la compra multiplicando el precio unitario por la cantidad
                totalCompra = precios[opcion - 1] * cantidad;

                // Muestra el total de la compra utilizando el método MostrarTotal
                MostrarTotal(nombres[opcion - 1], cantidad, precios[opcion - 1], totalCompra);
            }
        }

        // Método que muestra el resumen de la compra
        static void MostrarTotal(string producto, int cantidad, int precioUnitario, int total)
        {
            Console.WriteLine($"Producto: {producto}"); // Muestra el nombre del producto
            Console.WriteLine($"Cantidad: {cantidad}"); // Muestra la cantidad comprada
            Console.WriteLine($"Precio unitario: ${precioUnitario}"); // Muestra el precio unitario del producto
            Console.WriteLine($"Total de la compra: ${total}"); // Muestra el total de la compra
        }
    }
}