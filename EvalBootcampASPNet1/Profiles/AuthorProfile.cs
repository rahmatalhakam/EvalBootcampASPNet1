using System;
using AutoMapper;
using EvalBootcampASPNet1.Dtos;
using EvalBootcampASPNet1.Models;

namespace EvalBootcampASPNet1.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorGDto>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => DateTime.Now.Year - src.DateOfBirth.Year));
            CreateMap<AuthorCUDto, Author>();

        }
    }
}
