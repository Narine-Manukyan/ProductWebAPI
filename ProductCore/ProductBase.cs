using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductCore
{
    public class ProductBase
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
