using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelAdvisorDAL.Models
{
    public class HotelDetailsViewModel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public FileContentResult Image { get; set; }

        [Display(Name="Average rating")]
        public decimal AverageRating { get; set; }

        [Display(Name="Total reviews")]
        public int TotalReviews { get; set; }
        public List<CommentViewModel> Comments { get; set; }

        public string Address { get; set; }

        public int HouseNumber { get; set; }

        public string City { get; set; }

        public string Description { get; set; }
    }
}