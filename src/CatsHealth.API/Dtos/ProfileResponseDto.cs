namespace CatsHealth.API.Dtos
{
    public record ProfileResponseDto
    {
        public string Id { get; }
        public string Name { get; }

        public ProfileResponseDto(string id, string name) => (Id, Name) = (id, name);
    }
}