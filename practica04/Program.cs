using System;
using practica04.Models;

namespace practica04
{
    class Program
    {
        static void Main(string[] args)
        {
            PruebaDeConexionABaseDeDatosSqlite();
        }

        private static void PruebaDeConexionABaseDeDatosSqlite()
        {
            Console.WriteLine("Conectando a la base de datos...");
            using (var db = new SqliteDbContext())
            {
                // db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                var usuario = new User()
                {
                    Name = "bidkar",
                    Password = "123",
                    FirstName = "Bidkar",
                    LastName = "Aragon",
                    Email = "bidkar.aragon@udo.mx",
                    Status = UserStatus.Active
                };
                // Create (insert)
                db.Add(usuario);
                db.SaveChanges();

                // Read (select)
                var usuarios = db.Users;
                foreach (var u in usuarios)
                {
                    Console.WriteLine("Usuario: " + u.Name);
                }
            }
        }
    }
}
