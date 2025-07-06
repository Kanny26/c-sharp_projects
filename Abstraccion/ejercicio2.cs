using System;

namespace Ejercicio2
{
    public class RegistroPagos
    {
        //declarar el atributo
        public double monto_pago;

        // Método para asignar un valor al monto del pago
        public void Asignar(double monto)
        {
            monto_pago = monto;
        }

        // Método para imprimir el mensaje de pago
        public void Pago()
        {
            Console.WriteLine($"Pago de ${monto_pago} realizado con éxito.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese la cantidad de pagos que desea realizar: ");
            int cantidadPagos = int.Parse(Console.ReadLine());

            //ciclo para que el usuario ingrese cuantos pagos realizara
            for (int i = 1; i <= cantidadPagos; i++)
            {
                Console.Write($"Ingrese el monto del pago {i}: ");
                double monto = double.Parse(Console.ReadLine());

                RegistroPagos pago = new RegistroPagos(); // Crear nueva instancia para cada pago
                pago.Asignar(monto);
                pago.Pago();
            }

            Console.WriteLine("Todos los pagos han sido procesados.");
        }
    }
}
