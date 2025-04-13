using AutoMapper;
using orakle_api.DTOs;
using orakle_api.Entities;

namespace orakle_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<source, destination>();

            CreateMap<Owner, OwnerDTO>().ReverseMap();
            CreateMap<Artefact, ArtefactDTO>().ReverseMap();
            CreateMap<Artefact, ArtefactSummaryDTO>().ReverseMap();
            CreateMap<Artefact, ArtefactCreateDTO>().ReverseMap();
            //CreateMap<Artefact, ArtefactUpdateDTO>().ReverseMap();

            CreateMap<ArtefactUpdateDTO, Artefact>()
                .ForMember(dest => dest.CreationDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(_ => DateTime.UtcNow));

        }
    }
    
}
