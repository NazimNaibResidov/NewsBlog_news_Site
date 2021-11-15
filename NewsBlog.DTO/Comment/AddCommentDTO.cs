using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBlog.DTO.Comment
{
    public class AddCommentDTO
    {
        public string Header { get; set; }
        public string Ip { get; set; }
        public string Mail { get; set; }
        public string NameSurname { get; set; }
        public string Content { get; set; }
        public bool? IsActive { get; set; }
        public int? Likes { get; set; }
        public int? Tiksinti { get; set; }
        public int? NewsId { get; set; }
        public DateTime? AddedTime { get; set; }
    }
}
