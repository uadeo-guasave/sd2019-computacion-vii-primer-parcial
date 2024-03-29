using System.Collections.Generic;

namespace practica03.UAdeO
{
    public class Escuela : Base
    {
        // Características (Propiedades)
        public string Director { get; set; }
        public string ClaveSep { get; set; }
        public string UnidadRegional { get; set; }
        public string Domicilio { get; set; }
        public string SitioWebOficial { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public List<Carrera> Carreras { get; set; } = new List<Carrera>();

        // Funciones (Métodos)
        public void AbrirPeriodoDeInscripcion()
        {
            System.Console.WriteLine("El ciclo escolar 2019-2020 inicia el 26 de Agosto de 2019");
        }
        void CerrarPeriodoDeInscripcion() {}
        void DefinirCalendarioDelPeriodo(string periodo) {}

    }
}