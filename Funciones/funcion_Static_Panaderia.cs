//Calcular el total de la compra en una panadería, donde el usuario ingresará la cantidad de panes comprados
//y el precio unitario, y el programa calculará el total a pagar.
//Realizar este caso con función static

using System;
class Panaderia
{
    // Función static para calcular el total a pagar
    public static float CalcularTotal(int cantidad, float precioUnitario)
    {
        return cantidad * precioUnitario; //realizar la multiplicacion de la cantidad de panes por su precio
    }

    static void Main(string[] args)
    {
        Console.Write("Bienvenido al calculo de la panaderia\n");
        // Solicitar al usuario la cantidad de panes comprados
        Console.Write("\nIngrese la cantidad de panes comprados: ");
        int cantidad = Convert.ToInt32(Console.ReadLine());

        // Solicitar al usuario el precio unitario del pan
        Console.Write("Ingrese el precio unitario del pan: ");
        float precioUnitario = Convert.ToSingle(Console.ReadLine());

        // Calcular el total a pagar utilizando la función estática
        float total = CalcularTotal(cantidad, precioUnitario);

        // Mostrar el total a pagar
        Console.WriteLine($"El total a pagar es: {total}");
    }
}