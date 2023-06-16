using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OBS_MVC.Models
{
    public partial class OBSContext : DbContext
    {
        public OBSContext()
        {
        }

        public OBSContext(DbContextOptions<OBSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ObsBolum> Bolumler { get; set; }
        public virtual DbSet<ObsDers> Dersler { get; set; }
        public virtual DbSet<ObsDonem> Donemler { get; set; }
        public virtual DbSet<ObsDonemDers> DonemDersler { get; set; }
        public virtual DbSet<ObsDuyuru> Duyurular { get; set; }
        public virtual DbSet<ObsFakulte> Fakulteler { get; set; }
        public virtual DbSet<ObsKullanici> Kullanicilar { get; set; }
        public virtual DbSet<ObsOgrenci> Ogrenciler { get; set; }
        public virtual DbSet<ObsOgrenciDonemDers> OgrenciDonemDersler { get; set; }
        public virtual DbSet<ObsOgrenciSinav> OgrenciSinavlar { get; set; }
        public virtual DbSet<ObsOgretimGorevlisi> OgretimGorevlileri { get; set; }
        public virtual DbSet<ObsOgretimGorevlisiDers> OgretimGorevlisiDersleri { get; set; }
        public virtual DbSet<ObsSinavTarih> SinavTarihleri { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ObsCon"].ConnectionString;
                optionsBuilder.UseSqlServer("Server=localhost.;Database=OBS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<ObsBolum>(entity =>
            {
                entity.HasKey(e => e.BolumId)
                    .HasName("PK_Bolum");

                entity.ToTable("OBS_Bolum");

                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Kod)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.Fakulte)
                    .WithMany(p => p.Bolumler)
                    .HasForeignKey(d => d.FakulteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bolum_Fakulte_FakulteId");
            });

            modelBuilder.Entity<ObsDers>(entity =>
            {
                entity.HasKey(e => e.DersId)
                    .HasName("PK_Ders");

                entity.ToTable("OBS_Ders");

                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Kod)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bolum)
                    .WithMany(p => p.Dersler)
                    .HasForeignKey(d => d.BolumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ders_Bolum_BolumId");
            });

            modelBuilder.Entity<ObsDonem>(entity =>
            {
                entity.HasKey(e => e.DonemId)
                    .HasName("PK_Donem");

                entity.ToTable("OBS_Donem");
            });

            modelBuilder.Entity<ObsDonemDers>(entity =>
            {
                entity.HasKey(e => e.DonemDersId)
                    .HasName("PK_DonemDers");

                entity.ToTable("OBS_DonemDers");

                entity.HasOne(d => d.Ders)
                    .WithMany(p => p.DonemDers)
                    .HasForeignKey(d => d.DersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DonemDers_Ders_DersId");

                entity.HasOne(d => d.Donem)
                    .WithMany(p => p.DonemDersleri)
                    .HasForeignKey(d => d.DonemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DonemDers_Donem_DonemId");

                entity.HasOne(d => d.OgretimGorevlisi)
                    .WithMany(p => p.DonemDersleri)
                    .HasForeignKey(d => d.OgretimGorevlisiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DonemDers_OgGorevId");
            });

            modelBuilder.Entity<ObsDuyuru>(entity =>
            {
                entity.HasKey(e => e.DuyuruId)
                    .HasName("PK_Duyuru");

                entity.ToTable("OBS_Duyuru");

                entity.Property(e => e.BolumId).HasColumnName("BolumID");

                entity.Property(e => e.Duyuru)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bolum)
                    .WithMany(p => p.Duyurular)
                    .HasForeignKey(d => d.BolumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Duyuru_Bolum");
            });

            modelBuilder.Entity<ObsFakulte>(entity =>
            {
                entity.HasKey(e => e.FakulteId)
                    .HasName("PK_Fakulte");

                entity.ToTable("OBS_Fakulte");

                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ObsKullanici>(entity =>
            {
                entity.HasKey(e => e.KullaniciId);

                entity.ToTable("OBS_Kullanici");

                entity.Property(e => e.KimlikNo).HasMaxLength(11);

                entity.Property(e => e.KullaniciAdi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sifre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Turu)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ObsOgrenci>(entity =>
            {
                entity.HasKey(e => e.OgrenciId)
                    .HasName("PK_Ogrenci");

                entity.ToTable("OBS_Ogrenci");

                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                //entity.Property(e => e.CikisTarih).HasColumnType("datetime");

                entity.Property(e => e.DogumTarih).HasColumnType("datetime");

                entity.Property(e => e.Eposta)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EPosta");

                entity.Property(e => e.GirisTarih).HasColumnType("datetime");

                entity.Property(e => e.KimlikNo)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Soyad)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bolum)
                    .WithMany(p => p.Ogrenciler)
                    .HasForeignKey(d => d.BolumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ogrenci_Bolum_BolumId");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.Ogrenciler)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OBS_Ogrenci_OBS_Kullanici");
            });

            modelBuilder.Entity<ObsOgrenciDonemDers>(entity =>
            {
                entity.HasKey(e => e.KayıtId)
                    .HasName("PK_OgrenciDonemDers");

                entity.ToTable("OBS_OgrenciDonemDers");

                entity.Property(e => e.FinalNot).HasColumnName("Final_Not");

                entity.HasOne(d => d.DonemDers)
                    .WithMany(p => p.OgrenciDonemDers)
                    .HasForeignKey(d => d.DonemDersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OgrenciDonemDersId");

                entity.HasOne(d => d.Ogrenci)
                    .WithMany(p => p.OgrenciDonemDersleri)
                    .HasForeignKey(d => d.OgrenciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OgrenciDonemDers_Id");
            });

            modelBuilder.Entity<ObsOgrenciSinav>(entity =>
            {
                entity.HasKey(e => e.OgrenciSinavId);

                entity.ToTable("OBS_OgrenciSinav");

                entity.Property(e => e.OgrenciSinavId).ValueGeneratedNever();

                entity.HasOne(d => d.Ogrenci)
                    .WithMany(p => p.OgrenciSinavlari)
                    .HasForeignKey(d => d.OgrenciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OBS_OgrenciSinav_OBS_Ogrenci");

                entity.HasOne(d => d.Sinav)
                    .WithMany(p => p.OgrenciSinavlari)
                    .HasForeignKey(d => d.SinavId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OBS_OgrenciSinav_OBS_Sinav_Tarih");
            });

            modelBuilder.Entity<ObsOgretimGorevlisi>(entity =>
            {
                entity.HasKey(e => e.OgretimGorevlisiId)
                    .HasName("PK_OgretimGorevlisi");

                entity.ToTable("OBS_OgretimGorevlisi");

                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                //entity.Property(e => e.CikisTarih).HasColumnType("datetime");

                entity.Property(e => e.DogumTarih).HasColumnType("datetime");

                entity.Property(e => e.Eposta)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EPosta");

                entity.Property(e => e.GirisTarih).HasColumnType("datetime");

                entity.Property(e => e.KimlikNo)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Soyad)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Resim);

                entity.HasOne(d => d.Bolum)
                    .WithMany(p => p.OgretimGorevlileri)
                    .HasForeignKey(d => d.BolumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OgretimGorevlisi");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.OgretimGorevlileri)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OBS_OgretimGorevlisi_OBS_Kullanici");
            });

            modelBuilder.Entity<ObsOgretimGorevlisiDers>(entity =>
            {
                entity.HasKey(e => e.OgretmenDersId);

                entity.ToTable("OBS_OgretimGorevlisiDers");

                entity.Property(e => e.OgretmenDersId).ValueGeneratedNever();

                entity.HasOne(d => d.DonemDers)
                    .WithMany(p => p.OgretimGorevlisiDers)
                    .HasForeignKey(d => d.DonemDersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OBS_OgretimGorevlisiDers_OBS_DonemDers");

                entity.HasOne(d => d.OgretimGorevlisi)
                    .WithMany(p => p.OgretimGorevlisiDersleri)
                    .HasForeignKey(d => d.OgretimGorevlisiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OBS_OgretimGorevlisiDers_OBS_OgretimGorevlisi");
            });

            modelBuilder.Entity<ObsSinavTarih>(entity =>
            {
                entity.HasKey(e => e.SinavId)
                    .HasName("PK_Sinav_Tarih");

                entity.ToTable("OBS_Sinav_Tarih");

                entity.Property(e => e.SinavId).HasColumnName("Sinav_Id");

                entity.Property(e => e.SinavTarih)
                    .HasColumnType("datetime")
                    .HasColumnName("Sinav_Tarih");

                entity.Property(e => e.SinavTur).HasColumnName("Sinav_Tur");

                entity.HasOne(d => d.DonemDers)
                    .WithMany(p => p.SinavTarihleri)
                    .HasForeignKey(d => d.DonemDersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sinav_DonemDers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
