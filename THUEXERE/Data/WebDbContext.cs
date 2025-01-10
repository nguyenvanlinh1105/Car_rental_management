using Microsoft.EntityFrameworkCore;

namespace WEBAPI.Data
{
    public class WebDbContext :DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VaiTro_NguoiDung>()
                .HasKey(vt => new { vt.MaVT, vt.MaND });
            modelBuilder.Entity<DonThue_DichVu>()
                .HasKey(dtdv => new { dtdv.MaDV, dtdv.MaDT });
        }

        public DbSet<LoaiXe> LoaiXes { get; set; }
        public DbSet<DanhMucXe> DanhMucXes { get; set; }
        public DbSet<MauXe> MauXes { get; set; }
        public DbSet<Xe> Xes { get; set; }
        public DbSet<VaiTro> VaiTros { get; set; }
        public DbSet<NguoiDung> NguoiTros { get; set; }
        public DbSet<VaiTro_NguoiDung> VaiTro_NguoiDungs { get; set; }
        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<DonThue> DonThues {  get; set; }
        public DbSet<GopY> GopYs { get; set; }
        public DbSet<DonThue_DichVu> DonThue_DichVus { get; set; }
        public DbSet<ChiTietDonThue> chiTietDonThues { get; set; }
        public DbSet<NoiDung> NoiDungs { set; get; }
        public DbSet<BaiViet> BaiViets { get; set; }
        public DbSet<AnhNoiDung> AnhNoiDungs { get; set; }
        public DbSet<BangGia> BangGias { get; set; }

    }
}
