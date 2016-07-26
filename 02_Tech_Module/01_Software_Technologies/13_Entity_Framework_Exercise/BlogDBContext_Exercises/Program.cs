using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDBContext_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new BlogDBContext();
            //TODO READ
            //PrintPosts(db);
            //PrintUsers(db);
            //PrintSelectedColumnsFromPosts(db);
            //PrintSelectedColumnsFromOrderedUsers(db);
            //PrintUsersOrderedBy2Columns(db);
            //PrintUsersWithAtleast1Post(db);
            //PrintUsersWithCorrespondingPostTitles(db);
            //PrintAuthorOfCertainPost(db);
            //PrintUsersSortedByID(db);

            //TODO CREATE
            //AddPostToDB(db);

            //TODO UPDATE
            //UpdateDataFromDB(db);

            //TODO REMOVE
            //DeletePostFromDB(db);
        }

        private static void DeletePostFromDB(BlogDBContext db)
        {
            var post = db.Posts.FirstOrDefault(p => p.Comments.Count > 0);
            var comment = post.Comments.FirstOrDefault();
            comment.Users.Comments.Remove(comment);
            post.Comments.Remove(comment);
            db.SaveChanges();
        }

        private static void UpdateDataFromDB(BlogDBContext db)
        {
            var user = db.Users.Find(2);
            user.FullName = "updated";
            db.SaveChanges();
        }

        private static void AddPostToDB(BlogDBContext db)
        {
            Posts post = new Posts()
            {
                AuthorId = 2,
                Title = "title",
                Body = "body",
                Date = DateTime.Now
            };
            db.Posts.Add(post);
            db.Users.Find(2).Posts.Add(post);
            db.SaveChanges();
        }

        private static void PrintUsersSortedByID(BlogDBContext db)
        {
            var users = db.Users.Where(u => u.Posts.Count > 0).OrderBy(u => u.Id).ThenBy(u => u.Posts.Count);
            foreach (var user in users)
            {
                Console.WriteLine(user.UserName);
                Console.WriteLine(user.FullName);
            }
        }

        private static void PrintAuthorOfCertainPost(BlogDBContext db)
        {
            var post = db.Posts.Find(4);
            if (post != null)
            {
                Console.WriteLine(post.Users.FullName);
                Console.WriteLine(post.Title);
            }
        }

        private static void PrintUsersWithCorrespondingPostTitles(BlogDBContext db)
        {
            var usersWithPostTitles = db.Users.SelectMany(u => u.Posts, (u, p) => new {u.UserName, p.Title});
            foreach (var user in usersWithPostTitles)
            {
                Console.WriteLine("Username: " + user.UserName);
                Console.WriteLine("postTitle name: " + user.Title);
            }
        }

        private static void PrintUsersWithAtleast1Post(BlogDBContext db)
        {
            var usersWithPosts = db.Users.Where(u => u.Posts.Count > 0);
            foreach (var user in usersWithPosts)
            {
                Console.WriteLine("Username: " + user.UserName);
                Console.WriteLine("Full name: " + user.FullName);
                Console.WriteLine("Posts count: " + user.Posts.Count);
            }
        }

        private static void PrintUsersOrderedBy2Columns(BlogDBContext db)
        {
            var users = db.Users.OrderBy(u => u.UserName).ThenBy(u => u.FullName);
            foreach (var user in users)
            {
                Console.WriteLine("Username: " + user.UserName);
                Console.WriteLine("Full name: " + user.FullName);
            }
        }

        private static void PrintSelectedColumnsFromOrderedUsers(BlogDBContext db)
        {
            var users = db.Users.OrderBy(u => u.UserName);
            foreach (var user in users)
            {
                Console.WriteLine("Username: " + user.UserName);
                Console.WriteLine("Full name: " + user.FullName);
            }
        }

        private static void PrintSelectedColumnsFromPosts(BlogDBContext db)
        {
            var posts = db.Posts.Select(p => new
            {
                p.Title,
                p.Body
            });
            foreach (var post in posts)
            {
                Console.WriteLine(post.Title);
                Console.WriteLine(post.Body);
                Console.WriteLine();
            }
        }

        private static void PrintUsers(BlogDBContext db)
        {
            var users = db.Users.ToList();
            foreach (var user in users)
            {
                Console.WriteLine("name: {0}", user.FullName);
                Console.WriteLine("ID: {0}", user.Id);
                Console.WriteLine("comments count: {0}", user.Comments.Count);
                Console.WriteLine("posts count: {0}", user.Posts.Count);
                Console.WriteLine();
            }
        }

        private static void PrintPosts(BlogDBContext db)
        {
            var posts = db.Posts.ToList();
            foreach (var post in posts)
            {
                Console.WriteLine("title: {0}", post.Title);
                Console.WriteLine("authorID: {0}", post.AuthorId);
                Console.WriteLine("body: {0}", post.Body);
                Console.WriteLine("comments count: {0}", post.Comments.Count);
                Console.WriteLine("tags count: {0}", post.Tags.Count);
                Console.WriteLine();
            }
        }
    }
}
