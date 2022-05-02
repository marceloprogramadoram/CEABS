using AutoMapper;
using CEABS.Domain.Entities;
using CEABS.Service.DTO;

namespace CEABS.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ModelCar, ModelCarDTO>().ReverseMap();

            CreateMap<Vehicle, VehicleDTO>().ReverseMap()
                .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.Plate))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.ModelCarId, opt => opt.MapFrom(src => src.ModelCarId))
                .ForMember(dest => dest.ProducerId, opt => opt.MapFrom(src => src.ProducerId))
                .ForMember(dest => dest.YearFabrication, opt => opt.MapFrom(src => src.YearFabrication));

            CreateMap<Producer, ProducerDTO>().ReverseMap();

        }
    }
}
