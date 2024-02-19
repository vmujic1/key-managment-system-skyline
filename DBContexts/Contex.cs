using key_managment_system.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace key_managment_system.DBContexts
{
    public class Contex : DbContext
    {
        public Contex()
        {
            
        }
        public Contex(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Keycard> KeyCards { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        

            string connectionString = ConfigurationManager.ConnectionStrings["link"].ConnectionString;
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        }



    }
}
