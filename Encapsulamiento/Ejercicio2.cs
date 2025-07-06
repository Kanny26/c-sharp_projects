using System;

namespace Encapsulamiento2
{
    // Clase que representa un creador de objetos que maneja materiales y permite fabricar objetos
    class CreadorDeObjetos
    {
        // Array que almacena la cantidad disponible de cada material
        private int[] materialesCantidad = new int[6];

        // Array con los nombres de los materiales disponibles
        private string[] materiales =
        {
            "Tablón de madera",
            "Diamante",
            "Lingote de hierro",
            "Bloque de piedra",
            "Palo",
            "Cuero"
        };


        // Método que muestra una guía con los materiales necesarios para fabricar diferentes objetos
        public void MostrarGuiaMateriales()
        {
            Console.WriteLine("\n--- Guía de Materiales Necesarios ---");

            Console.WriteLine("Para fabricar una Espada de Madera:");
            Console.WriteLine("  - 2 Tablones de madera");
            Console.WriteLine("  - 1 Palo\n");

            Console.WriteLine("Para fabricar una Espada de Hierro:");
            Console.WriteLine("  - 2 Lingotes de hierro");
            Console.WriteLine("  - 1 Palo\n");

            Console.WriteLine("Para fabricar una Espada de Diamante:");
            Console.WriteLine("  - 2 Diamantes");
            Console.WriteLine("  - 1 Palo\n");

            Console.WriteLine("Para fabricar un Casco de Cuero:");
            Console.WriteLine("  - 5 Cuero\n");

            Console.WriteLine("Para fabricar una Pechera de Hierro:");
            Console.WriteLine("  - 8 Lingotes de hierro");
            Console.WriteLine("  - 5 Cuero\n");

            Console.WriteLine("Para fabricar Pantalones de Cuero:");
            Console.WriteLine("  - 7 Cuero\n");

            Console.WriteLine("Para fabricar Botas de Cuero:");
            Console.WriteLine("  - 3 Cuero\n");
        }

