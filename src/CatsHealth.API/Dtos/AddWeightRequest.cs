using System;

namespace CatsHealth.API.Dtos
{
    public record AddWeightRequest
    {
        public string ProfileId { get; }
        public double Value { get; }
        public DateTime RegisteredOn { get; }

        public AddWeightRequest(string profileId, double value, DateTime registeredOn)
        => (ProfileId, Value, RegisteredOn) = (profileId, value, registeredOn);

    }
}