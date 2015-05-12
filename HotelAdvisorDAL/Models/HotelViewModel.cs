using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HotelAdvisorDAL.Models
{
    public class HotelViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Display(Name = "House number")]
        public int HouseNumber { get; set; }

        public string City { get; set; }

        public HttpPostedFileBase Image { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
