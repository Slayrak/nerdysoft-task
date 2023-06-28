using AutoMapper;
using NerdysoftWebAPI.Database.Dto_s;
using NerdysoftWebAPI.Database.Models;

namespace NerdysoftWebAPI.MapperProfiles;

public class AnnouncementProfile : Profile
{
    public AnnouncementProfile() 
    {
        CreateMap<AnnouncementModelDTO, AnnouncementModel>()
            .ForMember(x => x.Id, opt => opt.MapFrom(srs => srs.Id))
            .ForMember(x => x.Title, opt => opt.MapFrom(srs => srs.Title))
            .ForMember(x => x.Description, opt => opt.MapFrom(srs => srs.Description))
            .ForMember(x => x.DateAdded, opt => opt.MapFrom(srs => srs.DateAdded));

        CreateMap<AnnouncementModel, AnnouncementModelDTO>()
            .ForMember(x => x.Id, opt => opt.MapFrom(srs => srs.Id))
            .ForMember(x => x.Title, opt => opt.MapFrom(srs => srs.Title))
            .ForMember(x => x.Description, opt => opt.MapFrom(srs => srs.Description))
            .ForMember(x => x.DateAdded, opt => opt.MapFrom(srs => srs.DateAdded));
    }
}
