using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBlog.DTO.NewsTag
{
   public class NewsTagDTO:BaseDTO
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int TagId { get; set; }

       
    }
   
}
