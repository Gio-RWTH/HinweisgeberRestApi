using AutoMapper;
using HinweigeberRestApi.Areas.Meldungen.Models;
using HinweigeberRestApi.Data;

namespace HinweigeberRestApi.Areas.Meldungen.Mapper
{
    public class MeldungProfile : Profile
    {
        public MeldungProfile()
        {
            CreateMap<MeldungenAddDTO, Meldung>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.PartnerId, opt => opt.MapFrom(u => u.PartnerId))
                .ForMember(p => p.isFinished, opt => opt.MapFrom(u => u.isFinished))
				.ForMember(p => p.Beschreibung, opt => opt.MapFrom(u => u.Beschreibung));

            CreateMap<Meldung, MeldungenReadDTO>()
                .ForMember(p => p.Id, opt => opt.MapFrom(u => u.Id))
                .ForMember(p => p.PartnerId, opt => opt.MapFrom(u => u.PartnerId))
                .ForMember(p => p.isFinished, opt => opt.MapFrom(u => u.isFinished))
				.ForMember(p => p.Massnahmen, opt => opt.MapFrom(u => u.Massnahmen))
				.ForMember(p => p.CreateDate, opt => opt.MapFrom(u => u.CreateDate.ToShortDateString()))
                .ForMember(p => p.Beschreibung, opt => opt.MapFrom(u => u.Beschreibung));
        }
    }
}
