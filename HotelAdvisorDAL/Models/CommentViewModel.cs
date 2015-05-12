using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAdvisorDAL.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public decimal Rating { get; set; }

        public DateTime DateAdded { get; set; }

        public string UserName { get; set; }

        public string Text { get; set; }

        public string Title { get; set; }
    }
}
