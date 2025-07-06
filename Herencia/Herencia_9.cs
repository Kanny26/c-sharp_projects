using System;

class Animal {
    public string nombre;
    public string especie;
    public int edad;
    public float peso;
    public string historialMedico = "";

    public void RealizarConsulta() {
        Console.WriteLine("Consulta realizada para: " + nombre);
        historialMedico += "Consulta general\n";
    }

    public void MostrarHistorial() {
        Console.WriteLine("Historial médico de " + nombre + ":");
        Console.WriteLine(historialMedico);
    }

    public void ActualizarHistorial(string entrada) {
        historialMedico += entrada + "\n";
    }
}

class Perro : Animal {
    public void Vacunar() {
        Console.WriteLine("Vacuna aplicada para moquillo, rabia y parvovirus.");
        ActualizarHistorial("Vacuna aplicada (moquillo, rabia, parvovirus)");
    }

    public void Desparacitar() {
        Console.WriteLine("Tratamiento antipulgas y desparasitante aplicado.");
        ActualizarHistorial("Tratamiento antipulgas y desparasitación");
    }
}

class Gato : Animal {
    public void Vacunar() {
        Console.WriteLine("Vacuna aplicada para leucemia felina y rabia.");
        ActualizarHistorial("Vacuna aplicada (leucemia felina, rabia)");
    }

    public void Esterilizar() {
        Console.WriteLine("Esterilización realizada.");
        ActualizarHistorial("Esterilización realizada");
    }
}

class Ave : Animal {
    public void TratarEnfermedadRespiratoria() {
        Console.WriteLine("Tratamiento para enfermedad respiratoria aplicado.");
        ActualizarHistorial("Tratamiento para enfermedad respiratoria");
    }

    public void CuidadoDePlumas() {
        Console.WriteLine("Cuidado de plumas realizado.");
        ActualizarHistorial("Cuidado de plumas");
    }
}

class Roedor : Animal {
    public void ControlDental() {
        Console.WriteLine("Control dental realizado.");
        ActualizarHistorial("Control dental");
    }

    public void TratamientoDigestivo() {
        Console.WriteLine("Tratamiento digestivo aplicado.");
        ActualizarHistorial("Tratamiento digestivo");
    }
}

class Programa {
    static void Main() {
        int opcion = 0;
        while (opcion != 6) {
            Console.WriteLine("\n--- Sistema de Veterinaria ---");
            Console.WriteLine("1. Registrar perro");
            Console.WriteLine("2. Registrar gato");
            Console.WriteLine("3. Registrar ave");
            Console.WriteLine("4. Registrar roedor");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            if (opcion == 1) {
                Perro perro = new Perro();
                Console.Write("Nombre: ");
                perro.nombre = Console.ReadLine();
                perro.especie = "Perro";
                Console.Write("Edad: ");
                perro.edad = int.Parse(Console.ReadLine());
                Console.Write("Peso: ");
                perro.peso = float.Parse(Console.ReadLine());

                perro.RealizarConsulta();
                perro.Vacunar();
                perro.Desparacitar();
                perro.MostrarHistorial();

            } else if (opcion == 2) {
                Gato gato = new Gato();
                Console.Write("Nombre: ");
                gato.nombre = Console.ReadLine();
                gato.especie = "Gato";
                Console.Write("Edad: ");
                gato.edad = int.Parse(Console.ReadLine());
                Console.Write("Peso: ");
                gato.peso = float.Parse(Console.ReadLine());

                gato.RealizarConsulta();
                gato.Vacunar();
                gato.Esterilizar();
                gato.MostrarHistorial();

            } else if (opcion == 3) {
                Ave ave = new Ave();
                Console.Write("Nombre: ");
                ave.nombre = Console.ReadLine();
                ave.especie = "Ave";
                Console.Write("Edad: ");
                ave.edad = int.Parse(Console.ReadLine());
                Console.Write("Peso: ");
                ave.peso = float.Parse(Console.ReadLine());

                ave.RealizarConsulta();
                ave.TratarEnfermedadRespiratoria();
                ave.CuidadoDePlumas();
                ave.MostrarHistorial();

            } else if (opcion == 4) {
                Roedor roedor = new Roedor();
                Console.Write("Nombre: ");
                roedor.nombre = Console.ReadLine();
                roedor.especie = "Roedor";
                Console.Write("Edad: ");
                roedor.edad = int.Parse(Console.ReadLine());
                Console.Write("Peso: ");
                roedor.peso = float.Parse(Console.ReadLine());

                roedor.RealizarConsulta();
                roedor.ControlDental();
                roedor.TratamientoDigestivo();
                roedor.MostrarHistorial();

            } else if (opcion == 5) {
                Console.WriteLine("Saliendo del sistema...");
                opcion = 6;
            } else {
                Console.WriteLine("Opción no válida.");
            }
        }
    }
}
