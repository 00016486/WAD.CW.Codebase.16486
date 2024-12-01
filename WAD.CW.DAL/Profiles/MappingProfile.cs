using AutoMapper;
using WAD.CW.Codebase._16486.DTOModels;

namespace WAD.CW.Codebase._16486.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Visitor mappings
            CreateMap<Visitor, VisitorDto>()
                .ForMember(dest => dest.ReceptionistName, opt => opt.MapFrom(src => src.Receptionist.Name));
            CreateMap<CreateVisitorDto, Visitor>();
            CreateMap<UpdateVisitorDto, Visitor>();

            // Receptionist mappings
            CreateMap<Receptionist, ReceptionistDto>();
            CreateMap<CreateReceptionistDto, Receptionist>();
            CreateMap<UpdateReceptionistDto, Receptionist>();
        }
    }
}
