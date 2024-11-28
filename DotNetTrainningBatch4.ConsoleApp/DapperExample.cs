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
            //Edit(2);
            //Edit(3);
            //Create("Dapper", "Nyi Nyi", "n@gmail.com");
            //Update(3,"Good","Nyi","v@gmail.com");
            Delete(3);
        }

        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            List<BlogDot> lst = db.Query<BlogDot>("SELECT * FROM Tbl_Blog").ToList();

            foreach (BlogDot item in lst)
            {
                Console.WriteLine("Blog Id => " + item.BlogId);
                Console.WriteLine("Blog Title => " + item.BlogTitle);
                Console.WriteLine("BLog Author => " + item.BlogAuthor);
                Console.WriteLine("Blog Content => " + item.BlogContent);
                Console.WriteLine("_________________________________________");
            }
        }

        private void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogDot>("SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId ",new BlogDot {BlogId = id}).FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("No Data Found");
                Console.WriteLine("____________________");
                return;
            }

            Console.WriteLine("Blog Id => " + item.BlogId);
            Console.WriteLine("Blog Title => " + item.BlogTitle);
            Console.WriteLine("BLog Author => " + item.BlogAuthor);
            Console.WriteLine("Blog Content => " + item.BlogContent);
            Console.WriteLine("_________________________________________");
        }

        private void Create (string title,string author,string content)
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

           using IDbConnection db = new  SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
          int result =  db.Execute(query,item);

            string message = result > 0 ? "Saving successful" : "Saving Fail";
            Console.WriteLine(message);
        }

        private void Update(int id,string title, string author, string content)
        {
            var item = new BlogDot
            {
                BlogId = id,
                BlogTitle= title,
                BlogAuthor = author,    
                BlogContent = content
            };

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId;";

            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string message = result > 0 ? "Updating successful " : "Updating fail";
            Console.WriteLine (message);    
        }


        private void Delete(int id)
        {
            var item = new BlogDot
            {
                BlogId= id
            };

            string query = @"
DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId;";
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string message = result > 0 ? "Deleting successful" : "Deleting fail";
           Console.WriteLine (message);
        }
       
    }
}
