using System;

// Clase que representa un bloque con un nombre y una categoría
class Bloque
{
    private string nombre; // Nombre del bloque
    private string categoria; // Categoría del bloque

    // Constructor que inicializa el bloque con un nombre y una categoría
    public Bloque(string nombreBloque, string categoriaBloque)
    {
        nombre = nombreBloque;
        categoria = categoriaBloque;
    }

    // Método para obtener el nombre del bloque
    public string ObtenerNombre()
    {
        return nombre;
    }

    // Método para obtener la descripción del bloque (nombre y categoría)
    public string ObtenerDescripcion()
    {
        return nombre + " (" + categoria + ")";
    }
}

// Clase que representa un inventario de bloques
class Inventario
{
    private Bloque[] bloques = new Bloque[5]; // Array para almacenar bloques, con un tamaño máximo de 5
    private int cantidad = 0; // Contador de bloques en el inventario

    // Método para agregar un bloque al inventario
    public void AgregarBloque(Bloque bloque)
    {
        if (cantidad < bloques.Length) // Verifica si hay espacio en el inventario
        {
            bloques[cantidad] = bloque; // Agrega el bloque al inventario
            cantidad++; // Incrementa la cantidad de bloques
            Console.WriteLine("Bloque agregado: " + bloque.ObtenerDescripcion());
        }
        else
        {
            Console.WriteLine("El inventario está lleno."); // Mensaje si el inventario está lleno
        }
    }

    // Método para eliminar un bloque del inventario por su índice
    public void EliminarBloque(int indice)
    {
        if (indice >= 0 && indice < cantidad) // Verifica si el índice es válido
        {
            Console.WriteLine("Bloque eliminado: " + bloques[indice].ObtenerDescripcion());

            // Desplaza los elementos hacia atrás para llenar el espacio vacío
            for (int i = indice; i < cantidad - 1; i++)
            {
                bloques[i] = bloques[i + 1];
            }

            // Limpia el último espacio
            bloques[cantidad - 1] = null;
            cantidad--; // Decrementa la cantidad de bloques
        }
        else
        {
            Console.WriteLine("Índice inválido."); // Mensaje si el índice no es válido
        }
    }

    // Método para mostrar el inventario actual
    public void MostrarInventario()
    {
        Console.WriteLine("\nInventario actual:");
        if (cantidad == 0) // Verifica si el inventario está vacío
        {
            Console.WriteLine("El inventario está vacío.");
        }
        else
        {
            // Muestra cada bloque en el inventario
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine("- " + bloques[i].ObtenerDescripcion());
            }
        }
    }
}
class Program
{
    static void Main()
    {
        Inventario inventario = new Inventario(); // Crea una instancia del inventario

        //Datos de bloques por categoría
        string[] categorias = {
            "Bloques de construcción",
            "Bloques de recursos",
            "Bloques funcionales",
            "Bloques naturales",
            "Bloques de decoración",
            "Bloques interactivos",
            "Bloques del Nether",
            "Bloques del End"
        };

        // Array de bloques organizados por categoría
        string[][] bloquesPorCategoria = {
            new string[] { "Piedra", "Madera", "Ladrillos", "Piedra lisa", "Bloques de lana" },
            new string[] { "Mineral de hierro", "Mineral de diamante", "Mineral de oro", "Esmeralda" },
            new string[] { "Cofre", "Mesa de trabajo", "Horno", "Bloque de obsidiana", "Bloque de redstone" },
            new string[] { "Hierba", "Tierra", "Arena", "Agua", "Lava" },
            new string[] { "Maceta de flores", "Lámpara de piedra roja", "Escultura de nieve", "Estatua de la cabeza de mobs" },
            new string[] { "Puerta", "Escalera", "Alma de bloque", "Trampilla" },
            new string[] { "Netherrack", "Soul Soil", "Bloque de cuarzo", "Ladrillo de magma" },
            new string[] { "End Stone", "Perla de Ender", "Obelisco del End" }
        };

        bool continuar = true; // Variable para controlar el bucle del menú

        while (continuar) // Bucle para mostrar el menú hasta que el usuario decida salir
        {
            // Muestra el menú principal
            Console.WriteLine("\nMENÚ PRINCIPAL:");
            Console.WriteLine("1. Agregar bloque");
            Console.WriteLine("2. Ver inventario");
            Console.WriteLine("3. Eliminar bloque");
            Console.WriteLine("4. Salir");
            Console.Write("Elige una opción (1-4): ");
            string opcion = Console.ReadLine(); // Lee la opción del usuario

            if (opcion == "1") // Opción para agregar un bloque
            {
                Console.WriteLine("\nCategorías disponibles:");
                // Muestra las categorías disponibles
                for (int i = 0; i < categorias.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + categorias[i]);
                }

                Console.Write("Elige una categoría (1-" + categorias.Length + "): ");
                int numCat;
                // Intenta convertir la entrada en un número válido de categoría
                if (int.TryParse(Console.ReadLine(), out numCat) && numCat >= 1 && numCat <= categorias.Length)
                {
                    string categoriaSeleccionada = categorias[numCat - 1];
                    string[] bloques = bloquesPorCategoria[numCat - 1];

                    Console.WriteLine("\nBloques disponibles en " + categoriaSeleccionada + ":");
                    // Muestra los bloques disponibles dentro de la categoría seleccionada
                    for (int j = 0; j < bloques.Length; j++)
                    {
                        Console.WriteLine((j + 1) + ". " + bloques[j]);
                    }

                    Console.Write("Elige un bloque (1-" + bloques.Length + "): ");
                    int numBloque;
                    // Intenta convertir la entrada en un número válido de bloque
                    if (int.TryParse(Console.ReadLine(), out numBloque) && numBloque >= 1 && numBloque <= bloques.Length)
                    {
                        // Crea una nueva instancia de Bloque con el nombre y categoría seleccionados
                        Bloque nuevo = new Bloque(bloques[numBloque - 1], categoriaSeleccionada);
                        // Agrega el nuevo bloque al inventario
                        inventario.AgregarBloque(nuevo);
                    }
                    else
                    {
                        Console.WriteLine("Número de bloque no válido."); // Mensaje si la selección de bloque es inválida
                    }
                }
                else
                {
                    Console.WriteLine("Número de categoría no válido."); // Mensaje si la selección de categoría es inválida
                }
            }
            else if (opcion == "2") // Opción para ver el inventario actual
            {
                inventario.MostrarInventario();
            }
            else if (opcion == "3") // Opción para eliminar un bloque del inventario
            {
                inventario.MostrarInventario(); // Muestra los bloques actuales

                Console.Write("\nElige el número del bloque que deseas eliminar (empezando en 1): ");
                int indice;
                // Intenta obtener un índice válido para eliminar el bloque
                if (int.TryParse(Console.ReadLine(), out indice))
                {
                    inventario.EliminarBloque(indice - 1); // Elimina el bloque seleccionado
                }
                else
                {
                    Console.WriteLine("Entrada inválida."); // Mensaje si la entrada no es un número válido
                }
            }
            else if (opcion == "4") // Opción para salir del programa
            {
                continuar = false; // Finaliza el bucle
                Console.WriteLine("¡Hasta luego!");
            }
            else
            {
                Console.WriteLine("Opción no válida. Por favor, elige entre 1 y 4."); // Mensaje para opciones inválidas
            }
        }
    }
}
