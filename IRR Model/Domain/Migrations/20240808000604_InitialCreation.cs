using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRR.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "LossEvent_EventCode_Seq");

            migrationBuilder.CreateTable(
                name: "__MigrationHistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContextKey = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Model = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProductVersion = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.__MigrationHistory", x => new { x.MigrationId, x.ContextKey });
                });

            migrationBuilder.CreateTable(
                name: "AlphaGuAnalysis",
                columns: table => new
                {
                    AlphaGuAnalysisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SimYears = table.Column<int>(type: "int", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AlphaGuAnalysis", x => x.AlphaGuAnalysisId);
                });

            migrationBuilder.CreateTable(
                name: "AppSection",
                columns: table => new
                {
                    AppSectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DataType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsEditable = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AppSection", x => x.AppSectionId);
                });

            migrationBuilder.CreateTable(
                name: "attrep_truncation_safeguard",
                columns: table => new
                {
                    latchTaskName = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    latchMachineGUID = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    LatchKey = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    latchLocker = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__attrep_t__65C99AC86CCB78C8", x => new { x.latchTaskName, x.latchMachineGUID, x.LatchKey });
                });

            migrationBuilder.CreateTable(
                name: "AuditTxn",
                columns: table => new
                {
                    AuditTxnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AuditTxn", x => x.AuditTxnId);
                });

            migrationBuilder.CreateTable(
                name: "BrokerGroup",
                columns: table => new
                {
                    BrokerGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RegisId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.BrokerGroup", x => x.BrokerGroupId);
                });

            migrationBuilder.CreateTable(
                name: "CedentGroup",
                columns: table => new
                {
                    CedentGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RegisId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.CedentGroup", x => x.CedentGroupId);
                });

            migrationBuilder.CreateTable(
                name: "CedentLoss",
                columns: table => new
                {
                    CedentLossId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LossEventId = table.Column<int>(type: "int", nullable: false),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Product = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    ValuationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidLoss = table.Column<double>(type: "float", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IncurredLoss = table.Column<double>(type: "float", nullable: false),
                    ClaimCount = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.CedentLoss", x => x.CedentLossId);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LegalEntCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    BaseCurrency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DefaultEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    DefaultDomain = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: ""),
                    DefaultReinsurerId = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    LegalRegion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "ContractClause",
                columns: table => new
                {
                    ContractClauseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ClauseType = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ContractClause", x => x.ContractClauseId);
                });

            migrationBuilder.CreateTable(
                name: "DBFile",
                columns: table => new
                {
                    DBFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FileData = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.DBFile", x => x.DBFileId);
                });

            migrationBuilder.CreateTable(
                name: "FXRate",
                columns: table => new
                {
                    FXRateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseCurrency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    FXDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.FXRate", x => x.FXRateId);
                });

            migrationBuilder.CreateTable(
                name: "FxRateSBF",
                columns: table => new
                {
                    FxRateSBFId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseCurrency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    FXDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.FxRateSBF", x => x.FxRateSBFId);
                });

            migrationBuilder.CreateTable(
                name: "Geography",
                columns: table => new
                {
                    GeographyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentGeographyId = table.Column<int>(type: "int", nullable: true),
                    GeoLevelCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CRESTACode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CRESTAName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AreaCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AreaName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubareaCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubareaName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Geography", x => x.GeographyId);
                    table.ForeignKey(
                        name: "FK_dbo.Geography_dbo.Geography_ParentGeographyId",
                        column: x => x.ParentGeographyId,
                        principalTable: "Geography",
                        principalColumn: "GeographyId");
                });

            migrationBuilder.CreateTable(
                name: "IndustryCalibrationAnalysis",
                columns: table => new
                {
                    IndustryCalibrationAnalysisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Platform = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Version = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Peril = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.IndustryCalibrationAnalysis", x => x.IndustryCalibrationAnalysisId);
                });

            migrationBuilder.CreateTable(
                name: "IndustryGuAnalysis",
                columns: table => new
                {
                    IndustryGuAnalysisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Platform = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Version = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Peril = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.IndustryGuAnalysis", x => x.IndustryGuAnalysisId);
                });

            migrationBuilder.CreateTable(
                name: "IndustryLossFilter",
                columns: table => new
                {
                    IndustryLossFilterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SelectedGeographyIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerilCodes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: false),
                    EventThreshold = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.IndustryLossFilter", x => x.IndustryLossFilterId);
                });

            migrationBuilder.CreateTable(
                name: "IndustryLossRegion",
                columns: table => new
                {
                    IndustryLossRegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.IndustryLossRegion", x => x.IndustryLossRegionId);
                });

            migrationBuilder.CreateTable(
                name: "LossPool",
                columns: table => new
                {
                    LossPoolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LegalEntity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StateCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LossPool", x => x.LossPoolId);
                });

            migrationBuilder.CreateTable(
                name: "LossZone",
                columns: table => new
                {
                    LossZoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LossZone", x => x.LossZoneId);
                });

            migrationBuilder.CreateTable(
                name: "MajorZone",
                columns: table => new
                {
                    MajorZoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StdvFactor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.MajorZone", x => x.MajorZoneId);
                });

            migrationBuilder.CreateTable(
                name: "NotificationEvent",
                columns: table => new
                {
                    NotificationEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventLevel = table.Column<int>(type: "int", nullable: false),
                    AlertRule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.NotificationEvent", x => x.NotificationEventId);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccessLevel = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Permission", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "PolicyTrackerLog",
                columns: table => new
                {
                    PolicyTrackerLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisMKey = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegisContractId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UpdatedFields = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PolicyTrackerLog", x => x.PolicyTrackerLogId);
                });

            migrationBuilder.CreateTable(
                name: "Portfolio",
                columns: table => new
                {
                    PortfolioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UWYear = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PortfolioType = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastPricedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPricedUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LossView = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, defaultValue: ""),
                    FXDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobStatus = table.Column<int>(type: "int", nullable: false),
                    RunStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RunEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    JobMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CessionAsOfDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrossROE = table.Column<double>(type: "float", nullable: false),
                    GrossCapital = table.Column<double>(type: "float", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Inception = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Attachment = table.Column<int>(type: "int", nullable: false),
                    EarningType = table.Column<int>(type: "int", nullable: false),
                    FilterString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RetroProgramIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasRetroSelection = table.Column<bool>(type: "bit", nullable: false),
                    UseCessionGross = table.Column<bool>(type: "bit", nullable: false),
                    ShouldStorePortfolioYelt = table.Column<bool>(type: "bit", nullable: false),
                    ShouldStorePortfolioYlt = table.Column<bool>(type: "bit", nullable: false),
                    ShouldStorePortMetricYlt = table.Column<bool>(type: "bit", nullable: false),
                    IsVerboseLoggingEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AsOfDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    UseRevised = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Portfolio", x => x.PortfolioId);
                });

            migrationBuilder.CreateTable(
                name: "PortLayerProjectedCessionPeriod",
                columns: table => new
                {
                    PortLayerProjectedCessionPeriodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Projected1OrigInception = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Projected1Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Projected2OrigInception = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Projected2Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PortLayerProjectedCessionPeriod", x => x.PortLayerProjectedCessionPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "PremiumSurplusRatio",
                columns: table => new
                {
                    PremiumSurplusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SurplusRatio = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PremiumSurplusRatio", x => x.PremiumSurplusId);
                });

            migrationBuilder.CreateTable(
                name: "PresetLDP",
                columns: table => new
                {
                    PresetLDPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PresetLDP", x => x.PresetLDPId);
                });

            migrationBuilder.CreateTable(
                name: "RiskZone",
                columns: table => new
                {
                    RiskZoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RegisId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    RegisName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    IRISTerritoryCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RiskZone", x => x.RiskZoneId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "SnpLob",
                columns: table => new
                {
                    SnpLobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PremiumFactor = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ReserveFactor = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SnpLob", x => x.SnpLobId);
                });

            migrationBuilder.CreateTable(
                name: "SubmissionWriteup",
                columns: table => new
                {
                    SubmissionWriteupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RiskFlowNotes = table.Column<string>(type: "ntext", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SpreadsheetData = table.Column<byte[]>(type: "image", nullable: true),
                    UWSpreadsheetData = table.Column<byte[]>(type: "image", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SubmissionWriteup", x => x.SubmissionWriteupId);
                });

            migrationBuilder.CreateTable(
                name: "tmpla",
                columns: table => new
                {
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    Peril = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<short>(type: "smallint", nullable: false),
                    MajorZone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Loss = table.Column<double>(type: "float", nullable: true),
                    DefaultMajorZonePct = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tmpra",
                columns: table => new
                {
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    Peril = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<short>(type: "smallint", nullable: false),
                    MajorZone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Loss = table.Column<double>(type: "float", nullable: true),
                    DefaultMajorZonePct = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TopUpZone",
                columns: table => new
                {
                    TopUpZoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ELThreshold = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Cession = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CessionCap = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CessionCapQS2 = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    ZoneStart = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    ZoneEnd = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.TopUpZone", x => x.TopUpZoneId);
                });

            migrationBuilder.CreateTable(
                name: "ZoneDefinition",
                columns: table => new
                {
                    ZoneDefinitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ZoneDefinition", x => x.ZoneDefinitionId);
                });

            migrationBuilder.CreateTable(
                name: "zzzIndustryLoss_DupRecs_Import_220920",
                columns: table => new
                {
                    LossEventId = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    State = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EstType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AlphaModelAnalysis",
                columns: table => new
                {
                    AlphaModelAnalysisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlphaGuAnalysisId = table.Column<int>(type: "int", nullable: false),
                    Peril = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DistributionType = table.Column<int>(type: "int", nullable: false),
                    TargetLR = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CV = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    TargetEL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Alpha = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RandomSeed = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DistributionLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AttachmentPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AlphaModelAnalysis", x => x.AlphaModelAnalysisId);
                    table.ForeignKey(
                        name: "FK_dbo.AlphaModelAnalysis_dbo.AlphaGuAnalysis_AlphaGuAnalysisId",
                        column: x => x.AlphaGuAnalysisId,
                        principalTable: "AlphaGuAnalysis",
                        principalColumn: "AlphaGuAnalysisId");
                });

            migrationBuilder.CreateTable(
                name: "AuditEvent",
                columns: table => new
                {
                    AuditEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditTxnId = table.Column<int>(type: "int", nullable: false),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    ObjectType = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    ObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AuditEvent", x => x.AuditEventId);
                    table.ForeignKey(
                        name: "FK_dbo.AuditEvent_dbo.AuditTxn_AuditTxnId",
                        column: x => x.AuditTxnId,
                        principalTable: "AuditTxn",
                        principalColumn: "AuditTxnId");
                });

            migrationBuilder.CreateTable(
                name: "Broker",
                columns: table => new
                {
                    BrokerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BrokerGroupId = table.Column<int>(type: "int", nullable: false),
                    RegisId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    StreetAddress2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    State = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    DomicileCountry = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    DomicileState = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    ArchAffiliate = table.Column<bool>(type: "bit", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalComments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IRISBrokerCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Broker", x => x.BrokerId);
                    table.ForeignKey(
                        name: "FK_dbo.Broker_dbo.BrokerGroup_BrokerGroupId",
                        column: x => x.BrokerGroupId,
                        principalTable: "BrokerGroup",
                        principalColumn: "BrokerGroupId");
                });

            migrationBuilder.CreateTable(
                name: "Cedent",
                columns: table => new
                {
                    CedentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CedentGroupId = table.Column<int>(type: "int", nullable: false),
                    RegisId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    StreetAddress2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    State = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    DomicileCountry = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    DomicileState = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FormerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NameChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    ArchAffiliate = table.Column<bool>(type: "bit", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalComments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Cedent", x => x.CedentId);
                    table.ForeignKey(
                        name: "FK_dbo.Cedent_dbo.CedentGroup_CedentGroupId",
                        column: x => x.CedentGroupId,
                        principalTable: "CedentGroup",
                        principalColumn: "CedentGroupId");
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    RegisId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Office", x => x.OfficeId);
                    table.ForeignKey(
                        name: "FK_dbo.Office_dbo.Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId");
                });

            migrationBuilder.CreateTable(
                name: "IndustryLossSubRegion",
                columns: table => new
                {
                    IndustryLossSubRegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndustryLossRegionId = table.Column<int>(type: "int", nullable: false),
                    GeographyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.IndustryLossSubRegion", x => x.IndustryLossSubRegionId);
                    table.ForeignKey(
                        name: "FK_dbo.IndustryLossSubRegion_dbo.Geography_GeographyId",
                        column: x => x.GeographyId,
                        principalTable: "Geography",
                        principalColumn: "GeographyId");
                    table.ForeignKey(
                        name: "FK_dbo.IndustryLossSubRegion_dbo.IndustryLossRegion_IndustryLossRegionId",
                        column: x => x.IndustryLossRegionId,
                        principalTable: "IndustryLossRegion",
                        principalColumn: "IndustryLossRegionId");
                });

            migrationBuilder.CreateTable(
                name: "PoolGuAnalysis",
                columns: table => new
                {
                    PoolGuAnalysisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LossPoolId = table.Column<int>(type: "int", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peril = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PoolGuAnalysis", x => x.PoolGuAnalysisId);
                    table.ForeignKey(
                        name: "FK_dbo.PoolGuAnalysis_dbo.LossPool_LossPoolId",
                        column: x => x.LossPoolId,
                        principalTable: "LossPool",
                        principalColumn: "LossPoolId");
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationEventId = table.Column<int>(type: "int", nullable: false),
                    EventLevel = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Subscription", x => x.SubscriptionId);
                    table.ForeignKey(
                        name: "FK_dbo.Subscription_dbo.NotificationEvent_NotificationEventId",
                        column: x => x.NotificationEventId,
                        principalTable: "NotificationEvent",
                        principalColumn: "NotificationEventId");
                });

            migrationBuilder.CreateTable(
                name: "PortAdj",
                columns: table => new
                {
                    PortAdjId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilterString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PortAdj", x => x.PortAdjId);
                    table.ForeignKey(
                        name: "FK_dbo.PortAdj_dbo.Portfolio_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolio",
                        principalColumn: "PortfolioId");
                });

            migrationBuilder.CreateTable(
                name: "PortfolioFX",
                columns: table => new
                {
                    PortfolioFXId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    FXRate = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FXDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PortfolioFX", x => x.PortfolioFXId);
                    table.ForeignKey(
                        name: "FK_dbo.PortfolioFX_dbo.Portfolio_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolio",
                        principalColumn: "PortfolioId");
                });

            migrationBuilder.CreateTable(
                name: "PortMetric",
                columns: table => new
                {
                    PortMetricId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    LossView = table.Column<int>(type: "int", nullable: false),
                    PortMetricType = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: true),
                    NumberOfLayersWithShare = table.Column<int>(type: "int", nullable: false),
                    MinInception = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxInception = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstLimit = table.Column<double>(type: "float", nullable: false),
                    AggLimit = table.Column<double>(type: "float", nullable: false),
                    DepositPremium = table.Column<double>(type: "float", nullable: false),
                    ReinstPremium = table.Column<double>(type: "float", nullable: false),
                    ExpectedGrossPremium = table.Column<double>(type: "float", nullable: false),
                    AveRolOnFirstLimit = table.Column<double>(type: "float", nullable: false),
                    RPAmount = table.Column<double>(type: "float", nullable: false),
                    RBAmount = table.Column<double>(type: "float", nullable: false),
                    EL = table.Column<double>(type: "float", nullable: false),
                    ELAmount = table.Column<double>(type: "float", nullable: false),
                    ELModeledAmount = table.Column<double>(type: "float", nullable: false),
                    ELNonModeledAmount = table.Column<double>(type: "float", nullable: false),
                    ELLargeLossAmount = table.Column<double>(type: "float", nullable: false),
                    ELAttritionalAmount = table.Column<double>(type: "float", nullable: false),
                    ELMultiple = table.Column<double>(type: "float", nullable: false),
                    LR = table.Column<double>(type: "float", nullable: false),
                    ProfitCommAmount = table.Column<double>(type: "float", nullable: false),
                    SSCommAmount = table.Column<double>(type: "float", nullable: false),
                    NCBCommAmount = table.Column<double>(type: "float", nullable: false),
                    ExpensesAmount = table.Column<double>(type: "float", nullable: false),
                    NetPremiumToExpenses = table.Column<double>(type: "float", nullable: false),
                    ER = table.Column<double>(type: "float", nullable: false),
                    CR = table.Column<double>(type: "float", nullable: false),
                    ExpectedProfit = table.Column<double>(type: "float", nullable: false),
                    StandaloneCapital = table.Column<double>(type: "float", nullable: false),
                    StandalonePML = table.Column<double>(type: "float", nullable: false),
                    PremiumFactor = table.Column<double>(type: "float", nullable: false),
                    ReserveFactor = table.Column<double>(type: "float", nullable: false),
                    RequiredCollateral = table.Column<double>(type: "float", nullable: false),
                    CollateralPctOfAggLimit = table.Column<double>(type: "float", nullable: false),
                    Leverage = table.Column<double>(type: "float", nullable: false),
                    StandaloneROE = table.Column<double>(type: "float", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ReasonStale = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PortMetric", x => x.PortMetricId);
                    table.ForeignKey(
                        name: "FK_dbo.PortMetric_dbo.Portfolio_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolio",
                        principalColumn: "PortfolioId");
                });

            migrationBuilder.CreateTable(
                name: "PresetLDPDist",
                columns: table => new
                {
                    PresetLDPDistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresetLDPId = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    PaidLossPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PresetLDPDist", x => x.PresetLDPDistId);
                    table.ForeignKey(
                        name: "FK_dbo.PresetLDPDist_dbo.PresetLDP_PresetLDPId",
                        column: x => x.PresetLDPId,
                        principalTable: "PresetLDP",
                        principalColumn: "PresetLDPId");
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    RolePermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RolePermission", x => x.RolePermissionId);
                    table.ForeignKey(
                        name: "FK_dbo.RolePermission_dbo.Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "PermissionId");
                    table.ForeignKey(
                        name: "FK_dbo.RolePermission_dbo.Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "TopUpZoneGeoMap",
                columns: table => new
                {
                    TopUpZoneGeoMapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopUpZoneId = table.Column<int>(type: "int", nullable: false),
                    GeoLevelCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    AreaCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.TopUpZoneGeoMap", x => x.TopUpZoneGeoMapId);
                    table.ForeignKey(
                        name: "FK_dbo.TopUpZoneGeoMap_dbo.TopUpZone_TopUpZoneId",
                        column: x => x.TopUpZoneId,
                        principalTable: "TopUpZone",
                        principalColumn: "TopUpZoneId");
                });

            migrationBuilder.CreateTable(
                name: "ZoneGeography",
                columns: table => new
                {
                    ZoneGeographyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneDefinitionId = table.Column<int>(type: "int", nullable: false),
                    GeographyId = table.Column<int>(type: "int", nullable: false),
                    Peril = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    LossZoneId = table.Column<int>(type: "int", nullable: false),
                    MajorZoneId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ZoneGeography", x => x.ZoneGeographyId);
                    table.ForeignKey(
                        name: "FK_dbo.ZoneGeography_dbo.Geography_GeographyId",
                        column: x => x.GeographyId,
                        principalTable: "Geography",
                        principalColumn: "GeographyId");
                    table.ForeignKey(
                        name: "FK_dbo.ZoneGeography_dbo.LossZone_LossZoneId",
                        column: x => x.LossZoneId,
                        principalTable: "LossZone",
                        principalColumn: "LossZoneId");
                    table.ForeignKey(
                        name: "FK_dbo.ZoneGeography_dbo.MajorZone_MajorZoneId",
                        column: x => x.MajorZoneId,
                        principalTable: "MajorZone",
                        principalColumn: "MajorZoneId");
                    table.ForeignKey(
                        name: "FK_dbo.ZoneGeography_dbo.ZoneDefinition_ZoneDefinitionId",
                        column: x => x.ZoneDefinitionId,
                        principalTable: "ZoneDefinition",
                        principalColumn: "ZoneDefinitionId");
                });

            migrationBuilder.CreateTable(
                name: "AuditDetail",
                columns: table => new
                {
                    AuditDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditEventId = table.Column<int>(type: "int", nullable: false),
                    Property = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    OrigValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AuditDetail", x => x.AuditDetailId);
                    table.ForeignKey(
                        name: "FK_dbo.AuditDetail_dbo.AuditEvent_AuditEventId",
                        column: x => x.AuditEventId,
                        principalTable: "AuditEvent",
                        principalColumn: "AuditEventId");
                });

            migrationBuilder.CreateTable(
                name: "BrokerContact",
                columns: table => new
                {
                    BrokerContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneCell = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmailPers = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BrokerId = table.Column<int>(type: "int", nullable: false),
                    RegisId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.BrokerContact", x => x.BrokerContactId);
                    table.ForeignKey(
                        name: "FK_dbo.BrokerContact_dbo.Broker_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Broker",
                        principalColumn: "BrokerId");
                });

            migrationBuilder.CreateTable(
                name: "CedentContact",
                columns: table => new
                {
                    CedentContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CedentId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cell = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Events = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Interests = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.CedentContact", x => x.CedentContactId);
                    table.ForeignKey(
                        name: "FK_dbo.CedentContact_dbo.Cedent_CedentId",
                        column: x => x.CedentId,
                        principalTable: "Cedent",
                        principalColumn: "CedentId");
                });

            migrationBuilder.CreateTable(
                name: "LossEvent",
                columns: table => new
                {
                    LossEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Peril = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PCSCatNum = table.Column<int>(type: "int", nullable: true),
                    AIREventId = table.Column<int>(type: "int", nullable: true),
                    RMSEventId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CedentId = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    EventYear = table.Column<int>(type: "int", nullable: false),
                    IndustryEventCode = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LossEvent", x => x.LossEventId);
                    table.ForeignKey(
                        name: "FK_dbo.LossEvent_dbo.Cedent_CedentId",
                        column: x => x.CedentId,
                        principalTable: "Cedent",
                        principalColumn: "CedentId");
                });

            migrationBuilder.CreateTable(
                name: "Dept",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    RegisId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeptEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Dept", x => x.DeptId);
                    table.ForeignKey(
                        name: "FK_dbo.Dept_dbo.Office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Office",
                        principalColumn: "OfficeId");
                });

            migrationBuilder.CreateTable(
                name: "PortAdjAction",
                columns: table => new
                {
                    PortAdjActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortAdjId = table.Column<int>(type: "int", nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    Prop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StringParam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PortAdjAction", x => x.PortAdjActionId);
                    table.ForeignKey(
                        name: "FK_dbo.PortAdjAction_dbo.PortAdj_PortAdjId",
                        column: x => x.PortAdjId,
                        principalTable: "PortAdj",
                        principalColumn: "PortAdjId");
                });

            migrationBuilder.CreateTable(
                name: "IndustryLoss",
                columns: table => new
                {
                    IndustryLossId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LossEventId = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    State = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    EstType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    EstInsPmt = table.Column<double>(type: "float", nullable: false),
                    ComAvgPmt = table.Column<double>(type: "float", nullable: true),
                    ComLoss = table.Column<double>(type: "float", nullable: true),
                    ComClaimCount = table.Column<double>(type: "float", nullable: true),
                    PersLoss = table.Column<double>(type: "float", nullable: true),
                    PersClaimCount = table.Column<double>(type: "float", nullable: true),
                    PersAvgPmt = table.Column<double>(type: "float", nullable: true),
                    AutoClaimCount = table.Column<double>(type: "float", nullable: true),
                    AutoAvgPmt = table.Column<double>(type: "float", nullable: true),
                    AutoLoss = table.Column<double>(type: "float", nullable: true),
                    WCClaimCount = table.Column<double>(type: "float", nullable: true),
                    WCAvgPmt = table.Column<double>(type: "float", nullable: true),
                    WCLoss = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    GeographyId = table.Column<int>(type: "int", nullable: false),
                    OnLevelDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    OnLevelLoss = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.IndustryLoss", x => x.IndustryLossId);
                    table.ForeignKey(
                        name: "FK_dbo.IndustryLoss_dbo.Geography_GeographyId",
                        column: x => x.GeographyId,
                        principalTable: "Geography",
                        principalColumn: "GeographyId");
                    table.ForeignKey(
                        name: "FK_dbo.IndustryLoss_dbo.LossEvent_LossEventId",
                        column: x => x.LossEventId,
                        principalTable: "LossEvent",
                        principalColumn: "LossEventId");
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CedentId = table.Column<int>(type: "int", nullable: false),
                    IsFac = table.Column<bool>(type: "bit", nullable: false),
                    RegisId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegisNbr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FacilityDefault = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SegmentDefault = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LOBDefault = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContractTypeDefault = table.Column<int>(type: "int", nullable: false),
                    LimitBasisDefault = table.Column<int>(type: "int", nullable: false),
                    ExtName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ReinsurerId = table.Column<int>(type: "int", nullable: false),
                    Insured = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsType = table.Column<int>(type: "int", nullable: false),
                    QSofXS = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Program", x => x.ProgramId);
                    table.ForeignKey(
                        name: "FK_dbo.Program_dbo.Cedent_CedentId",
                        column: x => x.CedentId,
                        principalTable: "Cedent",
                        principalColumn: "CedentId");
                    table.ForeignKey(
                        name: "FK_dbo.Program_dbo.Cedent_ReinsurerId",
                        column: x => x.ReinsurerId,
                        principalTable: "Cedent",
                        principalColumn: "CedentId");
                    table.ForeignKey(
                        name: "FK_dbo.Program_dbo.Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_dbo.Program_dbo.Dept_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Dept",
                        principalColumn: "DeptId");
                    table.ForeignKey(
                        name: "FK_dbo.Program_dbo.Office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Office",
                        principalColumn: "OfficeId");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RegisStaffCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RegisId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DefaultUserLayoutId = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    ProvisionedCompanies = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AdminComments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IRISUWCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExcludedOffices = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Upn = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_dbo.User_dbo.Dept_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Dept",
                        principalColumn: "DeptId");
                    table.ForeignKey(
                        name: "FK_dbo.User_dbo.Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "IndustryOnLevelLoss",
                columns: table => new
                {
                    IndustryOnLevelLossId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndustryLossId = table.Column<int>(type: "int", nullable: false),
                    OnLevelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OnLevelLoss = table.Column<double>(type: "float", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.IndustryOnLevelLoss", x => x.IndustryOnLevelLossId);
                    table.ForeignKey(
                        name: "FK_dbo.IndustryOnLevelLoss_dbo.IndustryLoss_IndustryLossId",
                        column: x => x.IndustryLossId,
                        principalTable: "IndustryLoss",
                        principalColumn: "IndustryLossId");
                });

            migrationBuilder.CreateTable(
                name: "AppPref",
                columns: table => new
                {
                    AppPrefId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Value3 = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    RegisValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RegisId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    AppSectionId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    LegalRegion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AppPref", x => x.AppPrefId);
                    table.ForeignKey(
                        name: "FK_dbo.AppPref_dbo.AppSection_AppSectionId",
                        column: x => x.AppSectionId,
                        principalTable: "AppSection",
                        principalColumn: "AppSectionId");
                    table.ForeignKey(
                        name: "FK_dbo.AppPref_dbo.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "ClientMemo",
                columns: table => new
                {
                    ClientMemoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrokerId = table.Column<int>(type: "int", nullable: true),
                    Conference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MeetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrokerRep = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ArchRep = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LOB = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LocationFollowup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MonthFollowup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Memo = table.Column<string>(type: "ntext", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ClientMemo", x => x.ClientMemoId);
                    table.ForeignKey(
                        name: "FK_dbo.ClientMemo_dbo.Broker_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Broker",
                        principalColumn: "BrokerId");
                    table.ForeignKey(
                        name: "FK_dbo.ClientMemo_dbo.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "ContractReviewerRule",
                columns: table => new
                {
                    ContractReviewerRuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewerId = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ContractReviewerRule", x => x.ContractReviewerRuleId);
                    table.ForeignKey(
                        name: "FK_dbo.ContractReviewerRule_dbo.User_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "LegalTerms",
                columns: table => new
                {
                    LegalTermsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddnlComments = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    WordingReceived = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WordingReturned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OsReason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OsAsOf = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Wind = table.Column<bool>(type: "bit", nullable: false),
                    WindHours = table.Column<int>(type: "int", nullable: false),
                    WindComments = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Quake = table.Column<bool>(type: "bit", nullable: false),
                    QuakeHours = table.Column<int>(type: "int", nullable: false),
                    QuakeComments = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Riot = table.Column<bool>(type: "bit", nullable: false),
                    RiotHours = table.Column<int>(type: "int", nullable: false),
                    RiotComments = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Flood = table.Column<bool>(type: "bit", nullable: false),
                    FloodHours = table.Column<int>(type: "int", nullable: false),
                    FloodComments = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OtherNat = table.Column<bool>(type: "bit", nullable: false),
                    OtherNatHours = table.Column<int>(type: "int", nullable: false),
                    OtherNatComments = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BrushFire = table.Column<bool>(type: "bit", nullable: false),
                    BrushFireHours = table.Column<int>(type: "int", nullable: false),
                    BrushFireComments = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TerrCert = table.Column<bool>(type: "bit", nullable: false),
                    ForeignIncl = table.Column<bool>(type: "bit", nullable: false),
                    NBC = table.Column<bool>(type: "bit", nullable: false),
                    Personal = table.Column<bool>(type: "bit", nullable: false),
                    Commercial = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TerrorComments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cyber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CyberColltzd = table.Column<bool>(type: "bit", nullable: false),
                    CyberComments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Freeze = table.Column<bool>(type: "bit", nullable: false),
                    FreezeHours = table.Column<int>(type: "int", nullable: false),
                    FreezeComments = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ReviewerId = table.Column<int>(type: "int", nullable: true),
                    LegalReview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommDiseaseExcl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommDiseaseComments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    ContractClauseSet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmailNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnderwriterDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnderwriterStatus = table.Column<int>(type: "int", nullable: false),
                    LegalReviewerId = table.Column<int>(type: "int", nullable: true),
                    LegalDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LegalDataLinkNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TAReviewerId = table.Column<int>(type: "int", nullable: true),
                    WordingStatus = table.Column<int>(type: "int", nullable: false),
                    ReviewerComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerLiabilityLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EcoXplPct = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    IsOccupationDisease = table.Column<bool>(type: "bit", nullable: false),
                    OccupationDiseaseHours = table.Column<int>(type: "int", nullable: true),
                    IsOccupationDiseasePerEmployee = table.Column<bool>(type: "bit", nullable: false),
                    IsOccupationDiseasePerEmployer = table.Column<bool>(type: "bit", nullable: false),
                    SunsetTerm = table.Column<int>(type: "int", nullable: true),
                    CommutationTerm = table.Column<int>(type: "int", nullable: true),
                    IsAffirmativeTerrorism = table.Column<bool>(type: "bit", nullable: false),
                    IsAbsoluteExclusion = table.Column<bool>(type: "bit", nullable: false),
                    IsPartialExclusion = table.Column<bool>(type: "bit", nullable: false),
                    IsNCBRExcluded = table.Column<bool>(type: "bit", nullable: false),
                    IsGovernmentalPoolBenefit = table.Column<bool>(type: "bit", nullable: false),
                    IsOtherInuringBenefitToReinsure = table.Column<bool>(type: "bit", nullable: false),
                    Territory = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsSilent = table.Column<bool>(type: "bit", nullable: false),
                    ReviewedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LegalTerms", x => x.LegalTermsId);
                    table.ForeignKey(
                        name: "FK_dbo.LegalTerms_dbo.User_LegalReviewerId",
                        column: x => x.LegalReviewerId,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_dbo.LegalTerms_dbo.User_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_dbo.LegalTerms_dbo.User_TAReviewerId",
                        column: x => x.TAReviewerId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "RetroProfile",
                columns: table => new
                {
                    RetroProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegisId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RetroProfile", x => x.RetroProfileId);
                    table.ForeignKey(
                        name: "FK_dbo.RetroProfile_dbo.Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_dbo.RetroProfile_dbo.Dept_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Dept",
                        principalColumn: "DeptId");
                    table.ForeignKey(
                        name: "FK_dbo.RetroProfile_dbo.Office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Office",
                        principalColumn: "OfficeId");
                    table.ForeignKey(
                        name: "FK_dbo.RetroProfile_dbo.User_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserLayout",
                columns: table => new
                {
                    UserLayoutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Layout = table.Column<string>(type: "ntext", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.UserLayout", x => x.UserLayoutId);
                    table.ForeignKey(
                        name: "FK_dbo.UserLayout_dbo.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                columns: table => new
                {
                    UserPermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.UserPermission", x => x.UserPermissionId);
                    table.ForeignKey(
                        name: "FK_dbo.UserPermission_dbo.Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "PermissionId");
                    table.ForeignKey(
                        name: "FK_dbo.UserPermission_dbo.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserSubscription",
                columns: table => new
                {
                    UserSubscriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilterCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiveAs = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.UserSubscription", x => x.UserSubscriptionId);
                    table.ForeignKey(
                        name: "FK_dbo.UserSubscription_dbo.Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "SubscriptionId");
                    table.ForeignKey(
                        name: "FK_dbo.UserSubscription_dbo.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "ClientMemoCedent",
                columns: table => new
                {
                    ClientMemoCedentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientMemoId = table.Column<int>(type: "int", nullable: false),
                    CedentId = table.Column<int>(type: "int", nullable: false),
                    ClientRep = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ClientMemoCedent", x => x.ClientMemoCedentId);
                    table.ForeignKey(
                        name: "FK_dbo.ClientMemoCedent_dbo.Cedent_CedentId",
                        column: x => x.CedentId,
                        principalTable: "Cedent",
                        principalColumn: "CedentId");
                    table.ForeignKey(
                        name: "FK_dbo.ClientMemoCedent_dbo.ClientMemo_ClientMemoId",
                        column: x => x.ClientMemoId,
                        principalTable: "ClientMemo",
                        principalColumn: "ClientMemoId");
                });

            migrationBuilder.CreateTable(
                name: "ClientMemoDoc",
                columns: table => new
                {
                    ClientMemoDocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ClientMemoId = table.Column<int>(type: "int", nullable: false),
                    DBFileId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ClientMemoDoc", x => x.ClientMemoDocId);
                    table.ForeignKey(
                        name: "FK_dbo.ClientMemoDoc_dbo.ClientMemo_ClientMemoId",
                        column: x => x.ClientMemoId,
                        principalTable: "ClientMemo",
                        principalColumn: "ClientMemoId");
                    table.ForeignKey(
                        name: "FK_dbo.ClientMemoDoc_dbo.DBFile_DBFileId",
                        column: x => x.DBFileId,
                        principalTable: "DBFile",
                        principalColumn: "DBFileId");
                });

            migrationBuilder.CreateTable(
                name: "ContractReviewerCriteria",
                columns: table => new
                {
                    ContractReviewerCriteriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractReviewerRuleId = table.Column<int>(type: "int", nullable: false),
                    FilterCriteriaPropertyType = table.Column<int>(type: "int", nullable: false),
                    FilterCriteriaValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    OperationType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ContractReviewerCriteria", x => x.ContractReviewerCriteriaId);
                    table.ForeignKey(
                        name: "FK_dbo.ContractReviewerCriteria_dbo.ContractReviewerRule_ContractReviewerRuleId",
                        column: x => x.ContractReviewerRuleId,
                        principalTable: "ContractReviewerRule",
                        principalColumn: "ContractReviewerRuleId");
                });

            migrationBuilder.CreateTable(
                name: "LegalTermClause",
                columns: table => new
                {
                    LegalTermClauseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractClauseId = table.Column<int>(type: "int", nullable: false),
                    LegalTermsId = table.Column<int>(type: "int", nullable: false),
                    CommentsTA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentsLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Applicable = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LegalTermClause", x => x.LegalTermClauseId);
                    table.ForeignKey(
                        name: "FK_dbo.LegalTermClause_dbo.ContractClause_ContractClauseId",
                        column: x => x.ContractClauseId,
                        principalTable: "ContractClause",
                        principalColumn: "ContractClauseId");
                    table.ForeignKey(
                        name: "FK_dbo.LegalTermClause_dbo.LegalTerms_LegalTermsId",
                        column: x => x.LegalTermsId,
                        principalTable: "LegalTerms",
                        principalColumn: "LegalTermsId");
                });

            migrationBuilder.CreateTable(
                name: "Submission",
                columns: table => new
                {
                    SubmissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    RegisId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BaseCurrency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    FXRate = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    FXDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TranType = table.Column<int>(type: "int", nullable: false),
                    InceptionDefault = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UWYearDefault = table.Column<int>(type: "int", nullable: false),
                    IsMultiyear = table.Column<bool>(type: "bit", nullable: false),
                    IsCancellable = table.Column<bool>(type: "bit", nullable: false),
                    ExpirationDefault = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuoteDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuthDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Arrived = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BrokerId = table.Column<int>(type: "int", nullable: false),
                    BrokerContactId = table.Column<int>(type: "int", nullable: true),
                    UnderwriterId = table.Column<int>(type: "int", nullable: false),
                    ActuaryId = table.Column<int>(type: "int", nullable: true),
                    AnalystId = table.Column<int>(type: "int", nullable: true),
                    ModelerId = table.Column<int>(type: "int", nullable: true),
                    RiskZoneId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "ntext", nullable: true),
                    UWNotes = table.Column<string>(type: "ntext", nullable: true),
                    Correspondence = table.Column<string>(type: "ntext", nullable: true),
                    StrategicNotes = table.Column<string>(type: "ntext", nullable: true),
                    RefId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsRenewal = table.Column<bool>(type: "bit", nullable: false),
                    DocStatus = table.Column<int>(type: "int", nullable: false),
                    ModelingStatus = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpiringSubmissionId = table.Column<int>(type: "int", nullable: true),
                    Surplus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientScore = table.Column<int>(type: "int", nullable: false),
                    SubmissionWriteupId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LegalTermsId = table.Column<int>(type: "int", nullable: true),
                    PlacementYear = table.Column<int>(type: "int", nullable: false),
                    ParentSubmissionId = table.Column<int>(type: "int", nullable: true),
                    CedentAltName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ModelingDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModelingNotes = table.Column<string>(type: "ntext", nullable: true),
                    DataLinkNotes = table.Column<string>(type: "ntext", nullable: true),
                    MdlStatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActuarialNotes = table.Column<string>(type: "ntext", nullable: true),
                    RelshipUnderwriterId = table.Column<int>(type: "int", nullable: true),
                    MarketShare = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    CorreAuthDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CorreStatus = table.Column<int>(type: "int", nullable: false),
                    ActuarialStatus = table.Column<int>(type: "int", nullable: false),
                    SubmissionDataLinkNotes = table.Column<string>(type: "ntext", nullable: true),
                    ActuarialDataLinkNotes = table.Column<string>(type: "ntext", nullable: true),
                    ActuarialDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsCorreInterest = table.Column<bool>(type: "bit", nullable: false),
                    ActuarialPriority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RegisSyncStatus = table.Column<int>(type: "int", nullable: false),
                    LastRegisSyncByUserId = table.Column<int>(type: "int", nullable: true),
                    LastRegisSyncDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModelingComplexity = table.Column<int>(type: "int", nullable: false),
                    ActuarialDataCheck = table.Column<string>(type: "ntext", nullable: true),
                    ActuarialRanking = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActuarialDataCheckRequested = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    ERCLossViewArch = table.Column<int>(type: "int", nullable: false),
                    ERCLossViewAir = table.Column<int>(type: "int", nullable: false),
                    ERCLossViewRMS = table.Column<int>(type: "int", nullable: false),
                    FxRateSBFUSD = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    FxRateSBFGBP = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    FxDateSBF = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IrisPolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RationaleQuote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RationaleAuth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RationaleSigned = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IrisSLA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCollateralized = table.Column<bool>(type: "bit", nullable: false),
                    BrokerRating = table.Column<int>(type: "int", nullable: false),
                    BrokerRationale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PNOCDays = table.Column<int>(type: "int", nullable: false),
                    ClientAdvocacyRating = table.Column<int>(type: "int", nullable: false),
                    ClientAdvocacyRationale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LMXIndicator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActuaryPeerReviewerId = table.Column<int>(type: "int", nullable: true),
                    ClientAdvocacyLink = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    GroupBuyerId = table.Column<int>(type: "int", nullable: true),
                    LocalBuyerId = table.Column<int>(type: "int", nullable: true),
                    IsActuaryPeerReviewNotRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Submission", x => x.SubmissionId);
                    table.ForeignKey(
                        name: "FK_dbo.Submission_dbo.BrokerContact_BrokerContactId",
                        column: x => x.BrokerContactId,
                        principalTable: "BrokerContact",
                        principalColumn: "BrokerContactId");
                    table.ForeignKey(
                        name: "FK_dbo.Submission_dbo.Broker_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Broker",
                        principalColumn: "BrokerId");
                    table.ForeignKey(
                        name: "FK_dbo.Submission_dbo.CedentContact_GroupBuyerId",
                        column: x => x.GroupBuyerId,
                        principalTable: "CedentContact",
                        principalColumn: "CedentContactId");
                    table.ForeignKey(
                        name: "FK_dbo.Submission_dbo.CedentContact_LocalBuyerId",
                        column: x => x.LocalBuyerId,
                        principalTable: "CedentContact",
                        principalColumn: "CedentContactId");
                    table.ForeignKey(
                        name: "FK_dbo.Submission_dbo.LegalTerms_LegalTermsId",
                        column: x => x.LegalTermsId,
                        principalTable: "LegalTerms",
                        principalColumn: "LegalTermsId");
                    table.ForeignKey(
                        name: "FK_dbo.Submission_dbo.Program_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Program",
                        principalColumn: "ProgramId");
                    table.ForeignKey(
                        name: "FK_dbo.Submission_dbo.RiskZone_RiskZoneId",
                        column: x => x.RiskZoneId,
                        principalTable: "RiskZone",
                        principalColumn: "RiskZoneId");
                    table.ForeignKey(
                        name: "FK_dbo.Submission_dbo.SubmissionWriteup_SubmissionWriteupId",
                        column: x => x.SubmissionWriteupId,
                        principalTable: "SubmissionWriteup",
                        principalColumn: "SubmissionWriteupId");
                    table.ForeignKey(
                        name: "FK_dbo.Submission_dbo.Submission_ExpiringSubmissionId",
                        column: x => x.ExpiringSubmissionId,
                        principalTable: "Submission",
                        principalColumn: "SubmissionId");
                    table.ForeignKey(
                        name: "FK_dbo.Submission_dbo.User_ActuaryId",
                        column: x => x.ActuaryId,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_dbo.Submission_dbo.User_ActuaryPeerReviewerId",
                        column: x => x.ActuaryPeerReviewerId,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_dbo.Submission_dbo.User_AnalystId",
                        column: x => x.AnalystId,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_dbo.Submission_dbo.User_LastRegisSyncByUserId",
                        column: x => x.LastRegisSyncByUserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_dbo.Submission_dbo.User_ModelerId",
                        column: x => x.ModelerId,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_dbo.Submission_dbo.User_RelshipUnderwriterId",
                        column: x => x.RelshipUnderwriterId,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_dbo.Submission_dbo.User_UnderwriterId",
                        column: x => x.UnderwriterId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Doc",
                columns: table => new
                {
                    DocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DocType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    DBFileId = table.Column<int>(type: "int", nullable: false),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Layers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    IsStale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Doc", x => x.DocId);
                    table.ForeignKey(
                        name: "FK_dbo.Doc_dbo.Submission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submission",
                        principalColumn: "SubmissionId");
                });

            migrationBuilder.CreateTable(
                name: "GuAnalysis",
                columns: table => new
                {
                    GuAnalysisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<int>(type: "int", nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Version = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Database = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Perils = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    RunDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobStatus = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ExtJobId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExtJobStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    JobMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Server = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SimYears = table.Column<int>(type: "int", nullable: false),
                    LossDetailType = table.Column<int>(type: "int", nullable: false),
                    ZoneDefinitionId = table.Column<int>(type: "int", nullable: true),
                    RunStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UseSwift = table.Column<bool>(type: "bit", nullable: false),
                    CompatibleVersions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdjustmentType = table.Column<int>(type: "int", nullable: false),
                    YeltRowCount = table.Column<int>(type: "int", nullable: false),
                    YeltGeoRowCount = table.Column<int>(type: "int", nullable: false),
                    GuAnalysisGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.GuAnalysis", x => x.GuAnalysisId);
                    table.ForeignKey(
                        name: "FK_dbo.GuAnalysis_dbo.Submission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submission",
                        principalColumn: "SubmissionId");
                    table.ForeignKey(
                        name: "FK_dbo.GuAnalysis_dbo.ZoneDefinition_ZoneDefinitionId",
                        column: x => x.ZoneDefinitionId,
                        principalTable: "ZoneDefinition",
                        principalColumn: "ZoneDefinitionId");
                });

            migrationBuilder.CreateTable(
                name: "Layer",
                columns: table => new
                {
                    LayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    LayerNum = table.Column<int>(type: "int", nullable: false),
                    SubLayerNum = table.Column<int>(type: "int", nullable: false),
                    ReinstCount = table.Column<int>(type: "int", nullable: false),
                    Placement = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    OccLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OccRetention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CascadeRetention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AAD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Var1Retention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Var2Retention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AggLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AggRetention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Franchise = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FranchiseReverse = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RiskLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inception = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UWYear = table.Column<int>(type: "int", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Facility = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Segment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LOB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContractType = table.Column<int>(type: "int", nullable: false),
                    LimitBasis = table.Column<int>(type: "int", nullable: false),
                    AttachBasis = table.Column<int>(type: "int", nullable: false),
                    LAETerm = table.Column<int>(type: "int", nullable: false),
                    LossTrigger = table.Column<int>(type: "int", nullable: false),
                    ROL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    QuoteROL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ERC = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    ERCModel = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ERCMid = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ERCPareto = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RegisId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegisNbr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegisMKey = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegisIdCt = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegisNbrCt = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BurnReported = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    BurnTrended = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    YearPeriodSelected = table.Column<int>(type: "int", nullable: false),
                    YearPeriodLoss = table.Column<int>(type: "int", nullable: false),
                    CatLoss1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CatLoss2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CatLoss3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstimatedShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SignedShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    AuthShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    QuotedShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LayerDesc = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RegisMsg = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ExpiringLayerId = table.Column<int>(type: "int", nullable: true),
                    Commission = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CommOverride = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Brokerage = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    OtherExpenses = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    IsVarComm = table.Column<bool>(type: "bit", nullable: false),
                    VarCommHi = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    VarCommLow = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    IsGrossUpComm = table.Column<bool>(type: "bit", nullable: false),
                    GrossUpFactor = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    IsSlidingScale = table.Column<bool>(type: "bit", nullable: false),
                    SSCommProv = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SSCommMax = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SSCommMin = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SSLossRatioProv = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SSLossRatioMax = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SSLossRatioMin = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    IsProfitComm = table.Column<bool>(type: "bit", nullable: false),
                    ProfitComm = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CCFYears = table.Column<int>(type: "int", nullable: false),
                    DCFYears = table.Column<int>(type: "int", nullable: false),
                    DCFAmount = table.Column<int>(type: "int", nullable: false),
                    PCStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ComAccountProtect = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ProfitCommissionExpAllowance = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PremiumFreq = table.Column<int>(type: "int", nullable: false),
                    AdjustmentBaseType = table.Column<int>(type: "int", nullable: false),
                    LayerType = table.Column<int>(type: "int", nullable: false),
                    FHCFBand = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TopUpZoneId = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    ERCQuote = table.Column<decimal>(type: "decimal(18,10)", nullable: true, defaultValue: 0m),
                    DeclineReason = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InuringLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RiskRetention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReinsurerExpenses = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LayerCategory = table.Column<int>(type: "int", nullable: false),
                    LayerCatalog = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuotePremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RiskZoneId = table.Column<int>(type: "int", nullable: true),
                    RelShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    TargetNetShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RegisLayerCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SnpLobId = table.Column<int>(type: "int", nullable: true),
                    InvestmentReturn = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    NonCatMarginAllowance = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LossDuration = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    DiversificationFactor = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    EarningType = table.Column<int>(type: "int", nullable: false),
                    SourceId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OrderPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    BrokerRef = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AcctBrokerId = table.Column<int>(type: "int", nullable: true),
                    IsAdditionalPremium = table.Column<bool>(type: "bit", nullable: false),
                    IsCommonAcct = table.Column<bool>(type: "bit", nullable: false),
                    EventNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsStopLoss = table.Column<bool>(type: "bit", nullable: false),
                    StopLossLimitPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    StopLossAttachPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    IsLossCorridor = table.Column<bool>(type: "bit", nullable: false),
                    LossCorridorBeginPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LossCorridorEndPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LossCorridorCedePct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    OccLimitInPct = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    OccRetnInPct = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    ExpiringCorreShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CorreAuthMin = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CorreAuthTarget = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CorreAuthMax = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CorreRenewalMin = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SharedToCorre = table.Column<int>(type: "int", nullable: false),
                    SignedCorreShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    QuotedCorreShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    AuthCorreShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    FrontingFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    NonCatWeightPC = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    NonCatWeightSS = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    BoundFXRate = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    BoundFXDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegisStatus = table.Column<int>(type: "int", nullable: false),
                    IsDifferentialTerms = table.Column<bool>(type: "bit", nullable: false),
                    RolRpp = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    WILResolution = table.Column<int>(type: "int", nullable: false),
                    IsParametric = table.Column<bool>(type: "bit", nullable: false),
                    PricingSource = table.Column<int>(type: "int", nullable: false),
                    IRISPolicySeqNumber = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    IRISStatus = table.Column<int>(type: "int", nullable: false),
                    IRISComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IRISRefId = table.Column<int>(type: "int", nullable: false),
                    IRISClassCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IRISBranchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IRISTradeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IRISPlacingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedGrossNetPremiumGBP = table.Column<double>(type: "float", nullable: false),
                    IRISProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StopLossBufferPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ERCActual = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    ERCActualSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ELMarketShare = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    ELHistoricalBurn = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    ELBroker = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    MAOL = table.Column<int>(type: "int", nullable: true),
                    NCBR = table.Column<bool>(type: "bit", nullable: false),
                    IsTerrorismSubLimitAppl = table.Column<bool>(type: "bit", nullable: false),
                    TerrorismSubLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TerrorismSubLimitComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LloydsCapital = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    LloydsROC = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    QuoteExpire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuthExpire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MktROL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    Cloud = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Ransom = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Layer", x => x.LayerId);
                    table.ForeignKey(
                        name: "FK_dbo.Layer_dbo.Broker_AcctBrokerId",
                        column: x => x.AcctBrokerId,
                        principalTable: "Broker",
                        principalColumn: "BrokerId");
                    table.ForeignKey(
                        name: "FK_dbo.Layer_dbo.Layer_ExpiringLayerId",
                        column: x => x.ExpiringLayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                    table.ForeignKey(
                        name: "FK_dbo.Layer_dbo.RiskZone_RiskZoneId",
                        column: x => x.RiskZoneId,
                        principalTable: "RiskZone",
                        principalColumn: "RiskZoneId");
                    table.ForeignKey(
                        name: "FK_dbo.Layer_dbo.Submission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submission",
                        principalColumn: "SubmissionId");
                });

            migrationBuilder.CreateTable(
                name: "LossEstScenario",
                columns: table => new
                {
                    LossEstScenarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<int>(type: "int", nullable: true),
                    LossAdjustmentIndex = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FXDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    IndLossFxRateUSD = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    IndustryLossFilterId = table.Column<int>(type: "int", nullable: true),
                    LossFreqMaxYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LossEstScenario", x => x.LossEstScenarioId);
                    table.ForeignKey(
                        name: "FK_dbo.LossEstScenario_dbo.IndustryLossFilter_IndustryLossFilterId",
                        column: x => x.IndustryLossFilterId,
                        principalTable: "IndustryLossFilter",
                        principalColumn: "IndustryLossFilterId");
                    table.ForeignKey(
                        name: "FK_dbo.LossEstScenario_dbo.Submission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submission",
                        principalColumn: "SubmissionId");
                });

            migrationBuilder.CreateTable(
                name: "ProgramRoeResult",
                columns: table => new
                {
                    ProgramRoeResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    LossView = table.Column<int>(type: "int", nullable: false),
                    CatPml = table.Column<double>(type: "float", nullable: true),
                    CatPmlAuth = table.Column<double>(type: "float", nullable: true),
                    CatPmlQuote = table.Column<double>(type: "float", nullable: true),
                    StandaloneROE = table.Column<double>(type: "float", nullable: true),
                    StandaloneROEAuth = table.Column<double>(type: "float", nullable: true),
                    StandaloneROEQuote = table.Column<double>(type: "float", nullable: true),
                    StandaloneCapital = table.Column<double>(type: "float", nullable: true),
                    StandaloneCapitalAuth = table.Column<double>(type: "float", nullable: true),
                    StandaloneCapitalQuote = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ProgramRoeResult", x => x.ProgramRoeResultId);
                    table.ForeignKey(
                        name: "FK_dbo.ProgramRoeResult_dbo.Submission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submission",
                        principalColumn: "SubmissionId");
                });

            migrationBuilder.CreateTable(
                name: "RiskTransferAnalysis",
                columns: table => new
                {
                    RiskTransferAnalysisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    Layers = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TreatyNbr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UWYear = table.Column<int>(type: "int", nullable: false),
                    IsSlidingScale = table.Column<bool>(type: "bit", nullable: false),
                    IsProfitComm = table.Column<bool>(type: "bit", nullable: false),
                    IsLossCorridor = table.Column<bool>(type: "bit", nullable: false),
                    IsAggLimitLess = table.Column<bool>(type: "bit", nullable: false),
                    IsExperienceAccount = table.Column<bool>(type: "bit", nullable: false),
                    IsFundsHeld = table.Column<bool>(type: "bit", nullable: false),
                    IsRated = table.Column<bool>(type: "bit", nullable: false),
                    IsRetroactiveContract = table.Column<bool>(type: "bit", nullable: false),
                    IsDerivativeAccounting = table.Column<bool>(type: "bit", nullable: false),
                    IsOptionsContract = table.Column<bool>(type: "bit", nullable: false),
                    IsFundBalance = table.Column<bool>(type: "bit", nullable: false),
                    IsPaymentTiming = table.Column<bool>(type: "bit", nullable: false),
                    HasSideAgreements = table.Column<bool>(type: "bit", nullable: false),
                    IsOthers = table.Column<bool>(type: "bit", nullable: false),
                    OtherDesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsCatException = table.Column<bool>(type: "bit", nullable: false),
                    LossProbability = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    LossPercentage = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    RiskTransferDiscussion = table.Column<bool>(type: "bit", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RiskTransferAnalysisNotes = table.Column<string>(type: "ntext", nullable: true),
                    CancelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsNoClaimBonus = table.Column<bool>(type: "bit", nullable: false),
                    IsMaintenanceFees = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RiskTransferAnalysis", x => x.RiskTransferAnalysisId);
                    table.ForeignKey(
                        name: "FK_dbo.RiskTransferAnalysis_dbo.Submission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submission",
                        principalColumn: "SubmissionId");
                });

            migrationBuilder.CreateTable(
                name: "SubmissionPxPortfolio",
                columns: table => new
                {
                    SubmissionPxPortfolioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    RunDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    JobStatus = table.Column<int>(type: "int", nullable: false),
                    JobMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SubmissionPxPortfolio", x => x.SubmissionPxPortfolioId);
                    table.ForeignKey(
                        name: "FK_dbo.SubmissionPxPortfolio_dbo.Portfolio_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolio",
                        principalColumn: "PortfolioId");
                    table.ForeignKey(
                        name: "FK_dbo.SubmissionPxPortfolio_dbo.Submission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submission",
                        principalColumn: "SubmissionId");
                });

            migrationBuilder.CreateTable(
                name: "ContractBinder",
                columns: table => new
                {
                    ContractBinderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    SubmissionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerId = table.Column<int>(type: "int", nullable: false),
                    BrokerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerOfficeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerContactId = table.Column<int>(type: "int", nullable: true),
                    BrokerContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActuaryId = table.Column<int>(type: "int", nullable: true),
                    ActuaryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalystId = table.Column<int>(type: "int", nullable: true),
                    AnalystName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelerId = table.Column<int>(type: "int", nullable: true),
                    ModelerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnderwriterId = table.Column<int>(type: "int", nullable: false),
                    UnderwriterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelshipUnderwriterId = table.Column<int>(type: "int", nullable: true),
                    RelshipUnderwriterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrategicNotes = table.Column<string>(type: "ntext", nullable: true),
                    UWYearDefaultExpiring = table.Column<int>(type: "int", nullable: true),
                    BaseCurrency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    FXRate = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    FXDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TranType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    InceptionDefault = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDefault = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UWYearDefault = table.Column<int>(type: "int", nullable: false),
                    IsMultiyear = table.Column<bool>(type: "bit", nullable: false),
                    IsCancellable = table.Column<bool>(type: "bit", nullable: false),
                    RefId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SubmissionStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    IsRenewal = table.Column<bool>(type: "bit", nullable: false),
                    ModelingStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ActuarialStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpiringSubmissionId = table.Column<int>(type: "int", nullable: true),
                    ExpiringSubmissionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MdlStatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CorreAuthDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CorreStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ActuarialDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActuarialPriority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModelingComplexity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ActuarialRanking = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CedentId = table.Column<int>(type: "int", nullable: false),
                    CedentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReinsurerId = table.Column<int>(type: "int", nullable: false),
                    ReinsurerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Insured = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    QSofXS = table.Column<bool>(type: "bit", nullable: false),
                    ContractBinderType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ContractBinderNotes = table.Column<string>(type: "ntext", nullable: true),
                    YoySummaryDivisor = table.Column<long>(type: "bigint", nullable: false),
                    YoySummaryCurrencyAndAmountSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossLimitQuote = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossLimitAuth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossLimitMultiYrIf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossLimitBoundNew = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossLimitTotalIf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossPremQuote = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossPremAuth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossPremMultiYrIf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossPremBoundNew = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossPremTotalIf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetLimitQuote = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetLimitAuth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetLimitMultiYrIf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetLimitBoundNew = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetLimitTotalIf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetPremQuote = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetPremAuth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetPremMultiYrIf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetPremBoundNew = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetPremTotalIf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossLimitQuoteExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossLimitAuthExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossLimitMultiYrIfExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossLimitBoundNewExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossLimitTotalIfExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossPremQuoteExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossPremAuthExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossPremMultiYrIfExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossPremBoundNewExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossPremTotalIfExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetLimitQuoteExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetLimitAuthExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetLimitMultiYrIfExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetLimitBoundNewExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetLimitTotalIfExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetPremQuoteExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetPremAuthExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetPremMultiYrIfExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetPremBoundNewExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetPremTotalIfExpiring = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CancelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warnings = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    RegisId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegisNbr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FxRateSBFUSD = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    FxRateSBFGBP = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    FxDateSBF = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rationale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocId = table.Column<int>(type: "int", nullable: true),
                    ChangeType = table.Column<int>(type: "int", nullable: true),
                    BrokerRating = table.Column<int>(type: "int", nullable: false),
                    BrokerRationale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientAdvocacyRating = table.Column<int>(type: "int", nullable: false),
                    ClientAdvocacyRationale = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ContractBinder", x => x.ContractBinderId);
                    table.ForeignKey(
                        name: "FK_dbo.ContractBinder_dbo.Doc_DocId",
                        column: x => x.DocId,
                        principalTable: "Doc",
                        principalColumn: "DocId");
                    table.ForeignKey(
                        name: "FK_dbo.ContractBinder_dbo.Submission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submission",
                        principalColumn: "SubmissionId");
                });

            migrationBuilder.CreateTable(
                name: "GuCurveAdjDef",
                columns: table => new
                {
                    GuCurveAdjDefId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceGuAnalysisId = table.Column<int>(type: "int", nullable: false),
                    TargetGuAnalysisId = table.Column<int>(type: "int", nullable: false),
                    PmlType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.GuCurveAdjDef", x => x.GuCurveAdjDefId);
                    table.ForeignKey(
                        name: "FK_dbo.GuCurveAdjDef_dbo.GuAnalysis_SourceGuAnalysisId",
                        column: x => x.SourceGuAnalysisId,
                        principalTable: "GuAnalysis",
                        principalColumn: "GuAnalysisId");
                    table.ForeignKey(
                        name: "FK_dbo.GuCurveAdjDef_dbo.GuAnalysis_TargetGuAnalysisId",
                        column: x => x.TargetGuAnalysisId,
                        principalTable: "GuAnalysis",
                        principalColumn: "GuAnalysisId");
                });

            migrationBuilder.CreateTable(
                name: "IndustryCalibrationDef",
                columns: table => new
                {
                    IndustryCalibrationDefId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceGuAnalysisId = table.Column<int>(type: "int", nullable: false),
                    SourceIndustryCalibrationAnalysisId = table.Column<int>(type: "int", nullable: false),
                    TargetGuAnalysisId = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.IndustryCalibrationDef", x => x.IndustryCalibrationDefId);
                    table.ForeignKey(
                        name: "FK_dbo.IndustryCalibrationDef_dbo.GuAnalysis_SourceGuAnalysisId",
                        column: x => x.SourceGuAnalysisId,
                        principalTable: "GuAnalysis",
                        principalColumn: "GuAnalysisId");
                    table.ForeignKey(
                        name: "FK_dbo.IndustryCalibrationDef_dbo.GuAnalysis_TargetGuAnalysisId",
                        column: x => x.TargetGuAnalysisId,
                        principalTable: "GuAnalysis",
                        principalColumn: "GuAnalysisId");
                    table.ForeignKey(
                        name: "FK_dbo.IndustryCalibrationDef_dbo.IndustryCalibrationAnalysis_SourceIndustryCalibrationAnalysisId",
                        column: x => x.SourceIndustryCalibrationAnalysisId,
                        principalTable: "IndustryCalibrationAnalysis",
                        principalColumn: "IndustryCalibrationAnalysisId");
                });

            migrationBuilder.CreateTable(
                name: "LossAnalysis",
                columns: table => new
                {
                    LossAnalysisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SimYears = table.Column<int>(type: "int", nullable: false),
                    JobStatus = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    JobMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RunDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReasonStale = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    EngineType = table.Column<int>(type: "int", nullable: false),
                    RunStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuAnalysisId = table.Column<int>(type: "int", nullable: true),
                    LossView = table.Column<int>(type: "int", nullable: false),
                    PerilEQ = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PerilWS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PerilCS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PerilWT = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PerilFL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PerilWF = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    GrowthEQ = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    GrowthWS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    GrowthCS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    GrowthWT = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    GrowthFL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    GrowthWF = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LaeEQ = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LaeWS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LaeCS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LaeWT = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LaeFL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LaeWF = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    IsCalcIndustryMetrics = table.Column<bool>(type: "bit", nullable: false),
                    Inflation = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SocialEQ = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SocialWS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SocialCS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SocialWT = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SocialFL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SocialWF = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CedentEQ = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CedentWS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CedentCS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CedentWT = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CedentFL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CedentWF = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SkipAggFeatures = table.Column<bool>(type: "bit", nullable: false),
                    LossAnalysisGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LossAnalysis", x => x.LossAnalysisId);
                    table.ForeignKey(
                        name: "FK_dbo.LossAnalysis_dbo.GuAnalysis_GuAnalysisId",
                        column: x => x.GuAnalysisId,
                        principalTable: "GuAnalysis",
                        principalColumn: "GuAnalysisId");
                    table.ForeignKey(
                        name: "FK_dbo.LossAnalysis_dbo.Submission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submission",
                        principalColumn: "SubmissionId");
                });

            migrationBuilder.CreateTable(
                name: "ModelAnalysis",
                columns: table => new
                {
                    ModelAnalysisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Platform = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Version = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Database = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AnalysisId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Perspective = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Peril = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Zones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    FXRate = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    FXDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RunDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RollUp = table.Column<int>(type: "int", nullable: false),
                    GuAnalysisId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ExcludedPerils = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExcludedGeographies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatyId = table.Column<int>(type: "int", nullable: false),
                    Server = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExcludedLobs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LossType = table.Column<byte>(type: "tinyint", nullable: false),
                    GeographyId = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CedentShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CurveType = table.Column<int>(type: "int", nullable: false),
                    YeltRowCount = table.Column<int>(type: "int", nullable: false),
                    YeltGeoRowCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ModelAnalysis", x => x.ModelAnalysisId);
                    table.ForeignKey(
                        name: "FK_dbo.ModelAnalysis_dbo.GuAnalysis_GuAnalysisId",
                        column: x => x.GuAnalysisId,
                        principalTable: "GuAnalysis",
                        principalColumn: "GuAnalysisId");
                });

            migrationBuilder.CreateTable(
                name: "PmlMatchingDef",
                columns: table => new
                {
                    PmlMatchingDefId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchingType = table.Column<int>(type: "int", nullable: false),
                    SourceType = table.Column<int>(type: "int", nullable: false),
                    SourceGuAnalysisId = table.Column<int>(type: "int", nullable: true),
                    SourceIndustryAnalysisId = table.Column<int>(type: "int", nullable: true),
                    TargetGuAnalysisId = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PmlMatchingDef", x => x.PmlMatchingDefId);
                    table.ForeignKey(
                        name: "FK_dbo.PmlMatchingDef_dbo.GuAnalysis_SourceGuAnalysisId",
                        column: x => x.SourceGuAnalysisId,
                        principalTable: "GuAnalysis",
                        principalColumn: "GuAnalysisId");
                    table.ForeignKey(
                        name: "FK_dbo.PmlMatchingDef_dbo.GuAnalysis_TargetGuAnalysisId",
                        column: x => x.TargetGuAnalysisId,
                        principalTable: "GuAnalysis",
                        principalColumn: "GuAnalysisId");
                    table.ForeignKey(
                        name: "FK_dbo.PmlMatchingDef_dbo.IndustryGuAnalysis_SourceIndustryAnalysisId",
                        column: x => x.SourceIndustryAnalysisId,
                        principalTable: "IndustryGuAnalysis",
                        principalColumn: "IndustryGuAnalysisId");
                });

            migrationBuilder.CreateTable(
                name: "SubmissionGuAnalysis",
                columns: table => new
                {
                    SubmissionGuAnalysisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuAnalysisId = table.Column<int>(type: "int", nullable: false),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    FXRate = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    FXDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SubmissionGuAnalysis", x => x.SubmissionGuAnalysisId);
                    table.ForeignKey(
                        name: "FK_dbo.SubmissionGuAnalysis_dbo.GuAnalysis_GuAnalysisId",
                        column: x => x.GuAnalysisId,
                        principalTable: "GuAnalysis",
                        principalColumn: "GuAnalysisId");
                    table.ForeignKey(
                        name: "FK_dbo.SubmissionGuAnalysis_dbo.Submission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submission",
                        principalColumn: "SubmissionId");
                });

            migrationBuilder.CreateTable(
                name: "LloydsRiskCode",
                columns: table => new
                {
                    LloydsRiskCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    RiskCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LloydsRiskCode", x => x.LloydsRiskCodeId);
                    table.ForeignKey(
                        name: "FK_dbo.LloydsRiskCode_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                });

            migrationBuilder.CreateTable(
                name: "LossViewResult",
                columns: table => new
                {
                    LossViewResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    LossView = table.Column<int>(type: "int", nullable: false),
                    RP = table.Column<double>(type: "float", nullable: true),
                    EL = table.Column<double>(type: "float", nullable: true),
                    ELAtt = table.Column<double>(type: "float", nullable: true),
                    ELLargeLoss = table.Column<double>(type: "float", nullable: true),
                    ELModeled = table.Column<double>(type: "float", nullable: true),
                    ELNonModeled = table.Column<double>(type: "float", nullable: true),
                    StdvAdj = table.Column<double>(type: "float", nullable: true),
                    PTM = table.Column<double>(type: "float", nullable: true),
                    PTMQuote = table.Column<double>(type: "float", nullable: true),
                    LR = table.Column<double>(type: "float", nullable: true),
                    LRAtt = table.Column<double>(type: "float", nullable: true),
                    LRLargeLoss = table.Column<double>(type: "float", nullable: true),
                    LRModeled = table.Column<double>(type: "float", nullable: true),
                    LRNonModeled = table.Column<double>(type: "float", nullable: true),
                    CR = table.Column<double>(type: "float", nullable: true),
                    RB = table.Column<double>(type: "float", nullable: true),
                    ProfitComm = table.Column<double>(type: "float", nullable: true),
                    NCBComm = table.Column<double>(type: "float", nullable: true),
                    SSComm = table.Column<double>(type: "float", nullable: true),
                    TotalExp = table.Column<double>(type: "float", nullable: true),
                    CatPml = table.Column<double>(type: "float", nullable: true),
                    StandaloneCapital = table.Column<double>(type: "float", nullable: true),
                    StandaloneROE = table.Column<double>(type: "float", nullable: true),
                    StandaloneROEQuote = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CatPmlQuote = table.Column<double>(type: "float", nullable: true),
                    StandaloneROECorreAuth = table.Column<double>(type: "float", nullable: true),
                    StandaloneROECorreQuote = table.Column<double>(type: "float", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LossViewResult", x => x.LossViewResultId);
                    table.ForeignKey(
                        name: "FK_dbo.LossViewResult_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                });

            migrationBuilder.CreateTable(
                name: "MultiyearShare",
                columns: table => new
                {
                    MultiyearShareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    UWYear = table.Column<int>(type: "int", nullable: false),
                    Inception = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Placement = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    EstimatedShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SignedShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    AuthShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    QuotedShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ROL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    BindYear = table.Column<int>(type: "int", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.MultiyearShare", x => x.MultiyearShareId);
                    table.ForeignKey(
                        name: "FK_dbo.MultiyearShare_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                });

            migrationBuilder.CreateTable(
                name: "PolicyTracker",
                columns: table => new
                {
                    PolicyTrackerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisMKey = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegisContractId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    RegisNbr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegisPgmNbr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RowEffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PolicyTracker", x => x.PolicyTrackerId);
                    table.ForeignKey(
                        name: "FK_dbo.PolicyTracker_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                });

            migrationBuilder.CreateTable(
                name: "PortLayer",
                columns: table => new
                {
                    PortLayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    Share = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ROL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    ShareAdjusted = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ROLAdjusted = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PremiumAdjusted = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsManualAdjustment = table.Column<bool>(type: "bit", nullable: false),
                    ReasonStale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PxMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobStatus = table.Column<int>(type: "int", nullable: false),
                    RunStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RunEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Share2Adjusted = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ROL2Adjusted = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Premium2Adjusted = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PortLayerProjectedCessionPeriodId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PortLayer", x => x.PortLayerId);
                    table.ForeignKey(
                        name: "FK_dbo.PortLayer_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                    table.ForeignKey(
                        name: "FK_dbo.PortLayer_dbo.PortLayerProjectedCessionPeriod_PortLayerProjectedCessionPeriodId",
                        column: x => x.PortLayerProjectedCessionPeriodId,
                        principalTable: "PortLayerProjectedCessionPeriod",
                        principalColumn: "PortLayerProjectedCessionPeriodId");
                    table.ForeignKey(
                        name: "FK_dbo.PortLayer_dbo.Portfolio_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolio",
                        principalColumn: "PortfolioId");
                });

            migrationBuilder.CreateTable(
                name: "PortRoeResult",
                columns: table => new
                {
                    PortRoeResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    GrossCapitalVar = table.Column<double>(type: "float", nullable: true),
                    NetCapitalVar = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturn = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturnWithFees = table.Column<double>(type: "float", nullable: true),
                    GrossCapitalTVar = table.Column<double>(type: "float", nullable: true),
                    GrossROEVar = table.Column<double>(type: "float", nullable: true),
                    NetROEVar = table.Column<double>(type: "float", nullable: true),
                    NetROEVarWithFees = table.Column<double>(type: "float", nullable: true),
                    GrossROETVar = table.Column<double>(type: "float", nullable: true),
                    GrossCatPmlVarArl = table.Column<double>(type: "float", nullable: true),
                    NetCatPmlArl = table.Column<double>(type: "float", nullable: true),
                    GrossCatPmlTVarArl = table.Column<double>(type: "float", nullable: true),
                    TargetRoe = table.Column<double>(type: "float", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PortRoeResult", x => x.PortRoeResultId);
                    table.ForeignKey(
                        name: "FK_dbo.PortRoeResult_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                    table.ForeignKey(
                        name: "FK_dbo.PortRoeResult_dbo.Portfolio_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolio",
                        principalColumn: "PortfolioId");
                });

            migrationBuilder.CreateTable(
                name: "PremiumBase",
                columns: table => new
                {
                    PremiumBaseId = table.Column<int>(type: "int", nullable: false),
                    SPIEst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SPIAct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SPIEstExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SPIActExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SIEst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SIAct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SIEstExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SIActExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EqEst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EqAct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EqEstExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EqActExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WdEst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WdAct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WdEstExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WdActExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MdEst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MdAct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MdEstExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MdActExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Flat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepositPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    DepositAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    MinAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Adjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PremiumMethod = table.Column<int>(type: "int", nullable: false),
                    NcbPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    AdjustmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstUltPremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAsCollected = table.Column<bool>(type: "bit", nullable: false),
                    IsPremiumPort = table.Column<bool>(type: "bit", nullable: false),
                    IsEqualInstallments = table.Column<bool>(type: "bit", nullable: false),
                    IsAccruals = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfInstallments = table.Column<int>(type: "int", nullable: true),
                    SettlementDays = table.Column<int>(type: "int", nullable: false),
                    ReportingDays = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CommAcctPrem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuoteCommAcctPrem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsSwingRated = table.Column<bool>(type: "bit", nullable: false),
                    SwingRateLossMultiplier = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    SwingRateMaxPct = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    SwingRateMinPct = table.Column<decimal>(type: "decimal(18,10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PremiumBase", x => x.PremiumBaseId);
                    table.ForeignKey(
                        name: "FK_dbo.PremiumBase_dbo.Layer_PremiumBaseId",
                        column: x => x.PremiumBaseId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                });

            migrationBuilder.CreateTable(
                name: "PxSection",
                columns: table => new
                {
                    PxSectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RollupOrder = table.Column<int>(type: "int", nullable: false),
                    YLTRollup = table.Column<int>(type: "int", nullable: false),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    PxLayerId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PxSection", x => x.PxSectionId);
                    table.ForeignKey(
                        name: "FK_dbo.PxSection_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                    table.ForeignKey(
                        name: "FK_dbo.PxSection_dbo.Layer_PxLayerId",
                        column: x => x.PxLayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                });

            migrationBuilder.CreateTable(
                name: "Reinstatement",
                columns: table => new
                {
                    ReinstatementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Brokerage = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsProRata = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Reinstatement", x => x.ReinstatementId);
                    table.ForeignKey(
                        name: "FK_dbo.Reinstatement_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                });

            migrationBuilder.CreateTable(
                name: "RoeAssumption",
                columns: table => new
                {
                    RoeAssumptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    RiskCarrier = table.Column<int>(type: "int", nullable: false),
                    CatastrophePremium = table.Column<double>(type: "float", nullable: false),
                    PremiumDuration = table.Column<double>(type: "float", nullable: false),
                    LossTiming = table.Column<int>(type: "int", nullable: false),
                    ProportionalWeight = table.Column<double>(type: "float", nullable: false),
                    CatastropheLossRatio = table.Column<double>(type: "float", nullable: false),
                    CatastropheOccurrenceLimit = table.Column<double>(type: "float", nullable: false),
                    PresetLDPId = table.Column<int>(type: "int", nullable: true),
                    AgencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RoeAssumption", x => x.RoeAssumptionId);
                    table.ForeignKey(
                        name: "FK_dbo.RoeAssumption_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                    table.ForeignKey(
                        name: "FK_dbo.RoeAssumption_dbo.PresetLDP_PresetLDPId",
                        column: x => x.PresetLDPId,
                        principalTable: "PresetLDP",
                        principalColumn: "PresetLDPId");
                });

            migrationBuilder.CreateTable(
                name: "RoeCapitalResult",
                columns: table => new
                {
                    RoeCapitalResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    FieldStatus = table.Column<int>(type: "int", nullable: false),
                    LossView = table.Column<int>(type: "int", nullable: false),
                    RoeResultBasis = table.Column<int>(type: "int", nullable: false),
                    PresentValueUnderwritingProfit = table.Column<double>(type: "float", nullable: true),
                    DiscountedCombinedRatio = table.Column<double>(type: "float", nullable: true),
                    DiscountedLossRatio = table.Column<double>(type: "float", nullable: true),
                    PremiumCharge = table.Column<double>(type: "float", nullable: true),
                    ReserveCharge = table.Column<double>(type: "float", nullable: true),
                    CatastropheCharge = table.Column<double>(type: "float", nullable: true),
                    AssetCharge = table.Column<double>(type: "float", nullable: true),
                    TotalCharge = table.Column<double>(type: "float", nullable: true),
                    AgencyCapitalCharge = table.Column<double>(type: "float", nullable: true),
                    ReturnOnEquity = table.Column<double>(type: "float", nullable: true),
                    DiscountRateOnReserves = table.Column<double>(type: "float", nullable: true),
                    DiscountRateOnPremiums = table.Column<double>(type: "float", nullable: true),
                    InvestmentYield = table.Column<double>(type: "float", nullable: true),
                    PaymentDuration = table.Column<double>(type: "float", nullable: true),
                    YieldCurveDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    OverallPremiumToSurplus = table.Column<double>(type: "float", nullable: true),
                    ImpliedMinimumCatastrophePremium = table.Column<double>(type: "float", nullable: true),
                    ImpliedCatastropheMargin = table.Column<double>(type: "float", nullable: true),
                    ImpliedMinimumCatastropheCapital = table.Column<double>(type: "float", nullable: true),
                    ImpliedCatastropheReserveCharge = table.Column<double>(type: "float", nullable: true),
                    OverallMinimumPremiumToSurplus = table.Column<double>(type: "float", nullable: true),
                    OverallMinimumCapital = table.Column<double>(type: "float", nullable: true),
                    OverallMinimumCapitalReturnOnEquity = table.Column<double>(type: "float", nullable: true),
                    MaximumCatastrophePremiumToSurplus = table.Column<double>(type: "float", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RoeCapitalResult", x => x.RoeCapitalResultId);
                    table.ForeignKey(
                        name: "FK_dbo.RoeCapitalResult_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                });

            migrationBuilder.CreateTable(
                name: "SSPoint",
                columns: table => new
                {
                    SSPointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    LossRatioFrom = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LossRatioTo = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SSPoint", x => x.SSPointId);
                    table.ForeignKey(
                        name: "FK_dbo.SSPoint_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                });

            migrationBuilder.CreateTable(
                name: "ExperienceLoss",
                columns: table => new
                {
                    ExperienceLossId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LossEstScenarioId = table.Column<int>(type: "int", nullable: false),
                    GeographyId = table.Column<int>(type: "int", nullable: false),
                    LossEventId = table.Column<int>(type: "int", nullable: true),
                    EventUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataSource = table.Column<int>(type: "int", nullable: false),
                    ValuationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EventYear = table.Column<int>(type: "int", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IndustryEventCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportedPeril = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Peril = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AreaCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubareaCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Division = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LineOfBusiness = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    ClaimsCount = table.Column<int>(type: "int", nullable: true),
                    IsOpen = table.Column<bool>(type: "bit", nullable: true),
                    ExposureAdjustment = table.Column<double>(type: "float", nullable: false),
                    IncurredLdfs = table.Column<double>(type: "float", nullable: false),
                    SeverityTrend = table.Column<double>(type: "float", nullable: false),
                    TotalExposureAdjustedLoss = table.Column<double>(type: "float", nullable: false),
                    ActualPaidLoss = table.Column<double>(type: "float", nullable: true),
                    ActualIncurredLoss = table.Column<double>(type: "float", nullable: false),
                    AsIfIncurredLoss = table.Column<double>(type: "float", nullable: true),
                    TrendedLossSelector = table.Column<int>(type: "int", nullable: false),
                    TrendedLoss = table.Column<double>(type: "float", nullable: false),
                    MarketShare = table.Column<double>(type: "float", nullable: true),
                    SelectedLayers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PCSCatNum = table.Column<int>(type: "int", nullable: true),
                    EventCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ExposureFactor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ExperienceLoss", x => x.ExperienceLossId);
                    table.ForeignKey(
                        name: "FK_dbo.ExperienceLoss_dbo.Geography_GeographyId",
                        column: x => x.GeographyId,
                        principalTable: "Geography",
                        principalColumn: "GeographyId");
                    table.ForeignKey(
                        name: "FK_dbo.ExperienceLoss_dbo.LossEstScenario_LossEstScenarioId",
                        column: x => x.LossEstScenarioId,
                        principalTable: "LossEstScenario",
                        principalColumn: "LossEstScenarioId");
                    table.ForeignKey(
                        name: "FK_dbo.ExperienceLoss_dbo.LossEvent_LossEventId",
                        column: x => x.LossEventId,
                        principalTable: "LossEvent",
                        principalColumn: "LossEventId");
                });

            migrationBuilder.CreateTable(
                name: "LayerLossEstScenario",
                columns: table => new
                {
                    LayerLossEstScenarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LossEstScenarioId = table.Column<int>(type: "int", nullable: false),
                    LayerId = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LayerLossEstScenario", x => x.LayerLossEstScenarioId);
                    table.ForeignKey(
                        name: "FK_dbo.LayerLossEstScenario_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                    table.ForeignKey(
                        name: "FK_dbo.LayerLossEstScenario_dbo.LossEstScenario_LossEstScenarioId",
                        column: x => x.LossEstScenarioId,
                        principalTable: "LossEstScenario",
                        principalColumn: "LossEstScenarioId");
                });

            migrationBuilder.CreateTable(
                name: "LossTrendFactor",
                columns: table => new
                {
                    LossTrendFactorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LossEstScenarioId = table.Column<int>(type: "int", nullable: false),
                    ExposureYear = table.Column<int>(type: "int", nullable: false),
                    HistoricalPremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DevelopFactor = table.Column<double>(type: "float", nullable: false),
                    ExposureTrend = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ExposureFactor = table.Column<double>(type: "float", nullable: false),
                    RateChange = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RateLevel = table.Column<double>(type: "float", nullable: false),
                    RateIndex = table.Column<double>(type: "float", nullable: false),
                    OnLevelPremium = table.Column<double>(type: "float", nullable: false),
                    PremiumIndex = table.Column<double>(type: "float", nullable: false),
                    IncurredLdfs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SeverityTrend = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SeverityFactor = table.Column<double>(type: "float", nullable: false),
                    HistPremXol = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HistPremProportional = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HistPremFacultative = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HistPremTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HistTivXol = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HistTivProportional = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HistTivFacultative = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HistTivTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HistTivIndex = table.Column<double>(type: "float", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    BaselineForPremiumIndex = table.Column<double>(type: "float", nullable: false),
                    FinalTrendFactor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LossTrendFactor", x => x.LossTrendFactorId);
                    table.ForeignKey(
                        name: "FK_dbo.LossTrendFactor_dbo.LossEstScenario_LossEstScenarioId",
                        column: x => x.LossEstScenarioId,
                        principalTable: "LossEstScenario",
                        principalColumn: "LossEstScenarioId");
                });

            migrationBuilder.CreateTable(
                name: "MarketShareFactor",
                columns: table => new
                {
                    MarketShareFactorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LossEstScenarioId = table.Column<int>(type: "int", nullable: false),
                    IndustryLossSubRegionId = table.Column<int>(type: "int", nullable: false),
                    Peril = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.MarketShareFactor", x => x.MarketShareFactorId);
                    table.ForeignKey(
                        name: "FK_dbo.MarketShareFactor_dbo.IndustryLossSubRegion_IndustryLossSubRegionId",
                        column: x => x.IndustryLossSubRegionId,
                        principalTable: "IndustryLossSubRegion",
                        principalColumn: "IndustryLossSubRegionId");
                    table.ForeignKey(
                        name: "FK_dbo.MarketShareFactor_dbo.LossEstScenario_LossEstScenarioId",
                        column: x => x.LossEstScenarioId,
                        principalTable: "LossEstScenario",
                        principalColumn: "LossEstScenarioId");
                });

            migrationBuilder.CreateTable(
                name: "RiskTransferAnalysisReviewer",
                columns: table => new
                {
                    RiskTransferAnalysisReviewerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RiskTransferAnalysisId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewerType = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RiskTransferAnalysisReviewer", x => x.RiskTransferAnalysisReviewerId);
                    table.ForeignKey(
                        name: "FK_dbo.RiskTransferAnalysisReviewer_dbo.RiskTransferAnalysis_RiskTransferAnalysisId",
                        column: x => x.RiskTransferAnalysisId,
                        principalTable: "RiskTransferAnalysis",
                        principalColumn: "RiskTransferAnalysisId");
                    table.ForeignKey(
                        name: "FK_dbo.RiskTransferAnalysisReviewer_dbo.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "DeltaPxResult",
                columns: table => new
                {
                    DeltaPxResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionPxPortfolioId = table.Column<int>(type: "int", nullable: false),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    GrossCapitalVarQuote = table.Column<double>(type: "float", nullable: true),
                    GrossCapitalVarAuth = table.Column<double>(type: "float", nullable: true),
                    GrossCapitalVarSigned = table.Column<double>(type: "float", nullable: true),
                    NetCapitalVarQuote = table.Column<double>(type: "float", nullable: true),
                    NetCapitalVarAuth = table.Column<double>(type: "float", nullable: true),
                    NetCapitalVarSigned = table.Column<double>(type: "float", nullable: true),
                    GrossCapitalTVarQuote = table.Column<double>(type: "float", nullable: true),
                    GrossCapitalTVarAuth = table.Column<double>(type: "float", nullable: true),
                    GrossCapitalTVarSigned = table.Column<double>(type: "float", nullable: true),
                    GrossROEVarQuote = table.Column<double>(type: "float", nullable: true),
                    GrossROEVarAuth = table.Column<double>(type: "float", nullable: true),
                    GrossROEVarSigned = table.Column<double>(type: "float", nullable: true),
                    NetROEVarQuote = table.Column<double>(type: "float", nullable: true),
                    NetROEVarAuth = table.Column<double>(type: "float", nullable: true),
                    NetROEVarSigned = table.Column<double>(type: "float", nullable: true),
                    GrossROETVarQuote = table.Column<double>(type: "float", nullable: true),
                    GrossROETVarAuth = table.Column<double>(type: "float", nullable: true),
                    GrossROETVarSigned = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NetROEVarWithFeesQuote = table.Column<double>(type: "float", nullable: true),
                    NetROEVarWithFeesAuth = table.Column<double>(type: "float", nullable: true),
                    NetROEVarWithFeesSigned = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturnQuote = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturnAuth = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturnSigned = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturnWithFeesQuote = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturnWithFeesAuth = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturnWithFeesSigned = table.Column<double>(type: "float", nullable: true),
                    GrossCatPmlVarArlQuote = table.Column<double>(type: "float", nullable: true),
                    GrossCatPmlVarArlAuth = table.Column<double>(type: "float", nullable: true),
                    GrossCatPmlVarArlSigned = table.Column<double>(type: "float", nullable: true),
                    NetCatPmlArlQuote = table.Column<double>(type: "float", nullable: true),
                    NetCatPmlArlAuth = table.Column<double>(type: "float", nullable: true),
                    NetCatPmlArlSigned = table.Column<double>(type: "float", nullable: true),
                    GrossCatPmlTVarArlQuote = table.Column<double>(type: "float", nullable: true),
                    GrossCatPmlTVarArlAuth = table.Column<double>(type: "float", nullable: true),
                    GrossCatPmlTVarArlSigned = table.Column<double>(type: "float", nullable: true),
                    TargetRoeQuote = table.Column<double>(type: "float", nullable: true),
                    TargetRoeAuth = table.Column<double>(type: "float", nullable: true),
                    TargetRoeSigned = table.Column<double>(type: "float", nullable: true),
                    GrossROEVarCorreQuote = table.Column<double>(type: "float", nullable: true),
                    GrossROEVarCorreAuth = table.Column<double>(type: "float", nullable: true),
                    ReasonStaleQuote = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ReasonStaleAuth = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ReasonStaleSigned = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    NetMinCapitalVarQuote = table.Column<double>(type: "float", nullable: true),
                    NetMinCapitalVarAuth = table.Column<double>(type: "float", nullable: true),
                    NetMinCapitalVarSigned = table.Column<double>(type: "float", nullable: true),
                    NetMinROEVarQuote = table.Column<double>(type: "float", nullable: true),
                    NetMinROEVarAuth = table.Column<double>(type: "float", nullable: true),
                    NetMinROEVarSigned = table.Column<double>(type: "float", nullable: true),
                    MaxCatPts = table.Column<double>(type: "float", nullable: true),
                    NetCatPmlTVarArlQuote = table.Column<double>(type: "float", nullable: true),
                    NetCatPmlTVarArlAuth = table.Column<double>(type: "float", nullable: true),
                    NetCatPmlTVarArlSigned = table.Column<double>(type: "float", nullable: true),
                    NetROETVarQuote = table.Column<double>(type: "float", nullable: true),
                    NetROETVarAuth = table.Column<double>(type: "float", nullable: true),
                    NetROETVarSigned = table.Column<double>(type: "float", nullable: true),
                    NetCapitalTVarQuote = table.Column<double>(type: "float", nullable: true),
                    NetCapitalTVarAuth = table.Column<double>(type: "float", nullable: true),
                    NetCapitalTVarSigned = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.DeltaPxResult", x => x.DeltaPxResultId);
                    table.ForeignKey(
                        name: "FK_dbo.DeltaPxResult_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                    table.ForeignKey(
                        name: "FK_dbo.DeltaPxResult_dbo.SubmissionPxPortfolio_SubmissionPxPortfolioId",
                        column: x => x.SubmissionPxPortfolioId,
                        principalTable: "SubmissionPxPortfolio",
                        principalColumn: "SubmissionPxPortfolioId");
                });

            migrationBuilder.CreateTable(
                name: "SubDeltaPxResult",
                columns: table => new
                {
                    SubDeltaPxResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionPxPortfolioId = table.Column<int>(type: "int", nullable: false),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    GrossCapitalVarQuote = table.Column<double>(type: "float", nullable: true),
                    GrossCapitalVarAuth = table.Column<double>(type: "float", nullable: true),
                    GrossCapitalVarSigned = table.Column<double>(type: "float", nullable: true),
                    NetCapitalVarQuote = table.Column<double>(type: "float", nullable: true),
                    NetCapitalVarAuth = table.Column<double>(type: "float", nullable: true),
                    NetCapitalVarSigned = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturnQuote = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturnAuth = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturnSigned = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturnWithFeesQuote = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturnWithFeesAuth = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturnWithFeesSigned = table.Column<double>(type: "float", nullable: true),
                    GrossCapitalTVarQuote = table.Column<double>(type: "float", nullable: true),
                    GrossCapitalTVarAuth = table.Column<double>(type: "float", nullable: true),
                    GrossCapitalTVarSigned = table.Column<double>(type: "float", nullable: true),
                    GrossROEVarQuote = table.Column<double>(type: "float", nullable: true),
                    GrossROEVarAuth = table.Column<double>(type: "float", nullable: true),
                    GrossROEVarSigned = table.Column<double>(type: "float", nullable: true),
                    NetROEVarQuote = table.Column<double>(type: "float", nullable: true),
                    NetROEVarAuth = table.Column<double>(type: "float", nullable: true),
                    NetROEVarSigned = table.Column<double>(type: "float", nullable: true),
                    NetROEVarWithFeesQuote = table.Column<double>(type: "float", nullable: true),
                    NetROEVarWithFeesAuth = table.Column<double>(type: "float", nullable: true),
                    NetROEVarWithFeesSigned = table.Column<double>(type: "float", nullable: true),
                    GrossROETVarQuote = table.Column<double>(type: "float", nullable: true),
                    GrossROETVarAuth = table.Column<double>(type: "float", nullable: true),
                    GrossROETVarSigned = table.Column<double>(type: "float", nullable: true),
                    GrossCatPmlVarArlQuote = table.Column<double>(type: "float", nullable: true),
                    GrossCatPmlVarArlAuth = table.Column<double>(type: "float", nullable: true),
                    GrossCatPmlVarArlSigned = table.Column<double>(type: "float", nullable: true),
                    NetCatPmlArlQuote = table.Column<double>(type: "float", nullable: true),
                    NetCatPmlArlAuth = table.Column<double>(type: "float", nullable: true),
                    NetCatPmlArlSigned = table.Column<double>(type: "float", nullable: true),
                    GrossCatPmlTVarArlQuote = table.Column<double>(type: "float", nullable: true),
                    GrossCatPmlTVarArlAuth = table.Column<double>(type: "float", nullable: true),
                    GrossCatPmlTVarArlSigned = table.Column<double>(type: "float", nullable: true),
                    TargetRoeQuote = table.Column<double>(type: "float", nullable: true),
                    TargetRoeAuth = table.Column<double>(type: "float", nullable: true),
                    TargetRoeSigned = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    GrossROEVarCorreQuote = table.Column<double>(type: "float", nullable: true),
                    GrossROEVarCorreAuth = table.Column<double>(type: "float", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    NetMinCapitalVarQuote = table.Column<double>(type: "float", nullable: true),
                    NetMinCapitalVarAuth = table.Column<double>(type: "float", nullable: true),
                    NetMinCapitalVarSigned = table.Column<double>(type: "float", nullable: true),
                    NetMinROEVarQuote = table.Column<double>(type: "float", nullable: true),
                    NetMinROEVarAuth = table.Column<double>(type: "float", nullable: true),
                    NetMinROEVarSigned = table.Column<double>(type: "float", nullable: true),
                    MaxCatPts = table.Column<double>(type: "float", nullable: true),
                    NetCatPmlTVarArlQuote = table.Column<double>(type: "float", nullable: true),
                    NetCatPmlTVarArlAuth = table.Column<double>(type: "float", nullable: true),
                    NetCatPmlTVarArlSigned = table.Column<double>(type: "float", nullable: true),
                    NetROETVarQuote = table.Column<double>(type: "float", nullable: true),
                    NetROETVarAuth = table.Column<double>(type: "float", nullable: true),
                    NetROETVarSigned = table.Column<double>(type: "float", nullable: true),
                    NetCapitalTVarQuote = table.Column<double>(type: "float", nullable: true),
                    NetCapitalTVarAuth = table.Column<double>(type: "float", nullable: true),
                    NetCapitalTVarSigned = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SubDeltaPxResult", x => x.SubDeltaPxResultId);
                    table.ForeignKey(
                        name: "FK_dbo.SubDeltaPxResult_dbo.SubmissionPxPortfolio_SubmissionPxPortfolioId",
                        column: x => x.SubmissionPxPortfolioId,
                        principalTable: "SubmissionPxPortfolio",
                        principalColumn: "SubmissionPxPortfolioId");
                    table.ForeignKey(
                        name: "FK_dbo.SubDeltaPxResult_dbo.Submission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submission",
                        principalColumn: "SubmissionId");
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractBinderId = table.Column<int>(type: "int", nullable: false),
                    ContractBinderType = table.Column<int>(type: "int", nullable: false),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    LayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LayerNum = table.Column<int>(type: "int", nullable: false),
                    SubLayerNum = table.Column<int>(type: "int", nullable: false),
                    LayerCategory = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LayerCatalog = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Inception = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UWYear = table.Column<int>(type: "int", nullable: false),
                    LayerDesc = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RegisMsg = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ExpiringLayerId = table.Column<int>(type: "int", nullable: true),
                    ExpiringLayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Placement = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ContractLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OccLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OccRetention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AggLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AggRetention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RiskLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RiskRetention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RiskZoneId = table.Column<int>(type: "int", nullable: false),
                    RiskZoneName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Franchise = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FranchiseReverse = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CessionTotal = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    TopUpZoneId = table.Column<int>(type: "int", nullable: true),
                    TopUpZone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReinstatementsDisplayShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReinstatementsDisplayFull = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facility = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Segment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LOB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContractType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LimitBasis = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AttachBasis = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LAETerm = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LossTrigger = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SourceId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RegisId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegisNbr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegisMKey = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SnpLobId = table.Column<int>(type: "int", nullable: true),
                    PremiumFactor = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    ReserveFactor = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    SnpLobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestmentReturn = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    NonCatMarginAllowance = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LossDuration = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    DiversificationFactor = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CommOverride = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Brokerage = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    OtherExpenses = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ReinsurerExpenses = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    IsVarComm = table.Column<bool>(type: "bit", nullable: false),
                    VarCommHi = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    VarCommLow = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    IsGrossUpComm = table.Column<bool>(type: "bit", nullable: false),
                    GrossUpFactor = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    IsSlidingScale = table.Column<bool>(type: "bit", nullable: false),
                    SSCommProv = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SSCommMax = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SSCommMin = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SSLossRatioProv = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SSLossRatioMax = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SSLossRatioMin = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    IsProfitComm = table.Column<bool>(type: "bit", nullable: false),
                    ProfitComm = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CCFYears = table.Column<int>(type: "int", nullable: false),
                    DCFYears = table.Column<int>(type: "int", nullable: false),
                    DCFAmount = table.Column<int>(type: "int", nullable: false),
                    PCStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PremiumFreq = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AdjustmentBaseType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EarningType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    BrokerRef = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AcctBrokerId = table.Column<int>(type: "int", nullable: true),
                    AcctBrokerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LayerType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FHCFBand = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    IsAdditionalPremium = table.Column<bool>(type: "bit", nullable: false),
                    IsCommonAcct = table.Column<bool>(type: "bit", nullable: false),
                    EventNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsStopLoss = table.Column<bool>(type: "bit", nullable: false),
                    StopLossLimitPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    StopLossAttachPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    IsLossCorridor = table.Column<bool>(type: "bit", nullable: false),
                    LossCorridorBeginPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LossCorridorEndPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LossCorridorCedePct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    OccLimitInPct = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    OccRetnInPct = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    ExpiringCorreShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CorreAuthMin = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CorreAuthTarget = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CorreAuthMax = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CorreRenewalMin = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SharedToCorre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FrontingFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ROL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ERC = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    Share = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ShareLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SharePremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CorreShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Warnings = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    BoundFXRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BoundFXDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegisStatus = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsApprovalRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsOccUnlimited = table.Column<bool>(type: "bit", nullable: false),
                    IsAggUnlimited = table.Column<bool>(type: "bit", nullable: false),
                    DisplayShareLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Contract", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_dbo.Contract_dbo.ContractBinder_ContractBinderId",
                        column: x => x.ContractBinderId,
                        principalTable: "ContractBinder",
                        principalColumn: "ContractBinderId");
                    table.ForeignKey(
                        name: "FK_dbo.Contract_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                });

            migrationBuilder.CreateTable(
                name: "ContractReviewer",
                columns: table => new
                {
                    ContractReviewerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractBinderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ContractReviewer", x => x.ContractReviewerId);
                    table.ForeignKey(
                        name: "FK_dbo.ContractReviewer_dbo.ContractBinder_ContractBinderId",
                        column: x => x.ContractBinderId,
                        principalTable: "ContractBinder",
                        principalColumn: "ContractBinderId");
                    table.ForeignKey(
                        name: "FK_dbo.ContractReviewer_dbo.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "SubDeltaPxResultContract",
                columns: table => new
                {
                    SubDeltaPxResultContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractBinderId = table.Column<int>(type: "int", nullable: false),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    PortfolioName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LossView = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    GrossCapitalVar = table.Column<double>(type: "float", nullable: true),
                    NetCapitalVar = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturn = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturnWithFees = table.Column<double>(type: "float", nullable: true),
                    GrossCapitalTVar = table.Column<double>(type: "float", nullable: true),
                    GrossROEVar = table.Column<double>(type: "float", nullable: true),
                    NetROEVar = table.Column<double>(type: "float", nullable: true),
                    NetROEVarWithFees = table.Column<double>(type: "float", nullable: true),
                    GrossROETVar = table.Column<double>(type: "float", nullable: true),
                    TargetRoe = table.Column<double>(type: "float", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SubDeltaPxResultContract", x => x.SubDeltaPxResultContractId);
                    table.ForeignKey(
                        name: "FK_dbo.SubDeltaPxResultContract_dbo.ContractBinder_ContractBinderId",
                        column: x => x.ContractBinderId,
                        principalTable: "ContractBinder",
                        principalColumn: "ContractBinderId");
                });

            migrationBuilder.CreateTable(
                name: "GuCurveAdjPmlSrc",
                columns: table => new
                {
                    GuCurveAdjPmlSrcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuCurveAdjDefId = table.Column<int>(type: "int", nullable: false),
                    ReturnPeriod = table.Column<int>(type: "int", nullable: false),
                    OEP = table.Column<double>(type: "float", nullable: false),
                    AEP = table.Column<double>(type: "float", nullable: false),
                    Peril = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrequencyFactor = table.Column<double>(type: "float", nullable: false),
                    SeverityFactor = table.Column<double>(type: "float", nullable: false),
                    MajorZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.GuCurveAdjPmlSrc", x => x.GuCurveAdjPmlSrcId);
                    table.ForeignKey(
                        name: "FK_dbo.GuCurveAdjPmlSrc_dbo.GuCurveAdjDef_GuCurveAdjDefId",
                        column: x => x.GuCurveAdjDefId,
                        principalTable: "GuCurveAdjDef",
                        principalColumn: "GuCurveAdjDefId");
                });

            migrationBuilder.CreateTable(
                name: "LayerLossAnalysis",
                columns: table => new
                {
                    LayerLossAnalysisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    LossAnalysisId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RP = table.Column<double>(type: "float", nullable: false),
                    StandaloneROE = table.Column<double>(type: "float", nullable: true),
                    EL = table.Column<double>(type: "float", nullable: false),
                    StdvAdj = table.Column<double>(type: "float", nullable: true),
                    GuAnalysisId = table.Column<int>(type: "int", nullable: true),
                    CR = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ER = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LR = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PerilEQ = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PerilWS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PerilCS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PerilWT = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PerilFL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PerilWF = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    GrowthEQ = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    GrowthWS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    GrowthCS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    GrowthWT = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    GrowthFL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    GrowthWF = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LaeEQ = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LaeWS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LaeCS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LaeWT = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LaeFL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LaeWF = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ELLargeLoss = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ELModeled = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ELNonModeled = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ELAttritional = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RB = table.Column<double>(type: "float", nullable: false),
                    TotalExp = table.Column<double>(type: "float", nullable: false),
                    CatPml = table.Column<double>(type: "float", nullable: false),
                    StandaloneCapital = table.Column<double>(type: "float", nullable: true),
                    StandaloneROEQuote = table.Column<double>(type: "float", nullable: true),
                    CatPmlQuote = table.Column<double>(type: "float", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    ReasonStale = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    AlphaGuAnalysisId = table.Column<int>(type: "int", nullable: true),
                    IncludeAttritional = table.Column<bool>(type: "bit", nullable: false),
                    IncludeLargeLoss = table.Column<bool>(type: "bit", nullable: false),
                    IncludeNonModel = table.Column<bool>(type: "bit", nullable: false),
                    Inflation = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SocialEQ = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SocialWS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SocialCS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SocialWT = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SocialFL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SocialWF = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CedentEQ = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CedentWS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CedentCS = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CedentWT = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CedentFL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CedentWF = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    IncludeModeled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LayerLossAnalysis", x => x.LayerLossAnalysisId);
                    table.ForeignKey(
                        name: "FK_dbo.LayerLossAnalysis_dbo.AlphaGuAnalysis_AlphaGuAnalysisId",
                        column: x => x.AlphaGuAnalysisId,
                        principalTable: "AlphaGuAnalysis",
                        principalColumn: "AlphaGuAnalysisId");
                    table.ForeignKey(
                        name: "FK_dbo.LayerLossAnalysis_dbo.GuAnalysis_GuAnalysisId",
                        column: x => x.GuAnalysisId,
                        principalTable: "GuAnalysis",
                        principalColumn: "GuAnalysisId");
                    table.ForeignKey(
                        name: "FK_dbo.LayerLossAnalysis_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                    table.ForeignKey(
                        name: "FK_dbo.LayerLossAnalysis_dbo.LossAnalysis_LossAnalysisId",
                        column: x => x.LossAnalysisId,
                        principalTable: "LossAnalysis",
                        principalColumn: "LossAnalysisId");
                });

            migrationBuilder.CreateTable(
                name: "TargetPMLDef",
                columns: table => new
                {
                    TargetPMLDefId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PMLMatchingDefId = table.Column<int>(type: "int", nullable: false),
                    LossZoneId = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peril = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RP = table.Column<int>(type: "int", nullable: false),
                    LossAmt = table.Column<double>(type: "float", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.TargetPMLDef", x => x.TargetPMLDefId);
                    table.ForeignKey(
                        name: "FK_dbo.TargetPMLDef_dbo.LossZone_LossZoneId",
                        column: x => x.LossZoneId,
                        principalTable: "LossZone",
                        principalColumn: "LossZoneId");
                    table.ForeignKey(
                        name: "FK_dbo.TargetPMLDef_dbo.PmlMatchingDef_PMLMatchingDefId",
                        column: x => x.PMLMatchingDefId,
                        principalTable: "PmlMatchingDef",
                        principalColumn: "PmlMatchingDefId");
                });

            migrationBuilder.CreateTable(
                name: "PolicyTrackerDetail",
                columns: table => new
                {
                    PolicyTrackerDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyTrackerId = table.Column<int>(type: "int", nullable: false),
                    RevoFieldName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ChildKey = table.Column<int>(type: "int", nullable: true),
                    ChildKeyType = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FieldValueNew = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangeUser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyTrackerDetailStatus = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PolicyTrackerDetail", x => x.PolicyTrackerDetailId);
                    table.ForeignKey(
                        name: "FK_dbo.PolicyTrackerDetail_dbo.PolicyTracker_PolicyTrackerId",
                        column: x => x.PolicyTrackerId,
                        principalTable: "PolicyTracker",
                        principalColumn: "PolicyTrackerId");
                });

            migrationBuilder.CreateTable(
                name: "PolicyUpdate",
                columns: table => new
                {
                    PolicyUpdateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyTrackerId = table.Column<int>(type: "int", nullable: false),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ChangeUser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PolicyUpdate", x => x.PolicyUpdateId);
                    table.ForeignKey(
                        name: "FK_dbo.PolicyUpdate_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                    table.ForeignKey(
                        name: "FK_dbo.PolicyUpdate_dbo.PolicyTracker_PolicyTrackerId",
                        column: x => x.PolicyTrackerId,
                        principalTable: "PolicyTracker",
                        principalColumn: "PolicyTrackerId");
                    table.ForeignKey(
                        name: "FK_dbo.PolicyUpdate_dbo.Submission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submission",
                        principalColumn: "SubmissionId");
                });

            migrationBuilder.CreateTable(
                name: "PortLayerEarnPattern",
                columns: table => new
                {
                    PortLayerEarnPatternId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortLayerId = table.Column<int>(type: "int", nullable: false),
                    LossView = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<short>(type: "smallint", nullable: false),
                    OccLoss = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PortLayerEarnPattern", x => x.PortLayerEarnPatternId);
                    table.ForeignKey(
                        name: "FK_dbo.PortLayerEarnPattern_dbo.PortLayer_PortLayerId",
                        column: x => x.PortLayerId,
                        principalTable: "PortLayer",
                        principalColumn: "PortLayerId");
                });

            migrationBuilder.CreateTable(
                name: "PortLayerFieldSelectionPerTypeResult",
                columns: table => new
                {
                    PortLayerFieldSelectionPerTypeResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortLayerId = table.Column<int>(type: "int", nullable: false),
                    Inforce = table.Column<int>(type: "int", nullable: false),
                    Next12 = table.Column<int>(type: "int", nullable: false),
                    CurrentYear = table.Column<int>(type: "int", nullable: false),
                    NextYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PortLayerFieldSelectionPerTypeResult", x => x.PortLayerFieldSelectionPerTypeResultId);
                    table.ForeignKey(
                        name: "FK_dbo.PortLayerFieldSelectionPerTypeResult_dbo.PortLayer_PortLayerId",
                        column: x => x.PortLayerId,
                        principalTable: "PortLayer",
                        principalColumn: "PortLayerId");
                });

            migrationBuilder.CreateTable(
                name: "PortLayerLossDuration",
                columns: table => new
                {
                    PortLayerLossDurationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortLayerId = table.Column<int>(type: "int", nullable: false),
                    LossView = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DayStart = table.Column<int>(type: "int", nullable: false),
                    DayEnd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PortLayerLossDuration", x => x.PortLayerLossDurationId);
                    table.ForeignKey(
                        name: "FK_dbo.PortLayerLossDuration_dbo.PortLayer_PortLayerId",
                        column: x => x.PortLayerId,
                        principalTable: "PortLayer",
                        principalColumn: "PortLayerId");
                });

            migrationBuilder.CreateTable(
                name: "PortLayerPriceResult",
                columns: table => new
                {
                    PortLayerPriceResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortLayerId = table.Column<int>(type: "int", nullable: false),
                    LossView = table.Column<int>(type: "int", nullable: false),
                    EarnPatternPctInforce = table.Column<double>(type: "float", nullable: true),
                    EarnPatternPctProjected = table.Column<double>(type: "float", nullable: true),
                    EarnPatternPctProjected2 = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PortLayerPriceResult", x => x.PortLayerPriceResultId);
                    table.ForeignKey(
                        name: "FK_dbo.PortLayerPriceResult_dbo.PortLayer_PortLayerId",
                        column: x => x.PortLayerId,
                        principalTable: "PortLayer",
                        principalColumn: "PortLayerId");
                });

            migrationBuilder.CreateTable(
                name: "PortPeriodResult",
                columns: table => new
                {
                    PortPeriodResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortLayerId = table.Column<int>(type: "int", nullable: false),
                    InforceInception = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InforceExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Next12Inception = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Next12Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentYearInception = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentYearExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextYearInception = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextYearExpiration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PortPeriodResult", x => x.PortPeriodResultId);
                    table.ForeignKey(
                        name: "FK_dbo.PortPeriodResult_dbo.PortLayer_PortLayerId",
                        column: x => x.PortLayerId,
                        principalTable: "PortLayer",
                        principalColumn: "PortLayerId");
                });

            migrationBuilder.CreateTable(
                name: "PremiumInstallment",
                columns: table => new
                {
                    PremiumInstallmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PremiumBaseId = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstallmentPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    InstallmentAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Brokerage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Override = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ncb = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PremiumInstallment", x => x.PremiumInstallmentId);
                    table.ForeignKey(
                        name: "FK_dbo.PremiumInstallment_dbo.PremiumBase_PremiumBaseId",
                        column: x => x.PremiumBaseId,
                        principalTable: "PremiumBase",
                        principalColumn: "PremiumBaseId");
                });

            migrationBuilder.CreateTable(
                name: "RoeLeverageFactor",
                columns: table => new
                {
                    RoeLeverageFactorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoeAssumptionId = table.Column<int>(type: "int", nullable: false),
                    ClassOfBusinessId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RoeLeverageFactor", x => x.RoeLeverageFactorId);
                    table.ForeignKey(
                        name: "FK_dbo.RoeLeverageFactor_dbo.RoeAssumption_RoeAssumptionId",
                        column: x => x.RoeAssumptionId,
                        principalTable: "RoeAssumption",
                        principalColumn: "RoeAssumptionId");
                });

            migrationBuilder.CreateTable(
                name: "RoeLossDevPattern",
                columns: table => new
                {
                    RoeLossDevPatternId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoeAssumptionId = table.Column<int>(type: "int", nullable: false),
                    AsOfMonth = table.Column<int>(type: "int", nullable: false),
                    PaidLoss = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RoeLossDevPattern", x => x.RoeLossDevPatternId);
                    table.ForeignKey(
                        name: "FK_dbo.RoeLossDevPattern_dbo.RoeAssumption_RoeAssumptionId",
                        column: x => x.RoeAssumptionId,
                        principalTable: "RoeAssumption",
                        principalColumn: "RoeAssumptionId");
                });

            migrationBuilder.CreateTable(
                name: "LayerExperienceLoss",
                columns: table => new
                {
                    LayerExperienceLossId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperienceLossId = table.Column<int>(type: "int", nullable: false),
                    LayerLossEstScenarioId = table.Column<int>(type: "int", nullable: false),
                    LayerLoss = table.Column<double>(type: "float", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LayerExperienceLoss", x => x.LayerExperienceLossId);
                    table.ForeignKey(
                        name: "FK_dbo.LayerExperienceLoss_dbo.ExperienceLoss_ExperienceLossId",
                        column: x => x.ExperienceLossId,
                        principalTable: "ExperienceLoss",
                        principalColumn: "ExperienceLossId");
                    table.ForeignKey(
                        name: "FK_dbo.LayerExperienceLoss_dbo.LayerLossEstScenario_LayerLossEstScenarioId",
                        column: x => x.LayerLossEstScenarioId,
                        principalTable: "LayerLossEstScenario",
                        principalColumn: "LayerLossEstScenarioId");
                });

            migrationBuilder.CreateTable(
                name: "LayerMarketShareFactor",
                columns: table => new
                {
                    LayerMarketShareFactorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketShareFactorId = table.Column<int>(type: "int", nullable: false),
                    LayerLossEstScenarioId = table.Column<int>(type: "int", nullable: false),
                    MarketShare = table.Column<double>(type: "float", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LayerMarketShareFactor", x => x.LayerMarketShareFactorId);
                    table.ForeignKey(
                        name: "FK_dbo.LayerMarketShareFactor_dbo.LayerLossEstScenario_LayerLossEstScenarioId",
                        column: x => x.LayerLossEstScenarioId,
                        principalTable: "LayerLossEstScenario",
                        principalColumn: "LayerLossEstScenarioId");
                    table.ForeignKey(
                        name: "FK_dbo.LayerMarketShareFactor_dbo.MarketShareFactor_MarketShareFactorId",
                        column: x => x.MarketShareFactorId,
                        principalTable: "MarketShareFactor",
                        principalColumn: "MarketShareFactorId");
                });

            migrationBuilder.CreateTable(
                name: "MarketShareLoss",
                columns: table => new
                {
                    MarketShareLossId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LossEstScenarioId = table.Column<int>(type: "int", nullable: false),
                    IndustryLossId = table.Column<int>(type: "int", nullable: false),
                    IndustryOnLevelLoss = table.Column<double>(type: "float", nullable: false),
                    IndustryOnLevelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MarketShareFactorId = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.MarketShareLoss", x => x.MarketShareLossId);
                    table.ForeignKey(
                        name: "FK_dbo.MarketShareLoss_dbo.IndustryLoss_IndustryLossId",
                        column: x => x.IndustryLossId,
                        principalTable: "IndustryLoss",
                        principalColumn: "IndustryLossId");
                    table.ForeignKey(
                        name: "FK_dbo.MarketShareLoss_dbo.LossEstScenario_LossEstScenarioId",
                        column: x => x.LossEstScenarioId,
                        principalTable: "LossEstScenario",
                        principalColumn: "LossEstScenarioId");
                    table.ForeignKey(
                        name: "FK_dbo.MarketShareLoss_dbo.MarketShareFactor_MarketShareFactorId",
                        column: x => x.MarketShareFactorId,
                        principalTable: "MarketShareFactor",
                        principalColumn: "MarketShareFactorId");
                });

            migrationBuilder.CreateTable(
                name: "DeltaPxResultContract",
                columns: table => new
                {
                    DeltaPxResultContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    PortfolioName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LossView = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ReasonStale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossCapitalVar = table.Column<double>(type: "float", nullable: true),
                    NetCapitalVar = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturn = table.Column<double>(type: "float", nullable: true),
                    NetExcessReturnWithFees = table.Column<double>(type: "float", nullable: true),
                    GrossCapitalTVar = table.Column<double>(type: "float", nullable: true),
                    GrossROEVar = table.Column<double>(type: "float", nullable: true),
                    NetROEVar = table.Column<double>(type: "float", nullable: true),
                    NetROEVarWithFees = table.Column<double>(type: "float", nullable: true),
                    GrossROETVar = table.Column<double>(type: "float", nullable: true),
                    TargetRoe = table.Column<double>(type: "float", nullable: true),
                    GrossROEVarCorre = table.Column<double>(type: "float", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NetMinCapitalVar = table.Column<double>(type: "float", nullable: true),
                    NetMinROEVar = table.Column<double>(type: "float", nullable: true),
                    MaxCatPts = table.Column<double>(type: "float", nullable: true),
                    NetROETVar = table.Column<double>(type: "float", nullable: true),
                    NetCapitalTVar = table.Column<double>(type: "float", nullable: true),
                    GrossCatPmlVarArl = table.Column<double>(type: "float", nullable: true),
                    GrossCatPmlTVarArl = table.Column<double>(type: "float", nullable: true),
                    NetCatPmlArl = table.Column<double>(type: "float", nullable: true),
                    NetCatPmlTVarArl = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.DeltaPxResultContract", x => x.DeltaPxResultContractId);
                    table.ForeignKey(
                        name: "FK_dbo.DeltaPxResultContract_dbo.Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId");
                });

            migrationBuilder.CreateTable(
                name: "LayerTopUpLossContract",
                columns: table => new
                {
                    LayerTopUpLossContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    TopUpZoneId = table.Column<int>(type: "int", nullable: false),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZoneLoss = table.Column<double>(type: "float", nullable: false),
                    ZoneLossPercent = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LayerTopUpLossContract", x => x.LayerTopUpLossContractId);
                    table.ForeignKey(
                        name: "FK_dbo.LayerTopUpLossContract_dbo.Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId");
                });

            migrationBuilder.CreateTable(
                name: "LossViewResultContract",
                columns: table => new
                {
                    LossViewResultContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    LossView = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    RP = table.Column<double>(type: "float", nullable: true),
                    EL = table.Column<double>(type: "float", nullable: true),
                    ELAmount = table.Column<double>(type: "float", nullable: true),
                    ELAtt = table.Column<double>(type: "float", nullable: true),
                    ELLargeLoss = table.Column<double>(type: "float", nullable: true),
                    ELModeled = table.Column<double>(type: "float", nullable: true),
                    ELNonModeled = table.Column<double>(type: "float", nullable: true),
                    StdvAdj = table.Column<double>(type: "float", nullable: true),
                    RB = table.Column<double>(type: "float", nullable: true),
                    ProfitComm = table.Column<double>(type: "float", nullable: true),
                    NCBComm = table.Column<double>(type: "float", nullable: true),
                    SSComm = table.Column<double>(type: "float", nullable: true),
                    TotalExp = table.Column<double>(type: "float", nullable: true),
                    ER = table.Column<double>(type: "float", nullable: true),
                    TotalPremium = table.Column<double>(type: "float", nullable: true),
                    ReinstPremAmount = table.Column<double>(type: "float", nullable: true),
                    PTM = table.Column<double>(type: "float", nullable: true),
                    LR = table.Column<double>(type: "float", nullable: true),
                    LRAtt = table.Column<double>(type: "float", nullable: true),
                    LRLargeLoss = table.Column<double>(type: "float", nullable: true),
                    LRModeled = table.Column<double>(type: "float", nullable: true),
                    LRNonModeled = table.Column<double>(type: "float", nullable: true),
                    CR = table.Column<double>(type: "float", nullable: true),
                    StandaloneCapital = table.Column<double>(type: "float", nullable: true),
                    StandaloneROE = table.Column<double>(type: "float", nullable: true),
                    StandaloneROECorre = table.Column<double>(type: "float", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CatPml = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LossViewResultContract", x => x.LossViewResultContractId);
                    table.ForeignKey(
                        name: "FK_dbo.LossViewResultContract_dbo.Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId");
                });

            migrationBuilder.CreateTable(
                name: "PremiumBaseContract",
                columns: table => new
                {
                    PremiumBaseContractId = table.Column<int>(type: "int", nullable: false),
                    PremiumMethod = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SPIEst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SPIAct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SPIEstExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SPIActExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SIEst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SIAct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SIEstExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SIActExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EqEst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EqAct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EqEstExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EqActExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WdEst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WdAct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WdEstExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WdActExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MdEst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MdAct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MdEstExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MdActExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Flat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepositPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    DepositAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    MinAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NcbPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    AdjustmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Adjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstUltPremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsAsCollected = table.Column<bool>(type: "bit", nullable: false),
                    IsPremiumPort = table.Column<bool>(type: "bit", nullable: false),
                    IsEqualInstallments = table.Column<bool>(type: "bit", nullable: false),
                    IsAccruals = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfInstallments = table.Column<int>(type: "int", nullable: true),
                    SettlementDays = table.Column<int>(type: "int", nullable: false),
                    ReportingDays = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PremiumBaseContract", x => x.PremiumBaseContractId);
                    table.ForeignKey(
                        name: "FK_dbo.PremiumBaseContract_dbo.Contract_PremiumBaseContractId",
                        column: x => x.PremiumBaseContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId");
                });

            migrationBuilder.CreateTable(
                name: "PxSectionContract",
                columns: table => new
                {
                    PxSectionContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    RollupOrder = table.Column<int>(type: "int", nullable: false),
                    YLTRollup = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    LayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PxLayerId = table.Column<int>(type: "int", nullable: false),
                    PxLayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PxSectionContract", x => x.PxSectionContractId);
                    table.ForeignKey(
                        name: "FK_dbo.PxSectionContract_dbo.Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId");
                });

            migrationBuilder.CreateTable(
                name: "ReinstatementContract",
                columns: table => new
                {
                    ReinstatementContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Brokerage = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ReinstatementContract", x => x.ReinstatementContractId);
                    table.ForeignKey(
                        name: "FK_dbo.ReinstatementContract_dbo.Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId");
                });

            migrationBuilder.CreateTable(
                name: "SSPointContract",
                columns: table => new
                {
                    SSPointContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    LossRatioFrom = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LossRatioTo = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SSPointContract", x => x.SSPointContractId);
                    table.ForeignKey(
                        name: "FK_dbo.SSPointContract_dbo.Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId");
                });

            migrationBuilder.CreateTable(
                name: "PolicyUpdateDetail",
                columns: table => new
                {
                    PolicyUpdateDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyUpdateId = table.Column<int>(type: "int", nullable: false),
                    RevoFieldName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ChildKey = table.Column<int>(type: "int", nullable: true),
                    ChildKeyType = table.Column<int>(type: "int", nullable: false),
                    PreviousValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevisedValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PolicyUpdateDetail", x => x.PolicyUpdateDetailId);
                    table.ForeignKey(
                        name: "FK_dbo.PolicyUpdateDetail_dbo.PolicyUpdate_PolicyUpdateId",
                        column: x => x.PolicyUpdateId,
                        principalTable: "PolicyUpdate",
                        principalColumn: "PolicyUpdateId");
                });

            migrationBuilder.CreateTable(
                name: "LayerMarketShareLoss",
                columns: table => new
                {
                    LayerMarketShareLossId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketShareLossId = table.Column<int>(type: "int", nullable: false),
                    LayerLossEstScenarioId = table.Column<int>(type: "int", nullable: false),
                    LayerLoss = table.Column<double>(type: "float", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LayerMarketShareLoss", x => x.LayerMarketShareLossId);
                    table.ForeignKey(
                        name: "FK_dbo.LayerMarketShareLoss_dbo.LayerLossEstScenario_LayerLossEstScenarioId",
                        column: x => x.LayerLossEstScenarioId,
                        principalTable: "LayerLossEstScenario",
                        principalColumn: "LayerLossEstScenarioId");
                    table.ForeignKey(
                        name: "FK_dbo.LayerMarketShareLoss_dbo.MarketShareLoss_MarketShareLossId",
                        column: x => x.MarketShareLossId,
                        principalTable: "MarketShareLoss",
                        principalColumn: "MarketShareLossId");
                });

            migrationBuilder.CreateTable(
                name: "PremiumInstallmentContract",
                columns: table => new
                {
                    PremiumInstallmentContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PremiumBaseContractId = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstallmentPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    InstallmentAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Brokerage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Override = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ncb = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PremiumInstallmentContract", x => x.PremiumInstallmentContractId);
                    table.ForeignKey(
                        name: "FK_dbo.PremiumInstallmentContract_dbo.PremiumBaseContract_PremiumBaseContractId",
                        column: x => x.PremiumBaseContractId,
                        principalTable: "PremiumBaseContract",
                        principalColumn: "PremiumBaseContractId");
                });

            migrationBuilder.CreateTable(
                name: "PortLayerCession",
                columns: table => new
                {
                    PortLayerCessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortLayerId = table.Column<int>(type: "int", nullable: false),
                    RetroProgramId = table.Column<int>(type: "int", nullable: false),
                    ShouldCessionApply = table.Column<bool>(type: "bit", nullable: false),
                    CessionGross = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CessionNet = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CessionNetAdjusted = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CessionFeesRaw = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    CalculationMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PortLayerCession", x => x.PortLayerCessionId);
                    table.ForeignKey(
                        name: "FK_dbo.PortLayerCession_dbo.PortLayer_PortLayerId",
                        column: x => x.PortLayerId,
                        principalTable: "PortLayer",
                        principalColumn: "PortLayerId");
                });

            migrationBuilder.CreateTable(
                name: "PortLayerCessionDuration",
                columns: table => new
                {
                    PortLayerCessionDurationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LossView = table.Column<int>(type: "int", nullable: false),
                    PortLayerId = table.Column<int>(type: "int", nullable: false),
                    RetroProgramId = table.Column<int>(type: "int", nullable: false),
                    DayStart = table.Column<int>(type: "int", nullable: false),
                    DayEnd = table.Column<int>(type: "int", nullable: false),
                    CessionNet = table.Column<double>(type: "float", nullable: false),
                    EarnPatternWeightPct = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PortLayerCessionDuration", x => x.PortLayerCessionDurationId);
                    table.ForeignKey(
                        name: "FK_dbo.PortLayerCessionDuration_dbo.PortLayer_PortLayerId",
                        column: x => x.PortLayerId,
                        principalTable: "PortLayer",
                        principalColumn: "PortLayerId");
                });

            migrationBuilder.CreateTable(
                name: "PortProjectedRetro",
                columns: table => new
                {
                    PortProjectedRetroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    RetroProgramId = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PortProjectedRetro", x => x.PortProjectedRetroId);
                    table.ForeignKey(
                        name: "FK_dbo.PortProjectedRetro_dbo.Portfolio_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolio",
                        principalColumn: "PortfolioId");
                });

            migrationBuilder.CreateTable(
                name: "RCSSPoint",
                columns: table => new
                {
                    RCSSPointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetroCommissionId = table.Column<int>(type: "int", nullable: false),
                    LossRatioFrom = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    LossRatioTo = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RCSSPoint", x => x.RCSSPointId);
                });

            migrationBuilder.CreateTable(
                name: "RetroAllocation",
                columns: table => new
                {
                    RetroAllocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    EL = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Zone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LayerId = table.Column<int>(type: "int", nullable: false),
                    RetroInvestorId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegisStatus = table.Column<int>(type: "int", nullable: false),
                    RegisMessage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CessionNet = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CessionDemand = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CessionGross = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CessionCapFactor = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CessionCapFactorSent = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    CessionGrossFinalSent = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    CessionNetFinalSent = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    AllocationStatus = table.Column<int>(type: "int", nullable: false),
                    Override = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    Brokerage = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    Taxes = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    OverrideSent = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    BrokerageSent = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    TaxesSent = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    ManagementFee = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    TailFee = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    IsPortInExpiredLayer = table.Column<bool>(type: "bit", nullable: false),
                    TopUpZoneId = table.Column<int>(type: "int", nullable: true),
                    CessionPlaced = table.Column<decimal>(type: "decimal(18,10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RetroAllocation", x => x.RetroAllocationId);
                    table.ForeignKey(
                        name: "FK_dbo.RetroAllocation_dbo.Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "LayerId");
                });

            migrationBuilder.CreateTable(
                name: "RetroBufferByEvent",
                columns: table => new
                {
                    RetroBufferByEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetroInvestorId = table.Column<int>(type: "int", nullable: false),
                    SortIndex = table.Column<int>(type: "int", nullable: false),
                    DayStart = table.Column<int>(type: "int", nullable: false),
                    DayEnd = table.Column<int>(type: "int", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MultiplierPct = table.Column<double>(type: "float", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RetroBufferByEvent", x => x.RetroBufferByEventId);
                });

            migrationBuilder.CreateTable(
                name: "RetroBufferByTime",
                columns: table => new
                {
                    RetroBufferByTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetroInvestorId = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BufferPct = table.Column<double>(type: "float", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RetroBufferByTime", x => x.RetroBufferByTimeId);
                });

            migrationBuilder.CreateTable(
                name: "RetroCommission",
                columns: table => new
                {
                    RetroCommissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BrokerId = table.Column<int>(type: "int", nullable: false),
                    BrokerContactId = table.Column<int>(type: "int", nullable: true),
                    BrokerageBasis = table.Column<int>(type: "int", nullable: false),
                    Brokerage = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Taxes = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Other = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    OverridePremBasisType = table.Column<int>(type: "int", nullable: false),
                    IsProfitComm = table.Column<bool>(type: "bit", nullable: false),
                    IsNoClaimBonus = table.Column<bool>(type: "bit", nullable: false),
                    ProfitComm2 = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RHOE2 = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PCShare = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PCShare2 = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CCFYears = table.Column<int>(type: "int", nullable: false),
                    DCFYears = table.Column<int>(type: "int", nullable: false),
                    DCFAmount = table.Column<int>(type: "int", nullable: false),
                    PCStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSlidingScale = table.Column<bool>(type: "bit", nullable: false),
                    SSCommProv = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SSCommMin = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SSLossRatioMin = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SSCommMax = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    SSLossRatioMax = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RetroProgramId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CommissionBasis = table.Column<int>(type: "int", nullable: false),
                    TailFeeBasis = table.Column<int>(type: "int", nullable: false),
                    TailFee = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    HurdleType = table.Column<int>(type: "int", nullable: false),
                    IsHighWaterMark = table.Column<bool>(type: "bit", nullable: false),
                    HighWaterMark = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RetroCommission", x => x.RetroCommissionId);
                    table.ForeignKey(
                        name: "FK_dbo.RetroCommission_dbo.BrokerContact_BrokerContactId",
                        column: x => x.BrokerContactId,
                        principalTable: "BrokerContact",
                        principalColumn: "BrokerContactId");
                    table.ForeignKey(
                        name: "FK_dbo.RetroCommission_dbo.Broker_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Broker",
                        principalColumn: "BrokerId");
                });

            migrationBuilder.CreateTable(
                name: "RetroProgram",
                columns: table => new
                {
                    RetroProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetroProfileId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UWYear = table.Column<int>(type: "int", nullable: false),
                    Inception = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RetroProgramType = table.Column<int>(type: "int", nullable: false),
                    RetroLevelType = table.Column<int>(type: "int", nullable: false),
                    CedeSelectionType = table.Column<int>(type: "int", nullable: false),
                    CessionType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SubjectOfficeIds = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubjectFacilities = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TgtInvestorColl = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TgtPremExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TgtPayCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstInvestorColl = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstPremExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstPayCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CmtdInvestorColl = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CmtdPremExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CmtdPayCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SignedInvestorColl = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SignedPremExp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SignedPayCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    DefaultRetroCommissionId = table.Column<int>(type: "int", nullable: false),
                    CanApplyZonalCession = table.Column<bool>(type: "bit", nullable: false),
                    CanApplyZonalROL = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegisSetupStatus = table.Column<int>(type: "int", nullable: false),
                    RegisSetupStatusMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CessionCapBuffer = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CanAttachCededContracts = table.Column<bool>(type: "bit", nullable: false),
                    SubjectLOBs = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsPortIn = table.Column<bool>(type: "bit", nullable: false),
                    IsPortOut = table.Column<bool>(type: "bit", nullable: false),
                    OriginalDeductions = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Override = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ManagementFee = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ProfitComm = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RHOE = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PerformanceFee = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    HurdleRate = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CanPortInExpiredLayers = table.Column<bool>(type: "bit", nullable: false),
                    HasSentPortInExpiredLayers = table.Column<bool>(type: "bit", nullable: false),
                    JobStatus = table.Column<int>(type: "int", nullable: false),
                    LastFinalizeDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    AllowAutoFinalize = table.Column<bool>(type: "bit", nullable: false),
                    IsProjected = table.Column<bool>(type: "bit", nullable: false),
                    IsCededContractsIncludedInRunRules = table.Column<bool>(type: "bit", nullable: false),
                    IsReplicated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RetroProgram", x => x.RetroProgramId);
                    table.ForeignKey(
                        name: "FK_dbo.RetroProgram_dbo.RetroCommission_DefaultRetroCommissionId",
                        column: x => x.DefaultRetroCommissionId,
                        principalTable: "RetroCommission",
                        principalColumn: "RetroCommissionId");
                    table.ForeignKey(
                        name: "FK_dbo.RetroProgram_dbo.RetroProfile_RetroProfileId",
                        column: x => x.RetroProfileId,
                        principalTable: "RetroProfile",
                        principalColumn: "RetroProfileId");
                });

            migrationBuilder.CreateTable(
                name: "RetroDoc",
                columns: table => new
                {
                    RetroDocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DocType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RetroProgramId = table.Column<int>(type: "int", nullable: false),
                    DBFileId = table.Column<int>(type: "int", nullable: false),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RetroDoc", x => x.RetroDocId);
                    table.ForeignKey(
                        name: "FK_dbo.RetroDoc_dbo.DBFile_DBFileId",
                        column: x => x.DBFileId,
                        principalTable: "DBFile",
                        principalColumn: "DBFileId");
                    table.ForeignKey(
                        name: "FK_dbo.RetroDoc_dbo.RetroProgram_RetroProgramId",
                        column: x => x.RetroProgramId,
                        principalTable: "RetroProgram",
                        principalColumn: "RetroProgramId");
                });

            migrationBuilder.CreateTable(
                name: "RetroProgramReset",
                columns: table => new
                {
                    RetroProgramResetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetroProgramId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TargetCollateral = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TargetPremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RetroProgramReset", x => x.RetroProgramResetId);
                    table.ForeignKey(
                        name: "FK_dbo.RetroProgramReset_dbo.RetroProgram_RetroProgramId",
                        column: x => x.RetroProgramId,
                        principalTable: "RetroProgram",
                        principalColumn: "RetroProgramId");
                });

            migrationBuilder.CreateTable(
                name: "RetroZone",
                columns: table => new
                {
                    RetroZoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetroProgramId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    ELLowerBound = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ELUpperBound = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ROLLowerBound = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ROLUpperBound = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Cession = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CessionCap = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CessionCapAdjusted = table.Column<double>(type: "float", nullable: false),
                    TopUpZoneId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RetroZone", x => x.RetroZoneId);
                    table.ForeignKey(
                        name: "FK_dbo.RetroZone_dbo.RetroProgram_RetroProgramId",
                        column: x => x.RetroProgramId,
                        principalTable: "RetroProgram",
                        principalColumn: "RetroProgramId");
                });

            migrationBuilder.CreateTable(
                name: "SPInsurer",
                columns: table => new
                {
                    SPInsurerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetroProgramId = table.Column<int>(type: "int", nullable: false),
                    SegregatedAccount = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ContractId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    InsurerId = table.Column<int>(type: "int", nullable: false),
                    TrustBank = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    TrustAccountNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FundsWithheldAccountNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InitialCommutationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalCommutationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SPInsurer", x => x.SPInsurerId);
                    table.ForeignKey(
                        name: "FK_dbo.SPInsurer_dbo.Cedent_InsurerId",
                        column: x => x.InsurerId,
                        principalTable: "Cedent",
                        principalColumn: "CedentId");
                    table.ForeignKey(
                        name: "FK_dbo.SPInsurer_dbo.RetroProgram_RetroProgramId",
                        column: x => x.RetroProgramId,
                        principalTable: "RetroProgram",
                        principalColumn: "RetroProgramId");
                });

            migrationBuilder.CreateTable(
                name: "RetroInvestor",
                columns: table => new
                {
                    RetroInvestorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SPInsurerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TargetCollateral = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NotionalCollateral = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvestmentEstimated = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    InvestmentAuth = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    InvestmentSigned = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    InvestmentEstimatedAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvestmentAuthAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvestmentSignedAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExcludedFacilities = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ExcludedLayerSubNos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExcludedDomiciles = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsFundsWithheld = table.Column<bool>(type: "bit", nullable: false),
                    RetroCommissionId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RuleDefs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    ExcludedLayerIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetPremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Override = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ManagementFee = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    ProfitComm = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    PerformanceFee = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RHOE = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    HurdleRate = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    IsPortIn = table.Column<bool>(type: "bit", nullable: false),
                    IsPortOut = table.Column<bool>(type: "bit", nullable: false),
                    RetroBufferType = table.Column<int>(type: "int", nullable: false),
                    CessionCapBufferPct = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RetroValuesToBuffer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RetroInvestor", x => x.RetroInvestorId);
                    table.ForeignKey(
                        name: "FK_dbo.RetroInvestor_dbo.RetroCommission_RetroCommissionId",
                        column: x => x.RetroCommissionId,
                        principalTable: "RetroCommission",
                        principalColumn: "RetroCommissionId");
                    table.ForeignKey(
                        name: "FK_dbo.RetroInvestor_dbo.SPInsurer_SPInsurerId",
                        column: x => x.SPInsurerId,
                        principalTable: "SPInsurer",
                        principalColumn: "SPInsurerId");
                });

            migrationBuilder.CreateTable(
                name: "RetroFacilityOverride",
                columns: table => new
                {
                    RetroFacilityOverrideId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetroInvestorId = table.Column<int>(type: "int", nullable: false),
                    Facility = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cession = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RetroFacilityOverride", x => x.RetroFacilityOverrideId);
                    table.ForeignKey(
                        name: "FK_dbo.RetroFacilityOverride_dbo.RetroInvestor_RetroInvestorId",
                        column: x => x.RetroInvestorId,
                        principalTable: "RetroInvestor",
                        principalColumn: "RetroInvestorId");
                });

            migrationBuilder.CreateTable(
                name: "RetroInvestorReset",
                columns: table => new
                {
                    RetroInvestorResetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetroInvestorId = table.Column<int>(type: "int", nullable: false),
                    RetroProgramResetId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TargetCollateral = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TargetPremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvestmentSignedAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvestmentSigned = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RetroInvestorReset", x => x.RetroInvestorResetId);
                    table.ForeignKey(
                        name: "FK_dbo.RetroInvestorReset_dbo.RetroInvestor_RetroInvestorId",
                        column: x => x.RetroInvestorId,
                        principalTable: "RetroInvestor",
                        principalColumn: "RetroInvestorId");
                    table.ForeignKey(
                        name: "FK_dbo.RetroInvestorReset_dbo.RetroProgramReset_RetroProgramResetId",
                        column: x => x.RetroProgramResetId,
                        principalTable: "RetroProgramReset",
                        principalColumn: "RetroProgramResetId");
                });

            migrationBuilder.CreateTable(
                name: "RetroInvestorZone",
                columns: table => new
                {
                    RetroInvestorZoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetroInvestorId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TopUpZoneId = table.Column<int>(type: "int", nullable: false),
                    CessionCapInitial = table.Column<double>(type: "float", nullable: false),
                    CessionCapAdjusted = table.Column<double>(type: "float", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RetroInvestorZone", x => x.RetroInvestorZoneId);
                    table.ForeignKey(
                        name: "FK_dbo.RetroInvestorZone_dbo.RetroInvestor_RetroInvestorId",
                        column: x => x.RetroInvestorId,
                        principalTable: "RetroInvestor",
                        principalColumn: "RetroInvestorId");
                });

            migrationBuilder.CreateTable(
                name: "RetroZoneOverride",
                columns: table => new
                {
                    RetroZoneOverrideId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetroInvestorId = table.Column<int>(type: "int", nullable: false),
                    RetroZoneId = table.Column<int>(type: "int", nullable: false),
                    Cession = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RetroZoneOverride", x => x.RetroZoneOverrideId);
                    table.ForeignKey(
                        name: "FK_dbo.RetroZoneOverride_dbo.RetroInvestor_RetroInvestorId",
                        column: x => x.RetroInvestorId,
                        principalTable: "RetroInvestor",
                        principalColumn: "RetroInvestorId");
                    table.ForeignKey(
                        name: "FK_dbo.RetroZoneOverride_dbo.RetroZone_RetroZoneId",
                        column: x => x.RetroZoneId,
                        principalTable: "RetroZone",
                        principalColumn: "RetroZoneId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlphaGuAnalysisId",
                table: "AlphaModelAnalysis",
                column: "AlphaGuAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPref_AppSectionId",
                table: "AppPref",
                column: "AppSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPref_UserId",
                table: "AppPref",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UQ_PrefName",
                table: "AppPref",
                columns: new[] { "Name", "LegalRegion", "AppSectionId", "UserId" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [LegalRegion] IS NOT NULL AND [UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_SectionName",
                table: "AppSection",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditEventId",
                table: "AuditDetail",
                column: "AuditEventId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditTxnId",
                table: "AuditEvent",
                column: "AuditTxnId");

            migrationBuilder.CreateIndex(
                name: "IX_BrokerGroupId",
                table: "Broker",
                column: "BrokerGroupId");

            migrationBuilder.CreateIndex(
                name: "UQ_RegisIdBroker",
                table: "Broker",
                column: "RegisId",
                unique: true,
                filter: "([RegisId] IS NOT NULL AND [RegisId]<>'')");

            migrationBuilder.CreateIndex(
                name: "IX_BrokerId",
                table: "BrokerContact",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "UQ_RegisIdBrokerGroup",
                table: "BrokerGroup",
                column: "RegisId",
                unique: true,
                filter: "([RegisId] IS NOT NULL AND [RegisId]<>'')");

            migrationBuilder.CreateIndex(
                name: "IX_CedentGroupId",
                table: "Cedent",
                column: "CedentGroupId");

            migrationBuilder.CreateIndex(
                name: "UQ_RegisIdCedent",
                table: "Cedent",
                column: "RegisId",
                unique: true,
                filter: "([RegisId] IS NOT NULL AND [RegisId]<>'')");

            migrationBuilder.CreateIndex(
                name: "IX_CedentId",
                table: "CedentContact",
                column: "CedentId");

            migrationBuilder.CreateIndex(
                name: "UQ_RegisIdCedentGroup",
                table: "CedentGroup",
                column: "RegisId",
                unique: true,
                filter: "([RegisId] IS NOT NULL AND [RegisId]<>'')");

            migrationBuilder.CreateIndex(
                name: "IX_BrokerId",
                table: "ClientMemo",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "ClientMemo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CedentId",
                table: "ClientMemoCedent",
                column: "CedentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMemoId",
                table: "ClientMemoCedent",
                column: "ClientMemoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMemoId",
                table: "ClientMemoDoc",
                column: "ClientMemoId");

            migrationBuilder.CreateIndex(
                name: "IX_DBFileId",
                table: "ClientMemoDoc",
                column: "DBFileId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntCode",
                table: "Company",
                column: "LegalEntCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Company",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractBinderId",
                table: "Contract",
                column: "ContractBinderId");

            migrationBuilder.CreateIndex(
                name: "IX_LayerId",
                table: "Contract",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_DocId",
                table: "ContractBinder",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionId",
                table: "ContractBinder",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "UQ_ClauseCode",
                table: "ContractClause",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_ClauseName",
                table: "ContractClause",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractBinderId",
                table: "ContractReviewer",
                column: "ContractBinderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "ContractReviewer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractReviewerRuleId",
                table: "ContractReviewerCriteria",
                column: "ContractReviewerRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewerId",
                table: "ContractReviewerRule",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_LayerId",
                table: "DeltaPxResult",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionPxPortfolioId",
                table: "DeltaPxResult",
                column: "SubmissionPxPortfolioId");

            migrationBuilder.CreateIndex(
                name: "UQ_DeltaPxResult",
                table: "DeltaPxResult",
                columns: new[] { "SubmissionPxPortfolioId", "LayerId" },
                unique: true,
                filter: "([IsActive]=(1) AND [IsDeleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_ContractId",
                table: "DeltaPxResultContract",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Dept_OfficeId",
                table: "Dept",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "UQ_DeptOffice",
                table: "Dept",
                columns: new[] { "Name", "OfficeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionId",
                table: "Doc",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_GeographyId",
                table: "ExperienceLoss",
                column: "GeographyId");

            migrationBuilder.CreateIndex(
                name: "IX_LossEstScenarioId",
                table: "ExperienceLoss",
                column: "LossEstScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LossEventId",
                table: "ExperienceLoss",
                column: "LossEventId");

            migrationBuilder.CreateIndex(
                name: "UQ_ExperienceLoss",
                table: "ExperienceLoss",
                columns: new[] { "LossEstScenarioId", "LossEventId", "DataSource", "ValuationDate", "EventYear", "EventName", "Peril", "CountryCode", "AreaCode", "Division", "LineOfBusiness" },
                unique: true,
                filter: "([IsActive]=(1) AND [LossEventId] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UQ_FXRate",
                table: "FXRate",
                columns: new[] { "BaseCurrency", "Currency", "FXDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_FXRateSBF",
                table: "FxRateSBF",
                columns: new[] { "BaseCurrency", "Currency", "FXDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParentGeographyId",
                table: "Geography",
                column: "ParentGeographyId");

            migrationBuilder.CreateIndex(
                name: "IXGeography_AreaSubArea",
                table: "Geography",
                columns: new[] { "SubareaCode", "AreaCode" });

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionId",
                table: "GuAnalysis",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneDefinitionId",
                table: "GuAnalysis",
                column: "ZoneDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_SourceGuAnalysisId",
                table: "GuCurveAdjDef",
                column: "SourceGuAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetGuAnalysisId",
                table: "GuCurveAdjDef",
                column: "TargetGuAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_GuCurveAdjDefId",
                table: "GuCurveAdjPmlSrc",
                column: "GuCurveAdjDefId");

            migrationBuilder.CreateIndex(
                name: "IX_SourceGuAnalysisId",
                table: "IndustryCalibrationDef",
                column: "SourceGuAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_SourceIndustryCalibrationAnalysisId",
                table: "IndustryCalibrationDef",
                column: "SourceIndustryCalibrationAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetGuAnalysisId",
                table: "IndustryCalibrationDef",
                column: "TargetGuAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_GeographyId",
                table: "IndustryLoss",
                column: "GeographyId");

            migrationBuilder.CreateIndex(
                name: "IX_LossEventId",
                table: "IndustryLoss",
                column: "LossEventId");

            migrationBuilder.CreateIndex(
                name: "UQ_IndustryLossRegion",
                table: "IndustryLossRegion",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IndustryLossSubRegion_GeographyId",
                table: "IndustryLossSubRegion",
                column: "GeographyId");

            migrationBuilder.CreateIndex(
                name: "UQ_IndustryLossSubRegion",
                table: "IndustryLossSubRegion",
                columns: new[] { "IndustryLossRegionId", "GeographyId", "Name" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IndustryLossId",
                table: "IndustryOnLevelLoss",
                column: "IndustryLossId");

            migrationBuilder.CreateIndex(
                name: "IX_AcctBrokerId",
                table: "Layer",
                column: "AcctBrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpiringLayerId",
                table: "Layer",
                column: "ExpiringLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskZoneId",
                table: "Layer",
                column: "RiskZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionId",
                table: "Layer",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "UQ_RegisIdLayer",
                table: "Layer",
                column: "RegisId",
                unique: true,
                filter: "([RegisId] IS NOT NULL AND [RegisId]<>'' AND [RegisId]<>'0' AND [IsDeleted]=(0) AND [IsActive]=(1))");

            migrationBuilder.CreateIndex(
                name: "UQ_SourceId",
                table: "Layer",
                column: "SourceId",
                unique: true,
                filter: "([IsActive]=(1) AND [IsDeleted]=(0) AND ([SourceId] IS NOT NULL AND [SourceId]<>''))");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceLossId",
                table: "LayerExperienceLoss",
                column: "ExperienceLossId");

            migrationBuilder.CreateIndex(
                name: "IX_LayerLossEstScenarioId",
                table: "LayerExperienceLoss",
                column: "LayerLossEstScenarioId");

            migrationBuilder.CreateIndex(
                name: "UQ_LayerExperienceLoss",
                table: "LayerExperienceLoss",
                columns: new[] { "ExperienceLossId", "LayerLossEstScenarioId" },
                unique: true,
                filter: "([IsActive]=(1))");

            migrationBuilder.CreateIndex(
                name: "IX_AlphaGuAnalysisId",
                table: "LayerLossAnalysis",
                column: "AlphaGuAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_GuAnalysisId",
                table: "LayerLossAnalysis",
                column: "GuAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_LayerLossAnalysis_LayerId",
                table: "LayerLossAnalysis",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_LossAnalysisId",
                table: "LayerLossAnalysis",
                column: "LossAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_LayerId",
                table: "LayerLossEstScenario",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_LossEstScenarioId",
                table: "LayerLossEstScenario",
                column: "LossEstScenarioId");

            migrationBuilder.CreateIndex(
                name: "UQ_LayerLossEstScenario",
                table: "LayerLossEstScenario",
                columns: new[] { "LossEstScenarioId", "LayerId" },
                unique: true,
                filter: "([LayerId] IS NOT NULL AND [ISActive]=(1))");

            migrationBuilder.CreateIndex(
                name: "IX_LayerLossEstScenarioId",
                table: "LayerMarketShareFactor",
                column: "LayerLossEstScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketShareFactorId",
                table: "LayerMarketShareFactor",
                column: "MarketShareFactorId");

            migrationBuilder.CreateIndex(
                name: "UQ_LayerMarketShareFactor",
                table: "LayerMarketShareFactor",
                columns: new[] { "MarketShareFactorId", "LayerLossEstScenarioId" },
                unique: true,
                filter: "([IsActive]=(1))");

            migrationBuilder.CreateIndex(
                name: "IX_LayerLossEstScenarioId",
                table: "LayerMarketShareLoss",
                column: "LayerLossEstScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketShareLossId",
                table: "LayerMarketShareLoss",
                column: "MarketShareLossId");

            migrationBuilder.CreateIndex(
                name: "UQ_LayerMarketShareLoss",
                table: "LayerMarketShareLoss",
                columns: new[] { "MarketShareLossId", "LayerLossEstScenarioId" },
                unique: true,
                filter: "([IsActive]=(1))");

            migrationBuilder.CreateIndex(
                name: "IX_ContractId",
                table: "LayerTopUpLossContract",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalTermClause_ContractClauseId",
                table: "LegalTermClause",
                column: "ContractClauseId");

            migrationBuilder.CreateIndex(
                name: "UQ_LegalTermClause",
                table: "LegalTermClause",
                columns: new[] { "LegalTermsId", "ContractClauseId" },
                unique: true,
                filter: "([IsDeleted]=(0) AND [IsActive]=(1))");

            migrationBuilder.CreateIndex(
                name: "IX_LegalReviewerId",
                table: "LegalTerms",
                column: "LegalReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewerId",
                table: "LegalTerms",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_TAReviewerId",
                table: "LegalTerms",
                column: "TAReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_LayerId",
                table: "LloydsRiskCode",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_LossAnalysis_GuAnalysisId",
                table: "LossAnalysis",
                column: "GuAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionId",
                table: "LossAnalysis",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "UQ_LossAnalysis_Name",
                table: "LossAnalysis",
                columns: new[] { "Name", "SubmissionId", "Model" },
                unique: true,
                filter: "([IsActive]=(1) AND [IsDeleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "UQ_LossView",
                table: "LossAnalysis",
                columns: new[] { "SubmissionId", "LossView" },
                unique: true,
                filter: "([IsActive]=(1) AND ([LossView] IN ((1), (2), (3))))");

            migrationBuilder.CreateIndex(
                name: "IX_IndustryLossFilterId",
                table: "LossEstScenario",
                column: "IndustryLossFilterId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionId",
                table: "LossEstScenario",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_CedentId",
                table: "LossEvent",
                column: "CedentId");

            migrationBuilder.CreateIndex(
                name: "UQ_LossEventCode",
                table: "LossEvent",
                column: "EventCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LossEstScenarioId",
                table: "LossTrendFactor",
                column: "LossEstScenarioId");

            migrationBuilder.CreateIndex(
                name: "UQ_LossTrendFactor",
                table: "LossTrendFactor",
                columns: new[] { "LossEstScenarioId", "ExposureYear" },
                unique: true,
                filter: "([IsActive]=(1))");

            migrationBuilder.CreateIndex(
                name: "IX_LayerId",
                table: "LossViewResult",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "UQ_LossView",
                table: "LossViewResult",
                columns: new[] { "LayerId", "LossView" },
                unique: true,
                filter: "([IsActive]=(1))");

            migrationBuilder.CreateIndex(
                name: "IX_ContractId",
                table: "LossViewResultContract",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "UQ_LossZoneName",
                table: "LossZone",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_MajorZoneName",
                table: "MajorZone",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IndustryLossSubRegionId",
                table: "MarketShareFactor",
                column: "IndustryLossSubRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_LossEstScenarioId",
                table: "MarketShareFactor",
                column: "LossEstScenarioId");

            migrationBuilder.CreateIndex(
                name: "UQ_MarketShareFactor",
                table: "MarketShareFactor",
                columns: new[] { "LossEstScenarioId", "IndustryLossSubRegionId", "Peril" },
                unique: true,
                filter: "([IsActive]=(1))");

            migrationBuilder.CreateIndex(
                name: "IX_IndustryLossId",
                table: "MarketShareLoss",
                column: "IndustryLossId");

            migrationBuilder.CreateIndex(
                name: "IX_LossEstScenarioId",
                table: "MarketShareLoss",
                column: "LossEstScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketShareFactorId",
                table: "MarketShareLoss",
                column: "MarketShareFactorId");

            migrationBuilder.CreateIndex(
                name: "UQ_MarketShareLoss",
                table: "MarketShareLoss",
                columns: new[] { "LossEstScenarioId", "IndustryLossId" },
                unique: true,
                filter: "([IsActive]=(1))");

            migrationBuilder.CreateIndex(
                name: "IX_GuAnalysisId",
                table: "ModelAnalysis",
                column: "GuAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_LayerId",
                table: "MultiyearShare",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyId",
                table: "Office",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Office",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Permission_Name",
                table: "Permission",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SourceGuAnalysisId",
                table: "PmlMatchingDef",
                column: "SourceGuAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_SourceIndustryAnalysisId",
                table: "PmlMatchingDef",
                column: "SourceIndustryAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetGuAnalysisId",
                table: "PmlMatchingDef",
                column: "TargetGuAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_LayerId",
                table: "PolicyTracker",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyTrackerId",
                table: "PolicyTrackerDetail",
                column: "PolicyTrackerId");

            migrationBuilder.CreateIndex(
                name: "IX_LayerId",
                table: "PolicyUpdate",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyTrackerId",
                table: "PolicyUpdate",
                column: "PolicyTrackerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionId",
                table: "PolicyUpdate",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyUpdateId",
                table: "PolicyUpdateDetail",
                column: "PolicyUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_LossPoolId",
                table: "PoolGuAnalysis",
                column: "LossPoolId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioId",
                table: "PortAdj",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_PortAdjId",
                table: "PortAdjAction",
                column: "PortAdjId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioId",
                table: "PortfolioFX",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_LayerId",
                table: "PortLayer",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioId",
                table: "PortLayer",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_PortLayerProjectedCessionPeriodId",
                table: "PortLayer",
                column: "PortLayerProjectedCessionPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_PortLayerId",
                table: "PortLayerCession",
                column: "PortLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RetroProgramId",
                table: "PortLayerCession",
                column: "RetroProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_PortLayerId",
                table: "PortLayerCessionDuration",
                column: "PortLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RetroProgramId",
                table: "PortLayerCessionDuration",
                column: "RetroProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_PortLayerId",
                table: "PortLayerEarnPattern",
                column: "PortLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PortLayerId",
                table: "PortLayerFieldSelectionPerTypeResult",
                column: "PortLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PortLayerId",
                table: "PortLayerLossDuration",
                column: "PortLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PortLayerId",
                table: "PortLayerPriceResult",
                column: "PortLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioId",
                table: "PortMetric",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_PortLayerId",
                table: "PortPeriodResult",
                column: "PortLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioId",
                table: "PortProjectedRetro",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_RetroProgramId",
                table: "PortProjectedRetro",
                column: "RetroProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_LayerId",
                table: "PortRoeResult",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioId",
                table: "PortRoeResult",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_PremiumBaseId",
                table: "PremiumBase",
                column: "PremiumBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PremiumBaseContractId",
                table: "PremiumBaseContract",
                column: "PremiumBaseContractId");

            migrationBuilder.CreateIndex(
                name: "IX_PremiumBaseId",
                table: "PremiumInstallment",
                column: "PremiumBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PremiumBaseContractId",
                table: "PremiumInstallmentContract",
                column: "PremiumBaseContractId");

            migrationBuilder.CreateIndex(
                name: "IX_PresetLDPId",
                table: "PresetLDPDist",
                column: "PresetLDPId");

            migrationBuilder.CreateIndex(
                name: "IX_CedentId",
                table: "Program",
                column: "CedentId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyId",
                table: "Program",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DeptId",
                table: "Program",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeId",
                table: "Program",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReinsurerId",
                table: "Program",
                column: "ReinsurerId");

            migrationBuilder.CreateIndex(
                name: "UQ_RegisIdProgram",
                table: "Program",
                column: "RegisId",
                unique: true,
                filter: "([RegisId] IS NOT NULL AND [RegisId]<>'' AND [IsDeleted]=(0) AND [IsActive]=(1))");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionId",
                table: "ProgramRoeResult",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PxSection_PxLayerId",
                table: "PxSection",
                column: "PxLayerId");

            migrationBuilder.CreateIndex(
                name: "UQ_PxSection",
                table: "PxSection",
                columns: new[] { "LayerId", "PxLayerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractId",
                table: "PxSectionContract",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_RetroCommissionId",
                table: "RCSSPoint",
                column: "RetroCommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_LayerId",
                table: "Reinstatement",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractId",
                table: "ReinstatementContract",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_RetroAllocation_LayerId",
                table: "RetroAllocation",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "UQ_RetroInvestorId_LayerId",
                table: "RetroAllocation",
                columns: new[] { "RetroInvestorId", "LayerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RetroInvestorId",
                table: "RetroBufferByEvent",
                column: "RetroInvestorId");

            migrationBuilder.CreateIndex(
                name: "IX_RetroInvestorId",
                table: "RetroBufferByTime",
                column: "RetroInvestorId");

            migrationBuilder.CreateIndex(
                name: "IX_BrokerContactId",
                table: "RetroCommission",
                column: "BrokerContactId");

            migrationBuilder.CreateIndex(
                name: "IX_BrokerId",
                table: "RetroCommission",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "UQ_RetroCommissionName",
                table: "RetroCommission",
                columns: new[] { "RetroProgramId", "Name" },
                unique: true,
                filter: "([RetroProgramId] IS NOT NULL AND [IsActive]=(1) AND [IsDeleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_DBFileId",
                table: "RetroDoc",
                column: "DBFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RetroProgramId",
                table: "RetroDoc",
                column: "RetroProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_RetroInvestorId",
                table: "RetroFacilityOverride",
                column: "RetroInvestorId");

            migrationBuilder.CreateIndex(
                name: "IX_RetroCommissionId",
                table: "RetroInvestor",
                column: "RetroCommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SPInsurerId",
                table: "RetroInvestor",
                column: "SPInsurerId");

            migrationBuilder.CreateIndex(
                name: "IX_RetroInvestorId",
                table: "RetroInvestorReset",
                column: "RetroInvestorId");

            migrationBuilder.CreateIndex(
                name: "IX_RetroProgramResetId",
                table: "RetroInvestorReset",
                column: "RetroProgramResetId");

            migrationBuilder.CreateIndex(
                name: "UQ_RetroInvestorZone",
                table: "RetroInvestorZone",
                columns: new[] { "RetroInvestorId", "StartDate", "TopUpZoneId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyId",
                table: "RetroProfile",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DeptId",
                table: "RetroProfile",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerId",
                table: "RetroProfile",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeId",
                table: "RetroProfile",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultRetroCommissionId",
                table: "RetroProgram",
                column: "DefaultRetroCommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RetroProfileId",
                table: "RetroProgram",
                column: "RetroProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_RetroProgramId",
                table: "RetroProgramReset",
                column: "RetroProgramId");

            migrationBuilder.CreateIndex(
                name: "UQ_RetroZoneWithStartDate",
                table: "RetroZone",
                columns: new[] { "RetroProgramId", "StartDate", "TopUpZoneId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RetroZoneOverride_RetroZoneId",
                table: "RetroZoneOverride",
                column: "RetroZoneId");

            migrationBuilder.CreateIndex(
                name: "UQ_RetroInvestorId_RetroZoneId",
                table: "RetroZoneOverride",
                columns: new[] { "RetroInvestorId", "RetroZoneId" },
                unique: true,
                filter: "([IsActive]=(1))");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionId",
                table: "RiskTransferAnalysis",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskTransferAnalysisId",
                table: "RiskTransferAnalysisReviewer",
                column: "RiskTransferAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "RiskTransferAnalysisReviewer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LayerId",
                table: "RoeAssumption",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PresetLDPId",
                table: "RoeAssumption",
                column: "PresetLDPId");

            migrationBuilder.CreateIndex(
                name: "UQ_RoeCapitalResult",
                table: "RoeCapitalResult",
                columns: new[] { "LayerId", "FieldStatus", "LossView", "RoeResultBasis" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoeAssumptionId",
                table: "RoeLeverageFactor",
                column: "RoeAssumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoeAssumptionId",
                table: "RoeLossDevPattern",
                column: "RoeAssumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleId",
                table: "RolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UQ_SnpLob_Name",
                table: "SnpLob",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InsurerId",
                table: "SPInsurer",
                column: "InsurerId");

            migrationBuilder.CreateIndex(
                name: "IX_RetroProgramId",
                table: "SPInsurer",
                column: "RetroProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_LayerId",
                table: "SSPoint",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractId",
                table: "SSPointContract",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionId",
                table: "SubDeltaPxResult",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionPxPortfolioId",
                table: "SubDeltaPxResult",
                column: "SubmissionPxPortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractBinderId",
                table: "SubDeltaPxResultContract",
                column: "ContractBinderId");

            migrationBuilder.CreateIndex(
                name: "IX_ActuaryId",
                table: "Submission",
                column: "ActuaryId");

            migrationBuilder.CreateIndex(
                name: "IX_ActuaryPeerReviewerId",
                table: "Submission",
                column: "ActuaryPeerReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalystId",
                table: "Submission",
                column: "AnalystId");

            migrationBuilder.CreateIndex(
                name: "IX_BrokerContactId",
                table: "Submission",
                column: "BrokerContactId");

            migrationBuilder.CreateIndex(
                name: "IX_BrokerId",
                table: "Submission",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpiringSubmissionId",
                table: "Submission",
                column: "ExpiringSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupBuyerId",
                table: "Submission",
                column: "GroupBuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_LastRegisSyncByUserId",
                table: "Submission",
                column: "LastRegisSyncByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalTermsId",
                table: "Submission",
                column: "LegalTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalBuyerId",
                table: "Submission",
                column: "LocalBuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelerId",
                table: "Submission",
                column: "ModelerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramId",
                table: "Submission",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_RelshipUnderwriterId",
                table: "Submission",
                column: "RelshipUnderwriterId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskZoneId",
                table: "Submission",
                column: "RiskZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionWriteupId",
                table: "Submission",
                column: "SubmissionWriteupId");

            migrationBuilder.CreateIndex(
                name: "IX_UnderwriterId",
                table: "Submission",
                column: "UnderwriterId");

            migrationBuilder.CreateIndex(
                name: "IX_GuAnalysisId",
                table: "SubmissionGuAnalysis",
                column: "GuAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_GuAnalysis",
                table: "SubmissionGuAnalysis",
                columns: new[] { "GuAnalysisId", "SubmissionId" },
                unique: true,
                filter: "([IsDeleted]=(0) AND [IsActive]=(1))");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionId",
                table: "SubmissionGuAnalysis",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioId",
                table: "SubmissionPxPortfolio",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionId",
                table: "SubmissionPxPortfolio",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "UQ_SubmissionId_PortfolioId",
                table: "SubmissionPxPortfolio",
                columns: new[] { "SubmissionId", "PortfolioId" },
                unique: true,
                filter: "([IsActive]=(1))");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationEventId",
                table: "Subscription",
                column: "NotificationEventId");

            migrationBuilder.CreateIndex(
                name: "IX_LossZoneId",
                table: "TargetPMLDef",
                column: "LossZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_PMLMatchingDefId",
                table: "TargetPMLDef",
                column: "PMLMatchingDefId");

            migrationBuilder.CreateIndex(
                name: "UQ_TopZoneName",
                table: "TopUpZone",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TopUpZoneId",
                table: "TopUpZoneGeoMap",
                column: "TopUpZoneId");

            migrationBuilder.CreateIndex(
                name: "UQ_TopUpZoneGeoMap",
                table: "TopUpZoneGeoMap",
                columns: new[] { "GeoLevelCode", "CountryCode", "AreaCode" },
                unique: true,
                filter: "[GeoLevelCode] IS NOT NULL AND [CountryCode] IS NOT NULL AND [AreaCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeptId",
                table: "User",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UQ_DomainUsername",
                table: "User",
                columns: new[] { "Username", "Domain" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "UserLayout",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionId",
                table: "UserPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "UserPermission",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UQ_UserIdPermissionId",
                table: "UserPermission",
                columns: new[] { "UserId", "PermissionId" },
                unique: true,
                filter: "([IsActive]=(1) AND [IsDeleted]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionId",
                table: "UserSubscription",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "UserSubscription",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LossZoneId",
                table: "ZoneGeography",
                column: "LossZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_MajorZoneId",
                table: "ZoneGeography",
                column: "MajorZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGeography_GeographyId",
                table: "ZoneGeography",
                column: "GeographyId");

            migrationBuilder.CreateIndex(
                name: "UQ_ZoneDefGeography",
                table: "ZoneGeography",
                columns: new[] { "ZoneDefinitionId", "GeographyId", "Peril" },
                unique: true,
                filter: "[Peril] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.PortLayerCession_dbo.RetroProgram_RetroProgramId",
                table: "PortLayerCession",
                column: "RetroProgramId",
                principalTable: "RetroProgram",
                principalColumn: "RetroProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.PortLayerCessionDuration_dbo.RetroProgram_RetroProgramId",
                table: "PortLayerCessionDuration",
                column: "RetroProgramId",
                principalTable: "RetroProgram",
                principalColumn: "RetroProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.PortProjectedRetro_dbo.RetroProgram_RetroProgramId",
                table: "PortProjectedRetro",
                column: "RetroProgramId",
                principalTable: "RetroProgram",
                principalColumn: "RetroProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.RCSSPoint_dbo.RetroCommission_RetroCommissionId",
                table: "RCSSPoint",
                column: "RetroCommissionId",
                principalTable: "RetroCommission",
                principalColumn: "RetroCommissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.RetroAllocation_dbo.RetroInvestor_RetroInvestorId",
                table: "RetroAllocation",
                column: "RetroInvestorId",
                principalTable: "RetroInvestor",
                principalColumn: "RetroInvestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.RetroBufferByEvent_dbo.RetroInvestor_RetroInvestorId",
                table: "RetroBufferByEvent",
                column: "RetroInvestorId",
                principalTable: "RetroInvestor",
                principalColumn: "RetroInvestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.RetroBufferByTime_dbo.RetroInvestor_RetroInvestorId",
                table: "RetroBufferByTime",
                column: "RetroInvestorId",
                principalTable: "RetroInvestor",
                principalColumn: "RetroInvestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.RetroCommission_dbo.RetroProgram_RetroProgramId",
                table: "RetroCommission",
                column: "RetroProgramId",
                principalTable: "RetroProgram",
                principalColumn: "RetroProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.RetroProfile_dbo.User_ManagerId",
                table: "RetroProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Broker_dbo.BrokerGroup_BrokerGroupId",
                table: "Broker");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.BrokerContact_dbo.Broker_BrokerId",
                table: "BrokerContact");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.RetroCommission_dbo.Broker_BrokerId",
                table: "RetroCommission");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Dept_dbo.Office_OfficeId",
                table: "Dept");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.RetroProfile_dbo.Office_OfficeId",
                table: "RetroProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.RetroProfile_dbo.Company_CompanyId",
                table: "RetroProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.RetroCommission_dbo.RetroProgram_RetroProgramId",
                table: "RetroCommission");

            migrationBuilder.DropTable(
                name: "__MigrationHistory");

            migrationBuilder.DropTable(
                name: "AlphaModelAnalysis");

            migrationBuilder.DropTable(
                name: "AppPref");

            migrationBuilder.DropTable(
                name: "attrep_truncation_safeguard");

            migrationBuilder.DropTable(
                name: "AuditDetail");

            migrationBuilder.DropTable(
                name: "CedentLoss");

            migrationBuilder.DropTable(
                name: "ClientMemoCedent");

            migrationBuilder.DropTable(
                name: "ClientMemoDoc");

            migrationBuilder.DropTable(
                name: "ContractReviewer");

            migrationBuilder.DropTable(
                name: "ContractReviewerCriteria");

            migrationBuilder.DropTable(
                name: "DeltaPxResult");

            migrationBuilder.DropTable(
                name: "DeltaPxResultContract");

            migrationBuilder.DropTable(
                name: "FXRate");

            migrationBuilder.DropTable(
                name: "FxRateSBF");

            migrationBuilder.DropTable(
                name: "GuCurveAdjPmlSrc");

            migrationBuilder.DropTable(
                name: "IndustryCalibrationDef");

            migrationBuilder.DropTable(
                name: "IndustryOnLevelLoss");

            migrationBuilder.DropTable(
                name: "LayerExperienceLoss");

            migrationBuilder.DropTable(
                name: "LayerLossAnalysis");

            migrationBuilder.DropTable(
                name: "LayerMarketShareFactor");

            migrationBuilder.DropTable(
                name: "LayerMarketShareLoss");

            migrationBuilder.DropTable(
                name: "LayerTopUpLossContract");

            migrationBuilder.DropTable(
                name: "LegalTermClause");

            migrationBuilder.DropTable(
                name: "LloydsRiskCode");

            migrationBuilder.DropTable(
                name: "LossTrendFactor");

            migrationBuilder.DropTable(
                name: "LossViewResult");

            migrationBuilder.DropTable(
                name: "LossViewResultContract");

            migrationBuilder.DropTable(
                name: "ModelAnalysis");

            migrationBuilder.DropTable(
                name: "MultiyearShare");

            migrationBuilder.DropTable(
                name: "PolicyTrackerDetail");

            migrationBuilder.DropTable(
                name: "PolicyTrackerLog");

            migrationBuilder.DropTable(
                name: "PolicyUpdateDetail");

            migrationBuilder.DropTable(
                name: "PoolGuAnalysis");

            migrationBuilder.DropTable(
                name: "PortAdjAction");

            migrationBuilder.DropTable(
                name: "PortfolioFX");

            migrationBuilder.DropTable(
                name: "PortLayerCession");

            migrationBuilder.DropTable(
                name: "PortLayerCessionDuration");

            migrationBuilder.DropTable(
                name: "PortLayerEarnPattern");

            migrationBuilder.DropTable(
                name: "PortLayerFieldSelectionPerTypeResult");

            migrationBuilder.DropTable(
                name: "PortLayerLossDuration");

            migrationBuilder.DropTable(
                name: "PortLayerPriceResult");

            migrationBuilder.DropTable(
                name: "PortMetric");

            migrationBuilder.DropTable(
                name: "PortPeriodResult");

            migrationBuilder.DropTable(
                name: "PortProjectedRetro");

            migrationBuilder.DropTable(
                name: "PortRoeResult");

            migrationBuilder.DropTable(
                name: "PremiumInstallment");

            migrationBuilder.DropTable(
                name: "PremiumInstallmentContract");

            migrationBuilder.DropTable(
                name: "PremiumSurplusRatio");

            migrationBuilder.DropTable(
                name: "PresetLDPDist");

            migrationBuilder.DropTable(
                name: "ProgramRoeResult");

            migrationBuilder.DropTable(
                name: "PxSection");

            migrationBuilder.DropTable(
                name: "PxSectionContract");

            migrationBuilder.DropTable(
                name: "RCSSPoint");

            migrationBuilder.DropTable(
                name: "Reinstatement");

            migrationBuilder.DropTable(
                name: "ReinstatementContract");

            migrationBuilder.DropTable(
                name: "RetroAllocation");

            migrationBuilder.DropTable(
                name: "RetroBufferByEvent");

            migrationBuilder.DropTable(
                name: "RetroBufferByTime");

            migrationBuilder.DropTable(
                name: "RetroDoc");

            migrationBuilder.DropTable(
                name: "RetroFacilityOverride");

            migrationBuilder.DropTable(
                name: "RetroInvestorReset");

            migrationBuilder.DropTable(
                name: "RetroInvestorZone");

            migrationBuilder.DropTable(
                name: "RetroZoneOverride");

            migrationBuilder.DropTable(
                name: "RiskTransferAnalysisReviewer");

            migrationBuilder.DropTable(
                name: "RoeCapitalResult");

            migrationBuilder.DropTable(
                name: "RoeLeverageFactor");

            migrationBuilder.DropTable(
                name: "RoeLossDevPattern");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "SnpLob");

            migrationBuilder.DropTable(
                name: "SSPoint");

            migrationBuilder.DropTable(
                name: "SSPointContract");

            migrationBuilder.DropTable(
                name: "SubDeltaPxResult");

            migrationBuilder.DropTable(
                name: "SubDeltaPxResultContract");

            migrationBuilder.DropTable(
                name: "SubmissionGuAnalysis");

            migrationBuilder.DropTable(
                name: "TargetPMLDef");

            migrationBuilder.DropTable(
                name: "tmpla");

            migrationBuilder.DropTable(
                name: "tmpra");

            migrationBuilder.DropTable(
                name: "TopUpZoneGeoMap");

            migrationBuilder.DropTable(
                name: "UserLayout");

            migrationBuilder.DropTable(
                name: "UserPermission");

            migrationBuilder.DropTable(
                name: "UserSubscription");

            migrationBuilder.DropTable(
                name: "ZoneGeography");

            migrationBuilder.DropTable(
                name: "zzzIndustryLoss_DupRecs_Import_220920");

            migrationBuilder.DropTable(
                name: "AppSection");

            migrationBuilder.DropTable(
                name: "AuditEvent");

            migrationBuilder.DropTable(
                name: "ClientMemo");

            migrationBuilder.DropTable(
                name: "ContractReviewerRule");

            migrationBuilder.DropTable(
                name: "GuCurveAdjDef");

            migrationBuilder.DropTable(
                name: "IndustryCalibrationAnalysis");

            migrationBuilder.DropTable(
                name: "ExperienceLoss");

            migrationBuilder.DropTable(
                name: "AlphaGuAnalysis");

            migrationBuilder.DropTable(
                name: "LossAnalysis");

            migrationBuilder.DropTable(
                name: "LayerLossEstScenario");

            migrationBuilder.DropTable(
                name: "MarketShareLoss");

            migrationBuilder.DropTable(
                name: "ContractClause");

            migrationBuilder.DropTable(
                name: "PolicyUpdate");

            migrationBuilder.DropTable(
                name: "LossPool");

            migrationBuilder.DropTable(
                name: "PortAdj");

            migrationBuilder.DropTable(
                name: "PortLayer");

            migrationBuilder.DropTable(
                name: "PremiumBase");

            migrationBuilder.DropTable(
                name: "PremiumBaseContract");

            migrationBuilder.DropTable(
                name: "DBFile");

            migrationBuilder.DropTable(
                name: "RetroProgramReset");

            migrationBuilder.DropTable(
                name: "RetroInvestor");

            migrationBuilder.DropTable(
                name: "RetroZone");

            migrationBuilder.DropTable(
                name: "RiskTransferAnalysis");

            migrationBuilder.DropTable(
                name: "RoeAssumption");

            migrationBuilder.DropTable(
                name: "SubmissionPxPortfolio");

            migrationBuilder.DropTable(
                name: "PmlMatchingDef");

            migrationBuilder.DropTable(
                name: "TopUpZone");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "LossZone");

            migrationBuilder.DropTable(
                name: "MajorZone");

            migrationBuilder.DropTable(
                name: "AuditTxn");

            migrationBuilder.DropTable(
                name: "IndustryLoss");

            migrationBuilder.DropTable(
                name: "MarketShareFactor");

            migrationBuilder.DropTable(
                name: "PolicyTracker");

            migrationBuilder.DropTable(
                name: "PortLayerProjectedCessionPeriod");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "SPInsurer");

            migrationBuilder.DropTable(
                name: "PresetLDP");

            migrationBuilder.DropTable(
                name: "Portfolio");

            migrationBuilder.DropTable(
                name: "GuAnalysis");

            migrationBuilder.DropTable(
                name: "IndustryGuAnalysis");

            migrationBuilder.DropTable(
                name: "NotificationEvent");

            migrationBuilder.DropTable(
                name: "LossEvent");

            migrationBuilder.DropTable(
                name: "IndustryLossSubRegion");

            migrationBuilder.DropTable(
                name: "LossEstScenario");

            migrationBuilder.DropTable(
                name: "ContractBinder");

            migrationBuilder.DropTable(
                name: "Layer");

            migrationBuilder.DropTable(
                name: "ZoneDefinition");

            migrationBuilder.DropTable(
                name: "Geography");

            migrationBuilder.DropTable(
                name: "IndustryLossRegion");

            migrationBuilder.DropTable(
                name: "IndustryLossFilter");

            migrationBuilder.DropTable(
                name: "Doc");

            migrationBuilder.DropTable(
                name: "Submission");

            migrationBuilder.DropTable(
                name: "CedentContact");

            migrationBuilder.DropTable(
                name: "LegalTerms");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "RiskZone");

            migrationBuilder.DropTable(
                name: "SubmissionWriteup");

            migrationBuilder.DropTable(
                name: "Cedent");

            migrationBuilder.DropTable(
                name: "CedentGroup");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "BrokerGroup");

            migrationBuilder.DropTable(
                name: "Broker");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "RetroProgram");

            migrationBuilder.DropTable(
                name: "RetroCommission");

            migrationBuilder.DropTable(
                name: "RetroProfile");

            migrationBuilder.DropTable(
                name: "BrokerContact");

            migrationBuilder.DropTable(
                name: "Dept");

            migrationBuilder.DropSequence(
                name: "LossEvent_EventCode_Seq");
        }
    }
}
