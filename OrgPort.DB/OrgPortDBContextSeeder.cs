using OrgPort.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgPort.DB
{
    public partial class OrgPortDBContext : ISeedDatabase
    {
        public void Seed()
        {
            SeedUsers();
            SeedNews();
            //SeedTags();
            this.SaveAllChanges();
        }

        private void SeedUsers()
        {
            SeedUser(name: "user1", password: "user1", email: "user1@orgport.com", phone: "+975997654321", mainRole: UserRole.User);
            SeedUser(name: "user2", password: "user2", email: "user2@orgport.com", phone: "+975997654322", mainRole: UserRole.User);
            SeedUser(name: "admin", password: "adminadmin", email: "admin@orgport.com", phone: "+5555566666666", mainRole: UserRole.Admin);
            SeedUser(name: "teacher", password: "teacher", email: "teacher@orgport.com", phone: "+4444466666666", mainRole: UserRole.Teacher);
        }


        private void SeedNews()
        {
            var users = new List<User>();
            users.Add(SeedUser(name: "userForNews1", password: "user1"));
            users.Add(SeedUser(name: "userForNews2", password: "user2"));
            users.Add(SeedUser(name: "userForNews3", password: "user3"));
            var tags = new List<Tag>();
            tags.Add(SeedTag("sample"));
            tags.Add(SeedTag("news"));

            var news = new List<NewsItem>();
            news.Add(SeedNewsItem(title: "News item 1", users: users, tags: tags, date: DateTime.UtcNow.Subtract(TimeSpan.FromDays(1)), targetDate: DateTime.UtcNow, text: "news item 1 text", subtitle: "news item 1 subtitle", type: NewsItemType.NewsItem));
            news.Add(SeedNewsItem(title: "News item 2", users: users, tags: tags, date: DateTime.UtcNow.Subtract(TimeSpan.FromDays(2)), targetDate: DateTime.UtcNow, text: "news item 2 text", subtitle: "news item 2 subtitle", type: NewsItemType.NewsItem));
            news.Add(SeedNewsItem(title: "News item 3", users: users, tags: tags, date: DateTime.UtcNow.Subtract(TimeSpan.FromDays(3)), targetDate: DateTime.UtcNow, text: "news item 3 text", subtitle: "news item 3 subtitle", type: NewsItemType.NewsItem));

            var users2 = new List<User>();
            users2.Add(SeedUser(name: "userForRewards1", password: "user1"));
            users2.Add(SeedUser(name: "userForRewards2", password: "user2"));
            users2.Add(SeedUser(name: "userForRewards3", password: "user3"));
            news.Add(SeedNewsItem(title: "Event item 1", users: users2, tags: tags, date: DateTime.UtcNow, targetDate: DateTime.UtcNow.AddDays(1), text: "Event item 1 text", subtitle: "Event item 1 subtitle", type: NewsItemType.PublicEvent));
            news.Add(SeedNewsItem(title: "Event item 2", users: users2, tags: tags, date: DateTime.UtcNow, targetDate: DateTime.UtcNow.AddDays(2), text: "Event item 2 text", subtitle: "Event item 2 subtitle", type: NewsItemType.PublicEvent));
            news.Add(SeedNewsItem(title: "Event item 3", users: users2, tags: tags, date: DateTime.UtcNow, targetDate: DateTime.UtcNow.AddDays(3), text: "Event item 3 text", subtitle: "Event item 3 subtitle", type: NewsItemType.PublicEvent));

            users.AddRange(users2);            

            news.Add(SeedNewsItem(title: "Reward item 1", users: users, tags: tags, date: DateTime.UtcNow.Subtract(TimeSpan.FromDays(1)), targetDate: DateTime.UtcNow, text: "Reward item 1 text", subtitle: "Reward item 1 subtitle", type: NewsItemType.Reward));
            news.Add(SeedNewsItem(title: "Reward item 2", users: users, tags: tags, date: DateTime.UtcNow.Subtract(TimeSpan.FromDays(2)), targetDate: DateTime.UtcNow, text: "Reward item 2 text", subtitle: "Reward item 2 subtitle", type: NewsItemType.Reward));
            news.Add(SeedNewsItem(title: "Reward item 3", users: users, tags: tags, date: DateTime.UtcNow.Subtract(TimeSpan.FromDays(3)), targetDate: DateTime.UtcNow, text: "Reward item 3 text", subtitle: "Reward item 3 subtitle", type: NewsItemType.Reward));

            foreach (var newsItem in news)
            {
                foreach (var user in users)
                {
                    SeedComment(user.Id, newsItem.Id, user.UserName + "thinks that" + newsItem.Title + "  is BAD News");
                }
                users.Reverse();
                foreach (var user in users)
                {
                    SeedComment(user.Id, newsItem.Id, user.UserName + "has no comments on this");
                }
            }
        }

        private NewsItem SeedNewsItem(string title, List<User> users, List<Tag> tags, DateTime date, DateTime targetDate, string text = "sample text", string subtitle = "sample subtitle", 
            NewsItemType type = NewsItemType.NewsItem)
        {
            var newsItem = new NewsItem { Date = date != null ? date : DateTime.UtcNow, Title = title, Text = text, SubTitle = subtitle, Users = users, Tags = tags, TargetDate = date != null ? date : DateTime.UtcNow.AddDays(2), Type = type };
            this.NewsItems.Add(newsItem);
            //http://stackoverflow.com/questions/7795300/validation-failed-for-one-or-more-entities-see-entityvalidationerrors-propert
            try
            {
                this.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var error in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        error.Entry.Entity.GetType().Name, error.Entry.State);
                    foreach (var intError in error.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            intError.PropertyName, intError.ErrorMessage);
                    }
                }
            }
            return newsItem;
        }

        private User SeedUser(string name, string password, string email = "common@orgport.com", string phone = "+210987654321", UserRole mainRole = UserRole.User)
        {
            var user = new User { UserName = name, Email = email, Phone = phone, RegistrationDate = DateTime.UtcNow, Password = password };
            user.Roles.Add(mainRole);
            this.Users.Add(user);
            return user;
        }

        private Tag SeedTag(string text)
        {
            var tag = new Tag { Text = text };
            this.Tags.Add(tag);
            return tag;
        }

        private void SeedComment(int userId, int newsItemId, string text = "comment sample text")
        {
            var comment = new Comment { UserId = userId, NewsId = newsItemId, Text = text, Date = DateTime.UtcNow };
            this.Comments.Add(comment);
        }
    }
}
