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

        public static bool ShirtExists(int id)
        {
            return shirts.Any(s => s.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(s => s.ShirtId == id);
        }
    }
}
