using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string City { get; set; }

        public string Country { get; set; }



        public string? PostalCode { get; set; }
        public string? PostOffice { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        public decimal Total { get; set; }

        public List<OrderProductDto> OrderProducts { get; set; }

    }
}
