using AutoMapper;
using RegengyBookShelf_Api.Models;
using RegengyBookShelf_Api.Models.Dtos;

namespace RegengyBookShelf_Api
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Series, SeriesDto>().ReverseMap();
        }
    }
}
