using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBlog.DTO.News
{
    public class AddNewsDTO
    {
        public string Header { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public int? KateoriId { get; set; }
        public IFormFile File { get; set; }
        public int? ImageId { get; set; }
        public int? NewsTypeId { get; set; }
        public DateTime? NewsTime { get; set; }
        public string UserId { get; set; }
    }
}
