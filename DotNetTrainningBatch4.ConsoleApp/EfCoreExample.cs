using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch4.ConsoleApp
{
    internal class EfCoreExample
    {
        private readonly AppDbContex db = new AppDbContex();
        public void Run()
        {
            // Read();
            // Edit(6);
            // Create("BB", "BB", "b@gmail.com");
            // Update(6, "CC", "CC", "CC");
            Delete(6);
        }

        private void Read()
        {

            var lst = db.Blogs.ToList();

            foreach (var item in lst)
            {
                Console.WriteLine("Blog Id => " + item.BlogId);
                Console.WriteLine("Blog Title => " + item.BlogTitle);
                Console.WriteLine("Blog Author => " + item.BlogAuthor);
                Console.WriteLine("Blog Content => " + item.BlogContent);
                Console.WriteLine("_____________===___________===_____");
            }
        }

        private void Edit(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            Console.WriteLine("Blog Id => " + item.BlogId);
            Console.WriteLine("Blog Title => " + item.BlogTitle);
            Console.WriteLine("Blog Author => " + item.BlogAuthor);
            Console.WriteLine("Blog Content => " + item.BlogContent);
            Console.WriteLine("_____________===___________===_____");
        }

        private void Create (string title, string author, string content)
        {
            var item = new BlogDot
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            db.Blogs.Add(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Saving successful" : "Saving fail";
            Console.WriteLine(message);
        }

        private void Update(int id, string title, string author, string content)
        {
            var item = db.Blogs.FirstOrDefault (x => x.BlogId == id);

            if(item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            item.BlogId = id;
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
            int result = db.SaveChanges();
            string message = result > 0 ? "Updating successful" : "Updating fail";
            Console.WriteLine(message);
        }

        private void Delete (int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId==id);

            if(item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            db.Remove(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Deleting successful" : "Deleting fail";
            Console.WriteLine(message);
        }
    }
}
