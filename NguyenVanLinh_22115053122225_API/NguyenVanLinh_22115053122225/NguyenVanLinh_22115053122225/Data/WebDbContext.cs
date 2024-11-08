using Microsoft.EntityFrameworkCore;

namespace NguyenVanLinh_22115053122225.Data
{
    public class WebDbContext:DbContext
    {
        public WebDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DanhMucHoa> danhMucHoas { get; set; }
        public DbSet<Hoa> hoas { get; set; }
        public DbSet<GioHang> gioHangs { get; set; }
        public DbSet<User> users { get; set; }

    }
}
