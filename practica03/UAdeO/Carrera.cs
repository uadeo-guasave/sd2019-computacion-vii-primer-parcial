namespace practica03.UAdeO
{
    public class Carrera : Base
    {
        // Encapsulamiento
        // atributos
        ModalidadDeCarrera modalidad; // trimestral o semestral
        int planDeEstudios; // Año del plan de estudios
        public int Duración { get; set; }
        public int EscuelaId { get; set; }

        // Constructor
        public Carrera()
        {
            var rnd = new System.Random();
            // id = rnd.Next(1,100);
            modalidad = ModalidadDeCarrera.Trimestral;
            planDeEstudios = rnd.Next(2000,2018);
        }

        // Sobrecarga
        public Carrera(ModalidadDeCarrera modalidad, int planDeEstudios)
        {
            var rnd = new System.Random();
            // id = rnd.Next(1,100);
            this.modalidad = modalidad;
            this.planDeEstudios = planDeEstudios;
        }

        // Sobreescritura
        public override string ToString()
        {
            return $"Id: {Id}\nCarrera: {Nombre}\nModalidad: {modalidad}\nPlan: {planDeEstudios}\nDuración: {Duración}";
        }
    }
}