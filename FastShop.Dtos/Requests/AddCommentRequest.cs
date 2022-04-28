using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastShop.Dtos.Requests
{
    public class AddCommentRequest
    {
        public int CommentID { get; set; }
        [Required(ErrorMessage ="Lütfen İsminizi Giriniz.")]
        public string CommentUserName { get; set; }
        [Required(ErrorMessage = "Lütfen Konu Başlığını Giriniz.")]
        public string CommentTitle { get; set; }
        [Required(ErrorMessage = "Lütfen İçerik Giriniz.")]
        [MinLength(5)]
        [MaxLength(150)]
        public string CommentContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool CommentStatus { get; set; }
        public int ProductId { get; set; }
       
    }
}
