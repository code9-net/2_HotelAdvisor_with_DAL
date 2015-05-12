using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelAdvisorDAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HotelAdvisorDAL.DataContext
{
    public class HotelAdvisorContext : IdentityDbContext<ApplicationUser>
    {
        public HotelAdvisorContext() : base("DefaultConnection") 
        {
        }

        public static HotelAdvisorContext Create()
        {
            return new HotelAdvisorContext();
        }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Comment> Comments { get; set; }

    }
}