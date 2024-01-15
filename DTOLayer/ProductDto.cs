using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public string? ProductPhotoUrl { get; set; }

        public string ProductTitle { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductDescription { get; set; }


    }
}
