﻿// <auto-generated />
using System;
using BAU_Project_RentACarPortal.App.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BAU_Project_RentACarPortal.App.DataAccess.Migrations
{
    [DbContext(typeof(RentalDbContext))]
    [Migration("20231010171945_degerlendirmeEntity")]
    partial class degerlendirmeEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.DataAccess.Identity.Model.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.DataAccess.Identity.Model.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Cinsiyet")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DogumYili")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TCKNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.Araba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArabaDetayId")
                        .HasColumnType("int");

                    b.Property<int>("ArabaKategoriId")
                        .HasColumnType("int");

                    b.Property<int>("FirmaId")
                        .HasColumnType("int");

                    b.Property<int?>("HasarDurumu")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plaka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SaatlikUcret")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SigortaId")
                        .HasColumnType("int");

                    b.Property<string>("UretimYili")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArabaKategoriId");

                    b.HasIndex("FirmaId");

                    b.HasIndex("SigortaId");

                    b.ToTable("Arabalar");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.ArabaDetay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ArabaId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Km")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Renk")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vites")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yakıt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArabaId")
                        .IsUnique();

                    b.ToTable("ArabaDetaylar");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.ArabaKategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ArabaKategorileri");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.Degerlendirme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArabaId")
                        .HasColumnType("int");

                    b.Property<int?>("FirmaId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MusteriId")
                        .HasColumnType("int");

                    b.Property<string>("Yorum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("YorumTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ArabaId");

                    b.HasIndex("FirmaId");

                    b.ToTable("Degerlendirmeler");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.Devir", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("ArabaId")
                        .HasColumnType("int");

                    b.Property<int>("FaturaNo")
                        .HasColumnType("int");

                    b.Property<int?>("HasarDurumu")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("Km")
                        .HasColumnType("int");

                    b.Property<string>("Resimler")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FaturaNo")
                        .IsUnique();

                    b.ToTable("Devirler");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.Firma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirmaAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirmaAdresi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirmaTel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Firmalar");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.Kiralama", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FaturaNo")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("KiralamaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("MusteriId")
                        .HasColumnType("int");

                    b.Property<decimal>("ToplamTutar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Kiralamalar");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.KiralamaDetay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArabaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BaslangicTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("BitisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("FaturaNo")
                        .HasColumnType("int");

                    b.Property<decimal>("GunlukUcret")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("KiralamaId")
                        .HasColumnType("int");

                    b.Property<int>("ToplamAdet")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArabaId");

                    b.HasIndex("KiralamaId");

                    b.ToTable("KiralamaDetaylar");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.Sigorta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("SigortaAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SigortaBaslangic")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SigortaBitis")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SigortaUcret")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Sigortalar");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.Teslim", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("ArabaId")
                        .HasColumnType("int");

                    b.Property<int>("FaturaNo")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("Km")
                        .HasColumnType("int");

                    b.Property<string>("Resimler")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FaturaNo")
                        .IsUnique();

                    b.ToTable("Teslimler");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.Araba", b =>
                {
                    b.HasOne("BAU_Project_RentACarPortal.App.Entity.Entities.ArabaKategori", "ArabaKategori")
                        .WithMany("Arabalar")
                        .HasForeignKey("ArabaKategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BAU_Project_RentACarPortal.App.Entity.Entities.Firma", "Firma")
                        .WithMany("Arabalar")
                        .HasForeignKey("FirmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BAU_Project_RentACarPortal.App.Entity.Entities.Sigorta", "Sigorta")
                        .WithMany()
                        .HasForeignKey("SigortaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArabaKategori");

                    b.Navigation("Firma");

                    b.Navigation("Sigorta");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.ArabaDetay", b =>
                {
                    b.HasOne("BAU_Project_RentACarPortal.App.Entity.Entities.Araba", "Araba")
                        .WithOne("ArabaDetay")
                        .HasForeignKey("BAU_Project_RentACarPortal.App.Entity.Entities.ArabaDetay", "ArabaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Araba");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.Degerlendirme", b =>
                {
                    b.HasOne("BAU_Project_RentACarPortal.App.Entity.Entities.Araba", "Araba")
                        .WithMany("Degerlendirmes")
                        .HasForeignKey("ArabaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BAU_Project_RentACarPortal.App.Entity.Entities.Firma", null)
                        .WithMany("Degerlendirmelers")
                        .HasForeignKey("FirmaId");

                    b.Navigation("Araba");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.Devir", b =>
                {
                    b.HasOne("BAU_Project_RentACarPortal.App.Entity.Entities.KiralamaDetay", "KiralamaDetay")
                        .WithOne("Devir")
                        .HasForeignKey("BAU_Project_RentACarPortal.App.Entity.Entities.Devir", "FaturaNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KiralamaDetay");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.KiralamaDetay", b =>
                {
                    b.HasOne("BAU_Project_RentACarPortal.App.Entity.Entities.Araba", "Araba")
                        .WithMany("KiralamaDetaylari")
                        .HasForeignKey("ArabaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BAU_Project_RentACarPortal.App.Entity.Entities.Kiralama", "Kiralama")
                        .WithMany("KiralamaDetaylari")
                        .HasForeignKey("KiralamaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Araba");

                    b.Navigation("Kiralama");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.Teslim", b =>
                {
                    b.HasOne("BAU_Project_RentACarPortal.App.Entity.Entities.KiralamaDetay", "KiralamaDetay")
                        .WithOne("Teslim")
                        .HasForeignKey("BAU_Project_RentACarPortal.App.Entity.Entities.Teslim", "FaturaNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KiralamaDetay");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("BAU_Project_RentACarPortal.App.DataAccess.Identity.Model.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("BAU_Project_RentACarPortal.App.DataAccess.Identity.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("BAU_Project_RentACarPortal.App.DataAccess.Identity.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("BAU_Project_RentACarPortal.App.DataAccess.Identity.Model.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BAU_Project_RentACarPortal.App.DataAccess.Identity.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("BAU_Project_RentACarPortal.App.DataAccess.Identity.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.Araba", b =>
                {
                    b.Navigation("ArabaDetay")
                        .IsRequired();

                    b.Navigation("Degerlendirmes");

                    b.Navigation("KiralamaDetaylari");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.ArabaKategori", b =>
                {
                    b.Navigation("Arabalar");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.Firma", b =>
                {
                    b.Navigation("Arabalar");

                    b.Navigation("Degerlendirmelers");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.Kiralama", b =>
                {
                    b.Navigation("KiralamaDetaylari");
                });

            modelBuilder.Entity("BAU_Project_RentACarPortal.App.Entity.Entities.KiralamaDetay", b =>
                {
                    b.Navigation("Devir")
                        .IsRequired();

                    b.Navigation("Teslim");
                });
#pragma warning restore 612, 618
        }
    }
}
