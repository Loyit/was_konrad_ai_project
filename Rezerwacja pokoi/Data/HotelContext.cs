using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rezerwacja_pokoi.Models;

namespace Rezerwacja_pokoi.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PermRoles> PermRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ChosenConv> ChosenConv { get; set; }
        public DbSet<Convenience> Conveniences { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<PermRoles>().ToTable("PermRoles");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
            modelBuilder.Entity<ChosenConv>().ToTable("ChosenConv");
            modelBuilder.Entity<Convenience>().ToTable("Convenience");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Payment>().ToTable("Payment");
        }
    }
}
