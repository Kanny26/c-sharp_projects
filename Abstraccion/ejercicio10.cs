using System;

// Clase que representa un gato
public class Gato
{
    public string Nombre;  // Nombre del gato
    public string Raza;    // Raza del gato
}

// Clase que representa una adopción
public class Adopcion
{
    public string NombreAdoptante; // Nombre de la persona que adopta
    public string NombreGato;      // Nombre del gato adoptado
}

internal class Program
{
    public static void Main()
    {
        // Arreglos para almacenar hasta 100 gatos y 100 adopciones
        Gato[] gatos = new Gato[100];
        Adopcion[] adopciones = new Adopcion[100];
        int totalGatos = 0;       // Número actual de gatos registrados
        int totalAdopciones = 0;  // Número actual de adopciones registradas

        int opcion;

        // Bucle principal del menú
        do
        {
            // Mostrar menú de opciones
            Console.WriteLine("\n--- MENÚ DEL REFUGIO DE GATOS ---");
            Console.WriteLine("1. Registrar un gato");
            Console.WriteLine("2. Ver gatos en adopción");
            Console.WriteLine("3. Registrar una adopción");
            Console.WriteLine("4. Ver adopciones realizadas");
            Console.WriteLine("5. Ver informe del refugio");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());  // Leer opción del usuario

            // Opción 1: Registrar un nuevo gato
            if (opcion == 1)
            {
                if (totalGatos < 100)
                {
                    Console.Write("Nombre del gato: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Raza del gato: ");
                    string raza = Console.ReadLine();

                    // Agregar gato al arreglo y aumentar el contador
                    gatos[totalGatos++] = new Gato { Nombre = nombre, Raza = raza };
                    Console.WriteLine("Gato registrado con éxito.");
                }
                else
                {
                    Console.WriteLine("Capacidad máxima de gatos alcanzada.");
                }
            }
            // Opción 2: Mostrar gatos disponibles para adopción
            else if (opcion == 2)
            {
                Console.WriteLine("\n--- GATOS DISPONIBLES ---");
                if (totalGatos == 0)
                    Console.WriteLine("No hay gatos disponibles.");
                else
                {
                    for (int i = 0; i < totalGatos; i++)
                    {
                        Console.WriteLine($"{i + 1}. Nombre: {gatos[i].Nombre} | Raza: {gatos[i].Raza}");
                    }
                }
            }
            // Opción 3: Registrar una adopción
            else if (opcion == 3)
            {
                if (totalGatos == 0)
                {
                    Console.WriteLine("No hay gatos disponibles para adoptar.");
                }
                else
                {
                    Console.Write("Nombre del adoptante: ");
                    string adoptante = Console.ReadLine();

                    Console.Write("Nombre del gato que desea adoptar: ");
                    string gatoAAdoptar = Console.ReadLine();

                    // Buscar el gato por nombre (ignorando mayúsculas/minúsculas)
                    int posicionDelGato = -1;
                    for (int i = 0; i < totalGatos; i++)
                    {
                        if (gatos[i].Nombre.ToLower() == gatoAAdoptar.ToLower())
                        {
                            posicionDelGato = i;
                            break;
                        }
                    }

                    // Si se encontró el gato, registrar la adopción y eliminarlo del arreglo
                    if (posicionDelGato != -1)
                    {
                        // Agregar a la lista de adopciones
                        adopciones[totalAdopciones++] = new Adopcion
                        {
                            NombreAdoptante = adoptante,
                            NombreGato = gatoAAdoptar
                        };

                        // Eliminar el gato del arreglo y desplazar los elementos restantes
                        for (int j = posicionDelGato; j < totalGatos - 1; j++)
                        {
                            gatos[j] = gatos[j + 1];
                        }
                        totalGatos--;

                        Console.WriteLine($"{adoptante} ha adoptado a {gatoAAdoptar}.");
                    }
                    else
                    {
                        Console.WriteLine($"El gato '{gatoAAdoptar}' no está disponible.");
                    }
                }
            }
            // Opción 4: Ver todas las adopciones realizadas
            else if (opcion == 4)
            {
                Console.WriteLine("\n--- ADOPCIONES REALIZADAS ---");
                if (totalAdopciones == 0)
                    Console.WriteLine("No se han realizado adopciones.");
                else
                {
                    for (int i = 0; i < totalAdopciones; i++)
                    {
                        Console.WriteLine($"{i + 1}. Adoptante: {adopciones[i].NombreAdoptante} | Gato: {adopciones[i].NombreGato}");
                    }
                }
            }
            // Opción 5: Ver informe del refugio
            else if (opcion == 5)
            {
                Console.WriteLine("\n--- INFORME DEL REFUGIO ---");
                Console.WriteLine($"Gatos adoptados: {totalAdopciones}");
                Console.WriteLine($"Gatos en el refugio: {totalGatos}");
                if (totalGatos == 0)
                    Console.WriteLine("El refugio está vacío.");
                else
                    Console.WriteLine("Aún hay gatos esperando adopción.");
            }
            // Opción 0: Salir del programa
            else if (opcion == 0)
            {
                Console.WriteLine("Gracias por usar el sistema de adopciones.");
            }
            // Cualquier otra opción no válida
            else
            {
                Console.WriteLine("Opción no válida.");
            }

        } while (opcion != 0);  // Repetir mientras el usuario no elija salir
    }
}
