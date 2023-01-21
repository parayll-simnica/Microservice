using PlatformService.Dtos;

namespace PlatformService.SynceDataService.Htpp
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto plat);
    }
}