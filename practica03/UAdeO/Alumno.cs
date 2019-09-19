using System;

namespace practica03.UAdeO
{
    public class Alumno : Base
    {
        public string Matricula { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public Genero Genero { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Generacion { get; set; } // 2017-2021
        public string CorreoElectronico { get; set; }
        public int EscuelaId { get; set; }
        public int CarreraId { get; set; }
    }
}