﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NguyenVanLinh_22115053122225.Data;

#nullable disable

namespace NguyenVanLinh_22115053122225.Migrations
{
    [DbContext(typeof(WebDbContext))]
    partial class WebDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NguyenVanLinh_22115053122225.Data.DanhMucHoa", b =>
                {
                    b.Property<int>("MaDM")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDM"));

                    b.Property<string>("Mota")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TenDM")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaDM");

                    b.ToTable("DanhMucHoa");
                });

            modelBuilder.Entity("NguyenVanLinh_22115053122225.Data.GioHang", b =>
                {
                    b.Property<int>("MaGioHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaGioHang"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MaGioHang");

                    b.HasIndex("UserId");

                    b.ToTable("GioHang");
                });

            modelBuilder.Entity("NguyenVanLinh_22115053122225.Data.Hoa", b =>
                {
                    b.Property<int>("MaH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaH"));

                    b.Property<decimal>("Dongia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Donvitinh")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Hinhanh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaDM")
                        .HasColumnType("int");

                    b.Property<int>("MaGioHang")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaH");

                    b.HasIndex("MaDM");

                    b.HasIndex("MaGioHang");

                    b.ToTable("Hoa");
                });

            modelBuilder.Entity("NguyenVanLinh_22115053122225.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("NguyenVanLinh_22115053122225.Data.GioHang", b =>
                {
                    b.HasOne("NguyenVanLinh_22115053122225.Data.User", "User")
                        .WithMany("GioHangs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NguyenVanLinh_22115053122225.Data.Hoa", b =>
                {
                    b.HasOne("NguyenVanLinh_22115053122225.Data.DanhMucHoa", "DanhMucHoa")
                        .WithMany("Hoas")
                        .HasForeignKey("MaDM")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NguyenVanLinh_22115053122225.Data.GioHang", "gioHang")
                        .WithMany("hoas")
                        .HasForeignKey("MaGioHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMucHoa");

                    b.Navigation("gioHang");
                });

            modelBuilder.Entity("NguyenVanLinh_22115053122225.Data.DanhMucHoa", b =>
                {
                    b.Navigation("Hoas");
                });

            modelBuilder.Entity("NguyenVanLinh_22115053122225.Data.GioHang", b =>
                {
                    b.Navigation("hoas");
                });

            modelBuilder.Entity("NguyenVanLinh_22115053122225.Data.User", b =>
                {
                    b.Navigation("GioHangs");
                });
#pragma warning restore 612, 618
        }
    }
}
