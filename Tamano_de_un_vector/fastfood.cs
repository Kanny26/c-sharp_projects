using System;

class Program
{
    static void Main()
    {
        string[] platos_principales = new string[]
        {
            "Pollo asado - arepa - papa - sopa        $35000",
            "Pollo broaster - arepa - papa - sopa     $38000",
            "Alas de pollo - papa francesa            $27000",
            "Carne asada - arepa - papa - sopa        $23000",
            "Carne ordeada - yuca - papa - sopa       $28000"
        };
        int[] precios_platos = { 35000, 38000, 27000, 23000, 28000 };

        string[] adicionales = new string[]
        {
            "Arepa",
            "Papa o yuca",
            "Papa francesa",
            "Sopa",
            "Arepa y papa"
        };
        int[] precios_adicionales = { 9000, 12000, 15000, 8000, 14000 };

        string[] horarios = new string[]
        {
            "Lunes a Domingo de 11:30am a 9pm"
        };

        Gestion_Platos(platos_principales, precios_platos, adicionales, precios_adicionales, horarios);
    }

    static void Gestion_Platos(string[] platos_principales, int[] precios_platos, string[] adicionales, int[] precios_adicionales, string[] horarios)
    {
        bool opcionValida = false;
        while (!opcionValida)
        {
            Console.Clear();
            Console.WriteLine("BIENVENIDO AL SISTEMA DE PEDIDOS DE FAST FOOD");
            Console.WriteLine("--- Si deseas comer bueno, te esperamos ---");
            Console.WriteLine("Elige una operación: ");
            Console.WriteLine("1. Ver menú");
            Console.WriteLine("2. Ordenar");
            Console.WriteLine("3. Ver horarios");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                MostrarMenu(platos_principales, adicionales, precios_adicionales);
            }
            else if (opcion == "2")
            {
                Ordenar(platos_principales, precios_platos, adicionales, precios_adicionales);
            }
            else if (opcion == "3")
            {
                Console.Clear();
                Console.WriteLine("Horarios: ");
                foreach (var horario in horarios)
                {
                    Console.WriteLine(horario);
                }
                Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Opción no válida. Por favor ingresa 1, 2 o 3.");
                Console.WriteLine("Presiona cualquier tecla para intentar de nuevo...");
                Console.ReadKey();
            }
        }
    }

    static void MostrarMenu(string[] platos_principales, string[] adicionales, int[] precios_adicionales)
    {
        Console.Clear();
        Console.WriteLine("-----------PLATOS FASTFOOD-----------       PRECIOS: ");
        Console.WriteLine("");
        for (int i = 0; i < platos_principales.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {platos_principales[i]}");
        }

        Console.WriteLine("\n¿Desea ver el menu de adicionales (s/n)?");
        string respuesta = Console.ReadLine().ToLower();

        if (respuesta == "s")
        {
            Console.WriteLine("Mostrando el menú de adicionales...");
            Console.WriteLine("\nMENÚ DE ADICIONALES: ");
            for (int i = 0; i < adicionales.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {adicionales[i]} - ${precios_adicionales[i]}");
            }
        }

        Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
        Console.ReadKey();
    }

    static void Ordenar(string[] platos_principales, int[] precios_platos, string[] adicionales, int[] precios_adicionales)
    {
        Console.Clear();
        Console.WriteLine("ORDENAR: ");
        Console.WriteLine("\n¿Cuántas órdenes deseas realizar?");
        int cantidadOrdenes = int.Parse(Console.ReadLine());

        List<string> pedidos = new List<string>();
        int totalGeneral = 0;

        for (int i = 0; i < cantidadOrdenes; i++)
        {
            Console.WriteLine($"\nOrden {i + 1}:");
            Console.WriteLine("Ingresa el nombre del comensal:");
            string nombre = Console.ReadLine();

            Console.WriteLine("\nSelecciona el plato principal (1-5): ");
            for (int j = 0; j < platos_principales.Length; j++)
            {
                Console.WriteLine($"{j + 1}. {platos_principales[j]}");
            }
            int platoSeleccionado = int.Parse(Console.ReadLine()) - 1;
            int precioPlato = precios_platos[platoSeleccionado];

            Console.WriteLine("\n¿Desea agregar un adicional a su pedido? (s/n)");
            string respuesta = Console.ReadLine().ToLower();

            int precioAdicional = 0;
            string adicionalTexto = "No se agregó adicional";
            if (respuesta == "s")
            {
                Console.WriteLine("\nMENÚ DE ADICIONALES: ");
                for (int k = 0; k < adicionales.Length; k++)
                {
                    Console.WriteLine($"{k + 1}. {adicionales[k]} - ${precios_adicionales[k]}");
                }
                int adicionalSeleccionado = int.Parse(Console.ReadLine()) - 1;
                precioAdicional = precios_adicionales[adicionalSeleccionado];
                adicionalTexto = $"{adicionales[adicionalSeleccionado]} - ${precioAdicional}";
            }

            int total = precioPlato + precioAdicional;
            totalGeneral += total;
            pedidos.Add($"\nNombre: {nombre}\nPlato: {platos_principales[platoSeleccionado]}\nAdicional: {adicionalTexto}\nTotal: ${total}\n---------------------");

        }

        Console.Clear();
        Console.WriteLine("\n-------- FACTURA --------");
        foreach (var pedido in pedidos)
        {
            Console.WriteLine(pedido);
        }
        Console.WriteLine($"TOTAL GENERAL A PAGAR: ${totalGeneral}");
        Console.WriteLine("--------------------------");

        Console.WriteLine("\n¡Gracias por ordenar! Presiona cualquier tecla para volver al menú...");
        Console.ReadKey();
    }
}