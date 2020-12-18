using System;

namespace CatsHealth.API.Data.Entities
{
    public class Weight : EntityBase<Weight>
    {
        public string ProfileId { get; set; }
        public double Value { get; set; }
        public DateTime RegisteredOn { get; set; }
    }
}