        // Método para agregar materiales al inventario
        public void AgregarMaterial()
        {
            bool continuar = true; // Controla el ciclo de agregar materiales

            while (continuar)
            {
                Console.WriteLine("Seleccione el material que desea agregar: ");
                // Muestra la lista de materiales disponibles con índice para selección
                for (int i = 0; i < materiales.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {materiales[i]}");
                }
                Console.Write("Opción: ");

                // Lee la opción del usuario y ajusta para índice base cero
                int opcion = int.Parse(Console.ReadLine()) - 1;

                // Verifica que la opción seleccionada sea válida
                if (opcion >= 0 && opcion < materiales.Length)
                {
                    Console.Write("Cantidad: ");
                    int cantidad = int.Parse(Console.ReadLine()); // Lee la cantidad a agregar
                    materialesCantidad[opcion] += cantidad; // Suma la cantidad en el inventario
                    Console.WriteLine($"{cantidad} {materiales[opcion]} agregado correctamente.");

                    // Pregunta si desea agregar otro material
                    Console.WriteLine("\n¿Desea agregar algún otro material? (1. Sí) (2. No)");
                    int opcion1 = int.Parse(Console.ReadLine());

                    if (opcion1 == 1)
                    {
                        continuar = true;
                    }
                    else if (opcion1 == 2)
                    {
                        continuar = false;
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                }
            }
        }

        // Método para mostrar el inventario con la cantidad de cada material
        public void VerInventario()
        {
            Console.WriteLine("\nInventario:");
            for (int i = 0; i < materiales.Length; i++)
            {
                Console.WriteLine($"{materiales[i]}: {materialesCantidad[i]}");
            }
        }

        public void Menu()
        {
            while (true) 
            {
                Console.WriteLine("\n¿Desea continuar?");
                Console.WriteLine("1.Volver al guia de materiales");
                Console.WriteLine("2.Crear una espada");
                Console.WriteLine("3.Crear una armadura");
                Console.WriteLine("4.Salir");
                Console.WriteLine("Seleccione una opcion: ");
                int opcion2 = int.Parse(Console.ReadLine());

                if (opcion2 == 1)
                {
                    MostrarGuiaMateriales();
                }
                else if (opcion2 == 2)
                {
                    FabricarEspada();// Permite fabricar una espada
                }
                else if (opcion2 == 3)
                {
                    FabricarArmadura();// Permite fabricar una pieza de armadura
                }
                else
                {
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                }
                if (opcion2 == 4)
                {
                    Console.WriteLine("Gracias por jugar :) ");
                    return;
                }
            }
            
        }
        // Método para fabricar espadas verificando si hay suficientes materiales
        public void FabricarEspada()
        {
            string[] espadas = { "Espada de madera", "Espada de hierro", "Espada de diamante" };
            int opcionEspada = SeleccionarOpcion("\n¿Qué espada fabricaremos hoy?", espadas);

            // Fabrica la espada según la opción seleccionada y verifica insumos
            if (opcionEspada == 1) // Espada de madera
            {
                // Requiere 2 Tablones de madera y 1 Palo
                if (materialesCantidad[0] >= 2 && materialesCantidad[4] >= 1)
                {
                    materialesCantidad[0] -= 2;
                    materialesCantidad[4] -= 1;
                    Console.WriteLine("Espada de madera fabricada.");
                }
                else
                {
                    Console.WriteLine("No tienes los materiales necesarios para fabricar una espada de madera.");
                }
            }
            else if (opcionEspada == 2) // Espada de hierro
            {
                // Requiere 2 Lingotes de hierro y 1 Palo
                if (materialesCantidad[2] >= 2 && materialesCantidad[4] >= 1)
                {
                    materialesCantidad[2] -= 2;
                    materialesCantidad[4] -= 1;
                    Console.WriteLine("Espada de hierro fabricada.");
                }
                else
                {
                    Console.WriteLine("No tienes los materiales necesarios para fabricar una espada de hierro.");
                }
            }
            else if (opcionEspada == 3) // Espada de diamante
            {
                // Requiere 2 Diamantes y 1 Palo
                if (materialesCantidad[1] >= 2 && materialesCantidad[4] >= 1)
                {
                    materialesCantidad[1] -= 2;
                    materialesCantidad[4] -= 1;
                    Console.WriteLine("Espada de diamante fabricada.");
                }
                else
                {
                    Console.WriteLine("No tienes los materiales necesarios para fabricar una espada de diamante.");
                }
            }
            

        }

        // Método para fabricar partes de armadura verificando materiales
        public void FabricarArmadura()
        {
            string[] armaduras = { "Casco de cuero", "Pechera de hierro", "Pantalones de cuero", "Botas de cuero" };
            int opcionArmadura = SeleccionarOpcion("\n¿Qué parte de la armadura fabricaremos hoy?", armaduras);

            // Fabrica la parte seleccionada y verifica insumos
            if (opcionArmadura == 1) // Casco de cuero
            {
                if (materialesCantidad[5] >= 5)  // 5 de Cuero
                {
                    materialesCantidad[5] -= 5;
                    Console.WriteLine("Casco de cuero fabricado.");
                }
                else
                {
                    Console.WriteLine("No tienes los materiales necesarios para fabricar un casco de cuero.");
                }
            }
            else if (opcionArmadura == 2) // Pechera de hierro
            {
                if (materialesCantidad[2] >= 8 && materialesCantidad[5] >= 5)  // 8 Lingotes de hierro y 5 Cuero
                {
                    materialesCantidad[2] -= 8;
                    materialesCantidad[5] -= 5;
                    Console.WriteLine("Pechera de hierro fabricada.");
                }
                else
                {
                    Console.WriteLine("No tienes los materiales necesarios para fabricar una pechera de hierro.");
                }
            }
            else if (opcionArmadura == 3) // Pantalones de cuero
            {
                if (materialesCantidad[5] >= 7)  // 7 Cuero
                {
                    materialesCantidad[5] -= 7;
                    Console.WriteLine("Pantalones de cuero fabricados.");
                }
                else
                {
                    Console.WriteLine("No tienes los materiales necesarios para fabricar pantalones de cuero.");
                }
            }
            else if (opcionArmadura == 4) // Botas de cuero
            {
                if (materialesCantidad[5] >= 3)  // 3 Cuero
                {
                    materialesCantidad[5] -= 3;
                    Console.WriteLine("Botas de cuero fabricadas.");
                }
                else
                {
                    Console.WriteLine("No tienes los materiales necesarios para fabricar botas de cuero.");
                }
            }
        }

        // Método genérico para mostrar opciones y obtener selección válida del usuario
        private int SeleccionarOpcion(string mensaje, string[] opciones)
        {
            int opcion;
            do
            {
                Console.WriteLine(mensaje);
                // Muestra las opciones disponibles para seleccionar
                for (int i = 0; i < opciones.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {opciones[i]}");
                }
                Console.Write("Seleccione una opción: ");
                bool esNumero = int.TryParse(Console.ReadLine(), out opcion);

                // Valida que la opción sea un número dentro del rango válido
                if (esNumero && opcion >= 1 && opcion <= opciones.Length)
                {
                    return opcion;
                }
                else
                {
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                }
            } while (true);
        }
    }

    // Clase con método Main para ejecutar el programa
    internal class Program
    {
        static void Main(string[] args)
        {
            CreadorDeObjetos creador = new CreadorDeObjetos(); // Instancia del creador

            creador.MostrarGuiaMateriales();   // Muestra la guía de materiales al iniciar
            creador.AgregarMaterial();         // Permite agregar materiales al inventario
            creador.VerInventario();            // Muestra el inventario actualizado
            creador.Menu();                      //Menu para fabricaciones 
        }
    }
}