using AutoMapper;
using Marks.Core.Models;
using Marks.Web.ViewModels;
using System.Linq;

namespace Marks.Web.Mapper
{
    /// <summary>
    /// Mapping descriptions.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<People, PeopleMarkViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.ResolveUsing(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Mark, opt => opt.ResolveUsing(src => src.Mark.Value))
                .ReverseMap()
                .ForMember(dest => dest.FirstName, opt => opt.ResolveUsing(src => src.FullName.Split(' ').First()))
                .ForMember(dest => dest.LastName, opt => opt.ResolveUsing(src => src.FullName.Split(' ').Last()))
                .ForMember(dest => dest.Mark, opt => opt.ResolveUsing(src => new Mark { Value = src.Mark }));
        }
    }
}
