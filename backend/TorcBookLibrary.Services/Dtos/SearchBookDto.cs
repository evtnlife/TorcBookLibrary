namespace TorcBookLibrary.Services.Dtos
{
    public class SearchBookDto
    {
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public string? Category { get; set; }
    }
}
