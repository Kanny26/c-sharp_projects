using System;

class Evento
{
    public string nombreEvento;
    public string lugar;
    public string fecha;
    public int numeroInvitados;

    public virtual void MostrarDetalles()
    {
        Console.WriteLine("\n=== DETALLES DEL EVENTO ===");
        Console.WriteLine("Nombre: " + nombreEvento);
        Console.WriteLine("Lugar: " + lugar);
        Console.WriteLine("Fecha: " + fecha);
        Console.WriteLine("Invitados: " + numeroInvitados);
    }
}

class Cumpleaños : Evento
{
    public string tema;

    public void PersonalizarTema()
    {
        Console.WriteLine("\nSeleccione el tema del cumpleaños:");
        Console.WriteLine("1. Superhéroes");
        Console.WriteLine("2. Princesas");
        Console.WriteLine("3. Dinosaurios");
        Console.Write("Opción: ");
        int opcion = int.Parse(Console.ReadLine());

        if (opcion == 1) tema = "Superhéroes";
        else if (opcion == 2) tema = "Princesas";
        else if (opcion == 3) tema = "Dinosaurios";
        else tema = "General";

        Console.WriteLine("Pastel personalizado con tema: " + tema);
    }
}

class Boda : Evento
{
    public string tipoCeremonia;
    public string banquete;

    public void PersonalizarBanquete()
    {
        Console.WriteLine("\nSeleccione el tipo de ceremonia:");
        Console.WriteLine("1. Religiosa");
        Console.WriteLine("2. Civil");
        Console.Write("Opción: ");
        int Cereopc = int.Parse(Console.ReadLine());

        tipoCeremonia = Cereopc == 1 ? "Religiosa" : "Civil";

        Console.WriteLine("\nSeleccione el tipo de banquete:");
        Console.WriteLine("1. Tradicional");
        Console.WriteLine("2. Vegetariano");
        Console.WriteLine("3. Internacional");
        Console.Write("Opción: ");
        int Bandaopcion = int.Parse(Console.ReadLine());

        if (Bandaopcion == 1) banquete = "Tradicional";
        else if (Bandaopcion == 2) banquete = "Vegetariano";
        else if (Bandaopcion == 3) banquete = "Internacional";
        else banquete = "General";

        Console.WriteLine("Ceremonia: " + tipoCeremonia + ", Banquete: " + banquete);
    }
}

class Concierto : Evento
{
    public string tipoMusica;

    public void PersonalizarMusica()
    {
        Console.WriteLine("\nSeleccione el tipo de música:");
        Console.WriteLine("1. Rock");
        Console.WriteLine("2. Popcion");
        Console.WriteLine("3. Electrónica");
        Console.Write("Opción: ");
        int opcion = int.Parse(Console.ReadLine());

        if (opcion == 1) tipoMusica = "Rock";
        else if (opcion == 2) tipoMusica = "Popcion";
        else if (opcion == 3) tipoMusica = "Electrónica";
        else tipoMusica = "General";

        Console.WriteLine("Artistas de música " + tipoMusica + " contratados.");
    }
}

class ProgramaEventos
{
    static void Main()
    {
        int opcioncion;

        do
        {
            Console.WriteLine("\n=== MENÚ DE EVENTOS ===");
            Console.WriteLine("1. Organizar Cumpleaños");
            Console.WriteLine("2. Organizar Boda");
            Console.WriteLine("3. Organizar Concierto");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opcionción: ");
            opcioncion = int.Parse(Console.ReadLine());

            if (opcioncion >= 1 && opcioncion <= 3)
            {
                Evento evento;

                if (opcioncion == 1) evento = new Cumpleaños();
                else if (opcioncion == 2) evento = new Boda();
                else evento = new Concierto();

                Console.WriteLine("\nSeleccione el nombre del evento:");
                if (opcioncion == 1)
                {
                    Console.WriteLine("1. Cumpleaños de Stephany");
                    Console.WriteLine("2. Fiesta Infantil");
                    Console.WriteLine("3. Celebración de 15 años");
                }
                else if (opcioncion == 2)
                {
                    Console.WriteLine("1. Boda de Laura y Cris");
                    Console.WriteLine("2. Ceremonia de Amor");
                    Console.WriteLine("3. Boda Clásica");
                }
                else
                {
                    Console.WriteLine("1. Rock Fest");
                    Console.WriteLine("2. Noche de Talentos");
                    Console.WriteLine("3. Festival de Música");
                }

                Console.Write("Opción: ");
                int nombreOpcion = int.Parse(Console.ReadLine());

                string[,] nombres = {
                    { "Cumpleaños de Stephany", "Fiesta Infantil", "Celebración de 15 años" },
                    { "Boda de Laura y Cris", "Ceremonia de Amor", "Boda Clásica" },
                    { "Rock Fest", "Noche de Talentos", "Festival de Música" }
                };

                evento.nombreEvento = nombres[opcioncion - 1, nombreOpcion - 1];

                Console.WriteLine("\nSeleccione el lugar:");
                Console.WriteLine("1. Salón Central");
                Console.WriteLine("2. Jardines del Lago");
                Console.WriteLine("3. Playa Dorada");
                Console.Write("Opción: ");
                int lugarOp = int.Parse(Console.ReadLine());
                string[] lugares = { "Salón Central", "Jardines del Lago", "Playa Dorada" };
                evento.lugar = lugares[lugarOp - 1];

                Console.WriteLine("\nSeleccione la fecha:");
                Console.WriteLine("1. 10/06/2025");
                Console.WriteLine("2. 24/05/2025");
                Console.WriteLine("3. 31/09/2025");
                Console.Write("Opción: ");
                int fechaOp = int.Parse(Console.ReadLine());
                string[] fechas = { "10/06/2025", "24/05/2025", "31/09/2025" };
                evento.fecha = fechas[fechaOp - 1];

                Console.WriteLine("\nSeleccione el número de invitados:");
                Console.WriteLine("1. 15");
                Console.WriteLine("2. 20");
                Console.WriteLine("3. 50");
                Console.Write("Opción: ");
                int invOp = int.Parse(Console.ReadLine());
                int[] invitados = { 15, 20, 50 };
                evento.numeroInvitados = invitados[invOp - 1];

                if (evento is Cumpleaños cumple)
                    cumple.PersonalizarTema();
                else if (evento is Boda boda)
                    boda.PersonalizarBanquete();
                else if (evento is Concierto concierto)
                    concierto.PersonalizarMusica();

                evento.MostrarDetalles();
            }

        } while (opcioncion != 4);

        Console.WriteLine("Gracias por usar el sistema.");
    }
}
