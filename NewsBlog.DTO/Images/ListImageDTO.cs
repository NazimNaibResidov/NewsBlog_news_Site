namespace NewsBlog.DTO.Images
{
    public class ListImageDTO:BaseDTO
    {
        
        public string Name { get; set; }
        public string BigPath { get; set; }
        public string SmallPath { get; set; }

        public string MidlePath { get; set; }
    }
}
