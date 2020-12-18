using System;

namespace CatsHealth.API.Dtos
{
    public record WeightResponse
    {
        public double Value { get; }
        public DateTime RegisteredOn { get; }

        public WeightResponse(double value, DateTime registeredOn) => (Value, RegisteredOn) = (value, registeredOn);
    }
}