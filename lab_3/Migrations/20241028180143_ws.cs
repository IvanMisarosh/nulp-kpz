using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab_3.Migrations
{
    /// <inheritdoc />
    public partial class CarServiceV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyType",
                columns: table => new
                {
                    BodyTypeID = table.Column<int>(type: "int", nullable: false),
                    BodyTypeName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BodyType__3F42D9814D081473", x => x.BodyTypeID);
                });

            migrationBuilder.CreateTable(
                name: "CarBrand",
                columns: table => new
                {
                    CarBrandID = table.Column<int>(type: "int", nullable: false),
                    BrandName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CarBrand__3EAE0B29EB7BA0BA", x => x.CarBrandID);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ColorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Color__8DA7676D5BE67B6B", x => x.ColorID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A4AE64B831C37328", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "DriveType",
                columns: table => new
                {
                    DriveTypeID = table.Column<int>(type: "int", nullable: false),
                    DriveTypeName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DriveTyp__05D279D71C9A2F32", x => x.DriveTypeID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePosition",
                columns: table => new
                {
                    EmployeePositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__6FDE9040257588CD", x => x.EmployeePositionID);
                });

            migrationBuilder.CreateTable(
                name: "EngineType",
                columns: table => new
                {
                    EngineTypeID = table.Column<int>(type: "int", nullable: false),
                    EngineTypeName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EngineTy__B01776DC7BAAB361", x => x.EngineTypeID);
                });

            migrationBuilder.CreateTable(
                name: "PartBrand",
                columns: table => new
                {
                    PartBrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PartBran__CAEA6FD94217E82E", x => x.PartBrandID);
                });

            migrationBuilder.CreateTable(
                name: "PartType",
                columns: table => new
                {
                    PartTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartTypeName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PartType__EDE4D59E9D0AACDD", x => x.PartTypeID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    PaymentStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentName = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PaymentS__34F8AC1F2A4157DA", x => x.PaymentStatusID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    ServiceTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTypeName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ServiceT__8ADFAA0CFCC5D982", x => x.ServiceTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    StationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Station__E0D8A6DD8BBA4695", x => x.StationID);
                });

            migrationBuilder.CreateTable(
                name: "SuspensionType",
                columns: table => new
                {
                    SuspensionTypeID = table.Column<int>(type: "int", nullable: false),
                    SuspensionTypeName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Suspensi__BAEC7EB6E399CA1E", x => x.SuspensionTypeID);
                });

            migrationBuilder.CreateTable(
                name: "TransmissionType",
                columns: table => new
                {
                    TransmissionTypeID = table.Column<int>(type: "int", nullable: false),
                    TransmissionTypeName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transmis__B976249686CDD672", x => x.TransmissionTypeID);
                });

            migrationBuilder.CreateTable(
                name: "VisitStatus",
                columns: table => new
                {
                    VisitStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VisitSta__8013A2F3B34EF93A", x => x.VisitStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    PartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartBrandID = table.Column<int>(type: "int", nullable: true),
                    PartTypeID = table.Column<int>(type: "int", nullable: true),
                    PartName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Dimensions = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    QuantityPerPackage = table.Column<int>(type: "int", nullable: true),
                    PricePerPackage = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Part__7C3F0D304C2ABA96", x => x.PartID);
                    table.ForeignKey(
                        name: "FK__Part__PartBrandI__787EE5A0",
                        column: x => x.PartBrandID,
                        principalTable: "PartBrand",
                        principalColumn: "PartBrandID");
                    table.ForeignKey(
                        name: "FK__Part__PartTypeID__797309D9",
                        column: x => x.PartTypeID,
                        principalTable: "PartType",
                        principalColumn: "PartTypeID");
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTypeID = table.Column<int>(type: "int", nullable: true),
                    ServiceName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Service__C51BB0EA8D2E2F36", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK__Service__Service__114A936A",
                        column: x => x.ServiceTypeID,
                        principalTable: "ServiceType",
                        principalColumn: "ServiceTypeID");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeePositionID = table.Column<int>(type: "int", nullable: true),
                    StationID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__7AD04FF1594F46A3", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK__Employee__Employ__08B54D69",
                        column: x => x.EmployeePositionID,
                        principalTable: "EmployeePosition",
                        principalColumn: "EmployeePositionID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK__Employee__Statio__09A971A2",
                        column: x => x.StationID,
                        principalTable: "Station",
                        principalColumn: "StationID");
                });

            migrationBuilder.CreateTable(
                name: "CarModel",
                columns: table => new
                {
                    CarModelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Dimensions = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    DriveTypeID = table.Column<int>(type: "int", nullable: true),
                    CarBrandID = table.Column<int>(type: "int", nullable: true),
                    SuspensionTypeID = table.Column<int>(type: "int", nullable: true),
                    TransmissionTypeID = table.Column<int>(type: "int", nullable: true),
                    EngineTypeID = table.Column<int>(type: "int", nullable: true),
                    BodyTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CarModel__C585C36F89C856B3", x => x.CarModelID);
                    table.ForeignKey(
                        name: "FK__CarModel__BodyTy__60A75C0F",
                        column: x => x.BodyTypeID,
                        principalTable: "BodyType",
                        principalColumn: "BodyTypeID");
                    table.ForeignKey(
                        name: "FK__CarModel__CarBra__5CD6CB2B",
                        column: x => x.CarBrandID,
                        principalTable: "CarBrand",
                        principalColumn: "CarBrandID");
                    table.ForeignKey(
                        name: "FK__CarModel__DriveT__5BE2A6F2",
                        column: x => x.DriveTypeID,
                        principalTable: "DriveType",
                        principalColumn: "DriveTypeID");
                    table.ForeignKey(
                        name: "FK__CarModel__Engine__5FB337D6",
                        column: x => x.EngineTypeID,
                        principalTable: "EngineType",
                        principalColumn: "EngineTypeID");
                    table.ForeignKey(
                        name: "FK__CarModel__Suspen__5DCAEF64",
                        column: x => x.SuspensionTypeID,
                        principalTable: "SuspensionType",
                        principalColumn: "SuspensionTypeID");
                    table.ForeignKey(
                        name: "FK__CarModel__Transm__5EBF139D",
                        column: x => x.TransmissionTypeID,
                        principalTable: "TransmissionType",
                        principalColumn: "TransmissionTypeID");
                });

            migrationBuilder.CreateTable(
                name: "PartInStation",
                columns: table => new
                {
                    PartInStationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationID = table.Column<int>(type: "int", nullable: false),
                    PartID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PartInSt__AE92DE83F804769E", x => x.PartInStationID);
                    table.ForeignKey(
                        name: "FK__PartInSta__PartI__02084FDA",
                        column: x => x.PartID,
                        principalTable: "Part",
                        principalColumn: "PartID");
                    table.ForeignKey(
                        name: "FK__PartInSta__Stati__01142BA1",
                        column: x => x.StationID,
                        principalTable: "Station",
                        principalColumn: "StationID");
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CarModelID = table.Column<int>(type: "int", nullable: false),
                    ColorID = table.Column<int>(type: "int", nullable: false),
                    ManufactureYear = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    VIN = table.Column<string>(type: "varchar(17)", unicode: false, maxLength: 17, nullable: true),
                    Mileage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Car__68A0340EEFEBB133", x => x.CarID);
                    table.ForeignKey(
                        name: "FK__Car__CarModelID__6C190EBB",
                        column: x => x.CarModelID,
                        principalTable: "CarModel",
                        principalColumn: "CarModelID");
                    table.ForeignKey(
                        name: "FK__Car__ColorID__6D0D32F4",
                        column: x => x.ColorID,
                        principalTable: "Color",
                        principalColumn: "ColorID");
                    table.ForeignKey(
                        name: "FK__Car__CustomerID__6B24EA82",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    VisitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitStatusID = table.Column<int>(type: "int", nullable: false),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    PaymentStatusID = table.Column<int>(type: "int", nullable: true),
                    VisitDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    PlannedEndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActualEndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Details = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    VisitNumber = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Visit__4D3AA1BEAD2DA5A7", x => x.VisitID);
                    table.ForeignKey(
                        name: "FK__Visit__CarID__1CBC4616",
                        column: x => x.CarID,
                        principalTable: "Car",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Visit__EmployeeI__1DB06A4F",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK__Visit__PaymentSt__1EA48E88",
                        column: x => x.PaymentStatusID,
                        principalTable: "PaymentStatus",
                        principalColumn: "PaymentStatusID");
                    table.ForeignKey(
                        name: "FK__Visit__VisitStat__1BC821DD",
                        column: x => x.VisitStatusID,
                        principalTable: "VisitStatus",
                        principalColumn: "VisitStatusID");
                });

            migrationBuilder.CreateTable(
                name: "VisitService",
                columns: table => new
                {
                    VisitServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitID = table.Column<int>(type: "int", nullable: false),
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VisitSer__97A666D19029D2CB", x => x.VisitServiceID);
                    table.ForeignKey(
                        name: "FK__VisitServ__Servi__22751F6C",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ServiceID");
                    table.ForeignKey(
                        name: "FK__VisitServ__Visit__2180FB33",
                        column: x => x.VisitID,
                        principalTable: "Visit",
                        principalColumn: "VisitID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProvidedService",
                columns: table => new
                {
                    ProvidedServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    VisitServiceID = table.Column<int>(type: "int", nullable: false),
                    ProvidedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Provided__F9D5757A238604A9", x => x.ProvidedServiceID);
                    table.ForeignKey(
                        name: "FK__ProvidedS__Emplo__2645B050",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK__ProvidedS__Visit__2739D489",
                        column: x => x.VisitServiceID,
                        principalTable: "VisitService",
                        principalColumn: "VisitServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequiredPart",
                columns: table => new
                {
                    RequiredPartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartInStationID = table.Column<int>(type: "int", nullable: false),
                    ProvidedServiceID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Required__6EA5F4741F9920AA", x => x.RequiredPartID);
                    table.ForeignKey(
                        name: "FK__RequiredP__PartI__2A164134",
                        column: x => x.PartInStationID,
                        principalTable: "PartInStation",
                        principalColumn: "PartInStationID");
                    table.ForeignKey(
                        name: "FK__RequiredP__Provi__2B0A656D",
                        column: x => x.ProvidedServiceID,
                        principalTable: "ProvidedService",
                        principalColumn: "ProvidedServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__BodyType__BBB9F784C008B655",
                table: "BodyType",
                column: "BodyTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarModelID",
                table: "Car",
                column: "CarModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ColorID",
                table: "Car",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_CustomerID",
                table: "Car",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "UQ__Car__C5DF234C06CA70EC",
                table: "Car",
                column: "VIN",
                unique: true,
                filter: "[VIN] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__CarBrand__2206CE9B8862FDD2",
                table: "CarBrand",
                column: "BrandName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_BodyTypeID",
                table: "CarModel",
                column: "BodyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_CarBrandID",
                table: "CarModel",
                column: "CarBrandID");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_DriveTypeID",
                table: "CarModel",
                column: "DriveTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_EngineTypeID",
                table: "CarModel",
                column: "EngineTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_SuspensionTypeID",
                table: "CarModel",
                column: "SuspensionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_TransmissionTypeID",
                table: "CarModel",
                column: "TransmissionTypeID");

            migrationBuilder.CreateIndex(
                name: "UQ__CarModel__67DC63B5820682CD",
                table: "CarModel",
                column: "ModelName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Color__C71A5A7BEC2CD5E9",
                table: "Color",
                column: "ColorName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Customer_Email_FirstName_LastName_PhoneNumber",
                table: "Customer",
                columns: new[] { "Email", "FirstName", "LastName", "PhoneNumber" },
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__DriveTyp__DA639FBC68B9442C",
                table: "DriveType",
                column: "DriveTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeePositionID",
                table: "Employee",
                column: "EmployeePositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_StationID",
                table: "Employee",
                column: "StationID");

            migrationBuilder.CreateIndex(
                name: "UQ_Employee_Phone_First_Last",
                table: "Employee",
                columns: new[] { "PhoneNumber", "FirstName", "LastName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__E46AEF426928F72A",
                table: "EmployeePosition",
                column: "PositionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__EngineTy__77F3361CCF50543A",
                table: "EngineType",
                column: "EngineTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Part_PartBrandID",
                table: "Part",
                column: "PartBrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Part_PartTypeID",
                table: "Part",
                column: "PartTypeID");

            migrationBuilder.CreateIndex(
                name: "UQ__PartBran__2206CE9BCE2C4E96",
                table: "PartBrand",
                column: "BrandName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartInStation_PartID",
                table: "PartInStation",
                column: "PartID");

            migrationBuilder.CreateIndex(
                name: "UQ_PartInStation_StationID_PartID",
                table: "PartInStation",
                columns: new[] { "StationID", "PartID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__PartType__E8493D2A5FAAFA4C",
                table: "PartType",
                column: "PartTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__PaymentS__FD0AE8EC65DCE085",
                table: "PaymentStatus",
                column: "PaymentName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedService_EmployeeID",
                table: "ProvidedService",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "UQ__Provided__97A666D074CD7968",
                table: "ProvidedService",
                column: "VisitServiceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequiredPart_PartInStationID",
                table: "RequiredPart",
                column: "PartInStationID");

            migrationBuilder.CreateIndex(
                name: "IX_RequiredPart_ProvidedServiceID",
                table: "RequiredPart",
                column: "ProvidedServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceTypeID",
                table: "Service",
                column: "ServiceTypeID");

            migrationBuilder.CreateIndex(
                name: "UQ__Service__A42B5F998B7F98C7",
                table: "Service",
                column: "ServiceName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__ServiceT__64009631F9572DD7",
                table: "ServiceType",
                column: "ServiceTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Station_Address_PhoneNumber",
                table: "Station",
                columns: new[] { "Address", "PhoneNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Suspensi__FCE0AEBAC72FC51E",
                table: "SuspensionType",
                column: "SuspensionTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Transmis__5AAFD6770C3A2CA8",
                table: "TransmissionType",
                column: "TransmissionTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visit_CarID",
                table: "Visit",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_EmployeeID",
                table: "Visit",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_PaymentStatusID",
                table: "Visit",
                column: "PaymentStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_VisitStatusID",
                table: "Visit",
                column: "VisitStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitService_ServiceID",
                table: "VisitService",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitService_VisitID",
                table: "VisitService",
                column: "VisitID");

            migrationBuilder.CreateIndex(
                name: "UQ__VisitSta__05E7698A007B09C0",
                table: "VisitStatus",
                column: "StatusName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequiredPart");

            migrationBuilder.DropTable(
                name: "PartInStation");

            migrationBuilder.DropTable(
                name: "ProvidedService");

            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "VisitService");

            migrationBuilder.DropTable(
                name: "PartBrand");

            migrationBuilder.DropTable(
                name: "PartType");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "VisitStatus");

            migrationBuilder.DropTable(
                name: "CarModel");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "EmployeePosition");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "BodyType");

            migrationBuilder.DropTable(
                name: "CarBrand");

            migrationBuilder.DropTable(
                name: "DriveType");

            migrationBuilder.DropTable(
                name: "EngineType");

            migrationBuilder.DropTable(
                name: "SuspensionType");

            migrationBuilder.DropTable(
                name: "TransmissionType");
        }
    }
}
