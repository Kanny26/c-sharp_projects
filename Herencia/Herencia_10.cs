using System;

class Solicitante
{
    public string nombreCompleto;
    public string paisOrigen;
    public string tipoVisa;
    public int numeroSolicitud;
    public string fechaSolicitud;

    public int puntajeRiesgo; // 0 (bajo) a 100 (alto)

    public string estadoSolicitud; // Pendiente, Aprobada, Denegada

    public bool VerificarElegibilidadGeneral()
    {
        if (nombreCompleto == "" || paisOrigen == "" || tipoVisa == "" || numeroSolicitud <= 0 || fechaSolicitud == "")
            return false;
        return true;
    }

    public virtual bool VerificarElegibilidadEspecifica()
    {
        return false;
    }

    public void ProcesarSolicitud()
    {
        if (!VerificarElegibilidadGeneral())
        {
            estadoSolicitud = "Denegada";
            Console.WriteLine("Denegado: Falta información básica.");
            return;
        }

        if (!VerificarElegibilidadEspecifica())
        {
            estadoSolicitud = "Denegada";
            Console.WriteLine("Denegado: No cumple requisitos específicos.");
            return;
        }

        // Consideramos puntajeRiesgo < 50 como aprobado
        if (puntajeRiesgo < 50)
            estadoSolicitud = "Aprobada";
        else
            estadoSolicitud = "Denegada";

        Console.WriteLine("Estado final: " + estadoSolicitud);
    }

    public virtual void Entrevista()
    {
        // En base al tipoVisa, preguntas específicas.
        // Método virtual, cada subclase lo sobreescribe.
    }

    public virtual void MostrarInforme()
    {
        Console.WriteLine("---- Informe Solicitud ----");
        Console.WriteLine("Nombre: " + nombreCompleto);
        Console.WriteLine("País: " + paisOrigen);
        Console.WriteLine("Tipo Visa: " + tipoVisa);
        Console.WriteLine("Número Solicitud: " + numeroSolicitud);
        Console.WriteLine("Fecha Solicitud: " + fechaSolicitud);
        Console.WriteLine("Puntaje Riesgo: " + puntajeRiesgo);
        Console.WriteLine("Estado Solicitud: " + estadoSolicitud);
    }
}

// Visa Turismo (B2)
class VisaTurismo : Solicitante
{
    public bool evidenciaIntencionRegresar;
    public bool antecedentesLimpios;
    public bool solvenciaEconomica;

    public override bool VerificarElegibilidadEspecifica()
    {
        if (evidenciaIntencionRegresar && antecedentesLimpios && solvenciaEconomica)
            return true;
        return false;
    }

    public override void Entrevista()
    {
        puntajeRiesgo = 0;
        string respuesta;

        Console.WriteLine("¿Tiene pruebas de intención de regresar a su país? (si/no)");
        respuesta = Console.ReadLine();
        if (respuesta == "no") puntajeRiesgo += 40;

        Console.WriteLine("¿Cuenta con solvencia económica comprobable? (si/no)");
        respuesta = Console.ReadLine();
        if (respuesta == "no") puntajeRiesgo += 30;

        Console.WriteLine("¿Posee antecedentes penales? (si/no)");
        respuesta = Console.ReadLine();
        if (respuesta == "si") puntajeRiesgo += 50;
    }

    public override void MostrarInforme()
    {
        base.MostrarInforme();
        Console.WriteLine("Evidencia intención regresar: " + (evidenciaIntencionRegresar ? "Sí" : "No"));
        Console.WriteLine("Antecedentes limpios: " + (antecedentesLimpios ? "Sí" : "No"));
        Console.WriteLine("Solvencia económica: " + (solvenciaEconomica ? "Sí" : "No"));
    }
}

// Visa Estudiante (F1)
class VisaEstudiante : Solicitante
{
    public bool aceptacionInstitucion;
    public bool fondosSuficientes;

    public override bool VerificarElegibilidadEspecifica()
    {
        if (aceptacionInstitucion && fondosSuficientes)
            return true;
        return false;
    }

    public override void Entrevista()
    {
        puntajeRiesgo = 0;
        string respuesta;

        Console.WriteLine("¿Tiene carta de aceptación de institución educativa? (si/no)");
        respuesta = Console.ReadLine();
        if (respuesta == "no") puntajeRiesgo += 50;

        Console.WriteLine("¿Cuenta con fondos suficientes para matrícula y manutención? (si/no)");
        respuesta = Console.ReadLine();
        if (respuesta == "no") puntajeRiesgo += 40;

        Console.WriteLine("¿Ha asistido a algún programa académico en EE. UU. anteriormente? (si/no)");
        respuesta = Console.ReadLine();
        if (respuesta == "no") puntajeRiesgo += 10;
    }

