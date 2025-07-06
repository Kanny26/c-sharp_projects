using System;

namespace HomeAccesories
{
    class Accesorios
    {
        public string Accesorios_hogar { get; set; }
        public double Precio { get; set; }
        public int cantidad { get; set; }

        public Accesorios(string producto, double precio)
        {
            Accesorios_hogar = producto;
            Precio = precio;
            cantidad = 0;
        }

        public double CalcularCompra()
        {
            return Precio * cantidad;
        }
    }

    class ventaCosasparahogar
    {
        public Accesorios[] Accesorio { get; set; }
        public double Total { get; set; }
        public DateTime FechaCompra { get; private set; }

        public ventaCosasparahogar()
        {
            Accesorio = new Accesorios[]
            {
                new Accesorios("Sofa Azul oscuro", 950000),
                new Accesorios("Sofa Negro", 1200000),
                new Accesorios("Sofa Marron", 1300000),
                new Accesorios("Mesa de Madera de roble", 1500000),
                new Accesorios("Mesa de Madera de pino", 1550000),
                new Accesorios("Cuadros de impresionismo", 150000),
                new Accesorios("Cuadros Abstractos", 180000),
                new Accesorios("Estufa de inducción", 1200000),
                new Accesorios("Estufa de Integral", 1200000),
            };
            FechaCompra = DateTime.Now;
            Total = 0;
        }

        public void CatalogoHogar()
        {
            Console.WriteLine("");
            Console.WriteLine("Catalogo de Accesorios: ");

            for (int i = 0; i < Accesorio.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Accesorio[i].Accesorios_hogar} - ${Accesorio[i].Precio}");
            }
        }

        public void Carrito_Compras(int indice, int cantidad)
        {
            if (indice >= 1 && indice <= Accesorio.Length)
            {
                Accesorio[indice - 1].cantidad += cantidad;
            }
            else
            {
                Console.WriteLine("Producto inválido.");
            }
        }

        public void TotalCompras()
        {
            Total = 0;
            for (int i = 0; i < Accesorio.Length; i++)
            {
                Total += Accesorio[i].CalcularCompra();
            }

            if (Total > 2000000)
            {
                Total *= 0.7; // Aplica el 30% de descuento si la compra supera los 2,000,000
            }
        }

        public void Recibo()
        {
            Console.WriteLine("\nRecibo de compra:");
            Console.WriteLine("");
            for (int i = 0; i < Accesorio.Length; i++)
            {
                if (Accesorio[i].cantidad > 0)
                {
                    Console.WriteLine($"{Accesorio[i].Accesorios_hogar} x {Accesorio[i].cantidad} - ${Accesorio[i].CalcularCompra()}");
                }
            }
            Console.WriteLine($"Total: ${Total}");
            Console.WriteLine($"Fecha de compra: {FechaCompra:dd/MM/yyyy}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ventaCosasparahogar venta = new ventaCosasparahogar();
            bool continuar = true;
            double saldoTarjeta = 0;
            double saldoTarjetaRegalo = 0;
            double saldoTarjetaCompra = 0;

            while (continuar)
            {
                Console.WriteLine("*  -   *   -   *   HOMEACCESORIES   *  -   *  -   *");
                Console.WriteLine("\n Bienvenido a la tienda de accesorios para el hogar");
                Console.WriteLine("   1. Ver catálogo de productos");
                Console.WriteLine("   2. Ver saldo de tarjeta");
                Console.WriteLine("   3. Obtener tarjeta de regalo");
                Console.WriteLine("   4. Obtener tarjeta de compras");
                Console.WriteLine("   5. Realizar compra");
                Console.WriteLine("   0. Salir");
                Console.Write("\nIngrese una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    venta.CatalogoHogar();    
                }
                else if (opcion == 2)
                {
                    Console.WriteLine($"\nSaldo de la tarjeta: ${saldoTarjeta}");
                }
                else if (opcion == 3)
                {
                    Console.Write("\nIngrese el monto para la tarjeta de regalo: ");
                    saldoTarjetaRegalo = double.Parse(Console.ReadLine());
                }
                else if (opcion == 4)
                {
                    Console.Write("\nIngrese el monto para la tarjeta de compras: ");
                    saldoTarjetaCompra = double.Parse(Console.ReadLine());
                }
                else if (opcion == 5)
                {
                    bool seguirComprando = true;
                    while (seguirComprando)
                    {
                        venta.CatalogoHogar();
                        Console.Write("\nIngrese el número del producto que desea comprar (o 0 para terminar): ");
                        int opcionProducto = int.Parse(Console.ReadLine());

                        if (opcionProducto == 0)
                        {
                            seguirComprando = false;
                            break;
                        }

                        Console.Write("Ingrese la cantidad: ");
                        int cantidad = int.Parse(Console.ReadLine());

                        venta.Carrito_Compras(opcionProducto, cantidad);
                        Console.Write("\n¿Desea agregar otro producto? (s/n): ");
                        char respuesta = char.Parse(Console.ReadLine().ToLower());

                        if (respuesta == 'n')
                        {
                            seguirComprando = false;
                            break;
                        }
                    }

                    venta.TotalCompras();
                    venta.Recibo();
                }
                else if (opcion == 0)
                {
                    continuar = false;
                }
                else
                {
                    Console.WriteLine("\nOpción inválida. Intente de nuevo.");
                }
            }

            Console.WriteLine("\nGracias por visitar nuestra tienda.");
        }
    }
}
