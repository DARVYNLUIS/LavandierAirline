using LavandierAirLine.Modelos;
using LavandierAirLine.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LavandierAirLine.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<MetodosPagos> MetodosPagos { get; set; }
        public DbSet<CategoriaVuelo> CategoriaVuelo { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Avion> Avion { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<DetalleBoleto> DetalleBoletos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<ApplicationUser> Cliente { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // <- Cambiar de Cascade a Restric
            modelBuilder.Entity<Pago>()
         .HasOne(p => p.Boleto)
         .WithMany() // No necesitas navegación inversa en Boleto (si no hay lista de Pagos)
         .HasForeignKey(p => p.BoletoId)
         .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MetodosPagos>().HasData(
                new MetodosPagos { MetodoPagoId = 1, Descripcion = "Tarjeta" },
                new MetodosPagos { MetodoPagoId = 2, Descripcion = "Efectivo" },
                new MetodosPagos { MetodoPagoId = 3, Descripcion = "Cheque" }
            );
            modelBuilder.Entity<Avion>().HasData(
            new Avion
            {
                Id = 1,
                Modelo = "Boeing 737",
                NumeroSerie = "737 MAX",
                Capacidad = 200
            },
            new Avion
            {
                Id = 2,
                Modelo = "Airbus A320",
                NumeroSerie = "A320neo",
                Capacidad = 180
            },
            new Avion
            {
                Id = 3,
                Modelo = "Boeing 787",
                NumeroSerie = "787 Dreamliner",
                Capacidad = 250
            },
            new Avion
            {
                Id = 4,
                Modelo = "Airbus A350",
                NumeroSerie = "A350 XWB",
                Capacidad = 300
            },
            new Avion
            {
                Id = 5 , Modelo = "Boeing 777", NumeroSerie = "777-200LR",  Capacidad = 350
            }
        );

            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole { Id = "6ac343b0-00ef-4a1c-8f64-68daaca77b5b ", Name = "Cliente", NormalizedName = "Cliente", ConcurrencyStamp = "6ac343b0-00ef-4a1c-8f64-68daaca77b5b" },
               new IdentityRole { Id = "6ac343b0-00ef-4a1c-8f64-68daaca77b4b", Name = "Admin", NormalizedName = "Admin", ConcurrencyStamp = "6ac343b0-00ef-4a1c-8f64-68daaca77b4b" },
               new IdentityRole { Id = "6ac343b0-00ef-4a1c-8f64-68daaca77b2b", Name = "Delivery", NormalizedName = "Delivery", ConcurrencyStamp = "6ac343b0-00ef-4a1c-8f64-68daaca77b2b" }
               );

            modelBuilder.Entity<Estados>().HasData(
                new Estados { EstadosId = 1, Nombre = "Pendiente" },
                new Estados { EstadosId = 2, Nombre = "Pagado" },
                new Estados { EstadosId = 3, Nombre = "Vencido" },
                new Estados { EstadosId = 4, Nombre = "Cancelado" },
                new Estados { EstadosId = 5, Nombre = "Aprobado" },
                new Estados { EstadosId = 6, Nombre = "Denegado" }

            );

            modelBuilder.Entity<CategoriaVuelo>().HasData(
                new CategoriaVuelo { CategoriaVueloId = 1, Nombre = "Primera clase", Descripcion = "Segunda mas top", Precio =425 },
                new CategoriaVuelo { CategoriaVueloId = 2, Nombre = "Turista", Descripcion = "Cuarta ms top.", Precio=225},
                new CategoriaVuelo { CategoriaVueloId = 3, Nombre = "Clase Premium", Descripcion = "Top" , Precio=500},
                new CategoriaVuelo { CategoriaVueloId = 4, Nombre = "economica", Descripcion = "Tercera mas top.", Precio=300 }
               );
        }
    }
}
