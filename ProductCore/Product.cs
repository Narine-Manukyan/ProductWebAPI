using System;

namespace ProductCore
{
    public class Product : ProductBase
    {
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
