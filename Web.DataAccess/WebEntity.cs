namespace Web.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebEntity : DbContext
    {
        public WebEntity()
            : base("name=WebEntity")
        {
        }

        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<BannerPosition> BannerPositions { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryPost> CategoryPosts { get; set; }
        public virtual DbSet<CMSNavigation> CMSNavigations { get; set; }
        public virtual DbSet<CMSNavigationPrivilegeMapping> CMSNavigationPrivilegeMappings { get; set; }
        public virtual DbSet<CMSPrivilege> CMSPrivileges { get; set; }
        public virtual DbSet<CMSRole> CMSRoles { get; set; }
        public virtual DbSet<CMSRoleNavigationPrivilegeMapping> CMSRoleNavigationPrivilegeMappings { get; set; }
        public virtual DbSet<CMSUser> CMSUsers { get; set; }
        public virtual DbSet<ContentType> ContentTypes { get; set; }
        public virtual DbSet<Navigation> Navigations { get; set; }
        public virtual DbSet<NavigationContentMapping> NavigationContentMappings { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostWidget> PostWidgets { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.CategoryPosts)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CMSNavigation>()
                .HasMany(e => e.CMSNavigation1)
                .WithOptional(e => e.CMSNavigation2)
                .HasForeignKey(e => e.ParentID);

            modelBuilder.Entity<CMSNavigation>()
                .HasMany(e => e.CMSNavigationPrivilegeMappings)
                .WithRequired(e => e.CMSNavigation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CMSNavigationPrivilegeMapping>()
                .HasMany(e => e.CMSRoleNavigationPrivilegeMappings)
                .WithRequired(e => e.CMSNavigationPrivilegeMapping)
                .HasForeignKey(e => e.CMSNavigationPrivilegeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CMSPrivilege>()
                .HasMany(e => e.CMSNavigationPrivilegeMappings)
                .WithRequired(e => e.CMSPrivilege)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CMSRole>()
                .HasMany(e => e.CMSRoleNavigationPrivilegeMappings)
                .WithRequired(e => e.CMSRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CMSRole>()
                .HasMany(e => e.CMSUsers)
                .WithRequired(e => e.CMSRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContentType>()
                .HasMany(e => e.NavigationContentMappings)
                .WithRequired(e => e.ContentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Navigation>()
                .HasMany(e => e.NavigationContentMappings)
                .WithRequired(e => e.Navigation)
                .HasForeignKey(e => e.NavID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostWidgets)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);
        }
    }
}
