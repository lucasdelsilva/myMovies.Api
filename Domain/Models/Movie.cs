﻿using System.ComponentModel.DataAnnotations;

namespace MyMovies.Api.Domain.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public List<string> Gender { get; set; }
        public List<string> Actors { get; set; }
        public int Duration { get; set; }
        public DateTime Year { get; set; }
    }
}