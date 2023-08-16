using AutoMapper;
using SpreadLayers.Application.DTOs;
using SpreadLayers.Domain.Entities;

namespace SpreadLayers.Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Empresa, EmpresaDTO>().ReverseMap();

        }
    }
}