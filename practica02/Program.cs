using System;

namespace practica02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Escribe tu nombre: ");
            var name = Console.ReadLine();
            Console.Write("Escribe tu edad: ");
            try
            {
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine($"Hello {name}, you're {age} old!");
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Error: La edad debe ser un valor numérico entero.");
            }

        }
    }
}
