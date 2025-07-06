using System;

namespace Apex_News
{
    internal class Program
    {
        static void Main()
        {
            //vectores paralelos para almacenar los titulos y los contenidos 
            string[] titulos = new string[]
            {
                "Desarrollo de software",
                "Ciberseguridad a escala global",
                "Bases y seguridad cuánticos",
                "Computación híbrida"
            };

            string[] contenidos = new string[]
            {
                "Para 2028, el 75% de los ingenieros de 'software' habrán adoptado sistemas basados en IA para mejorar la eficiencia y automatizar tareas complejas.",
                "Los últimos desarrollos en IA serán cruciales a la hora de detectar y prevenir ataques, pero también hay que poner foco en su uso por parte de los ciberdelincuentes para convertirlo en una herramienta con fines poco lícitos. Por ello, la ciberseguridad dejará de ser solo un problema a resolver para las empresas, y se convertirá en un elemento primordial de seguridad a nivel nacional y global.",
                "La llegaba de los qubits permite a los ordenadores cuánticos realizar cálculos que los tradicionales tardarían mucho tiempo o no podrían. Empresas y gobiernos de todo el mundo están invirtiendo millones en su desarrollo y, según Qureca, se prevé que su mercado alcance los 106.000 millones de dólares en 2040.\r\n\r\nPero este avance, que pronto será una realidad, puede dejar obsoletos muchos métodos criptográficos convencionales, lo que supone un riesgo para la seguridad de los datos. ",
                "El punto fuerte de la computación híbrida es que permite a las empresas aprovechar nuevas tecnologías como los sistemas fotónicos, bioinformáticos, neuromórficos y cuánticos para lograr un impacto disruptivo. Su ejemplo más destacado es la IA generativa, que necesita de computación avanzada, redes y almacenamiento a gran escala para resolver problemas complejos."
            };

            // Mostrar el menú de selección de noticias
            Menu_noticias(titulos, contenidos);
        }

        //el metodo menu_noticias, contiene la lista donde estan los titulos y los contenidos de las noticias
        static void Menu_noticias(string[] titulos, string[] contenidos)
        {
            bool opcionValida = false;

            while (!opcionValida)
            {
                Console.Clear();
                Console.WriteLine("---¡Bienvenido a Apex News!---\n");
                Console.WriteLine("Selecciona una noticia para leer:");

                // Mostrar las opciones disponibles
                for (int i = 0; i < titulos.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {titulos[i]}");
                }

                // Solicitar al usuario que elija una noticia
                Console.Write("\nIngresa el número de la noticia que deseas leer: ");
                string input = Console.ReadLine();

                // Convertir la entrada del usuario a un número entero
                if (int.TryParse(input, out int opcion) && opcion >= 1 && opcion <= titulos.Length)
                {
                    // Mostrar la noticia seleccionada
                    MostrarNoticia(titulos[opcion - 1], contenidos[opcion - 1]);

                    // Confirmar si desea leer otra noticia
                    Console.WriteLine("¿Quieres leer otra noticia? (s/n)");
                    string respuesta = Console.ReadLine().ToLower();

                    if (respuesta != "s")
                    {
                        Console.WriteLine("No seleccionaste una opcion correcta");
                        Console.WriteLine("Gracias por leer Apex News. ¡Hasta pronto!");
                        opcionValida = true;
                    }
                }
                else
                {
                    // Si la entrada no es válida, mostrar mensaje de error
                    Console.WriteLine("Opción no válida. Por favor ingresa un número entre 1 y " + titulos.Length + ".");
                    Console.WriteLine("Presiona cualquier tecla para intentar de nuevo...");
                    Console.ReadKey();
                }
            }
        }

        static void MostrarNoticia(string titulo, string contenido)
        {
            Console.Clear();
            Console.WriteLine($"Has seleccionado la noticia: {titulo}\n");
            Console.WriteLine(contenido);

            Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
            Console.ReadKey();
        }
    }
}