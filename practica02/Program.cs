using System;

namespace practica02
{
    class Program
    {
        static void Main(string[] args)
        {
            int age;

            Console.Write("Escribe tu nombre: ");
            var name = Console.ReadLine();

            Console.Write("Escribe tu edad: ");
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Error: La edad debe ser un valor numérico entero.");
                Console.Write("Escribe tu edad: ");
            }

            Console.WriteLine($"Hello {name}, you're {age} old!");
            // TODO: De acuerdo a la edad que hayas ingresado debe imprimir
            // 0-10 You're a child
            // >10<18 You're a teenager
            // >18<30 You're young
            // >30<60 You're an adult
            // >60<100 You're old
            // >100 You're very close to RIP
        }
    }
}
