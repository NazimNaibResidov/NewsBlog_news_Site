using System;

namespace NewsBlog.DTO.News
{
    public class ListNewsDTO:BaseDTO
    {
        public string Header { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string KateoriName { get; set; }
        public string imagePath { get; set; }
        public string NewsType { get; set; }
        public DateTime? NewsTime { get; set; }
        public string UserName { get; set; }
    }
}
