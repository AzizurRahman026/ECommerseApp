
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int QuantityInStock { get; set; }
    }

    
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int QuantityInStock { get; set; }
    }
}
