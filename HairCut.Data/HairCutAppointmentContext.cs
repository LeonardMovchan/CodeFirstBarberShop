using HairCut.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HairCut.Data
{
    public class HairCutAppointmentContext : DbContext
    {
        public HairCutAppointmentContext() : base("Data source=.;Initial Catalog = HairCutAppointment; Integrated Security = true")
        {

        }
        
        public DbSet<HairCutAppointment> HairCutAppointments { get; set; }
        public DbSet<BarberShop> BarberShops { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<BarberEquipment> BarberEquipments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region HairCutAppointment
            modelBuilder.Entity<HairCutAppointment>()
                .ToTable("HairCutAppointments")
                .HasKey(x => x.Id);

            modelBuilder.Entity<HairCutAppointment>()
                .HasRequired(x => x.Barber)
                .WithMany(x => x.HairCutAppointments)
                .HasForeignKey(x => x.BarberId);

            modelBuilder.Entity<HairCutAppointment>()
               .HasRequired(x => x.BarberShop)
               .WithMany(x => x.HairCutAppointments)
               .HasForeignKey(x => x.BarberShopId);

            #endregion

            #region BarberEquipment
            modelBuilder.Entity<BarberEquipment>()
                .HasRequired(x => x.Barber)
                .WithMany(x => x.BarberEquipments)
                .HasForeignKey(x => x.BarberId);

            modelBuilder.Entity<BarberEquipment>()
                .ToTable("BarberEquipments")
                .HasKey(x => x.Id);
            #endregion

            #region Barber
            modelBuilder.Entity<Barber>()
                .HasRequired(x => x.BarberShop)
                .WithMany(x => x.Barbers)
                .HasForeignKey(x => x.BarberShopId);

            modelBuilder.Entity<Barber>()
                .ToTable("Barbers")
                .HasKey(x => x.Id);

            #endregion
        }
    }
}
