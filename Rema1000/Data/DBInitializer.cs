using Rema1000.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Rema1000.Data
{
    public class DBInitializer
    {
        public void DbInitialize(Rema1000Context context)
        {
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var Categories = new Category[]
            {
                new Category { Name = "Clothes", Description ="bla"},
                new Category { Name = "Toys", Description ="bla1"},
                new Category { Name = "Grocery", Description ="bla2"}
            };

            var Suppliers = new Supplier[]
            {
                new Supplier { Name = "Bob´s virksomhed", Address = "bobvej", Postcode = 1234, ContactPerson = "Bob", Email = "bob@gmail.com", Phone = 123456},
                new Supplier { Name = "Manfreds´s virksomhed", Address = "aManfredvej", Postcode = 4321, ContactPerson = "Manfred", Email = "Manfred@gmail.com", Phone = 654321},

            };

            var Products = new Product[]
            {
                new Product { Name = "Kjole",
                    Description = "a good looking dress", Unit = 1, UnitCount = 1, Price = 19.99, Category = Categories[0], Stock = 10, Supplier = Suppliers[0] },

                new Product { Name = "Trøje",
                    Description = "A good looking sweater", Unit = 1, UnitCount = 1, Price = 9.99, Category = Categories[0], Stock = 15, Supplier = Suppliers[0] },

                new Product { Name = "Jeans Busker",
                    Description = "A good looking Denim Jeans", Unit = 1, UnitCount = 1, Price = 35.95, Category = Categories[0], Stock = 5, Supplier = Suppliers[0] },

                new Product { Name = "Legetøjs-bil",
                    Description = "Legetøj", Unit = 1, UnitCount = 1, Price = 10.00, Category = Categories[1], Stock = 3, Supplier = Suppliers[0] },

                new Product { Name = "Legetøjs-båd",
                    Description = "Legetøj", Unit = 1, UnitCount = 1, Price = 15.00, Category = Categories[1], Stock = 13, Supplier = Suppliers[0] },

                new Product { Name = "Vandpistol",
                    Description = "Legetøj", Unit = 1, UnitCount = 1, Price = 20.00, Category = Categories[1], Stock = 23, Supplier = Suppliers[0] },

                new Product { Name = "Milk",
                    Description = "Fresh Milk", Unit = 1, UnitCount = 1, Price = 2.99, Category = Categories[2], Stock = 100, Supplier = Suppliers[1] },

                new Product { Name = "banan",
                    Description = "Frugt", Unit = 1, UnitCount = 5, Price = 3.99, Category = Categories[2], Stock = 20, Supplier = Suppliers[1] },
            };

            context.AddRange(Categories);
            context.AddRange(Suppliers);
            context.AddRange(Products);

            context.SaveChanges();
        }
    }
}
