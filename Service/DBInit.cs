using CatalogueApp.Model;
using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace CatalogueApp.Service
{
    public static class DBInit{
        public static void initData(CatalogueRepository catalogueRepository){
            Console.WriteLine("Data Initialization...");
            catalogueRepository.Categories.Add(new Category{Name="Ordinateurs"});
            catalogueRepository.Categories.Add(new Category{Name="Imprimantes"});
            catalogueRepository.Categories.Add(new Category{Name="Ecrans"});
            catalogueRepository.Categories.Add(new Category{Name="Batteries"});
            catalogueRepository.Categories.Add(new Category{Name="Claviers"});
            catalogueRepository.Categories.Add(new Category{Name="Disck dur"});
            catalogueRepository.Categories.Add(new Category{Name="Téléphone"});
            catalogueRepository.Categories.Add(new Category{Name="Chargeurs"});
            catalogueRepository.Categories.Add(new Category{Name="Casques"});
            catalogueRepository.Products.Add(new Product{Name="HP 540", Price=6000.8, Characteristics = new string[] {"RAM 8 GB", "1 To of storage", "core i7", "NVIDEA GEFORCE"} ,CategoryID=1});
            catalogueRepository.Products.Add(new Product{Name="Lenovo 510", Price=9000.98371, Characteristics = new string[] {"RAM 16 GB", "1 To of storage", "core i8", "NVIDEA GEFORCE"} ,CategoryID=1});
            catalogueRepository.Products.Add(new Product{Name="Mac Book Pro", Price=15000.7, Characteristics = new string[] {"RAM 8 GB", "1 To of storage", "core i7", "Intel Iris Plus"} ,CategoryID=1});
            catalogueRepository.Products.Add(new Product{Name="Mac Book Pro", Price=20000.7, Characteristics = new string[] {"RAM 16 GB", "1 To of storage", "core i8", "Intel Iris Plus"} ,CategoryID=1});
            EntityEntry<Product> entityEntryProduct = catalogueRepository.Products.Add(new Product{Name="Epson 7654", Price=1700.5, Characteristics = new string[] {"180 buses noir", "59 Buses par couleur", "5.760 x 1.440 DPI (ppp)", "Home Office"} ,CategoryID=2});
            EntityEntry<Product> entityEntryProduct1 = catalogueRepository.Products.Add(new Product{Name="Samsung 2020", Price=1550, Characteristics = new string[] {"180 buses noir", "59 Buses par couleur", "5.760 x 1.440 DPI (ppp)", "Home Office"} ,CategoryID=2});
            EntityEntry<Product> entityEntryProduct2 = catalogueRepository.Products.Add(new Product{Name="Toshiba 9632", Price=1999.99, Characteristics = new string[] {"180 buses noir", "59 Buses par couleur", "5.760 x 1.440 DPI (ppp)", "Home Office"} ,CategoryID=2});
            EntityEntry<Product> entityEntryProduct3 = catalogueRepository.Products.Add(new Product{Name="DELL 1459", Price=3000.7, Characteristics = new string[] {"180 buses noir", "59 Buses par couleur", "5.760 x 1.440 DPI (ppp)", "Home Office"} ,CategoryID=2});

            catalogueRepository.Products.Add(new Product{Name="Asus 753", Price=6000.8, Characteristics = new string[] {"RAM 8 GB", "1 To of storage", "core i7", "NVIDEA GEFORCE"} ,CategoryID=1});
            catalogueRepository.Products.Add(new Product{Name="Hp 789", Price=9000.98371, Characteristics = new string[] {"RAM 16 GB", "1 To of storage", "core i8", "NVIDEA GEFORCE"} ,CategoryID=1});
            catalogueRepository.Products.Add(new Product{Name="Mac Book Pro", Price=15000.7, Characteristics = new string[] {"RAM 8 GB", "1 To of storage", "core i7", "Intel Iris Plus"} ,CategoryID=1});
            catalogueRepository.Products.Add(new Product{Name="Mac Book Pro", Price=20000.7, Characteristics = new string[] {"RAM 16 GB", "1 To of storage", "core i8", "Intel Iris Plus"} ,CategoryID=1});
            EntityEntry<Product> entityEntryProduct4 = catalogueRepository.Products.Add(new Product{Name="Epson 7654", Price=1700.5, Characteristics = new string[] {"180 buses noir", "59 Buses par couleur", "5.760 x 1.440 DPI (ppp)", "Home Office"} ,CategoryID=2});
            EntityEntry<Product> entityEntryProduct5 = catalogueRepository.Products.Add(new Product{Name="Samsung 2020", Price=1550, Characteristics = new string[] {"180 buses noir", "59 Buses par couleur", "5.760 x 1.440 DPI (ppp)", "Home Office"} ,CategoryID=2});
            EntityEntry<Product> entityEntryProduct6 = catalogueRepository.Products.Add(new Product{Name="Toshiba 9632", Price=1999.99, Characteristics = new string[] {"180 buses noir", "59 Buses par couleur", "5.760 x 1.440 DPI (ppp)", "Home Office"} ,CategoryID=2});
            EntityEntry<Product> entityEntryProduct7 = catalogueRepository.Products.Add(new Product{Name="DELL 1459", Price=3000.7, Characteristics = new string[] {"180 buses noir", "59 Buses par couleur", "5.760 x 1.440 DPI (ppp)", "Home Office"} ,CategoryID=2});

            catalogueRepository.Customers.Add(new Customer{Name="Mohammed", Email="mohammed@email.com", Phone="0654897415"});
            EntityEntry<Customer> entityEntryCustomer = catalogueRepository.Customers.Add(new Customer{Name="Amine", Email="amine@email.com", Phone="0647124519"});
            entityEntryCustomer.Entity.Products.Add(entityEntryProduct.Entity);
            Console.WriteLine(entityEntryCustomer.Entity.Products.GetEnumerator());
            catalogueRepository.Customers.Add(new Customer{Name="Rachid", Email="rachid@email.com", Phone="0754859633"});
            catalogueRepository.Customers.Add(new Customer{Name="Khalid", Email="khalid@email.com", Phone="0654127895"});
            catalogueRepository.Customers.Add(new Customer{Name="Janna", Email="janna@email.com", Phone="0754213698"});
            catalogueRepository.Customers.Add(new Customer{Name="Mariam", Email="mariam@email.com", Phone="0635241447"});
            catalogueRepository.Customers.Add(new Customer{Name="Nour", Email="nour@email.com", Phone="0745698321"});

            catalogueRepository.Customers.Add(new Customer{Name="Karim", Email="karim@email.com", Phone="0754213698"});
            catalogueRepository.Customers.Add(new Customer{Name="Nissrine", Email="nissrine@email.com", Phone="0635241447"});
            catalogueRepository.Customers.Add(new Customer{Name="Marouane", Email="marouane@email.com", Phone="0745698321"});
            //entityEntryCustomer.Entity.Products.Add(entityEntryProduct.Entity);
            /*var p1 = new Product {Name="P1", price=8500, CategoryID=1};
            catalogueRepository.AddRange(
                new Customer
                {
                    Name = "Monir",
                    Products = new List<Product> {p1}
                });*/
            catalogueRepository.SaveChanges();
        }
    } 
}