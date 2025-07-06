using System;

class BatallaTierraMedia
{
    static void Main()
    {
        // Puntos que obtendrá cada raza
        int[] Raza_bondadosa = { 1, 2, 3, 4, 5 }; // Pelosos, Sureños buenos, Enanos, Númenóreanos, Elfos
        int[] Raza_Malvado = { 2, 2, 2, 3, 5 };   // Sureños malos, Orcos, Goblins, Huargos, Trolls

        // Solicitar datos del ejército bondadoso
        int[] ejercitoBondadoso = new int[5];
        Console.WriteLine("Ingresa el número de integrantes de cada raza bondadosa:");
        Console.Write("Pelosos: ");
        ejercitoBondadoso[0] = int.Parse(Console.ReadLine());
        Console.Write("Sureños buenos: ");
        ejercitoBondadoso[1] = int.Parse(Console.ReadLine());
        Console.Write("Enanos: ");
        ejercitoBondadoso[2] = int.Parse(Console.ReadLine());
        Console.Write("Númenóreanos: ");
        ejercitoBondadoso[3] = int.Parse(Console.ReadLine());
        Console.Write("Elfos: ");
        ejercitoBondadoso[4] = int.Parse(Console.ReadLine());

        // Solicitar datos del ejército malvado
        int[] ejercitoMalvado = new int[5];
        Console.WriteLine("\nIngresa el número de integrantes de cada raza malvada:");
        Console.Write("Sureños malos: ");
        ejercitoMalvado[0] = int.Parse(Console.ReadLine());
        Console.Write("Orcos: ");
        ejercitoMalvado[1] = int.Parse(Console.ReadLine());
        Console.Write("Goblins: ");
        ejercitoMalvado[2] = int.Parse(Console.ReadLine());
        Console.Write("Huargos: ");
        ejercitoMalvado[3] = int.Parse(Console.ReadLine());
        Console.Write("Trolls: ");
        ejercitoMalvado[4] = int.Parse(Console.ReadLine());

        // Calcular poder total de cada ejército
        int poderBondadoso = 0;
        int poderMalvado = 0;

        for (int i = 0; i < 5; i++)
        {
            poderBondadoso += Raza_bondadosa[i] * ejercitoBondadoso[i];
            poderMalvado += Raza_Malvado[i] * ejercitoMalvado[i];
        }

        // Determinar resultado de la batalla
        Console.WriteLine("\nResultado de la batalla:");
        if (poderBondadoso > poderMalvado)
        {
            Console.WriteLine("¡El bien triunfa sobre el mal!");
        }
        else if (poderBondadoso < poderMalvado)
        {
            Console.WriteLine("¡El mal domina la Tierra Media!");
        }
        else
        {
            Console.WriteLine("¡La batalla termina en empate!");
        }
    }
}
