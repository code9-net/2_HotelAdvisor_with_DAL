namespace HotelAdvisorDAL.Migrations
{
    using HotelAdvisorDAL.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelAdvisorDAL.DataContext.HotelAdvisorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HotelAdvisorDAL.DataContext.HotelAdvisorContext context)
        {
            //  This method will be called after migrating to the latest version.
           
            // get image byte array
            byte[] parkImage = LoadImageFromFile("/Content/HotelImages/hotel-park-novi-sad.jpg");
            byte[] centarImage = LoadImageFromFile("/Content/HotelImages/hotel-centar-izgled-spolja.jpg");
            byte[] putnikImage = LoadImageFromFile("/Content/HotelImages/hotel-putnik_508f9bac6af3f.jpg");
            byte[] panoramaImage = LoadImageFromFile("/Content/HotelImages/hotel-panorama_508f98d5d1faf.jpg");
            byte[] fontanaImage = LoadImageFromFile("/Content/HotelImages/69_1233757047_noviiiiiii.jpg");
            byte[] dashImage = LoadImageFromFile("/Content/HotelImages/6.jpg");


            var hotels = new List<Hotel>
            {
                new Hotel{Name = "Hotel Park", Description = "Hotel Park se nalazi u Novom Sadu, na ivici velikog parka u mirnom okruženju",Address = "Novosadskog sajma", HouseNumber = 35, City="Novi Sad",  IsActive = true, Image = parkImage},
                new Hotel{Name = "Hotel Centar", Description = "Hotel Centar nalazi se blizu Srpskog narodnog pozorišta u centru Novog Sada. Nudi svetle i prostrane smeštajne jedinice.",Address = "Uspenska", HouseNumber = 1, City="Novi Sad",  IsActive = true, Image = centarImage},
                new Hotel{Name = "Hotel Putnik", Description = "Hotel Park se nalazi u Novom Sadu, na ivici velikog parka u mirnom okruženju",Address = "Ognjanovica", HouseNumber = 24, City="Novi Sad",  IsActive = true, Image = putnikImage},
                new Hotel{Name = "Hotel Panorama", Description = "Hotel Panorama nalazi se u centru Novog Sada i do njega se lako stiže, bez obzira odakle dolazite.",Address = "Futoska", HouseNumber = 1, City="Novi Sad",  IsActive = true, Image = panoramaImage},
                new Hotel{Name = "Fontana", Description = "Ovaj hotel se nalazi na svega 100 metara od pešaèke zone u starom gradskom jezgru Novog Sada i nudi besplatan bežièni internet i besplatan podzemni parking.",Address = "Nikole Pasica", HouseNumber = 27, City="Novi Sad",  IsActive = true, Image = fontanaImage},
                new Hotel{Name = "Dash Star", Description = "Hotel Dash Star se nalazi u blizini centra grada i Novosadskog sajma. U ponudi su elegantne klimatizovane sobe sa besplatnim bežiènim internetom",Address = "Vrsacka", HouseNumber = 11, City="Novi Sad",  IsActive = false, Image = dashImage}
            };

            hotels.ForEach(h => context.Hotels.Add(h));
            context.SaveChanges();


            //create role
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }

            //create user
            if (!context.Users.Any(u => u.UserName == "admin@admin.com"))
            {
                var user = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com" };

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                userManager.Create(user, "Admin@123");

                //add user to role
                userManager.AddToRole(user.Id, "Admin");
            }

        }

        // convert images to byte array
        public byte[] LoadImageFromFile(string fileLocation)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            Image img = Image.FromFile(basePath + fileLocation);
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }

            return arr;
        }
    }
}
