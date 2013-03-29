using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OrgPort.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrgPort.DB
{
    public partial class OrgPortDBContext : DbContext, IUnitOfWork
    {
        public void SaveAllChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            CreateUsersTable(modelBuilder);
            CreateNewsTable(modelBuilder);
            CreateCommentsTable(modelBuilder);
            CreateQuestionsTable(modelBuilder);
            CreateTagsTable(modelBuilder);
        }

        private static void CreateNewsTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsItem>().HasKey(n => n.Id);
            modelBuilder.Entity<NewsItem>().Property(n => n.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<NewsItem>().Property(n => n.Text).IsRequired();
            modelBuilder.Entity<NewsItem>().Property(n => n.Title).IsRequired();
            modelBuilder.Entity<NewsItem>().Property(n => n.Title).HasMaxLength(Constants.TITLE_MAX_LENGTH);
            modelBuilder.Entity<NewsItem>().Property(n => n.Type).IsRequired();
            modelBuilder.Entity<NewsItem>().HasMany(n => n.Users).WithMany(u => u.NewsItems);
            modelBuilder.Entity<NewsItem>().HasMany(n => n.Tags).WithMany(t=>t.NewsItems);
        }

        private static void CreateUsersTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<User>().Property(u => u.UserName).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.UserName).HasMaxLength(Constants.USERNAME_MAX_LENGTH);
            //modelBuilder.Entity<User>().Property(u => u.AuthorizationId).IsRequired();
            //modelBuilder.Entity<User>().Property(u => u.AuthorizationId).HasMaxLength(Constants.TITLE_MAX_LENGTH);
            modelBuilder.Entity<User>().HasMany(u => u.RelatedUsers).WithMany();
            modelBuilder.Entity<User>().HasMany(u => u.NewsItems).WithMany(n => n.Users);
        }

        private static void CreateCommentsTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasKey(c => c.Id);
            modelBuilder.Entity<Comment>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Comment>().Property(c => c.UserId).IsRequired();
            modelBuilder.Entity<Comment>().Property(c => c.Text).IsRequired();
            modelBuilder.Entity<Comment>().Property(c => c.NewsId).IsRequired();
        }

        private static void CreateTagsTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasKey(t => t.Id);
            modelBuilder.Entity<Tag>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Tag>().Property(t => t.Text).IsRequired();
            modelBuilder.Entity<Tag>().Property(t => t.Text).HasMaxLength(Constants.TAG_MAX_LENGTH);
            modelBuilder.Entity<Tag>().HasMany(u => u.NewsItems).WithMany(n => n.Tags);
        }

        private static void CreateQuestionsTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasKey(q => q.Id);
            modelBuilder.Entity<Question>().Property(q => q.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Question>().Property(q => q.UserId).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.TargetUserId).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.Text).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.Title).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.Title).HasMaxLength(Constants.TITLE_MAX_LENGTH);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<NewsItem> NewsItems { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Question> Questions { get; set; }
    }
}
