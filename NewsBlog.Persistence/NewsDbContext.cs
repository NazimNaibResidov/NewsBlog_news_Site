using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NewsBlog.Base.BaseAuditable;
using NewsBlog.Entities.CategoryEntity;
using NewsBlog.Entities.CommetEntity;
using NewsBlog.Entities.ImageEntity;
using NewsBlog.Entities.NewEntity;
using NewsBlog.Entities.NewsTagEntity;
using NewsBlog.Entities.NewsTypeEntity;
using NewsBlog.Entities.TagEntity;
using NewsBlog.Entities.TagNewsEntity;
using NewsBlog.Entities.UserEntity;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NewsBlog.Persistence
{
    public class NewsDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        #region .:: Save Setup ::.

        //private readonly ICurrentUserService _currentUserService;
        //private readonly IDateTime _dateTime;
        private readonly DbContextOptions _options;

        #endregion .:: Save Setup ::.

        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //string[] rolesArray = { "managers", "executives" };
            //Thread.CurrentPrincipal =
            //    new GenericPrincipal(new GenericIdentity(
            //    "Shamistan", "12345"), rolesArray);
            //var modifiedEntries = ChangeTracker.Entries()
            //    .Where(x => x.Entity is IAuditableEntity
            //        && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = Guid.NewGuid().ToString();
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = Guid.NewGuid().ToString();
                        entry.Entity.UpdatedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //ChangeDeleteBehaviorToRestrict(builder);

            base.OnModelCreating(builder);

            //builder.Seed();
        }

        private void ChangeDeleteBehaviorToRestrict(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                         .SelectMany(t => t.GetForeignKeys())
                         .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsTag> NewsTags { get; set; }
        public DbSet<NewsType> NewsTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagNews> TagNews { get; set; }
    }
}