using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DotNetTrainingBatch4.ConsoleApp
{
    internal class DapperExample
    {
        public void Run()
        {
            //Read();
            //Edit(4);
            //Edit(2);
            //Create("C#", "Nyi Nyi", "c@gmail.com");
            //Update(4, "Book", "Nyi Nyi", "N@gmail.com");
            Delete(5);
        }

        public void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionStringBuilder.ConnectionString);
            List<BlogDot> blog = db.Query<BlogDot>("SELECT * FROM Tbl_Blog").ToList();

            foreach (BlogDot item in blog)
            {
                Console.WriteLine("Blog Id => " + item.BlogId);
                Console.WriteLine("Blog Title => " + item.BlogTitle);
                Console.WriteLine("Blog Author => " + item.BlogAuthor);
                Console.WriteLine("Blog Content => " + item.BlogContent);
                Console.WriteLine("__________________________________________");
            }
        }

        public void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionStringBuilder.ConnectionString);
            var item = db.Query("SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId", new BlogDot { BlogId = id }).FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("No Data Found");
                Console.WriteLine("_________________");
                return;
            }

            Console.WriteLine("Blog Id => " + item.BlogId);
            Console.WriteLine("Blog Title => " + item.BlogTitle);
            Console.WriteLine("Blog Author => " + item.BlogAuthor);
            Console.WriteLine("Blog Content => " + item.BlogContent);
            Console.WriteLine("__________________________________________");
        }

        public void Create(string title, string author, string content)
        {

            var item = new BlogDot
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionStringBuilder.ConnectionString);
            int i = db.Execute(query, item);
            string messsage = i > 0 ? "Saving Successful" : "Saving Fail";
            Console.WriteLine(messsage);
        }

        public void Update(int id, string title, string author, string content)
        {
            var item = new BlogDot
            {
                BlogId = id
                , BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"
UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId =@BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionStringBuilder.ConnectionString);
          int i =   db.Execute(query, item);
            string message = i > 0 ? "Updating Successful" : "Updating Fail";
            Console.WriteLine(message); 
            
        }

        public void Delete(int id)
        {
            var item = new BlogDot { BlogId = id };

            string query = "DELETE FROM Tbl_Blog WHERE BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionStringBuilder.ConnectionString);
           int i =  db.Execute(query,item);
            string message = i > 0 ? "Deleting Successful" : "Deleting Fail";
            Console.WriteLine(message); 
        }
    }
}
