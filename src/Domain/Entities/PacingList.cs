using System;
using System.Collections.Generic;


namespace YdyoOBS.Domain.Entities
{
    public partial class PacingList
    {
        public int Id { get; set; }
        public int? HocaId { get; set; }
        public DateTime? Tarih { get; set; }
        public int? SinifId { get; set; }
        public string Touchstone { get; set; }
        public string Vocab { get; set; }
        public string Video { get; set; }
        public string TopGrammar { get; set; }
        public string Writing { get; set; }
        public string Speaking { get; set; }
        public string PracticalEnglish { get; set; }
        public string Sure { get; set; }
        public string GrammarExplorer { get; set; }
        public string LanguageLeader { get; set; }
        public int? KulId { get; set; }
        public DateTime? KayitTarihi { get; set; }
        public DateTime? DegTarihi { get; set; }
        public int? DonemId { get; set; }

        public virtual Donem Donem { get; set; }
        public virtual Sinif Sinif { get; set; }
        public virtual Hoca Hoca { get; set; }

    }
}
