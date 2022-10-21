namespace BookStore.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }  
        public string ProductType   { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
    }
}
