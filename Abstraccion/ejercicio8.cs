using System;

// Clase principal que representa la joyería
class Joyeria
{
    // Arreglos para guardar los nombres y precios de hasta 100 joyas
    private string[] nombresJoyas = new string[100];
    private double[] preciosJoyas = new double[100];
    private int cantidadJoyas = 0; // Lleva el conteo de cuántas joyas se han registrado

    // Método para agregar una nueva joya al inventario
    public void AgregarJoya(string nombre, double precio)
    {
        // Verifica si la joya ya existe ignorando mayúsculas y minúsculas
        for (int i = 0; i < cantidadJoyas; i++)
        {
            if (nombresJoyas[i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("La joya ya existe en el inventario.");
                return; // Sale del método si la joya ya está registrada
            }
        }

        // Verifica que no se exceda el límite de 100 joyas
        if (cantidadJoyas >= 100)
        {
            Console.WriteLine("El inventario está lleno. No se pueden agregar más joyas.");
            return;
        }

        // Si todo está bien, agrega la joya al inventario
        nombresJoyas[cantidadJoyas] = nombre;
        preciosJoyas[cantidadJoyas] = precio;
        cantidadJoyas++; // Aumenta el contador de joyas
        Console.WriteLine($"Joya '{nombre}' agregada con precio ${precio}.");
    }

    // Método para mostrar las joyas registradas
    public void MostrarJoyas()
    {
        Console.WriteLine("\nJoyas disponibles:");
        for (int i = 0; i < cantidadJoyas; i++)
        {
            Console.WriteLine($"- {nombresJoyas[i]}: ${preciosJoyas[i]}");
        }
    }

    // Método para realizar una compra de joya y acumular el total
    public double ComprarJoya(string nombre, double total)
    {
        for (int i = 0; i < cantidadJoyas; i++)
        {
            if (nombresJoyas[i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                total += preciosJoyas[i]; // Suma el precio al total
                Console.WriteLine($"Has comprado '{nombre}' por ${preciosJoyas[i]}. Total actual: ${total}");
                return total; // Devuelve el nuevo total
            }
        }

        // Si la joya no se encuentra en el inventario
        Console.WriteLine($"La joya '{nombre}' no está disponible.");
        return total; // Devuelve el mismo total sin cambios
    }
}

// Clase principal del programa
internal class Program
{
    static void Main(string[] args)
    {
        Joyeria joyeria = new Joyeria(); // Crea una instancia de la clase Joyeria
        double totalCompra = 0; // Inicializa el total de la compra

        Console.WriteLine("=== REGISTRO DE JOYAS ===");
        Console.Write("¿Cuántas joyas desea agregar? ");

        // Valida que la entrada sea un número entero positivo
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Entrada inválida. El programa terminará.");
            return;
        }

        // Solicita y registra cada joya
        for (int i = 0; i < n; i++)
        {
            Console.Write($"\nNombre de la joya #{i + 1}: ");
            string nombre = Console.ReadLine();

            Console.Write("Precio de la joya: ");
            if (!double.TryParse(Console.ReadLine(), out double precio) || precio <= 0)
            {
                Console.WriteLine("Precio inválido. Intente nuevamente.");
                i--; // Repite la iteración para ingresar correctamente
                continue;
            }

            joyeria.AgregarJoya(nombre, precio); // Agrega la joya al inventario
        }

        // Muestra el inventario de joyas registradas
        joyeria.MostrarJoyas();

        Console.WriteLine("\n=== COMPRA DE JOYAS ===");
        Console.Write("¿Cuántas joyas desea comprar? ");
        if (!int.TryParse(Console.ReadLine(), out int m) || m <= 0)
        {
            Console.WriteLine("Entrada inválida. El programa terminará.");
            return;
        }

        // Permite comprar joyas e ir sumando al total
        for (int i = 0; i < m; i++)
        {
            Console.Write($"\nNombre de la joya a comprar #{i + 1}: ");
            string nombreCompra = Console.ReadLine();
            totalCompra = joyeria.ComprarJoya(nombreCompra, totalCompra); // Actualiza el total
        }

        // Muestra el total final de la compra
        Console.WriteLine($"\nTotal final de la compra: ${totalCompra}");
        Console.WriteLine("Gracias por su compra.");
    }
}

