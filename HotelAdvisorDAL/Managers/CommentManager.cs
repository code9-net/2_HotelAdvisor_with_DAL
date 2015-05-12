using HotelAdvisorDAL.DataContext;
using HotelAdvisorDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAdvisorDAL.Managers
{
    public class CommentManager
    {
        public void Create(Comment comment)
        {
            using (var dbContext = new HotelAdvisorContext())
            {
                dbContext.Comments.Add(comment);
                dbContext.SaveChanges();
            }

        }
    }
}