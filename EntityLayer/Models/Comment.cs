using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string ?CommentTitle { get; set; }
        public string ?CommentText { get; set; }

        public int Point { get; set; }

        public int UserId { get; set; }

        public AppUser User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        

      
    }
}
