using AutoMapper;
using HinweigeberRestApi.Areas.Massnahmen.Models;
using HinweigeberRestApi.Data;

namespace HinweigeberRestApi.Areas.Massnahmen.Mapper
{
    public class MassnahmenProfile : Profile
    {
        public MassnahmenProfile()
        {
            //CreateMap<MassnahmeAddDTO, Massnahme>()
            //    .ForMember(p => p.Id, opt => opt.Ignore())
            //    .ForMember(p => p.PartnerId, opt => opt.MapFrom(u => u.PartnerId))
            //    .ForMember(p => p.Beschreibung, opt => opt.MapFrom(u => u.Beschreibung));

            CreateMap<Massnahme, MassnahmenReadDTO>()
                .ForMember(p => p.Id, opt => opt.MapFrom(u => u.Id))
                .ForMember(p => p.Meldungen, opt => opt.MapFrom(u => u.Meldungen))
                .ForMember(p => p.CreateDate, opt => opt.MapFrom(u => u.CreateDate.ToShortDateString()))
                .ForMember(p => p.Beschreibung, opt => opt.MapFrom(u => u.Beschreibung));
        }
    }
}
