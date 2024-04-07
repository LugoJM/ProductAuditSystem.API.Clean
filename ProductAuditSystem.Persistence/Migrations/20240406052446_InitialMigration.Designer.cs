﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductAuditSystem.Persistence.DataBaseContext;

#nullable disable

namespace ProductAuditSystem.Persistence.Migrations
{
    [DbContext(typeof(ProductAuditSystemDBContext))]
    [Migration("20240406052446_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductAuditSystem.Domain.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comentarios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Auditoria")
                        .HasColumnType("datetime2");

                    b.Property<int>("OEMID")
                        .HasColumnType("int");

                    b.Property<string>("Programa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OEMID");

                    b.HasIndex("StatusID");

                    b.ToTable("Audits");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.AuditQuestion", b =>
                {
                    b.Property<int>("AuditoriaID")
                        .HasColumnType("int");

                    b.Property<int>("PreguntaID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("AuditoriaID", "PreguntaID");

                    b.HasIndex("PreguntaID");

                    b.ToTable("AuditQuestion");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.AuditStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuditStatus");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.AuditUser", b =>
                {
                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.Property<int>("AuditoriaID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("UsuarioID", "AuditoriaID");

                    b.HasIndex("AuditoriaID");

                    b.ToTable("AuditUser");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.EvaluationPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PreguntaId")
                        .HasColumnType("int");

                    b.Property<int>("StatusPuntoID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreguntaId");

                    b.HasIndex("StatusPuntoID");

                    b.ToTable("EvaluationPoints");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.Files", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Content")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsReference")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReferenceDocument")
                        .HasColumnType("bit");

                    b.Property<string>("MIME_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionID");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.OEM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OEMs");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.PointStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PointStatus");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comentarios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComentariosPuntos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoporteID")
                        .HasColumnType("int");

                    b.Property<string>("referenceDocuments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SoporteID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("RolNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FechaCreacion = new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(5461),
                            FechaModificacion = new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(5473),
                            RolNombre = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            FechaCreacion = new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(5474),
                            FechaModificacion = new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(5475),
                            RolNombre = "NORMAL"
                        },
                        new
                        {
                            Id = 3,
                            FechaCreacion = new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(5476),
                            FechaModificacion = new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(5477),
                            RolNombre = "AUDITOR"
                        });
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.SupportDepartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SupportDepartment");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RolID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Correo = "jose.manuel.lugo.cardenas-ext@functionalaccount.com",
                            FechaCreacion = new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(6399),
                            FechaModificacion = new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(6400),
                            Nombre = "Lugo Cardenas-EXT, Jose Manuel",
                            RolID = 1,
                            Username = "uif87879"
                        },
                        new
                        {
                            Id = 2,
                            Correo = "Cesar.Angulo@continental-corporation.com",
                            FechaCreacion = new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(6402),
                            FechaModificacion = new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(6402),
                            Nombre = "Angulo, Cesar",
                            RolID = 1,
                            Username = "AnguloCE"
                        },
                        new
                        {
                            Id = 3,
                            Correo = "rosa.vanessa.montano@continental-corporation.com",
                            FechaCreacion = new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(6404),
                            FechaModificacion = new DateTime(2024, 4, 5, 22, 24, 46, 266, DateTimeKind.Local).AddTicks(6404),
                            Nombre = "MONTANO MOLINA, ROSA VANESSA",
                            RolID = 1,
                            Username = "uib64582"
                        });
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.Audit", b =>
                {
                    b.HasOne("ProductAuditSystem.Domain.OEM", "OEM")
                        .WithMany()
                        .HasForeignKey("OEMID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductAuditSystem.Domain.AuditStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OEM");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.AuditQuestion", b =>
                {
                    b.HasOne("ProductAuditSystem.Domain.Audit", "Auditoria")
                        .WithMany("AuditoriasPreguntas")
                        .HasForeignKey("AuditoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductAuditSystem.Domain.Question", "Pregunta")
                        .WithMany("AuditoriasPreguntas")
                        .HasForeignKey("PreguntaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auditoria");

                    b.Navigation("Pregunta");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.AuditUser", b =>
                {
                    b.HasOne("ProductAuditSystem.Domain.Audit", "Auditoria")
                        .WithMany("UsuariosAuditorias")
                        .HasForeignKey("AuditoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductAuditSystem.Domain.User", "Usuario")
                        .WithMany("UsuarioAuditorias")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auditoria");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.EvaluationPoint", b =>
                {
                    b.HasOne("ProductAuditSystem.Domain.Question", "Pregunta")
                        .WithMany("PuntosAEvaluar")
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductAuditSystem.Domain.PointStatus", "StatusPunto")
                        .WithMany()
                        .HasForeignKey("StatusPuntoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pregunta");

                    b.Navigation("StatusPunto");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.Files", b =>
                {
                    b.HasOne("ProductAuditSystem.Domain.Question", "Question")
                        .WithMany("Files")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.Question", b =>
                {
                    b.HasOne("ProductAuditSystem.Domain.SupportDepartment", "Soporte")
                        .WithMany()
                        .HasForeignKey("SoporteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Soporte");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.User", b =>
                {
                    b.HasOne("ProductAuditSystem.Domain.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.Audit", b =>
                {
                    b.Navigation("AuditoriasPreguntas");

                    b.Navigation("UsuariosAuditorias");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.Question", b =>
                {
                    b.Navigation("AuditoriasPreguntas");

                    b.Navigation("Files");

                    b.Navigation("PuntosAEvaluar");
                });

            modelBuilder.Entity("ProductAuditSystem.Domain.User", b =>
                {
                    b.Navigation("UsuarioAuditorias");
                });
#pragma warning restore 612, 618
        }
    }
}
