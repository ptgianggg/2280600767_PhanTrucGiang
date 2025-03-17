﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2280600767_PhanTrucGiang.Models;

#nullable disable

namespace _2280600767_PhanTrucGiang.Migrations
{
    [DbContext(typeof(GiangDbContext))]
    [Migration("20250317082046_AddHinhAnhToMonAn")]
    partial class AddHinhAnhToMonAn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("_2280600767_PhanTrucGiang.Models.LoaiMonAn", b =>
                {
                    b.Property<string>("MaLoaiMonAn")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenLoaiMonAn")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("MaLoaiMonAn");

                    b.ToTable("LoaiMonAn");
                });

            modelBuilder.Entity("_2280600767_PhanTrucGiang.Models.MonAn", b =>
                {
                    b.Property<string>("MaMonAn")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<float>("Dongia")
                        .HasColumnType("real");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaLoaiMonAn")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Soluongton")
                        .HasColumnType("int");

                    b.Property<string>("TenMonAn")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("MaMonAn");

                    b.HasIndex("MaLoaiMonAn");

                    b.ToTable("MonAn");
                });

            modelBuilder.Entity("_2280600767_PhanTrucGiang.Models.MonAn", b =>
                {
                    b.HasOne("_2280600767_PhanTrucGiang.Models.LoaiMonAn", "LoaiMonAn")
                        .WithMany("MonAn")
                        .HasForeignKey("MaLoaiMonAn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiMonAn");
                });

            modelBuilder.Entity("_2280600767_PhanTrucGiang.Models.LoaiMonAn", b =>
                {
                    b.Navigation("MonAn");
                });
#pragma warning restore 612, 618
        }
    }
}
