using System;

namespace Ejercicio3
{
    // Clase que representa un cajero automático
    public class CajeroAutomatico
    {
        // Campo privado que almacena el saldo disponible en el cajero
        prublic double saldoDisponible;

        // Constructor que inicializa el saldo con un valor dado
        public CajeroAutomatico(double saldoInicial)
        {
            saldoDisponible = saldoInicial;
        }

        // Método para realizar un depósito en la cuenta
        public void Deposito(double cantidad)
        {
            saldoDisponible += cantidad; // Se suma la cantidad al saldo disponible
            Console.WriteLine($"Depósito exitoso. Nuevo saldo: ${saldoDisponible}");
        }

        // Método para realizar un retiro de la cuenta
        public void Retirar(double cantidad)
        {
            if (cantidad <= saldoDisponible) // Verifica si hay suficiente saldo
            {
                saldoDisponible -= cantidad; // Se resta la cantidad del saldo disponible
                Console.WriteLine($"Retiro exitoso. Nuevo saldo: ${saldoDisponible}");
            }
            else
            {
                Console.WriteLine("Fondos insuficientes"); // Mensaje de error si no hay saldo suficiente
            }
        }

        // Método para mostrar el saldo actual
        public void MostrarSaldo()
        {
            Console.WriteLine($"Saldo actual: ${saldoDisponible}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Se crea una instancia del cajero automático con un saldo inicial de 1000
            CajeroAutomatico cajero = new CajeroAutomatico(1000);
            int opcion;

            // Se muestra el menú de opciones
            Console.WriteLine("1. Depositar");
            Console.WriteLine("2. Retirar");
            Console.WriteLine("3. Consultar saldo");
            Console.Write("Ingrese el número según la acción a realizar: ");

            // Se obtiene la opción ingresada por el usuario y se valida que sea un número entero
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                if (opcion == 1) // Opción para depositar dinero
                {
                    Console.Write("Ingrese la cantidad a depositar: ");
                    if (double.TryParse(Console.ReadLine(), out double deposito))
                    {
                        cajero.Deposito(deposito);
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida");
                    }
                }
                else if (opcion == 2) // Opción para retirar dinero
                {
                    Console.Write("Ingrese la cantidad a retirar: ");
                    if (double.TryParse(Console.ReadLine(), out double retiro))
                    {
                        cajero.Retirar(retiro);
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida");
                    }
                }
                else if (opcion == 3) // Opción para consultar el saldo
                {
                    cajero.MostrarSaldo();
                }
                else // Manejo de opción inválida
                {
                    Console.WriteLine("Opción no válida");
                }
            }
            else // Manejo de entrada inválida
            {
                Console.WriteLine("Entrada no válida");
            }
        }
    }
}
