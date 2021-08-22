using System;

namespace ProductCore
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
