using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CodeFirst.Models
{
    public partial class CarServiceKpzContext : DbContext
    {
        public CarServiceKpzContext()
            : base("name=CarServiceKpzContext")
        {
        }

        public virtual DbSet<C__EFMigrationsHistory> C__EFMigrationsHistory { get; set; }
        public virtual DbSet<BodyType> BodyTypes { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarBrand> CarBrands { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DriveType> DriveTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeePosition> EmployeePositions { get; set; }
        public virtual DbSet<EngineType> EngineTypes { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<PartBrand> PartBrands { get; set; }
        public virtual DbSet<PartInStation> PartInStations { get; set; }
        public virtual DbSet<PartType> PartTypes { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatus { get; set; }
        public virtual DbSet<ProvidedService> ProvidedServices { get; set; }
        public virtual DbSet<RequiredPart> RequiredParts { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<SuspensionType> SuspensionTypes { get; set; }
        public virtual DbSet<TransmissionType> TransmissionTypes { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<VisitService> VisitServices { get; set; }
        public virtual DbSet<VisitStatus> VisitStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BodyType>()
                .Property(e => e.BodyTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.VIN)
                .IsUnicode(false);

            modelBuilder.Entity<CarBrand>()
                .Property(e => e.BrandName)
                .IsUnicode(false);

            modelBuilder.Entity<CarModel>()
                .Property(e => e.ModelName)
                .IsUnicode(false);

            modelBuilder.Entity<CarModel>()
                .Property(e => e.Dimensions)
                .IsUnicode(false);

            modelBuilder.Entity<CarModel>()
                .HasMany(e => e.Cars)
                .WithRequired(e => e.CarModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Color>()
                .Property(e => e.ColorName)
                .IsUnicode(false);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.Cars)
                .WithRequired(e => e.Color)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Cars)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DriveType>()
                .Property(e => e.DriveTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Visits)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmployeePosition>()
                .Property(e => e.PositionName)
                .IsUnicode(false);

            modelBuilder.Entity<EngineType>()
                .Property(e => e.EngineTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<Part>()
                .Property(e => e.PartName)
                .IsUnicode(false);

            modelBuilder.Entity<Part>()
                .Property(e => e.Weight)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Part>()
                .Property(e => e.Dimensions)
                .IsUnicode(false);

            modelBuilder.Entity<Part>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Part>()
                .Property(e => e.PricePerPackage)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Part>()
                .HasMany(e => e.PartInStations)
                .WithRequired(e => e.Part)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartBrand>()
                .Property(e => e.BrandName)
                .IsUnicode(false);

            modelBuilder.Entity<PartInStation>()
                .HasMany(e => e.RequiredParts)
                .WithRequired(e => e.PartInStation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartType>()
                .Property(e => e.PartTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<PaymentStatus>()
                .Property(e => e.PaymentName)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.ServiceName)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.VisitServices)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.ServiceTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Station)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.PartInStations)
                .WithRequired(e => e.Station)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SuspensionType>()
                .Property(e => e.SuspensionTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<TransmissionType>()
                .Property(e => e.TransmissionTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<Visit>()
                .Property(e => e.Details)
                .IsUnicode(false);

            modelBuilder.Entity<Visit>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<VisitStatus>()
                .Property(e => e.StatusName)
                .IsUnicode(false);

            modelBuilder.Entity<VisitStatus>()
                .HasMany(e => e.Visits)
                .WithRequired(e => e.VisitStatus)
                .WillCascadeOnDelete(false);
        }
    }
}
