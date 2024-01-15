using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }

        public string Country { get; set; }

     

        public string ?PostalCode { get; set; }
        public string ?PostOffice { get; set; }
        public string? PhoneNumber { get; set;}
        public string? Address { get; set; }

        public decimal Total { get; set; }

        public int UserId { get; set; }

        public AppUser User { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
