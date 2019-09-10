using System;

namespace practica03
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela();
            escuela.Nombre = "Universidad Autónoma de Occidente";
            escuela.UnidadRegional = "Guasave";
            escuela.SitioWebOficial = "uadeo.mx";

            Console.WriteLine(escuela.Nombre);
            Console.WriteLine(escuela.UnidadRegional);
            Console.WriteLine("https://" + escuela.SitioWebOficial);
            
            escuela.AbrirPeriodoDeInscripcion();
        }
    }
}
