using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using YdyoOBS.Domain.Entities;

namespace YdyoOBS.Application.Common.Interfaces
{
    public interface IYdyoDbContext
    {
        DbSet<Hoca> Hocalar { get; set; }
        DbSet<Donem> Donemler { get; set; }
        DbSet<Kur> Kurlar { get; set; }
        DbSet<Sinif> Siniflar { get; set; }
        DbSet<Ogrenci> Ogrenciler { get; set; }
        DbSet<SinavTur> SinavTurleri { get; set; }
        DbSet<SinavSonuc> SinavSonuclari { get; set; }
        DbSet<Devamsizlik> Devamsizliklar { get; set; }
        DbSet<Telafi> Telafiler { get; set; }
        DbSet<PacingList> PacingListler { get; set; }
        DbSet<Toplanti> Toplantilar { get; set; }
        DbSet<Bolum> Bolumler { get; set; }
        DbSet<Fakulte> Fakulteler { get; set; }
        DbSet<DersSaati> DersSaatleri { get; set; }
        DbSet<Ders> Dersler { get; set; }
        DbSet<Derslik> Derslikler { get; set; }
        DbSet<OgrenciTuru> OgrenciTuru { get; set; }
        DbSet<SinifTur> SinifTur { get; set; }
        DbSet<BolumDurum> BolumDurum { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
