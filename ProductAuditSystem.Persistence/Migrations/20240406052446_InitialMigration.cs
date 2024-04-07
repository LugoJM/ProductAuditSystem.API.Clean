using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductAuditSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OEMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OEMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportDepartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Auditoria = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    OEMID = table.Column<int>(type: "int", nullable: false),
                    Programa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audits_AuditStatus_StatusID",
                        column: x => x.StatusID,
                        principalTable: "AuditStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Audits_OEMs_OEMID",
                        column: x => x.OEMID,
                        principalTable: "OEMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolID = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RolID",
                        column: x => x.RolID,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoporteID = table.Column<int>(type: "int", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComentariosPuntos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    referenceDocuments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_SupportDepartment_SoporteID",
                        column: x => x.SoporteID,
                        principalTable: "SupportDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditUser",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    AuditoriaID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditUser", x => new { x.UsuarioID, x.AuditoriaID });
                    table.ForeignKey(
                        name: "FK_AuditUser_Audits_AuditoriaID",
                        column: x => x.AuditoriaID,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditUser_Users_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditQuestion",
                columns: table => new
                {
                    PreguntaID = table.Column<int>(type: "int", nullable: false),
                    AuditoriaID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditQuestion", x => new { x.AuditoriaID, x.PreguntaID });
                    table.ForeignKey(
                        name: "FK_AuditQuestion_Audits_AuditoriaID",
                        column: x => x.AuditoriaID,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditQuestion_Questions_PreguntaID",
                        column: x => x.PreguntaID,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusPuntoID = table.Column<int>(type: "int", nullable: false),
                    PreguntaId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationPoints_PointStatus_StatusPuntoID",
                        column: x => x.StatusPuntoID,
                        principalTable: "PointStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationPoints_Questions_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    MIME_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    IsReference = table.Column<bool>(type: "bit", nullable: false),
                    IsReferenceDocument = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "FechaCreacion", "FechaModificacion", "RolNombre" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(5461), new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(5473), "ADMIN" },
                    { 2, new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(5474), new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(5475), "NORMAL" },
                    { 3, new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(5476), new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(5477), "AUDITOR" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Correo", "FechaCreacion", "FechaModificacion", "Nombre", "RolID", "Username" },
                values: new object[,]
                {
                    { 1, "jose.manuel.lugo.cardenas-ext@functionalaccount.com", new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(6399), new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(6400), "Lugo Cardenas-EXT, Jose Manuel", 1, "uif87879" },
                    { 2, "Cesar.Angulo@continental-corporation.com", new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(6402), new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(6402), "Angulo, Cesar", 1, "AnguloCE" },
                    { 3, "rosa.vanessa.montano@continental-corporation.com", new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(6404), new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(6404), "MONTANO MOLINA, ROSA VANESSA", 1, "uib64582" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditQuestion_PreguntaID",
                table: "AuditQuestion",
                column: "PreguntaID");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_OEMID",
                table: "Audits",
                column: "OEMID");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_StatusID",
                table: "Audits",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditUser_AuditoriaID",
                table: "AuditUser",
                column: "AuditoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationPoints_PreguntaId",
                table: "EvaluationPoints",
                column: "PreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationPoints_StatusPuntoID",
                table: "EvaluationPoints",
                column: "StatusPuntoID");

            migrationBuilder.CreateIndex(
                name: "IX_Files_QuestionID",
                table: "Files",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SoporteID",
                table: "Questions",
                column: "SoporteID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolID",
                table: "Users",
                column: "RolID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditQuestion");

            migrationBuilder.DropTable(
                name: "AuditUser");

            migrationBuilder.DropTable(
                name: "EvaluationPoints");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PointStatus");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "AuditStatus");

            migrationBuilder.DropTable(
                name: "OEMs");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SupportDepartment");
        }
    }
}
