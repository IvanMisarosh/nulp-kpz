using AutoMapper;
using System;
using System.Linq;
using DbFirst.Models;
using Abstraction.DTOs;
using Abstraction.ModelInterfaces;

namespace BLL.Mappers
{
    public class MapperProfile : Profile
    {
        //TODO: Check if .ForMember is necessary
        public MapperProfile()
        {
            // Add your mappings here
            // Map entities to DTOs and vice versa
            CreateMap<Car, CarDTO>()
                //.ForMember(dest => dest.CarModel, opt => opt.MapFrom(src => src.CarModel))
                //.ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                //.ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ReverseMap();

            CreateMap<CarDTO, ICar>()
                .ConstructUsing(dto => new Car())
                .ReverseMap();

            CreateMap<Customer, CustomerDTO>().ReverseMap();
           
            CreateMap<CustomerDTO, ICustomer>()
            .ConstructUsing(dto => new Customer())
            .ReverseMap();

            CreateMap<CarModel, CarModelDTO>().ReverseMap();
            CreateMap<Color, ColorDTO>().ReverseMap();

            CreateMap<Visit, VisitDTO>()
                //.ForMember(dest => dest.Car, opt => opt.MapFrom(src => src.Car))
                ////.ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.EmployeeID))
                //.ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.PaymentStatus))
                //.ForMember(dest => dest.VisitStatus, opt => opt.MapFrom(src => src.VisitStatus))
                .ReverseMap();

            CreateMap<VisitDTO, IVisit>()
                .ConstructUsing(dto => new Visit())
                //.ForMember(dest => dest.Car, opt => opt.MapFrom(src => src.Car))
                //.ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee))
                //.ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.PaymentStatus))
                //.ForMember(dest => dest.VisitStatus, opt => opt.MapFrom(src => src.VisitStatus))
                .ReverseMap();

            CreateMap<PaymentStatus, PaymentStatusDTO>().ReverseMap();
            CreateMap<VisitStatus, VisitStatusDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();

        }

    }
}
