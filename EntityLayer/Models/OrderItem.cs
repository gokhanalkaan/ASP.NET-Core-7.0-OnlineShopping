using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class OrderItem
    {
      

        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public int ProductId { get; set; }
        
        public Product Product { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public OrderItem()
        {
            this.CreatedAt =DateTime.Now ;
        }
    }
}
