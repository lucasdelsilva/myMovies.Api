using System.ComponentModel;

namespace MyMovies.Api.DTOs
{
    public class MovieAddDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public List<string> Gender { get; set; }
        public List<string> Actors { get; set; }
        public int Duration { get; set; }

        [DefaultValue("dd/mm/yyyy")]
        public string Year { get; set; }
    }
}
