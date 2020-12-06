namespace CatsHealth.API.Dtos
{
    public record ProfileRequestDto
    {
        public string Name { get; }

        public ProfileRequestDto(string name) => (Name) = (name);
    }
}