using AutoMapper;
using HinweigeberRestApi.Areas.Massnahmen.Models;
using HinweigeberRestApi.Areas.Meldungen.Models;
using HinweigeberRestApi.Areas.WeitereInfos.Models;
using HinweigeberRestApi.Data;

namespace HinweigeberRestApi.Areas.WeitereInfos.Mapper
{
	public class WeitereInfoProfile : Profile
	{
		public WeitereInfoProfile()
		{
			CreateMap<WeitereInfosReadDTO, Weitereinfo>()
				.ForMember(p => p.Id, opt => opt.MapFrom(u => u.Id))
				.ForMember(p => p.Code, opt => opt.MapFrom(u => u.Code))
				.ForMember(p => p.CreateDate, opt => opt.MapFrom(u => Convert.ToDateTime(u.CreateDate)))
				.ForMember(p => p.Beschreibung, opt => opt.MapFrom(u => u.Beschreibung));

			CreateMap<WeitereInfoUpdateDTO, Weitereinfo>()
				.ForMember(p => p.Id, opt => opt.MapFrom(u => u.Id))
				.ForMember(p => p.Beschreibung, opt => opt.MapFrom(u => u.Beschreibung));

			CreateMap<Weitereinfo, WeitereInfosReadDTO>()
				.ForMember(p => p.Id, opt => opt.MapFrom(u => u.Id))
				.ForMember(p => p.Code, opt => opt.MapFrom(u => u.Code))
				.ForMember(p => p.CreateDate, opt => opt.MapFrom(u => u.CreateDate.ToShortDateString()))
				.ForMember(p => p.Beschreibung, opt => opt.MapFrom(u => u.Beschreibung));

			CreateMap<WeitereInfoAddDTO, Weitereinfo>()
				.ForMember(p => p.Id, opt => opt.Ignore())
				.ForMember(p => p.Code, opt => opt.MapFrom(u => u.Code))
				.ForMember(p => p.MassnahmeId, opt => opt.MapFrom(u => u.MassnahmeId))
				.ForMember(p => p.CreateDate, opt => opt.MapFrom(u => Convert.ToDateTime(u.CreateDate)))
				.ForMember(p => p.Beschreibung, opt => opt.MapFrom(u => u.Beschreibung));
		}
	}
}
