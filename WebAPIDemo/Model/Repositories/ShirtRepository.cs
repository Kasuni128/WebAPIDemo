namespace WebAPIDemo.Model.Repositories
{
    public static class ShirtRepository
    {

        private static List<Shirt> shirts = new List<Shirt>
        {
            new Shirt { ShirtId = 1, Brand = "Red Shirt", Color = "Red", Size = 8, Gender = "Men", Price = 29.99 },
            new Shirt { ShirtId = 2, Brand = "Blue Shirt", Color = "Blue", Size = 6, Gender = "Women", Price = 19.99},
            new Shirt { ShirtId = 3, Brand = "Green Shirt", Color = "Green", Size = 12, Gender = "Men", Price = 39.99 }
        };

        public static List<Shirt> GetAllShirts()
        {
            return shirts;
        }

        public static bool ShirtExists(int id)
        {
            return shirts.Any(s => s.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(s => s.ShirtId == id);
        }

        public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
        {
            return shirts.FirstOrDefault(s =>
                !string.IsNullOrWhiteSpace(brand) && !string.IsNullOrWhiteSpace(s.Brand) && s.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(gender) && !string.IsNullOrWhiteSpace(s.Gender) && s.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(color) && !string.IsNullOrWhiteSpace(s.Color) && s.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
                size.HasValue && s.Size.HasValue && size.Value == s.Size.Value);
        }

        public static void AddShirt(Shirt shirt)
        {
            int maxId = shirts.Max(s => s.ShirtId);
            shirt.ShirtId = maxId + 1;
            shirts.Add(shirt);
        }

        public static void UpdateShirt(Shirt shirt)
        {
            var shirtToUpdate = shirts.FirstOrDefault(s => s.ShirtId == shirt.ShirtId);
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Gender= shirt.Gender;
            shirtToUpdate.Price = shirt.Price;
        }

        public static void DeleteShirt(int id)
        {
            var shirtToDelete = GetShirtById(id);
            if (shirtToDelete != null)
            {
                shirts.Remove(shirtToDelete);
            }
        }
    }
}
