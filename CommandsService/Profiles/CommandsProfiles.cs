using AutoMapper;
using ComandsService.Dtos;
using ComandsService.Models;

namespace ComandsService.Profiles
{
    public class CommandsProfiles : Profile
    {
        public CommandsProfiles()
        {
            // Source ---> Target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<Command, CommandReadDto>();
        }
    }
}