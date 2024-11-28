using System.Data.SqlClient;
using DotNetTrainingBatch4.ConsoleApp;

Console.WriteLine("Hello world this is 7th time");


AdoDotNetExample dotNetExample = new AdoDotNetExample();
/*dotNetExample.Read();*/
//dotNetExample.Create("7th times", "Nyi Nyi", "Nm@gmail.com");
//dotNetExample.Update(2, "testTitle", "Nyi Nyi", "n@gmail.com");
//dotNetExample.Delete(2);
dotNetExample.Edit(1);
Console.ReadKey();