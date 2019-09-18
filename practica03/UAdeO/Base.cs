namespace practica03.UAdeO
{
    public abstract class Base
    {
        public int Id { get; }
        public string Nombre { get; set; }

        public Base()
        {
            var rnd = new System.Random();
            Id = rnd.Next(1,100);
        }
    }
}