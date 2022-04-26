using FastShop.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastShop.Entities.Concrete
{
    public class Comment :IEntity
    {
        public int CommentID { get; set; }
        public string CommentUserName { get; set; }
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public int ProductScore { get; set; }
        public bool CommentStatus { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
