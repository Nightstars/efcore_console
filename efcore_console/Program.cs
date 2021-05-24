using efcore_console.DBContext;
using efcore_console.Entity;
using efcore_console.Service;
using System;
using System.Linq;

namespace efcore_console
{
    class Program
    {
        static void Main(string[] args)
        {
            //var DbContext = new MyDbContext();
            //var list = DbContext.Set<TestTable>().ToList();
            var testTableService = new TestTableService(new MyDbContext());
            //query
            testTableService.GetAll();
            Console.WriteLine();

            //insert
            testTableService.Insert(new TestTable
            {
                Id = 6,
                Name = "Black"
            });
            Console.WriteLine();
            testTableService.GetAll();
            Console.WriteLine();

            //update
            testTableService.update(new TestTable
            {
                Id = 3,
                Name = "Alice"
            });
            Console.WriteLine();
            testTableService.GetAll();
            Console.WriteLine();

            //delete
            //testTableService.Delete(new TestTable { 
            //    Id=1
            //});
            //Console.WriteLine();
            //testTableService.GetAll();
            //Console.WriteLine();

            Console.ReadKey();
        }
    }
}
