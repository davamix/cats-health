using System;

namespace CatsHealth.API.Data.Entities
{
    public class Profile : EntityBase<Profile>
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public DateTime Birthdate { get; set; }
        public string Sex { get; set; }
        public Weight LastWeight { get; set; }
    }
}