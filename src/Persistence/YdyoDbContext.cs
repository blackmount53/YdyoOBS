using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using YdyoOBS.Application.Common.Interfaces;
using YdyoOBS.Domain.Entities;

namespace YdyoOBS.Persistence
{
    public class YdyoDbContext : DbContext, IYdyoDbContext
    {
        //private readonly ICurrentUserService _currentUserService;
        public YdyoDbContext(DbContextOptions<YdyoDbContext> options):base(options)
        {

        }

        public virtual DbSet<Hoca> Hocalar { get; set; }
        public virtual DbSet<Donem> Donemler { get; set; }
        public virtual DbSet<Kur> Kurlar { get; set; }
        public virtual DbSet<Sinif> Siniflar { get; set; }
        public virtual DbSet<Ogrenci> Ogrenciler { get; set; }
        public virtual DbSet<SinavTur> SinavTurleri { get; set; }
        public virtual DbSet<SinavSonuc> SinavSonuclari { get; set; }
        public virtual DbSet<Devamsizlik> Devamsizliklar { get; set; }
        public virtual DbSet<Telafi> Telafiler { get; set; }
        public virtual DbSet<PacingList> PacingListler { get; set; }
        public virtual DbSet<Toplanti> Toplantilar { get; set; }
        public virtual DbSet<Bolum> Bolumler { get; set; }
        public virtual DbSet<Fakulte> Fakulteler { get; set; }
        public virtual DbSet<DersSaati> DersSaatleri { get; set; }
        public virtual DbSet<Ders> Dersler { get; set; }
        public virtual DbSet<Derslik> Derslikler { get; set; }
        public virtual DbSet<OgrenciTuru> OgrenciTuru { get; set; }
        public virtual DbSet<SinifTur> SinifTur { get; set; }
        public virtual DbSet<BolumDurum> BolumDurum { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            //foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            //{
            //    switch (entry.State)
            //    {
                 
            //        case EntityState.Modified:
            //            break;
            //        case EntityState.Added:
            //            break;
            //        default:
            //            break;
            //    }
            //}
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(YdyoDbContext).Assembly);
        }
    }
}
