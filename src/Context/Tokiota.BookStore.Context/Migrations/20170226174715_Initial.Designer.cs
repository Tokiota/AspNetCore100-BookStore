using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Tokiota.BookStore.Context;

namespace Tokiota.BookStore.Context.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20170226174715_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tokiota.BookStore.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Born");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("Tokiota.BookStore.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthorId");

                    b.Property<string>("Genre");

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.Property<int>("Published");

                    b.Property<Guid?>("SerieId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("SerieId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Tokiota.BookStore.Entities.Serie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthorId");

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Serie");
                });

            modelBuilder.Entity("Tokiota.BookStore.Entities.Book", b =>
                {
                    b.HasOne("Tokiota.BookStore.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tokiota.BookStore.Entities.Serie", "Serie")
                        .WithMany("Books")
                        .HasForeignKey("SerieId");
                });

            modelBuilder.Entity("Tokiota.BookStore.Entities.Serie", b =>
                {
                    b.HasOne("Tokiota.BookStore.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
