﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using practica04.Models;

namespace practica04
{
    class Program
    {
        static void Main(string[] args)
        {
            // PruebaDeConexionABaseDeDatosSqlite();
            // InsertarMultiplesRegistros();
            // BorrarDbYCrearDeNuevo();
            // InsertarUsuarioPorConsola();
            // ImprmirUsuariosConRoles();
            // CrearDataGeneral();
            ImprimirUsuariosConPermisos();
        }

        private static void ImprimirUsuariosConPermisos()
        {
            using (var db = new SqliteDbContext())
            {
                var usuarios = db.Users
                                 .Include(user => user.Role)
                                    .ThenInclude(role => role.RolesPermissions)
                                        .ThenInclude(rp => rp.Permission)
                                 .ToList();
                foreach (var u in usuarios)
                {
                    Console.WriteLine($"Permisos de {u.Name}");
                    foreach (var p in u.Role.RolesPermissions)
                    {
                        Console.WriteLine(p.Permission.Description);
                    }
                }
            }
        }

        private static void CrearDataGeneral()
        {
            using (var db = new SqliteDbContext())
            {
                var roles = new List<Role>
                {
                    new Role {Name = "Administrador"},
                    new Role {Name = "Usuario"}
                };

                var permisos = new List<Permission>
                {
                    new Permission { Description="Puede iniciar sesión", Level=PermissionLevel.TotalAccess },
                    new Permission { Description="Puede cobrar", Level=PermissionLevel.RestrictedAccess }
                };

                db.AddRange(
                    new RolePermission { Role=roles[0], Permission=permisos[0] },
                    new RolePermission { Role=roles[0], Permission=permisos[1] },
                    new RolePermission { Role=roles[1], Permission=permisos[1] }
                );

                db.SaveChanges();

                var usuarios = new List<User>
                {
                    new User
                    {
                        Name = "bidkar",
                        Password = "123",
                        FirstName = "Bidkar",
                        LastName = "Aragon",
                        Email = "bidkar@aragon",
                        Role = roles[0]
                    },
                    new User
                    {
                        Name = "citlalli",
                        Password = "123",
                        FirstName = "Citalli",
                        LastName = "Rivera",
                        Email = "citlalli@rivera",
                        Role = roles[1]
                    }
                };

                db.AddRange(usuarios);
                db.SaveChanges();
            }
        }

        private static void ImprmirUsuariosConRoles()
        {
            using (var db = new SqliteDbContext())
            {
                var users = db.Users.Include(role => role.Role).ToList();
                foreach (var u in users)
                {
                    Console.WriteLine($"Usuario:{u.FirstName} {u.LastName} at({u.Email}) with role: {u.Role.Name}");
                }
            }
        }

        private static void BorrarDbYCrearDeNuevo()
        {
            using (var db = new SqliteDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        private static void InsertarUsuarioPorConsola()
        {
            var usuario = new User();
            Console.WriteLine("Escribe los siguientes datos");
            Console.Write("Nombre de usuario: ");
            usuario.Name = Console.ReadLine();
            Console.Write("Contraseña: ");
            usuario.Password = Console.ReadLine();
            Console.Write("Nombre de pila: ");
            usuario.FirstName = Console.ReadLine();
            Console.Write("Apellidos: ");
            usuario.LastName = Console.ReadLine();
            Console.Write("Correo electrónico: ");
            usuario.Email = Console.ReadLine();
            Console.WriteLine($"Rol del usuario: {Role.ToStringList()}");
            usuario.RoleId = int.Parse(Console.ReadLine());
            using (var db = new SqliteDbContext())
            {
                db.Add(usuario);
                db.SaveChanges();
                ImprimirUsuarios();
                Console.WriteLine($"El id asignado al usuario {usuario.Name} es {usuario.Id}");
            }
        }

        private static void InsertarMultiplesRegistros()
        {
            var usuarios = new List<User>()
            {
                new User {
                    Name="lilian",
                    Password="123",
                    FirstName="Lilian Estefania",
                    LastName="Aragon Urias",
                    Email="lilian@aragon",
                    Status=UserStatus.Active
                },
                new User {
                    Name="laura",
                    Password="123",
                    FirstName="Laura",
                    LastName="No esta",
                    Email="laura@sefue",
                    Status=UserStatus.Active
                }
            };
            usuarios.Add(
                new User
                {
                    Name = "luis",
                    Password = "123",
                    FirstName = "Jose Luis",
                    LastName = "Si esta",
                    Email = "jluis@nosefue",
                    Status = UserStatus.Active
                }
            );

            // Guardar los usuarios creados anteriormente
            using (var db = new SqliteDbContext())
            {
                db.AddRange(usuarios);
                db.SaveChanges();
                ImprimirUsuarios();
            }

        }

        private static void ImprimirUsuarios()
        {
            using (var db = new SqliteDbContext())
            {
                var usuarios = db.Users;
                foreach (var u in usuarios)
                {
                    Console.WriteLine($"Usuario:{u.FirstName} {u.LastName} at({u.Email})");
                }
            }
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
