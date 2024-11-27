using System;

class eleccion_fiesta
{
    static void Main(string[] args)
    {
        int pastel = 0, entrada = 0, platoFuerte = 0, pasabocas = 0, bebida = 0, musica = 0;

        // Selección del tipo de pastel
        Console.WriteLine("************************ BIENVENIDO ************************");
        Console.WriteLine("************ Organicemos una fiesta innolvidable ************");
        Console.WriteLine();
        Console.WriteLine("-*-*-*-*-*-*-*-*-*-SELECCION DEL PASTEL-*-*-*-*-*-*-*-*-*-");
        Console.WriteLine("Seleccione el tipo de pastel:");
        Console.WriteLine("1. Esponjoso con chocolate");
        Console.WriteLine("2. Tres leches con vainilla");
        Console.WriteLine("3. Red Velvet con frutas frias");
        pastel = Convert.ToInt32(Console.ReadLine());
        if (pastel < 1 || pastel > 3)
        {
            Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 3.");
            pastel = Convert.ToInt32(Console.ReadLine());
        }

        // Selección de la entrada
        Console.WriteLine();
        Console.WriteLine("-*-*-*-*-*-*-*-*-*- SELECCION DE lA ENTRADA -*-*-*-*-*-*-*-*-*-");
        Console.WriteLine("Seleccione el tipo de entrada:");
        Console.WriteLine("1. Mini Hamburguesas");
        Console.WriteLine("2. Tacos Mini");
        Console.WriteLine("3. Mini pizzas");
        

        entrada = Convert.ToInt32(Console.ReadLine());
        if (entrada < 1 || entrada > 3)
        {
            Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 3.");
            entrada = Convert.ToInt32(Console.ReadLine());
        }

        // Selección del plato fuerte
        Console.WriteLine();
        Console.WriteLine("-*-*-*-*-*-*-*-*-*- SELECCION DEL PLATO FUERTE -*-*-*-*-*-*-*-*-*-");
        Console.WriteLine("Seleccione el plato fuerte:");
        Console.WriteLine("1. Pollo al Horno");
        Console.WriteLine("2. Lasaña");
        Console.WriteLine("3. Arroz con Pollo");
        platoFuerte = Convert.ToInt32(Console.ReadLine());
        if (platoFuerte < 1 || platoFuerte > 3)
        {
            Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 3.");
            platoFuerte = Convert.ToInt32(Console.ReadLine());
        }

        // Selección de pasabocas
        Console.WriteLine();
        Console.WriteLine("-*-*-*-*-*-*-*-*-*- SELECCION DE LOS PASABOCAS -*-*-*-*-*-*-*-*-*-");
        Console.WriteLine("Seleccione los pasabocas:");
        Console.WriteLine("1. Patacones con guacamole");
        Console.WriteLine("2. Mini empanadas de carne y pollo");
        Console.WriteLine("3. Deditos o churros de queso");
        pasabocas = Convert.ToInt32(Console.ReadLine());
        if (pasabocas < 1 || pasabocas > 3)
        {
            Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 3.");
            pasabocas = Convert.ToInt32(Console.ReadLine());
        }

        // Selección de bebidas
        Console.WriteLine();
        Console.WriteLine("-*-*-*-*-*-*-*-*-*- SELECCION DE LA BEBIDA -*-*-*-*-*-*-*-*-*-");
        Console.WriteLine("Seleccione la bebida:");
        Console.WriteLine("1. Bebidas alcohólicas");
        Console.WriteLine("2. Jugos Naturales");
        Console.WriteLine("3. Té helado ");
        Console.WriteLine("4. Agua ");
        bebida = Convert.ToInt32(Console.ReadLine());
        if (bebida< 1 || bebida > 3)
        {
            Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 3.");
            bebida= Convert.ToInt32(Console.ReadLine());
        }
        // Selección de música
        Console.WriteLine();
        Console.WriteLine("-*-*-*-*-*-*-*-*-*- SELECCION DE LA MUSICA -*-*-*-*-*-*-*-*-*-");
        Console.WriteLine("Seleccione el tipo de música:");
        Console.WriteLine("1. Pop y rock");
        Console.WriteLine("2. Salsa y merengue");
        Console.WriteLine("3. Reggaeton viejo y cumbias");
        musica = Convert.ToInt32(Console.ReadLine());
        if (musica < 1 || musica > 3)
        {
            Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 3.");
            musica = Convert.ToInt32(Console.ReadLine());
        }

        // Imprimir la selección final
        Console.WriteLine();
        Console.WriteLine("-*-*-*-*-*-*-*-*-*- LISTA DE SELECCION -*-*-*-*-*-*-*-*-*-");
        //Console.WriteLine("\nUsted ha seleccionado:");

        // Pastel
        Console.Write("PASTEL: ");
        if (pastel == 1) Console.WriteLine("Esponjoso con chocolate");
        else if (pastel == 2) Console.WriteLine("Tres leches con vainilla");
        else if (pastel == 3) Console.WriteLine("Red Velvet con frutas frias");

        //// Entrada 
        Console.Write("ENTRADA: ");
        if (entrada == 1) Console.WriteLine("Mini Hamburguesas");
        else if (entrada == 2) Console.WriteLine("Tacos Mini");
        else if (entrada == 3) Console.WriteLine("Mini pizzas");

        //// Plato fuerte
        Console.Write("PLATO FUERTE: ");
        if (platoFuerte == 1) Console.WriteLine("Pollo al Horno");
        else if (platoFuerte == 2) Console.WriteLine("Lasaña");
        else if (platoFuerte == 3) Console.WriteLine("Arroz con Pollo");

        //// Pasabocas
        Console.Write("PASABOCAS: ");
        if (pasabocas == 1) Console.WriteLine("Patacones con guacamole");
        else if (pasabocas == 2) Console.WriteLine("Mini empanadas de carne y pollo");
        else if (pasabocas == 3) Console.WriteLine("Deditos o churros de queso");

        //// Bebida
        Console.Write("BEBIDAS: ");
        if (bebida == 1) Console.WriteLine("Bebidas alcohólicas");
        else if (bebida == 2) Console.WriteLine("Jugos Naturales");
        else if (bebida == 3) Console.WriteLine("Té helado");
        else if (bebida == 4) Console.WriteLine("Agua");

        //// Música
        Console.Write("MUSICA: ");
        if (musica == 1) Console.WriteLine("Pop y rock");
        else if (musica == 2) Console.WriteLine("Salsa y merengue");
        else if (musica == 3) Console.WriteLine("Reggaeton viejo y cumbias");
        Console.WriteLine();
        Console.WriteLine("-*-*-*-*-*-*-*-*-*- GRACIAS POR USAR ESTE PROGRAMA -*-*-*-*-*-*-*-*-*-");
    }
}