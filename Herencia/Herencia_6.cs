using System;

class ProductoOptico
{
    public string nombreProducto;
    public double precio;
    public string materialLente;
    public string tipoLente;

    public virtual void CalcularPrecioFinal()
    {
        Console.WriteLine("Precio final del producto: $" + precio);
    }

    public void MostrarInformacion()
    {
        Console.WriteLine("Producto: " + nombreProducto);
        Console.WriteLine("Material del lente: " + materialLente);
        Console.WriteLine("Tipo de lente: " + tipoLente);
        Console.WriteLine("Precio base: $" + precio);
    }

    public void ElegirTipoLente()
    {
        Console.WriteLine("Seleccione el tipo de lente:");
        Console.WriteLine("1. Miopía");
        Console.WriteLine("2. Hipermetropía");
        Console.WriteLine("3. Astigmatismo");
        Console.Write("Opción: ");
        string opcion = Console.ReadLine();

        if (opcion == "1") { tipoLente = "Miopía"; }
        else if (opcion == "2") { tipoLente = "Hipermetropía"; }
        else if (opcion == "3") { tipoLente = "Astigmatismo"; }
        else { tipoLente = "Desconocido"; }
    }
}

class Gafas : ProductoOptico
{
    public string tipoMontura;

    public Gafas()
    {
        nombreProducto = "Gafas";
        precio = 150000;
        materialLente = "Cristal";
        tipoMontura = "No seleccionada";
    }

    public void ElegirMontura()
    {
        Console.WriteLine("Seleccione el tipo de montura:");
        Console.WriteLine("1. Plástica");
        Console.WriteLine("2. Metálica");
        Console.WriteLine("3. Deportiva");
        Console.Write("Opción: ");
        string opcion = Console.ReadLine();

        if (opcion == "1") { tipoMontura = "Plástica"; }
        else if (opcion == "2") { tipoMontura = "Metálica"; }
        else if (opcion == "3") { tipoMontura = "Deportiva"; }
        else { tipoMontura = "Desconocida"; }
    }

    public void AjustarMontura()
    {
        Console.WriteLine("Ajustando montura para mejor adaptación...");
        precio += 20000;
    }

    public void PersonalizarLentes()
    {
        Console.WriteLine("Personalizando lentes según prescripción...");
        precio += 30000;
    }

    public override void CalcularPrecioFinal()
    {
        Console.WriteLine("Tipo de montura: " + tipoMontura);
        Console.WriteLine("Precio final con servicios: $" + precio);
    }
}

class LentesContacto : ProductoOptico
{
    public string tipoUso;

    public LentesContacto()
    {
        nombreProducto = "Lentes de Contacto";
        precio = 100000;
        materialLente = "Plástico";
        tipoUso = "No seleccionado";
    }

    public void ElegirUso()
    {
        Console.WriteLine("Seleccione el tipo de uso:");
        Console.WriteLine("1. Diarias");
        Console.WriteLine("2. Mensuales");
        Console.Write("Opción: ");
        string opcion = Console.ReadLine();

        if (opcion == "1") { tipoUso = "Diarias"; }
        else if (opcion == "2") { tipoUso = "Mensuales"; }
        else { tipoUso = "Desconocido"; }
    }

    public void EntrenamientoUso()
    {
        Console.WriteLine("Realizando entrenamiento para uso correcto...");
        precio += 15000;
    }

    public void RecomendarTipo()
    {
        Console.WriteLine("Recomendando tipo de lentes según prescripción...");
        precio += 10000;
    }

    public override void CalcularPrecioFinal()
    {
        Console.WriteLine("Tipo de uso: " + tipoUso);
        Console.WriteLine("Precio final con servicios: $" + precio);
    }
}

class ProgramaOptica
{
    static void Main()
    {
        int opcionProducto = 0;

        while (opcionProducto != 3)
        {
            Console.WriteLine("\n--- MENÚ DE PRODUCTOS ÓPTICOS ---");
            Console.WriteLine("1. Comprar Gafas");
            Console.WriteLine("2. Comprar Lentes de Contacto");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            string entrada = Console.ReadLine();
            opcionProducto = int.Parse(entrada);

            if (opcionProducto == 1)
            {
                Gafas gafas = new Gafas();
                gafas.ElegirTipoLente();
                gafas.ElegirMontura();
                Console.WriteLine("\nInformación del producto:");
                gafas.MostrarInformacion();

                Console.WriteLine("\n¿Desea ajustar la montura? (1. Sí / 2. No)");
                string ajustar = Console.ReadLine();
                if (ajustar == "1") { gafas.AjustarMontura(); }

                Console.WriteLine("¿Desea personalizar los lentes? (1. Sí / 2. No)");
                string personalizar = Console.ReadLine();
                if (personalizar == "1") { gafas.PersonalizarLentes(); }

                Console.WriteLine("\n--- RESUMEN DE COMPRA ---");
                gafas.CalcularPrecioFinal();
            }
            else if (opcionProducto == 2)
            {
                LentesContacto lentes = new LentesContacto();
                lentes.ElegirTipoLente();
                lentes.ElegirUso();
                Console.WriteLine("\nInformación del producto:");
                lentes.MostrarInformacion();

                Console.WriteLine("\n¿Desea recibir entrenamiento de uso? (1. Sí / 2. No)");
                string entrenar = Console.ReadLine();
                if (entrenar == "1") { lentes.EntrenamientoUso(); }

                Console.WriteLine("¿Desea recibir recomendación de tipo? (1. Sí / 2. No)");
                string recomendar = Console.ReadLine();
                if (recomendar == "1") { lentes.RecomendarTipo(); }

                Console.WriteLine("\n--- RESUMEN DE COMPRA ---");
                lentes.CalcularPrecioFinal();
            }
            else if (opcionProducto == 3)
            {
                Console.WriteLine("Gracias por visitar la óptica.");
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }
    }
}
