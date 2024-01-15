using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer
{
 
        public class CommentDto
        {
            public int? Id { get; set; }
            public string? CommentTitle { get; set; }
            public string? CommentText { get; set; }

            public int Point { get; set; }

            public int ?UserId { get; set; }
            public int ?ProductId { get; set; }





        }
    
}
