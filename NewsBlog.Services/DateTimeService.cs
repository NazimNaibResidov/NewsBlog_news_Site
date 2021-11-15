using NewsBlog.Base.BaseDateTime;
using System;

namespace NewsBlog.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}