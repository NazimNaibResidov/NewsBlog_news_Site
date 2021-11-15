using Microsoft.AspNetCore.Identity;
using NewsBlog.Entities.NewEntity;
using System;
using System.Collections.Generic;

namespace NewsBlog.Entities.UserEntity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            News = new HashSet<News>();
        }

        public ICollection<News> News { get; set; }
    }
}