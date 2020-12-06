using System.Collections.Generic;
using CatsHealth.API.Dtos;

namespace CatsHealth.API.Services.ProfileService
{
    public interface IProfileService
    {
        ProfileResponseDto  GetProfile(string id);
        IList<ProfileResponseDto> GetProfiles();
    }
}