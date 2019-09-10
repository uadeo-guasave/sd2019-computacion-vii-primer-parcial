namespace practica03
{
    public class Escuela
    {
        // Características
        public string Nombre { get; set; }
        public string Director { get; set; }
        public string ClaveSep { get; set; }
        public string UnidadRegional { get; set; }
        public string Domicilio { get; set; }
        public string SitioWebOficial { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }

        // Funciones
        public void AbrirPeriodoDeInscripcion() {
            System.Console.WriteLine("El ciclo escolar 2019-2020 inicia el 26 de Agosto de 2019");
        }
        void CerrarPeriodoDeInscripcion() {}
        void DefinirCalendarioDelPeriodo(string periodo) {}

    }
}