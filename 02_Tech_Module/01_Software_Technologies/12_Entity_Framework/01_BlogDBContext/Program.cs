using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BlogDBContext
{
    class Program
    {
        static void Main()
        {
            var db = new BlogDBContext();

            //TODO CREATE
            //CreateUser(db);
            //CreatePost(db);

            //TODO READ
            //SelectUsers(db);
            //SelectSpecificRow(db);

            //TODO UPDATE
            //var post = db.Posts.OrderByDescending(p => p.Date).First();
            //var tag = new Tags() { Name = "newTag" };
            //AddTagsToExistingPost(db,post, new Tags[] {tag});

            //TODO DELETE
            //var user = db.Users.OrderByDescending(u => u.Id).First();
            //RemoveUser(db, user);
        }

        private static void RemoveUser(BlogDBContext db, Users user)
        {
            foreach (var comment in user.Comments)
            {
                //default id
                comment.AuthorId = 1;
            }
            foreach (var post in user.Posts)
            {
                post.AuthorId = 1;
            }
            db.Users.Remove(user);
            db.SaveChanges();
        }

        private static void AddTagsToExistingPost(BlogDBContext db,Posts post, IEnumerable<Tags> tags)
        {
            foreach (var tag in tags)
            {
                post.Tags.Add(tag);
                tag.Posts.Add(post);
            }
            post.Body += " added new tag";
            db.SaveChanges();
        }

        private static void CreatePost(BlogDBContext db)
        {
            var post = new Posts()
            {
                AuthorId = db.Users.OrderByDescending(u => u.Id).First().Id,
                Body = "new post body new post body new post body new post body new post body ",
                Title = "new post title",
                Date = DateTime.Now
            };
            db.Posts.Add(post);
            db.SaveChanges();
        }

        private static void CreateUser(BlogDBContext db)
        {
            var user = new Users()
            {
                FullName = "New User name",
                PasswordHash = new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0},
                UserName = "NewUserMate"
            };
            db.Users.Add(user);
            db.SaveChanges();
        }

        private static void SelectSpecificRow(BlogDBContext db)
        {
            var shouldBeAdmin = db.Users.Where(u => u.Id == 1).FirstOrDefault();
            Console.WriteLine(shouldBeAdmin.Id + " -> " + shouldBeAdmin.FullName);
        }

        private static void SelectUsers(BlogDBContext db)
        {
            foreach (var user in db.Users)
            {
                Console.WriteLine(user.Id + " " + user.FullName);
            }
        }
    }
}
