﻿using System.Data.SqlClient;
using DotNetTrainingBatch4.ConsoleApp;

Console.WriteLine("Hello world this is 7th time");


AdoDotNetExample dotNetExample = new AdoDotNetExample();
/*dotNetExample.Read();*/
//dotNetExample.Create("7th times", "Nyi Nyi", "Nm@gmail.com");
//dotNetExample.Update(2, "testTitle", "Nyi Nyi", "n@gmail.com");
//dotNetExample.Delete(2);
//dotNetExample.Edit(2);



//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

EfCoreExample ef = new EfCoreExample();
ef.Run();

Console.ReadKey();