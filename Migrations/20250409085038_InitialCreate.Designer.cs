﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskMaster.Data;

#nullable disable

namespace TaskMaster.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250409085038_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TaskMaster.Models.Assimiler", b =>
                {
                    b.Property<int>("Id_Task")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("Id_Etiquette")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("Id_Task", "Id_Etiquette");

                    b.HasIndex("Id_Etiquette");

                    b.ToTable("Assimilations");
                });

            modelBuilder.Entity("TaskMaster.Models.Categorie", b =>
                {
                    b.Property<int>("Id_Categorie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id_Categorie"));

                    b.Property<int>("Id_User")
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id_Categorie");

                    b.HasIndex("Id_User");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TaskMaster.Models.Commentaire", b =>
                {
                    b.Property<int>("Id_Commentaire")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id_Commentaire"));

                    b.Property<int>("Id_Task")
                        .HasColumnType("int");

                    b.Property<int>("Id_User")
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id_Commentaire");

                    b.HasIndex("Id_Task");

                    b.HasIndex("Id_User");

                    b.ToTable("Commentaires");
                });

            modelBuilder.Entity("TaskMaster.Models.Etiquette", b =>
                {
                    b.Property<int>("Id_Etiquette")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id_Etiquette"));

                    b.Property<int>("Id_User")
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id_Etiquette");

                    b.HasIndex("Id_User");

                    b.ToTable("Etiquettes");
                });

            modelBuilder.Entity("TaskMaster.Models.Priorite", b =>
                {
                    b.Property<int>("Id_Priorite")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id_Priorite"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id_Priorite");

                    b.ToTable("Priorites");
                });

            modelBuilder.Entity("TaskMaster.Models.RelationUserTasks", b =>
                {
                    b.Property<int>("Id_RelationUserTasks")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id_RelationUserTasks"));

                    b.Property<int>("Id_Task")
                        .HasColumnType("int");

                    b.Property<int>("Id_User")
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id_RelationUserTasks");

                    b.HasIndex("Id_Task");

                    b.HasIndex("Id_User");

                    b.ToTable("RelationUserTasks");
                });

            modelBuilder.Entity("TaskMaster.Models.Statut", b =>
                {
                    b.Property<int>("Id_Statut")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id_Statut"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id_Statut");

                    b.ToTable("Statuts");
                });

            modelBuilder.Entity("TaskMaster.Models.SubTask", b =>
                {
                    b.Property<int>("Id_SubTasks")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id_SubTasks"));

                    b.Property<DateTime?>("Echeance")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Id_Task")
                        .HasColumnType("int");

                    b.Property<string>("Statut")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id_SubTasks");

                    b.HasIndex("Id_Task");

                    b.ToTable("SubTasks");
                });

            modelBuilder.Entity("TaskMaster.Models.Task", b =>
                {
                    b.Property<int>("Id_Task")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id_Task"));

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("Echeance")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Id_Categorie")
                        .HasColumnType("int");

                    b.Property<int>("Id_Priorite")
                        .HasColumnType("int");

                    b.Property<int>("Id_Statut")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id_Task");

                    b.HasIndex("Id_Categorie");

                    b.HasIndex("Id_Priorite");

                    b.HasIndex("Id_Statut");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskMaster.Models.User", b =>
                {
                    b.Property<int>("Id_User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id_User"));

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id_User");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskMaster.Models.Assimiler", b =>
                {
                    b.HasOne("TaskMaster.Models.Etiquette", "Etiquette")
                        .WithMany("Assimilations")
                        .HasForeignKey("Id_Etiquette")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskMaster.Models.Task", "Task")
                        .WithMany("Assimilations")
                        .HasForeignKey("Id_Task")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etiquette");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("TaskMaster.Models.Categorie", b =>
                {
                    b.HasOne("TaskMaster.Models.User", "User")
                        .WithMany("Categories")
                        .HasForeignKey("Id_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskMaster.Models.Commentaire", b =>
                {
                    b.HasOne("TaskMaster.Models.Task", "Task")
                        .WithMany("Commentaires")
                        .HasForeignKey("Id_Task")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskMaster.Models.User", "User")
                        .WithMany("Commentaires")
                        .HasForeignKey("Id_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskMaster.Models.Etiquette", b =>
                {
                    b.HasOne("TaskMaster.Models.User", "User")
                        .WithMany("Etiquettes")
                        .HasForeignKey("Id_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskMaster.Models.RelationUserTasks", b =>
                {
                    b.HasOne("TaskMaster.Models.Task", "Task")
                        .WithMany("RelationUserTasks")
                        .HasForeignKey("Id_Task")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskMaster.Models.User", "User")
                        .WithMany("RelationUserTasks")
                        .HasForeignKey("Id_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskMaster.Models.SubTask", b =>
                {
                    b.HasOne("TaskMaster.Models.Task", "Task")
                        .WithMany("SubTasks")
                        .HasForeignKey("Id_Task")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("TaskMaster.Models.Task", b =>
                {
                    b.HasOne("TaskMaster.Models.Categorie", "Categorie")
                        .WithMany("Tasks")
                        .HasForeignKey("Id_Categorie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskMaster.Models.Priorite", "Priorite")
                        .WithMany("Tasks")
                        .HasForeignKey("Id_Priorite")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskMaster.Models.Statut", "Statut")
                        .WithMany("Tasks")
                        .HasForeignKey("Id_Statut")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Priorite");

                    b.Navigation("Statut");
                });

            modelBuilder.Entity("TaskMaster.Models.Categorie", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskMaster.Models.Etiquette", b =>
                {
                    b.Navigation("Assimilations");
                });

            modelBuilder.Entity("TaskMaster.Models.Priorite", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskMaster.Models.Statut", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskMaster.Models.Task", b =>
                {
                    b.Navigation("Assimilations");

                    b.Navigation("Commentaires");

                    b.Navigation("RelationUserTasks");

                    b.Navigation("SubTasks");
                });

            modelBuilder.Entity("TaskMaster.Models.User", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Commentaires");

                    b.Navigation("Etiquettes");

                    b.Navigation("RelationUserTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
