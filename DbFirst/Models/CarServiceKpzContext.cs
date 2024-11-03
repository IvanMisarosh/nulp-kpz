using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace DbFirst.Models;

public partial class CarServiceKpzContext : DbContext
{
    public CarServiceKpzContext()
    {
    }

    public CarServiceKpzContext(DbContextOptions<CarServiceKpzContext> options)
        : base(options)
    {
    }

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

    public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }

    public virtual DbSet<ProvidedService> ProvidedServices { get; set; }

    public virtual DbSet<RequiredPart> RequiredParts { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<SuspensionType> SuspensionTypes { get; set; }

    public virtual DbSet<TransmissionType> TransmissionTypes { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    public virtual DbSet<VisitService> VisitServices { get; set; }

    public virtual DbSet<VisitStatus> VisitStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=car_service_kpz;Trusted_Connection=True;TrustServerCertificate=True;");

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BodyType>(entity =>
        {
            entity.HasKey(e => e.BodyTypeId).HasName("PK__BodyType__3F42D9814D081473");

            entity.ToTable("BodyType");

            entity.HasIndex(e => e.BodyTypeName, "UQ__BodyType__BBB9F784C008B655").IsUnique();

            entity.Property(e => e.BodyTypeId)
                .ValueGeneratedNever()
                .HasColumnName("BodyTypeID");
            entity.Property(e => e.BodyTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__Car__68A0340EEFEBB133");

            entity.ToTable("Car");

            entity.HasIndex(e => e.Vin, "UQ__Car__C5DF234C06CA70EC").IsUnique();

            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.CarModelId).HasColumnName("CarModelID");
            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Vin)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("VIN");

            entity.HasOne(d => d.CarModel).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CarModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Car__CarModelID__6C190EBB");

            entity.HasOne(d => d.Color).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Car__ColorID__6D0D32F4");

            entity.HasOne(d => d.Customer).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Car__CustomerID__6B24EA82");
        });

        modelBuilder.Entity<CarBrand>(entity =>
        {
            entity.HasKey(e => e.CarBrandId).HasName("PK__CarBrand__3EAE0B29EB7BA0BA");

            entity.ToTable("CarBrand");

            entity.HasIndex(e => e.BrandName, "UQ__CarBrand__2206CE9B8862FDD2").IsUnique();

            entity.Property(e => e.CarBrandId)
                .ValueGeneratedNever()
                .HasColumnName("CarBrandID");
            entity.Property(e => e.BrandName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CarModel>(entity =>
        {
            entity.HasKey(e => e.CarModelId).HasName("PK__CarModel__C585C36F89C856B3");

            entity.ToTable("CarModel");

            entity.HasIndex(e => e.ModelName, "UQ__CarModel__67DC63B5820682CD").IsUnique();

            entity.Property(e => e.CarModelId).HasColumnName("CarModelID");
            entity.Property(e => e.BodyTypeId).HasColumnName("BodyTypeID");
            entity.Property(e => e.CarBrandId).HasColumnName("CarBrandID");
            entity.Property(e => e.Dimensions)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.DriveTypeId).HasColumnName("DriveTypeID");
            entity.Property(e => e.EngineTypeId).HasColumnName("EngineTypeID");
            entity.Property(e => e.ModelName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SuspensionTypeId).HasColumnName("SuspensionTypeID");
            entity.Property(e => e.TransmissionTypeId).HasColumnName("TransmissionTypeID");

            entity.HasOne(d => d.BodyType).WithMany(p => p.CarModels)
                .HasForeignKey(d => d.BodyTypeId)
                .HasConstraintName("FK__CarModel__BodyTy__60A75C0F");

            entity.HasOne(d => d.CarBrand).WithMany(p => p.CarModels)
                .HasForeignKey(d => d.CarBrandId)
                .HasConstraintName("FK__CarModel__CarBra__5CD6CB2B");

            entity.HasOne(d => d.DriveType).WithMany(p => p.CarModels)
                .HasForeignKey(d => d.DriveTypeId)
                .HasConstraintName("FK__CarModel__DriveT__5BE2A6F2");

            entity.HasOne(d => d.EngineType).WithMany(p => p.CarModels)
                .HasForeignKey(d => d.EngineTypeId)
                .HasConstraintName("FK__CarModel__Engine__5FB337D6");

            entity.HasOne(d => d.SuspensionType).WithMany(p => p.CarModels)
                .HasForeignKey(d => d.SuspensionTypeId)
                .HasConstraintName("FK__CarModel__Suspen__5DCAEF64");

            entity.HasOne(d => d.TransmissionType).WithMany(p => p.CarModels)
                .HasForeignKey(d => d.TransmissionTypeId)
                .HasConstraintName("FK__CarModel__Transm__5EBF139D");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("PK__Color__8DA7676D5BE67B6B");

            entity.ToTable("Color");

            entity.HasIndex(e => e.ColorName, "UQ__Color__C71A5A7BEC2CD5E9").IsUnique();

            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.ColorName)
                .HasMaxLength(70)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B831C37328");

            entity.ToTable("Customer");

            entity.HasIndex(e => new { e.Email, e.FirstName, e.LastName, e.PhoneNumber }, "UQ_Customer_Email_FirstName_LastName_PhoneNumber").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DriveType>(entity =>
        {
            entity.HasKey(e => e.DriveTypeId).HasName("PK__DriveTyp__05D279D71C9A2F32");

            entity.ToTable("DriveType");

            entity.HasIndex(e => e.DriveTypeName, "UQ__DriveTyp__DA639FBC68B9442C").IsUnique();

            entity.Property(e => e.DriveTypeId)
                .ValueGeneratedNever()
                .HasColumnName("DriveTypeID");
            entity.Property(e => e.DriveTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1594F46A3");

            entity.ToTable("Employee");

            entity.HasIndex(e => new { e.PhoneNumber, e.FirstName, e.LastName }, "UQ_Employee_Phone_First_Last").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmployeePositionId).HasColumnName("EmployeePositionID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.StationId).HasColumnName("StationID");

            entity.HasOne(d => d.EmployeePosition).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeePositionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Employee__Employ__08B54D69");

            entity.HasOne(d => d.Station).WithMany(p => p.Employees)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee__Statio__09A971A2");
        });

        modelBuilder.Entity<EmployeePosition>(entity =>
        {
            entity.HasKey(e => e.EmployeePositionId).HasName("PK__Employee__6FDE9040257588CD");

            entity.ToTable("EmployeePosition");

            entity.HasIndex(e => e.PositionName, "UQ__Employee__E46AEF426928F72A").IsUnique();

            entity.Property(e => e.EmployeePositionId).HasColumnName("EmployeePositionID");
            entity.Property(e => e.PositionName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EngineType>(entity =>
        {
            entity.HasKey(e => e.EngineTypeId).HasName("PK__EngineTy__B01776DC7BAAB361");

            entity.ToTable("EngineType");

            entity.HasIndex(e => e.EngineTypeName, "UQ__EngineTy__77F3361CCF50543A").IsUnique();

            entity.Property(e => e.EngineTypeId)
                .ValueGeneratedNever()
                .HasColumnName("EngineTypeID");
            entity.Property(e => e.EngineTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Part>(entity =>
        {
            entity.HasKey(e => e.PartId).HasName("PK__Part__7C3F0D304C2ABA96");

            entity.ToTable("Part");

            entity.Property(e => e.PartId).HasColumnName("PartID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Dimensions)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PartBrandId).HasColumnName("PartBrandID");
            entity.Property(e => e.PartName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PartTypeId).HasColumnName("PartTypeID");
            entity.Property(e => e.PricePerPackage).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Weight).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.PartBrand).WithMany(p => p.Parts)
                .HasForeignKey(d => d.PartBrandId)
                .HasConstraintName("FK__Part__PartBrandI__787EE5A0");

            entity.HasOne(d => d.PartType).WithMany(p => p.Parts)
                .HasForeignKey(d => d.PartTypeId)
                .HasConstraintName("FK__Part__PartTypeID__797309D9");
        });

        modelBuilder.Entity<PartBrand>(entity =>
        {
            entity.HasKey(e => e.PartBrandId).HasName("PK__PartBran__CAEA6FD94217E82E");

            entity.ToTable("PartBrand");

            entity.HasIndex(e => e.BrandName, "UQ__PartBran__2206CE9BCE2C4E96").IsUnique();

            entity.Property(e => e.PartBrandId).HasColumnName("PartBrandID");
            entity.Property(e => e.BrandName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PartInStation>(entity =>
        {
            entity.HasKey(e => e.PartInStationId).HasName("PK__PartInSt__AE92DE83F804769E");

            entity.ToTable("PartInStation");

            entity.HasIndex(e => new { e.StationId, e.PartId }, "UQ_PartInStation_StationID_PartID").IsUnique();

            entity.Property(e => e.PartInStationId).HasColumnName("PartInStationID");
            entity.Property(e => e.PartId).HasColumnName("PartID");
            entity.Property(e => e.StationId).HasColumnName("StationID");

            entity.HasOne(d => d.Part).WithMany(p => p.PartInStations)
                .HasForeignKey(d => d.PartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PartInSta__PartI__02084FDA");

            entity.HasOne(d => d.Station).WithMany(p => p.PartInStations)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PartInSta__Stati__01142BA1");
        });

        modelBuilder.Entity<PartType>(entity =>
        {
            entity.HasKey(e => e.PartTypeId).HasName("PK__PartType__EDE4D59E9D0AACDD");

            entity.ToTable("PartType");

            entity.HasIndex(e => e.PartTypeName, "UQ__PartType__E8493D2A5FAAFA4C").IsUnique();

            entity.Property(e => e.PartTypeId).HasColumnName("PartTypeID");
            entity.Property(e => e.PartTypeName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PaymentStatus>(entity =>
        {
            entity.HasKey(e => e.PaymentStatusId).HasName("PK__PaymentS__34F8AC1F2A4157DA");

            entity.ToTable("PaymentStatus");

            entity.HasIndex(e => e.PaymentName, "UQ__PaymentS__FD0AE8EC65DCE085").IsUnique();

            entity.Property(e => e.PaymentStatusId).HasColumnName("PaymentStatusID");
            entity.Property(e => e.PaymentName)
                .HasMaxLength(70)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProvidedService>(entity =>
        {
            entity.HasKey(e => e.ProvidedServiceId).HasName("PK__Provided__F9D5757A238604A9");

            entity.ToTable("ProvidedService");

            entity.HasIndex(e => e.VisitServiceId, "UQ__Provided__97A666D074CD7968").IsUnique();

            entity.Property(e => e.ProvidedServiceId).HasColumnName("ProvidedServiceID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.ProvidedDate).HasColumnType("datetime");
            entity.Property(e => e.VisitServiceId).HasColumnName("VisitServiceID");

            entity.HasOne(d => d.Employee).WithMany(p => p.ProvidedServices)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__ProvidedS__Emplo__2645B050");

            entity.HasOne(d => d.VisitService).WithOne(p => p.ProvidedService)
                .HasForeignKey<ProvidedService>(d => d.VisitServiceId)
                .HasConstraintName("FK__ProvidedS__Visit__2739D489");
        });

        modelBuilder.Entity<RequiredPart>(entity =>
        {
            entity.HasKey(e => e.RequiredPartId).HasName("PK__Required__6EA5F4741F9920AA");

            entity.ToTable("RequiredPart");

            entity.Property(e => e.RequiredPartId).HasColumnName("RequiredPartID");
            entity.Property(e => e.PartInStationId).HasColumnName("PartInStationID");
            entity.Property(e => e.ProvidedServiceId).HasColumnName("ProvidedServiceID");

            entity.HasOne(d => d.PartInStation).WithMany(p => p.RequiredParts)
                .HasForeignKey(d => d.PartInStationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RequiredP__PartI__2A164134");

            entity.HasOne(d => d.ProvidedService).WithMany(p => p.RequiredParts)
                .HasForeignKey(d => d.ProvidedServiceId)
                .HasConstraintName("FK__RequiredP__Provi__2B0A656D");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__C51BB0EA8D2E2F36");

            entity.ToTable("Service");

            entity.HasIndex(e => e.ServiceName, "UQ__Service__A42B5F998B7F98C7").IsUnique();

            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");

            entity.HasOne(d => d.ServiceType).WithMany(p => p.Services)
                .HasForeignKey(d => d.ServiceTypeId)
                .HasConstraintName("FK__Service__Service__114A936A");
        });

        modelBuilder.Entity<ServiceType>(entity =>
        {
            entity.HasKey(e => e.ServiceTypeId).HasName("PK__ServiceT__8ADFAA0CFCC5D982");

            entity.ToTable("ServiceType");

            entity.HasIndex(e => e.ServiceTypeName, "UQ__ServiceT__64009631F9572DD7").IsUnique();

            entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");
            entity.Property(e => e.ServiceTypeName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.StationId).HasName("PK__Station__E0D8A6DD8BBA4695");

            entity.ToTable("Station");

            entity.HasIndex(e => new { e.Address, e.PhoneNumber }, "UQ_Station_Address_PhoneNumber").IsUnique();

            entity.Property(e => e.StationId).HasColumnName("StationID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SuspensionType>(entity =>
        {
            entity.HasKey(e => e.SuspensionTypeId).HasName("PK__Suspensi__BAEC7EB6E399CA1E");

            entity.ToTable("SuspensionType");

            entity.HasIndex(e => e.SuspensionTypeName, "UQ__Suspensi__FCE0AEBAC72FC51E").IsUnique();

            entity.Property(e => e.SuspensionTypeId)
                .ValueGeneratedNever()
                .HasColumnName("SuspensionTypeID");
            entity.Property(e => e.SuspensionTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TransmissionType>(entity =>
        {
            entity.HasKey(e => e.TransmissionTypeId).HasName("PK__Transmis__B976249686CDD672");

            entity.ToTable("TransmissionType");

            entity.HasIndex(e => e.TransmissionTypeName, "UQ__Transmis__5AAFD6770C3A2CA8").IsUnique();

            entity.Property(e => e.TransmissionTypeId)
                .ValueGeneratedNever()
                .HasColumnName("TransmissionTypeID");
            entity.Property(e => e.TransmissionTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.VisitId).HasName("PK__Visit__4D3AA1BEAD2DA5A7");

            entity.ToTable("Visit");

            entity.Property(e => e.VisitId).HasColumnName("VisitID");
            entity.Property(e => e.ActualEndDate).HasColumnType("datetime");
            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.Details)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentStatusId).HasColumnName("PaymentStatusID");
            entity.Property(e => e.PlannedEndDate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.VisitDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.VisitStatusId).HasColumnName("VisitStatusID");

            entity.HasOne(d => d.Car).WithMany(p => p.Visits)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__Visit__CarID__1CBC4616");

            entity.HasOne(d => d.Employee).WithMany(p => p.Visits)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Visit__EmployeeI__1DB06A4F");

            entity.HasOne(d => d.PaymentStatus).WithMany(p => p.Visits)
                .HasForeignKey(d => d.PaymentStatusId)
                .HasConstraintName("FK__Visit__PaymentSt__1EA48E88");

            entity.HasOne(d => d.VisitStatus).WithMany(p => p.Visits)
                .HasForeignKey(d => d.VisitStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Visit__VisitStat__1BC821DD");
        });

        modelBuilder.Entity<VisitService>(entity =>
        {
            entity.HasKey(e => e.VisitServiceId).HasName("PK__VisitSer__97A666D19029D2CB");

            entity.ToTable("VisitService");

            entity.Property(e => e.VisitServiceId).HasColumnName("VisitServiceID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");

            entity.HasOne(d => d.Service).WithMany(p => p.VisitServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VisitServ__Servi__22751F6C");

            entity.HasOne(d => d.Visit).WithMany(p => p.VisitServices)
                .HasForeignKey(d => d.VisitId)
                .HasConstraintName("FK__VisitServ__Visit__2180FB33");
        });

        modelBuilder.Entity<VisitStatus>(entity =>
        {
            entity.HasKey(e => e.VisitStatusId).HasName("PK__VisitSta__8013A2F3B34EF93A");

            entity.ToTable("VisitStatus");

            entity.HasIndex(e => e.StatusName, "UQ__VisitSta__05E7698A007B09C0").IsUnique();

            entity.Property(e => e.VisitStatusId).HasColumnName("VisitStatusID");
            entity.Property(e => e.StatusName)
                .HasMaxLength(70)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