    public override void MostrarInforme()
    {
        base.MostrarInforme();
        Console.WriteLine("Aceptación institución: " + (aceptacionInstitucion ? "Sí" : "No"));
        Console.WriteLine("Fondos suficientes: " + (fondosSuficientes ? "Sí" : "No"));
    }
}

// Visa Trabajo (H1B)
class VisaTrabajo : Solicitante
{
    public bool ofertaLaboralValida;
    public bool calificacionProfesional;
    public bool demandaMercado;

    public override bool VerificarElegibilidadEspecifica()
    {
        if (ofertaLaboralValida && calificacionProfesional && demandaMercado)
            return true;
        return false;
    }

    public override void Entrevista()
    {
        puntajeRiesgo = 0;
        string respuesta;

        Console.WriteLine("¿Tiene oferta laboral válida en EE. UU.? (si/no)");
        respuesta = Console.ReadLine();
        if (respuesta == "no") puntajeRiesgo += 60;

        Console.WriteLine("¿Cuenta con la calificación profesional requerida? (si/no)");
        respuesta = Console.ReadLine();
        if (respuesta == "no") puntajeRiesgo += 40;

        Console.WriteLine("¿Existe demanda en el mercado laboral para su perfil? (si/no)");
        respuesta = Console.ReadLine();
        if (respuesta == "no") puntajeRiesgo += 30;
    }

    public override void MostrarInforme()
    {
        base.MostrarInforme();
        Console.WriteLine("Oferta laboral válida: " + (ofertaLaboralValida ? "Sí" : "No"));
        Console.WriteLine("Calificación profesional: " + (calificacionProfesional ? "Sí" : "No"));
        Console.WriteLine("Demanda mercado: " + (demandaMercado ? "Sí" : "No"));
    }
}

// Visa Inmigrante (EB)
class VisaInmigrante : Solicitante
{
    public bool cumpleCriteriosAdmisibilidad;
    public bool antecedentesFamiliares;
    public bool inversionSignificativa;

    public override bool VerificarElegibilidadEspecifica()
    {
        if (cumpleCriteriosAdmisibilidad && antecedentesFamiliares && inversionSignificativa)
            return true;
        return false;
    }

    public override void Entrevista()
    {
        puntajeRiesgo = 0;
        string respuesta;

        Console.WriteLine("¿Cumple con criterios de admisibilidad? (si/no)");
        respuesta = Console.ReadLine();
        if (respuesta == "no") puntajeRiesgo += 50;

        Console.WriteLine("¿Tiene antecedentes familiares en EE. UU.? (si/no)");
        respuesta = Console.ReadLine();
        if (respuesta == "no") puntajeRiesgo += 40;

        Console.WriteLine("¿Ha realizado inversión significativa en EE. UU.? (si/no)");
        respuesta = Console.ReadLine();
        if (respuesta == "no") puntajeRiesgo += 30;
    }

    public override void MostrarInforme()
    {
        base.MostrarInforme();
        Console.WriteLine("Cumple criterios admisibilidad: " + (cumpleCriteriosAdmisibilidad ? "Sí" : "No"));
        Console.WriteLine("Antecedentes familiares: " + (antecedentesFamiliares ? "Sí" : "No"));
        Console.WriteLine("Inversión significativa: " + (inversionSignificativa ? "Sí" : "No"));
    }
}

// Visa Negocios (B1)
class VisaNegocios : Solicitante
{
    public bool propositoComercial;
    public bool pruebaVinculosPais;

    public override bool VerificarElegibilidadEspecifica()
    {
        if (propositoComercial && pruebaVinculosPais)
            return true;
        return false;
    }

    public override void Entrevista()
    {
        puntajeRiesgo = 0;
        string respuesta;

        Console.WriteLine("¿Viaja por razones comerciales? (si/no)");
        respuesta = Console.ReadLine();
        if (respuesta == "no") puntajeRiesgo += 40;

        Console.WriteLine("¿Puede demostrar vínculos con su país de origen? (si/no)");
        respuesta = Console.ReadLine();
        if (respuesta == "no") puntajeRiesgo += 40;
    }

    public override void MostrarInforme()
    {
        base.MostrarInforme();
        Console.WriteLine("Propósito comercial: " + (propositoComercial ? "Sí" : "No"));
        Console.WriteLine("Prueba vínculos país: " + (pruebaVinculosPais ? "Sí" : "No"));
    }
}

