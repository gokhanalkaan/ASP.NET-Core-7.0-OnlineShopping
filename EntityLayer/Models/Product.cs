using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }

        public string ?ProductPhotoUrl { get; set; }

        public string ProductTitle { get; set; }
        
        public decimal ProductPrice { get; set; }

        public string ProductDescription { get; set; }

   
        public List<ProductCategory> ProductCategory { get; set; }
        public List<Comment> Comment { get; set; }
    }
}
