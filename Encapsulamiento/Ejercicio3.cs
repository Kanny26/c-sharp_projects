using System;

class Program
{
    // Clase Pelicula: Define las características y comportamientos de una película
    class Pelicula
    {
        // Atributos privados de la clase Pelicula
        private string titulo; // Título de la película
        private double puntuacion; // Puntuación de la película
        private string descripcion; // Descripción de la película
        private bool estaEnCartelera; // Indica si la película está en cartelera

        // Constructor de la clase Pelicula
        public Pelicula(string tituloPelicula, double puntuacionPelicula, string descripcionPelicula)
        {
            titulo = tituloPelicula;  // Asignar el título de la película
            puntuacion = puntuacionPelicula; // Asignar la puntuación
            descripcion = descripcionPelicula; // Asignar la descripción
            estaEnCartelera = false; // Inicialmente, la película no está en cartelera
        }

        // Método para mejorar la puntuación de una película
        public void MejorarPuntuacion(double nuevaPuntuacion)
        {
            puntuacion = nuevaPuntuacion; // Actualiza la puntuación de la película
        }

        // Establecer que la película está en cartelera
        public void EstablecerEnCartelera()
        {
            estaEnCartelera = true; // La película pasa a estar en cartelera
        }

        // Quitar la película de cartelera
        public void QuitarDeCartelera()
        {
            estaEnCartelera = false; // La película ya no está en cartelera
        }

        // Mostrar los detalles de la película
        public void MostrarDetalles()
        {
            Console.WriteLine($"Título: {titulo}");
            Console.WriteLine($"Puntuación: {puntuacion}");
            Console.WriteLine($"Descripción: {descripcion}");
            Console.WriteLine($"En Cartelera: {estaEnCartelera}");
        }

        // Métodos para obtener los valores de los atributos
        public string ObtenerTitulo()
        {
            return titulo; // Retorna el título de la película
        }

        public double ObtenerPuntuacion()
        {
            return puntuacion; // Retorna la puntuación de la película
        }

        public bool EstaEnCartelera()
        {
            return estaEnCartelera; // Retorna si la película está o no en cartelera
        }
    }

    // Clase Catalogo: Gestiona el catálogo de películas
    class Catalogo
    {
        // Arreglo de 5 películas
        private Pelicula[] peliculas = new Pelicula[5];
        private Pelicula peliculaEnCartelera; // Película que actualmente está en cartelera

        // Constructor de la clase Catalogo
        public Catalogo()
        {
            // Inicialización de las películas con títulos, puntuaciones y descripciones
            peliculas[0] = new Pelicula("Harry Potter y la piedra filosofal", 8.5, "El joven mago Harry Potter descubre su verdadera identidad.");
            peliculas[1] = new Pelicula("Harry Potter y la cámara secreta", 8.3, "Harry Potter se enfrenta a un misterio en la escuela de magia.");
            peliculas[2] = new Pelicula("Harry Potter y el prisionero de Azkaban", 9.0, "Harry Potter descubre más sobre su pasado y enfrenta un prisionero fugado.");
            peliculas[3] = new Pelicula("Harry Potter y el cáliz de fuego", 8.7, "Harry se enfrenta a un torneo mágico peligroso.");
            peliculas[4] = new Pelicula("Harry Potter y la orden del fénix", 8.1, "Harry lidera la lucha contra el Ministerio de Magia y una nueva amenaza.");
        }

        // Ver el catálogo completo de películas
        public void VerCatalogo()
        {
            Console.WriteLine("Catálogo de películas:");
            for (int i = 0; i < peliculas.Length; i++)
            {
                peliculas[i].MostrarDetalles(); // Muestra los detalles de cada película en el catálogo
            }
        }

