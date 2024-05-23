namespace CourseProvider.Models
{
    public class CourseModel
    {
        public string Title { get; set; } = null!;
        public string HeaderDescription { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Author { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int Hours { get; set; }
        public int? Likes { get; set; }
        public int? LikePercentage { get; set; }
        public bool IsBestSeller { get; set; } = false;
        public int? Rating { get; set; }
        public int? Reviews { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}
