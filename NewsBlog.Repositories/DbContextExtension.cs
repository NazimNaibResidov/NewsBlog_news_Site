using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NewsBlog.Repositories
{
    public static class DbContextExtension
    {
        public static void DetachAllEntries(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries().ToList())
            {
                context.Entry(entry.Entity).State = EntityState.Detached;
            }
        }
    }
}