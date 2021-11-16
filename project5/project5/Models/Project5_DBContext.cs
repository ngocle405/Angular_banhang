using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace project5.Models
{
    public partial class Project5_DBContext : DbContext
    {
        public Project5_DBContext()
        {
        }

        public Project5_DBContext(DbContextOptions<Project5_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Chitietdathang> Chitietdathangs { get; set; }
        public virtual DbSet<Dathang> Dathangs { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Lienhe> Lienhes { get; set; }
        public virtual DbSet<Loaisanpham> Loaisanphams { get; set; }
        public virtual DbSet<Loaitintuc> Loaitintucs { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<Tintuc> Tintucs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-MMD0QVJ;Database=Project5_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Admin");

                entity.Property(e => e.Anhdaidien).HasColumnName("anhdaidien");

                entity.Property(e => e.Diachi).HasColumnName("diachi");

                entity.Property(e => e.Dienthoai)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dienthoai");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Gioitinh).HasColumnName("gioitinh");

                entity.Property(e => e.Hocvan).HasColumnName("hocvan");

                entity.Property(e => e.Hoten)
                    .HasMaxLength(50)
                    .HasColumnName("hoten");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Namsinh)
                    .HasColumnType("date")
                    .HasColumnName("namsinh");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("date")
                    .HasColumnName("ngaytao");

                entity.Property(e => e.Nghenghiep).HasColumnName("nghenghiep");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Quequan)
                    .HasMaxLength(50)
                    .HasColumnName("quequan");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tendangnhap)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tendangnhap");
            });

            modelBuilder.Entity<Chitietdathang>(entity =>
            {
                entity.HasKey(e => e.Mactdh);

                entity.ToTable("chitietdathang");

                entity.Property(e => e.Mactdh).HasColumnName("mactdh");

                entity.Property(e => e.Giaban).HasColumnName("giaban");

                entity.Property(e => e.Madh).HasColumnName("madh");

                entity.Property(e => e.Masp).HasColumnName("masp");

                entity.Property(e => e.Ngaymua)
                    .HasColumnType("date")
                    .HasColumnName("ngaymua");

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.HasOne(d => d.MadhNavigation)
                    .WithMany(p => p.Chitietdathangs)
                    .HasForeignKey(d => d.Madh)
                    .HasConstraintName("FK_chitietdathang_dathang");

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.Chitietdathangs)
                    .HasForeignKey(d => d.Masp)
                    .HasConstraintName("FK_chitietdathang_sanpham");
            });

            modelBuilder.Entity<Dathang>(entity =>
            {
                entity.HasKey(e => e.Madh);

                entity.ToTable("dathang");

                entity.Property(e => e.Madh).HasColumnName("madh");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(50)
                    .HasColumnName("diachi");

                entity.Property(e => e.Diachinhanhang).HasColumnName("diachinhanhang");

                entity.Property(e => e.Dienthoai)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dienthoai");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Isdelete).HasColumnName("isdelete");

                entity.Property(e => e.Makh).HasColumnName("makh");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("date")
                    .HasColumnName("ngaytao");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tenkh)
                    .HasMaxLength(50)
                    .HasColumnName("tenkh");

                entity.Property(e => e.Tongtien).HasColumnName("tongtien");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Dathangs)
                    .HasForeignKey(d => d.Makh)
                    .HasConstraintName("FK_dathang_khachhang");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makh);

                entity.ToTable("khachhang");

                entity.Property(e => e.Makh).HasColumnName("makh");

                entity.Property(e => e.Anhdaidien).HasColumnName("anhdaidien");

                entity.Property(e => e.Diachi).HasColumnName("diachi");

                entity.Property(e => e.Dienthoai)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dienthoai");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Gioitinh).HasColumnName("gioitinh");

                entity.Property(e => e.Hoten).HasColumnName("hoten");

                entity.Property(e => e.Isdelete).HasColumnName("isdelete");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("date")
                    .HasColumnName("ngaytao");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tendangnhap)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tendangnhap");
            });

            modelBuilder.Entity<Lienhe>(entity =>
            {
                entity.ToTable("lienhe");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(50)
                    .HasColumnName("diachi");

                entity.Property(e => e.Dienthoai)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dienthoai");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("date")
                    .HasColumnName("ngaytao");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tenkh)
                    .HasMaxLength(50)
                    .HasColumnName("tenkh");

                entity.Property(e => e.Thongdiep).HasColumnName("thongdiep");
            });

            modelBuilder.Entity<Loaisanpham>(entity =>
            {
                entity.ToTable("Loaisanpham");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Hienthi).HasColumnName("hienthi");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Isdelete).HasColumnName("isdelete");

                entity.Property(e => e.Mota).HasColumnName("mota");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("date")
                    .HasColumnName("ngaytao");

                entity.Property(e => e.Nguoitao).HasColumnName("nguoitao");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tenloai).HasColumnName("tenloai");
            });

            modelBuilder.Entity<Loaitintuc>(entity =>
            {
                entity.HasKey(e => e.Maloaitt);

                entity.ToTable("loaitintuc");

                entity.Property(e => e.Maloaitt).HasColumnName("maloaitt");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(10)
                    .HasColumnName("isdelete")
                    .IsFixedLength(true);

                entity.Property(e => e.Tenloai)
                    .HasMaxLength(250)
                    .HasColumnName("tenloai");
            });

            modelBuilder.Entity<Nhacungcap>(entity =>
            {
                entity.ToTable("nhacungcap");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Diachi).HasColumnName("diachi");

                entity.Property(e => e.Dienthoai)
                    .HasMaxLength(50)
                    .HasColumnName("dienthoai");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Isdelete).HasColumnName("isdelete");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("date")
                    .HasColumnName("ngaytao");

                entity.Property(e => e.Nguoitao)
                    .HasMaxLength(50)
                    .HasColumnName("nguoitao");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tenncc).HasColumnName("tenncc");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.ToTable("sanpham");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Baohanh).HasColumnName("baohanh");

                entity.Property(e => e.Congsuattoida)
                    .HasMaxLength(50)
                    .HasColumnName("congsuattoida");

                entity.Property(e => e.Dairongcao).HasColumnName("dairongcao");

                entity.Property(e => e.Docaoyen)
                    .HasMaxLength(50)
                    .HasColumnName("docaoyen");

                entity.Property(e => e.Dongco).HasColumnName("dongco");

                entity.Property(e => e.Dungtichbinhxang)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dungtichbinhxang");

                entity.Property(e => e.Dungtichxylanh)
                    .HasMaxLength(50)
                    .HasColumnName("dungtichxylanh");

                entity.Property(e => e.Giaban).HasColumnName("giaban");

                entity.Property(e => e.Giakm).HasColumnName("giakm");

                entity.Property(e => e.Gianhap).HasColumnName("gianhap");

                entity.Property(e => e.Hienthi).HasColumnName("hienthi");

                entity.Property(e => e.Hinhanh).HasColumnName("hinhanh");

                entity.Property(e => e.Hopso)
                    .HasMaxLength(50)
                    .HasColumnName("hopso");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Isdelete).HasColumnName("isdelete");

                entity.Property(e => e.Khoiluong)
                    .HasMaxLength(50)
                    .HasColumnName("khoiluong");

                entity.Property(e => e.Khungxe).HasColumnName("khungxe");

                entity.Property(e => e.Maloai).HasColumnName("maloai");

                entity.Property(e => e.Mancc).HasColumnName("mancc");

                entity.Property(e => e.Mausac)
                    .HasMaxLength(50)
                    .HasColumnName("mausac");

                entity.Property(e => e.Mota).HasColumnName("mota");

                entity.Property(e => e.Muctieuthunguyenlieu).HasColumnName("muctieuthunguyenlieu");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("date")
                    .HasColumnName("ngaytao");

                entity.Property(e => e.Nguoitao).HasColumnName("nguoitao");

                entity.Property(e => e.Phuocsau).HasColumnName("phuocsau");

                entity.Property(e => e.Phuoctruoc).HasColumnName("phuoctruoc");

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tensp).HasColumnName("tensp");

                entity.Property(e => e.Tienich).HasColumnName("tienich");

                entity.Property(e => e.Tongdanhgia).HasColumnName("tongdanhgia");

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.Maloai)
                    .HasConstraintName("FK_sanpham_Loaisanpham");

                entity.HasOne(d => d.ManccNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.Mancc)
                    .HasConstraintName("FK_sanpham_nhacungcap");
            });

            modelBuilder.Entity<Tintuc>(entity =>
            {
                entity.HasKey(e => e.Matt);

                entity.ToTable("tintuc");

                entity.Property(e => e.Matt).HasColumnName("matt");

                entity.Property(e => e.Img1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("img1");

                entity.Property(e => e.Img2)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("img2");

                entity.Property(e => e.Img3)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("img3");

                entity.Property(e => e.Maloaitt).HasColumnName("maloaitt");

                entity.Property(e => e.Ngaydang)
                    .HasColumnType("date")
                    .HasColumnName("ngaydang");

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.Property(e => e.Tag)
                    .HasMaxLength(50)
                    .HasColumnName("tag");

                entity.Property(e => e.Tieude)
                    .HasMaxLength(250)
                    .HasColumnName("tieude");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
