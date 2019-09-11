namespace practica03
{
    public class Carrera
    {
        // Encapsulamiento
        // atributos
        int id;
        public int Id
        {
            get { return id; }
        }
        string nombre;
        public string Nombre
        {
            get { return "Lic. " + nombre; }
            set { nombre = value.ToUpper(); }
        }
        string modalidad;
        int planDeEstudios; // Año del plan de estudios
        public int Duración { get; set; }

        // Constructor
        public Carrera()
        {
            var rnd = new System.Random();
            id = rnd.Next(1,100);
            modalidad = "Trimestral";
            planDeEstudios = rnd.Next(2000,2018);
        }

        // Sobrecarga
        public Carrera(string modalidad, int planDeEstudios)
        {
            var rnd = new System.Random();
            id = rnd.Next(1,100);
            this.modalidad = modalidad;
            this.planDeEstudios = planDeEstudios;
        }

        // Sobreescritura
        public override string ToString()
        {
            return $"Id: {id}\nCarrera: {nombre}\nModalidad: {modalidad}\nPlan: {planDeEstudios}\nDuración: {Duración}";
        }
    }
}