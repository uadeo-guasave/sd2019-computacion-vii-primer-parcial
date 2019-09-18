namespace practica03.UAdeO
{
    public class Docente : Base
    {
        public int NumeroDeEmpleado { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Rfc { get; set; }
        public string DepartamentoDeAdscripcion { get; set; }
        public int EscuelaId { get; set; }
    }
}