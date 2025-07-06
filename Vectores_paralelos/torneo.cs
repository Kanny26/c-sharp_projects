class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenido al torneo");

        Console.WriteLine("\nEl torneo comenzará así: ");
        Console.WriteLine("\nCUARTOS DE FINAL:");
        Console.WriteLine("Equipo1 vs Equipo2");
        Console.WriteLine("Equipo3 vs Equipo4");
        Console.WriteLine("Equipo5 vs Equipo6");
        Console.WriteLine("Equipo7 vs Equipo8");

        Console.WriteLine("\n------- CUARTOS DE FINAL -------");
        string ganadorCuartos1 = JugarPartido("Equipo1", "Equipo2");
        string ganadorCuartos2 = JugarPartido("Equipo3", "Equipo4");
        string ganadorCuartos3 = JugarPartido("Equipo5", "Equipo6");
        string ganadorCuartos4 = JugarPartido("Equipo7", "Equipo8");

        Console.WriteLine("\n------- SEMIFINALES -------");
        string ganadorSemifinal1 = JugarPartido(ganadorCuartos1, ganadorCuartos2);
        string ganadorSemifinal2 = JugarPartido(ganadorCuartos3, ganadorCuartos4);

        Console.WriteLine("\n------- FINAL -------");
        string ganadorFinal = JugarPartido(ganadorSemifinal1, ganadorSemifinal2);

        Console.WriteLine("\n ¡El ganador del torneo es: " + ganadorFinal + " 🎉!");
    }

    static string JugarPartido(string equipo1, string equipo2)
    {
        int golesEquipo1, golesEquipo2;
        do
        {
            Console.WriteLine($"\n {equipo1} vs {equipo2}");
            golesEquipo1 = LeerGoles(equipo1);
            golesEquipo2 = LeerGoles(equipo2);

            if (golesEquipo1 == golesEquipo2)
            {
                Console.WriteLine("¡Empate! Se repetirá el partido hasta que haya un ganador.");
            }

        } while (golesEquipo1 == golesEquipo2);

        string ganador = golesEquipo1 > golesEquipo2 ? equipo1 : equipo2;
        Console.WriteLine($"El ganador del partido es: {ganador}");
        return ganador;
    }

    static int LeerGoles(string equipo)
    {
        int goles;
        while (true)
        {
            Console.Write($"Ingrese los goles de {equipo}: ");
            if (int.TryParse(Console.ReadLine(), out goles) && goles >= 0)
            {
                return goles;
            }
            Console.WriteLine("Entrada inválida. Debe ingresar un número entero mayor o igual a 0.");
        }
    }
}
