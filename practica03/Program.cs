using System;

namespace practica03
{
    class Program
    {
        static void Main(string[] args)
        {
            ProbarCarrera();
        }

        private static void ProbarCarrera()
        {
            var sistemas = new Carrera();
            sistemas.Nombre = "Sistemas Computacionales";
            Console.WriteLine(sistemas.Nombre);
            // sistemas.Id = 10; Error propiedad solo de lectura
            Console.WriteLine(sistemas.Id);
            Console.WriteLine(sistemas.ToString());

            var conta = new Carrera("Semestral", 2017);
            conta.Nombre = "Contabilidad";
            conta.Duración = 8;
            Console.WriteLine(conta.ToString());
        }

        private static void ProbarEscuela()
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
