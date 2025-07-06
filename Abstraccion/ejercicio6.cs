using System;

namespace Ejercicio6
{
    public class reproductorMusica
    {
        // Arreglo para almacenar hasta 100 canciones
        public string[] listaCanciones = new string[100]; // proceso de almacenamiento

        // Contador de canciones agregadas
        public int cantidadCanciones = 0; // proceso de conteo

        // Método para mostrar mensaje al agregar canción
        public void Agregarcancion(String Cancion)
        {
            Console.WriteLine($"La cancion {Cancion} fue agregada con exito"); // proceso de salida
        }

        // Método para simular reproducción de canción
        public void Reproducircancion(String Cancion)
        {
            Console.WriteLine($"{Cancion} Reproduciendo..."); // proceso de salida
        }

        // Mensaje si la canción no está en la lista
        public void Nodisponible()
        {
            Console.WriteLine("La cancion que deseas buscar no esta disponible en nuestra lista"); // proceso de salida
        }

        // Mensaje si no hay canciones en la lista
        public void Sincanciones()
        {
            Console.WriteLine("No hay canciones disponibles en la lista aun..."); // proceso de salida
        }

        // Mostrar una canción de la lista
        public void CancionesLista(String Cancion) 
        {
            Console.WriteLine($"* {Cancion}"); // proceso de salida
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            reproductorMusica Canciones = new reproductorMusica(); // proceso de creación de objeto
            int opc = 0; // proceso de inicialización

            // Menú interactivo hasta que el usuario seleccione salir (4)
            while (opc != 4)
            {
                Console.WriteLine("\n****** Reproductor de Música ******"); // proceso de salida
                Console.WriteLine("1. Agregar canción"); // proceso de salida
                Console.WriteLine("2. Reproducir canción"); // proceso de salida
                Console.WriteLine("3. Mostrar lista de canciones"); // proceso de salida
                Console.WriteLine("4. Salir"); // proceso de salida
                Console.Write("Seleccione una opción: "); // proceso de salida

                opc = Convert.ToInt32(Console.ReadLine()); // proceso de entrada y conversión

                if (opc == 1)
                {
                    // Agregar canción si hay espacio disponible
                    if (Canciones.cantidadCanciones < Canciones.listaCanciones.Length)
                    {
                        Console.WriteLine("Ingrese el nombre de la canción que desea agregar: "); // proceso de salida
                        string nuevaCancion = Console.ReadLine(); // proceso de entrada
                        Canciones.listaCanciones[Canciones.cantidadCanciones] = nuevaCancion; // proceso de asignación
                        Canciones.cantidadCanciones++; // proceso de incremento
                        Canciones.Agregarcancion(nuevaCancion); // proceso de método
                    }
                    else
                    {
                        Console.WriteLine("No se pueden agregar mas canciones ha alcanzado el limite"); // proceso de salida
                    }
                }

                if (opc == 2)
                {
                    // Buscar y reproducir canción si está en la lista
                    Console.WriteLine("Ingrese el nombre de la cancion para reproducirla"); // proceso de salida
                    string buscar = Console.ReadLine(); // proceso de entrada
                    bool encontrada = false; // proceso de inicialización

                    for (int i = 0; i < Canciones.cantidadCanciones; i++) // proceso de búsqueda
                    {
                        if (Canciones.listaCanciones[i] == buscar) // proceso de comparación
                        {
                            Canciones.Reproducircancion(buscar); // proceso de método
                            encontrada = true; // proceso de asignación
                            break;
                        }
                    }

                    if (!encontrada)
                    {
                        Canciones.Nodisponible(); // proceso de método
                    }
                }

                if (opc == 3) 
                {
                    // Mostrar lista de canciones agregadas
                    Console.WriteLine("Listado de canciones disponibles: "); // proceso de salida
                    if (Canciones.cantidadCanciones == 0)
                    {
                        Canciones.Sincanciones(); // proceso de método
                    }
                    else
                    {
                        for (int i = 0; i < Canciones.cantidadCanciones; i++) // proceso de recorrido
                        {
                            Canciones.CancionesLista(Canciones.listaCanciones[i]); // proceso de método
                        }
                    }
                }

                if (opc == 4)
                {
                    Console.WriteLine("¡Vuelve pronto!"); // proceso de salida
                }

                if (opc < 1 || opc > 4)
                {
                    Console.WriteLine("Opcion invalida, intenta de nuevo"); // proceso de salida
                }
            }
        }
    }
}
