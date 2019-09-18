namespace practica03.UAdeO
{
    public class Carrera : Base
    {
        // Encapsulamiento
        // atributos
        string modalidad;
        int planDeEstudios; // Año del plan de estudios
        public int Duración { get; set; }
        public int EscuelaId { get; set; }

        // Constructor
        public Carrera()
        {
            var rnd = new System.Random();
            // id = rnd.Next(1,100);
            modalidad = "Trimestral";
            planDeEstudios = rnd.Next(2000,2018);
        }

        // Sobrecarga
        public Carrera(string modalidad, int planDeEstudios)
        {
            var rnd = new System.Random();
            // id = rnd.Next(1,100);
            this.modalidad = modalidad;
            this.planDeEstudios = planDeEstudios;
        }

        // Sobreescritura
        // public override string ToString()
        // {
        //     // return $"Id: {id}\nCarrera: {nombre}\nModalidad: {modalidad}\nPlan: {planDeEstudios}\nDuración: {Duración}";
        // }
    }
}