using AutoMapper;
using System;
using YdyoOBS.Application.Common.Dto;
using YdyoOBS.Domain.Entities;

namespace YdyoOBS.Application.Common.Mappings
{
    public class GeneralMapping  :Profile
    {
        public GeneralMapping()
        {
            CreateMap<Donem, DonemDto>().ReverseMap();

            CreateMap<Kur, KurDto>()                
                .ForMember(k => k.HDersSaati, opt => opt.MapFrom(s => s.HdersSaati))
                .ForMember(k => k.DevamsizlikSaati, opt=> opt.MapFrom(s=>s.Devamsizlik==null? 0 : Convert.ToInt32(s.Devamsizlik)))
                .ForMember(k => k.DGSDevamsizlikSaati, opt => opt.MapFrom(s => s.DevamsizlikDgs == null ? 0 : Convert.ToInt32(s.DevamsizlikDgs)))
                .ForMember(k => k.DonemAdi, opt => opt.MapFrom(s => s.Donem == null ? "" : s.Donem.Adi ))
                .ReverseMap();

            CreateMap<Sinif, SinifDto>()
                .ForMember(s => s.KurId,opt=> opt.MapFrom(k=>k.KurId?? 0))
                .ForMember(s => s.DonemId, opt => opt.MapFrom(k => k.DonemId ?? 0))
                .ForMember(s => s.KurAdi, opt => opt.MapFrom(k => k.Kur == null ? "" : k.Kur.Adi))
                .ForMember(s => s.DonemAdi, opt => opt.MapFrom(k => k.Kur == null ? "" : k.Kur.Donem.Adi))      
                .ForMember(s=>s.HocaAdi, opt=> opt.MapFrom(h=>h.Hoca==null? "":  h.Hoca.Adi + " " + h.Hoca.Soyadi))
                .ReverseMap();

            CreateMap<Ogrenci, OgrenciDto>()
                .ForMember(o => o.SinifId, opt => opt.MapFrom(s => s.SinifId ?? 0))
                .ForMember(o => o.KurId, opt => opt.MapFrom(k => k.KurId ?? 0))
                .ForMember(o => o.DonemId, opt => opt.MapFrom(d => d.DonemId ?? 0))
                .ForMember(o => o.SinifAdi, opt => opt.MapFrom(s => s.Sinif == null ? "" : s.Sinif.Adi))
                .ForMember(o => o.KurAdi, opt => opt.MapFrom(k => k.Kur == null ? "" : k.Kur.Adi))
                .ForMember(o => o.DonemAdi, opt => opt.MapFrom(d => d.Donem == null ? "" : d.Donem.Adi))
                .ForMember(o => o.Cinsiyeti, opt => opt.MapFrom(x => x.Cinsiyeti.Trim()))
                //.ForMember(o=>o.FakulteAdi, opt=> opt.MapFrom(s=>s.FakulteAdi))
                //.ForMember(o => o.BolumAdi, opt => opt.MapFrom(s => s.BolumAdi))
                .ForMember(o => o.Aktif, opt => opt.MapFrom(o => o.Aktif ?? false))
                .ReverseMap();

            CreateMap<Ogrenci, SinifOgrenciDto>()
                .ForMember(o => o.OgrenciId, opt => opt.MapFrom(s => s.Id))
                .ForMember(o => o.OgrenciNo, opt => opt.MapFrom(s => s.OgrNo))
                .ForMember(o => o.SinifAdi, opt => opt.MapFrom(s => s.Sinif.Adi))
                .ForMember(o => o.KurAdi, opt => opt.MapFrom(s => s.Sinif.Kur.Adi))
                .ForMember(o => o.HocaAdi, opt => opt.MapFrom(s => s.Sinif.Hoca.Adi + " " + s.Sinif.Hoca.Soyadi));

            CreateMap<Hoca, HocaDto>()
                .ForMember(h => h.Adi, opt => opt.MapFrom(s => s.Adi))
                .ForMember(h => h.Soyadi, opt => opt.MapFrom(s => s.Soyadi));




        }
    }
}
