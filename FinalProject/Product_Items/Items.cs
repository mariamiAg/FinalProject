using FinalProject.DomainModels;

namespace FinalProject.Product_Items
{
    public class Toy : ProductDTO
    {
        public string Manufacturer { get; set; } = null!;

        public string Material { get; set; } = null!;

        public int RecommendedAge { get; set; }

        public int Description { get; set; }

        public int Price { get; set; }

    }

    public class Book : ProductDTO
    {
        public string Author { get; set; } = null!;

        public string PublishingHouse { get; set; } = null!;

        public int PublishingYear { get; set; }

        public int RecommendedAge { get; set; }

        public int Description { get; set; }

        public int Price { get; set; }

    }

    public class SportInventory : ProductDTO
    {
        public string Brand { get; set; } = null!;

        public int RecommendedAge { get; set; }

        public int Description { get; set; }

        public int Price { get; set; }

    }

}
