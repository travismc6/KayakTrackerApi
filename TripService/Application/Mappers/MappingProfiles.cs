using AutoMapper;
using KayakTracker.Application.DTOs;
using KayakTracker.Domain.Models;

namespace KayakTracker.Application.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Trip, TripDto>().IncludeMembers(x => x.River);
            CreateMap<River, TripDto>();
        }
    }
}
