using System;

namespace NewsBlog.DTO.News
{
    public class UpdateNewsDTO
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public int? KateoriId { get; set; }
        public int? ImageId { get; set; }
        public int? NewsTypeId { get; set; }
        public DateTime? NewsTime { get; set; }
        public string UserId { get; set; }
    }
}
