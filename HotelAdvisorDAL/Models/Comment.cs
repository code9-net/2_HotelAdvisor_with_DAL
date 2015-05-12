using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelAdvisorDAL.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public int HotelId { get; set; }

        public string UserId { get; set; }

        public string Text { get; set; }

        public string Title { get; set; }

        public decimal Rating { get; set; }

        public DateTime DateAdded { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("HotelId")]
        public virtual Hotel Hotel { get; set; }
    }
}