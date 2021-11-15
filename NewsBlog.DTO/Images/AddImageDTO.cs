using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBlog.DTO.Images
{
    public  class AddImageDTO
    {
        public string Name { get; set; }
        public string BigPath { get; set; }
        public string SmallPath { get; set; }
        public string MidlePath { get; set; }
    }
}