// Programa principal para probar
class Program
{
    static void Main()
    {
        int solicitudesProcesadas = 0;
        string continuar = "si";

        while (continuar == "si")
        {
            Console.WriteLine("Ingrese tipo de visa a solicitar (Turismo, Estudiante, Trabajo, Inmigrante, Negocios):");
            string tipo = Console.ReadLine();

            Solicitante solicitante;

            if (tipo == "Turismo")
                solicitante = new VisaTurismo();
            else if (tipo == "Estudiante")
                solicitante = new VisaEstudiante();
            else if (tipo == "Trabajo")
                solicitante = new VisaTrabajo();
            else if (tipo == "Inmigrante")
                solicitante = new VisaInmigrante();
            else if (tipo == "Negocios")
                solicitante = new VisaNegocios();
            else
            {
                Console.WriteLine("Tipo de visa inválido.");
                continue;
            }

            Console.WriteLine("Ingrese nombre completo:");
            solicitante.nombreCompleto = Console.ReadLine();

            Console.WriteLine("Ingrese país de origen:");
            solicitante.paisOrigen = Console.ReadLine();

            solicitante.tipoVisa = tipo;

            Console.WriteLine("Ingrese número de solicitud:");
            solicitante.numeroSolicitud = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese fecha de solicitud (dd/mm/yyyy):");
            solicitante.fechaSolicitud = Console.ReadLine();

            // Preguntar campos específicos según visa
            if (tipo == "Turismo")
            {
                VisaTurismo vt = (VisaTurismo)solicitante;

                Console.WriteLine("¿Tiene evidencia de intención de regresar? (si/no)");
                vt.evidenciaIntencionRegresar = (Console.ReadLine() == "si");

                Console.WriteLine("¿Tiene antecedentes limpios? (si/no)");
                vt.antecedentesLimpios = (Console.ReadLine() == "si");

                Console.WriteLine("¿Tiene solvencia económica? (si/no)");
                vt.solvenciaEconomica = (Console.ReadLine() == "si");
            }
            else if (tipo == "Estudiante")
            {
                VisaEstudiante ve = (VisaEstudiante)solicitante;

                Console.WriteLine("¿Tiene aceptación de institución educativa? (si/no)");
                ve.aceptacionInstitucion = (Console.ReadLine() == "si");

                Console.WriteLine("¿Cuenta con fondos suficientes? (si/no)");
                ve.fondosSuficientes = (Console.ReadLine() == "si");
            }
            else if (tipo == "Trabajo")
            {
                VisaTrabajo vt = (VisaTrabajo)solicitante;

                Console.WriteLine("¿Tiene oferta laboral válida? (si/no)");
                vt.ofertaLaboralValida = (Console.ReadLine() == "si");

                Console.WriteLine("¿Tiene calificación profesional? (si/no)");
                vt.calificacionProfesional = (Console.ReadLine() == "si");

                Console.WriteLine("¿Existe demanda en mercado laboral? (si/no)");
                vt.demandaMercado = (Console.ReadLine() == "si");
            }
            else if (tipo == "Inmigrante")
            {
                VisaInmigrante vi = (VisaInmigrante)solicitante;

                Console.WriteLine("¿Cumple criterios admisibilidad? (si/no)");
                vi.cumpleCriteriosAdmisibilidad = (Console.ReadLine() == "si");

                Console.WriteLine("¿Tiene antecedentes familiares? (si/no)");
                vi.antecedentesFamiliares = (Console.ReadLine() == "si");

                Console.WriteLine("¿Ha realizado inversión significativa? (si/no)");
                vi.inversionSignificativa = (Console.ReadLine() == "si");
            }
            else if (tipo == "Negocios")
            {
                VisaNegocios vn = (VisaNegocios)solicitante;

                Console.WriteLine("¿Viaja por razones comerciales? (si/no)");
                vn.propositoComercial = (Console.ReadLine() == "si");

                Console.WriteLine("¿Puede demostrar vínculos con su país? (si/no)");
                vn.pruebaVinculosPais = (Console.ReadLine() == "si");
            }

            Console.WriteLine("\n---- Entrevista ----");
            solicitante.Entrevista();

            Console.WriteLine("\n---- Procesando Solicitud ----");
            solicitante.ProcesarSolicitud();

            Console.WriteLine("\n---- Informe Final ----");
            solicitante.MostrarInforme();

            solicitudesProcesadas++;

            Console.WriteLine("\n¿Procesar otra solicitud? (si/no)");
            continuar = Console.ReadLine();
        }

        Console.WriteLine("Total solicitudes procesadas: " + solicitudesProcesadas);
    }
}
