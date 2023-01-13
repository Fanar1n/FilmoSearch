﻿namespace FilmoSearch.API.ViewModels.Review
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public int FilmId { get; set; }
    }
}
