using System;

namespace Ejercicio5
{
    // Clase que representa una máquina de pinball
    public class maquina_pinball
    {
        private int puntaje, bolasRestante; // Variables para el puntaje y bolas disponibles
        private Random random; // Generador de números aleatorios

        // Constructor que inicializa los valores del juego
        public maquina_pinball()
        {
            puntaje = 0;
            bolasRestante = 5;
            random = new Random();
        }

        // Método para reducir el número de bolas restantes
        public void Bolasrestantes()
        {
            bolasRestante--;
        }

        // Método para verificar si el juego continúa
        public bool Enjuego()
        {
            return bolasRestante > 0;
        }

        // Método para mostrar el estado actual del juego
        public void Estado_juego()
        {
            Console.WriteLine($"Puntaje de juego actual: {puntaje}");
            Console.WriteLine($"Bolas restantes: {bolasRestante}");
        }

        // Método para generar un puntaje aleatorio entre 100 y 1000 puntos
        public void Generarpuntaje()
        {
            int puntos = random.Next(100, 1001);
            puntaje += puntos;
            Console.WriteLine($"¡Obtuviste {puntos} puntos!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Se crea una instancia de la máquina de pinball
            maquina_pinball pinball = new maquina_pinball();

            Console.WriteLine("🎮 Bienvenido al Pinball Digital\n");

            // Bucle principal del juego
            while (pinball.Enjuego())
            {
                Console.WriteLine("Presiona Enter para lanzar la bola...");
                Console.ReadLine(); // Espera la entrada del usuario

                pinball.Generarpuntaje(); // Genera un puntaje aleatorio
                pinball.Bolasrestantes(); // Reduce el número de bolas restantes
                pinball.Estado_juego(); // Muestra el estado actual del juego

                if (!pinball.Enjuego()) // Si no quedan bolas, el juego termina
                {
                    Console.WriteLine("\n ¡Perdiste! Game Over.");
                }
                else
                {
                    Console.WriteLine("Acabas de perder una bola.");
                }

                Console.WriteLine("--------------------------------\n");
            }

            // Mensaje de despedida y espera para cerrar la consola
            Console.WriteLine(" Gracias por jugar. ¡Tu partida ha terminado!");
            Console.ReadKey();
        }
    }
}
