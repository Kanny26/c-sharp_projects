using System;

namespace TiendaDecoracionNavideña
{
    class Producto
    {
        public string Producto_navideño { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }

        public Producto(string nombre, double precio)
        {
            Producto_navideño = nombre;
            Precio = precio;
            Cantidad = 0;
        }

        public double CalcularSubtotal()
        {
            return Precio * Cantidad;
        }
    }

    class Venta_producto_navideño
    {
        public Producto[] Productos { get; set; }
        public DateTime FechaCompra { get; private set; }
        public double Total { get; private set; }
        public bool Regalo { get; private set; }

        public Venta_producto_navideño()
        {
            Productos = new Producto[]
            {
                new Producto("Árbol de Navidad", 50000),
                new Producto("Bolitas decorativas", 2000),
                new Producto("Muñecos de colgar", 8000),
                new Producto("Regalos pequeños", 12000),
                new Producto("Luces", 15000),
                new Producto("Guirnaldas", 15000),
                new Producto("Otros artículos de decoración", 10000)
            };
            FechaCompra = DateTime.Now;
            Total = 0;
            Regalo = false;
        }

        public void Catalogonavideño()
        {
            Console.WriteLine("Catálogo de productos:");
            for (int i = 0; i < Productos.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Productos[i].Producto_navideño} - ${Productos[i].Precio}");
            }
        }

        public void Carrito_compras(int indice, int cantidad)
        {
            if (indice >= 1 && indice <= Productos.Length)
            {
                Productos[indice - 1].Cantidad += cantidad;
            }
            else
            {
                Console.WriteLine("Producto inválido.");
            }
        }

        public void Totalcomprasnavideñas()
        {
            Total = 0;
            foreach (Producto producto in Productos)
            {
                Total += producto.CalcularSubtotal();
            }

            if (Total > 60000)
            {
                Regalo = true;
            }
        }

        public void Recibo()
        {
            Console.WriteLine("\nRecibo de compra:");
            for (int i = 0; i < Productos.Length; i++)
            {
                if (Productos[i].Cantidad > 0)
                {
                    Console.WriteLine($"{Productos[i].Producto_navideño} x{Productos[i].Cantidad} - ${Productos[i].CalcularSubtotal()}");
                }
            }
            Console.WriteLine($"Total: ${Total}");
            if (Regalo)
            {
                Console.WriteLine("Regalo: Caja de galletas");
            }
            Console.WriteLine($"Fecha de compra: {FechaCompra:dd/MM/yyyy}");
        }

        public void Devoluciones(DateTime fechaDevolucion)
        {
            TimeSpan diferencia = fechaDevolucion - FechaCompra;
            if (diferencia.Days <= 15)
            {
                Console.WriteLine("Devolución permitida.");
            }
            else
            {
                Console.WriteLine("No se permite la devolución. Han pasado más de 15 días.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Venta_producto_navideño venta = new Venta_producto_navideño();
            bool continuar = true;

            while (continuar)
            {
                venta.Catalogonavideño();
                Console.Write("\nIngrese el número del producto que desea comprar (o 0 para terminar): ");
                int opcion = int.Parse(Console.ReadLine());

                if (opcion == 0)
                {
                    continuar = false;
                    break;
                }

                Console.Write("Ingrese la cantidad: ");
                int cantidad = int.Parse(Console.ReadLine());

                venta.Carrito_compras(opcion, cantidad);
            }

            venta.Totalcomprasnavideñas();
            venta.Recibo();

            Console.Write("\nIngrese la fecha para validar devolución (dd/MM/yyyy): ");
            DateTime fechaDevolucion = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            venta.Devoluciones(fechaDevolucion);

            Console.WriteLine("\nGracias por su compra.");
        }
    }
}
