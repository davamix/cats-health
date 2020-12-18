using System;
using System.Collections.Generic;
using CatsHealth.API.Data.Entities;
using CatsHealth.API.Dtos;

namespace CatsHealth.API.Mappers
{

    public static class Mapper
    {
        public static Profile ToProfile(this ProfileRequestDto dto) => new Profile { Name = dto.Name };
        public static Weight ToWeight(this AddWeightRequest dto) => new Weight { ProfileId = dto.ProfileId, Value = dto.Value, RegisteredOn = dto.RegisteredOn };
    }


}