        // Establecer una película en cartelera
        public void EstablecerPeliculaEnCartelera(int opcion)
        {
            if (opcion >= 1 && opcion <= peliculas.Length)
            {
                if (peliculaEnCartelera != null)
                {
                    peliculaEnCartelera.QuitarDeCartelera(); // Quitar la película anterior de cartelera
                }
                peliculaEnCartelera = peliculas[opcion - 1]; // Asignar la película seleccionada
                peliculaEnCartelera.EstablecerEnCartelera(); // Establecerla como en cartelera
                Console.WriteLine($"La película '{peliculas[opcion - 1].ObtenerTitulo()}' está ahora en cartelera.");
            }
            else
            {
                Console.WriteLine("Opción no válida. Elige una película del catálogo.");
            }
        }

        // Mejorar la puntuación de una película
        public void MejorarPuntuacion(string titulo, double nuevaPuntuacion)
        {
            for (int i = 0; i < peliculas.Length; i++)
            {
                if (peliculas[i].ObtenerTitulo() == titulo)
                {
                    peliculas[i].MejorarPuntuacion(nuevaPuntuacion); // Mejorar la puntuación de la película
                    Console.WriteLine($"La puntuación de '{titulo}' ha sido mejorada.");
                    return;
                }
            }
            Console.WriteLine($"No se encontró la película '{titulo}' en el catálogo."); // En caso de no encontrar la película
        }

        // Ver detalles de la película actualmente en cartelera
        public void VerDetallesDePeliculaEnCartelera()
        {
            if (peliculaEnCartelera != null)
            {
                Console.WriteLine("Detalles de la película en cartelera:");
                peliculaEnCartelera.MostrarDetalles(); // Muestra los detalles de la película en cartelera
            }
            else
            {
                Console.WriteLine("No hay película actualmente en cartelera."); // Si no hay película en cartelera
            }
        }

        // Método para obtener las películas
        public Pelicula[] ObtenerPeliculas()
        {
            return peliculas; // Retorna el arreglo de películas
        }
    }

    static void Main(string[] args)
    {
        // Crear el catálogo de películas
        Catalogo catalogo = new Catalogo();

        // Menú interactivo para que el usuario elija qué acción realizar
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---- Catálogo de Películas de Harry Potter ----");
            Console.WriteLine("1. Ver catálogo completo");
            Console.WriteLine("2. Establecer película en cartelera");
            Console.WriteLine("3. Mejorar puntuación de una película");
            Console.WriteLine("4. Ver detalles de la película en cartelera");
            Console.WriteLine("5. Salir");
            Console.Write("Selecciona una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            // Dependiendo de la opción seleccionada, se realiza una acción
            if (opcion == 1)
            {
                catalogo.VerCatalogo(); // Mostrar todo el catálogo
            }
            else if (opcion == 2)
            {
                // Mostrar listado de películas para elegir cuál poner en cartelera
                Console.WriteLine("Seleccione el número de la película que desea poner en cartelera:");
                Pelicula[] peliculas = catalogo.ObtenerPeliculas(); // Obtener las películas

                // Mostrar las películas disponibles para elegir
                for (int i = 0; i < peliculas.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {peliculas[i].ObtenerTitulo()}");
                }

                // Leer la opción seleccionada por el usuario
                Console.Write("Ingrese el número de la película: ");
                int seleccion = int.Parse(Console.ReadLine());
                catalogo.EstablecerPeliculaEnCartelera(seleccion); // Establecer la película en cartelera
            }
            else if (opcion == 3)
            {
                // Mejorar la puntuación de una película
                Console.Write("Ingrese el título de la película para mejorar su puntuación: ");
                string titulo = Console.ReadLine();
                Console.Write("Ingrese la nueva puntuación (de 0 a 10): ");
                double nuevaPuntuacion = double.Parse(Console.ReadLine());
                catalogo.MejorarPuntuacion(titulo, nuevaPuntuacion); // Actualizar la puntuación
            }
            else if (opcion == 4)
            {
                catalogo.VerDetallesDePeliculaEnCartelera(); // Ver los detalles de la película en cartelera
            }
            else if (opcion == 5)
            {
                break; // Salir del programa
            }
            else
            {
                Console.WriteLine("Opción no válida, por favor elija de nuevo."); // Si la opción no es válida
            }

            // Esperar una tecla para continuar
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
