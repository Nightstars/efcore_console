using efcore_console.DBContext;
using efcore_console.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efcore_console.Service
{
    class TestTableService
    {
        #region TestTableService
        private MyDbContext _myDbContext { get; set; }
        public TestTableService(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        #endregion

        #region Insert
        public async void Insert(TestTable testTable)
        {
            if (_myDbContext.TestTables.Any(p => p.Id == testTable.Id))
                return;
            await _myDbContext.TestTables.AddAsync(testTable);
            _myDbContext.SaveChanges();
            Console.WriteLine("inserted successfully");
        }
        #endregion

        #region GetAll
        public void GetAll()
        {
            var list=_myDbContext.TestTables.ToList();
            Console.WriteLine($"TestTable count: {list.Count()}");
            if (!list.Any())
                return;
            Console.WriteLine("TestTable details: ");
            foreach (var item in list)
            {
                Console.WriteLine($"Id: {item.Id}   Name: {item.Name}");
            }
        }
        #endregion

        #region Update
        public void update(TestTable testTable)
        {
            var list = _myDbContext.TestTables.AsTracking().ToList();
            var firstEntity = list.FirstOrDefault(x => x.Id == testTable.Id);
            if (firstEntity != null)
                firstEntity.Name = testTable.Name;
            _myDbContext.SaveChanges();
            Console.WriteLine("update successfully");
        }
        #endregion

        #region Delete
        public void Delete(TestTable testTable)
        {
            var list = _myDbContext.TestTables.AsNoTracking().ToList();
            var firstEntity = list.FirstOrDefault(x => x.Id == testTable.Id);
            if (firstEntity != null)
                _myDbContext.TestTables.Remove(testTable);
            _myDbContext.SaveChanges();
            Console.WriteLine("delete successfully");
        }
        #endregion

        #region InsertHL
        public async void InsertHL(TestTable testTable)
        {
            if (_myDbContext.TestTables.Any(x => x.Id == testTable.Id))
                return;
            await _myDbContext.TestTables.AddAsync(testTable);
            _myDbContext.SaveChanges();
            Console.WriteLine("insertHL successfully!");
        }
        #endregion

        #region GetByPk
        public void GetByPk(int id)
        {
            var query = _myDbContext.TestTables.FirstOrDefault(x => x.Id == id);
            if (query != null)
            {
                Console.WriteLine($"id: {query.Id}  name: {query.Id}");
                Console.WriteLine();
                var list = query.testTableDetails.ToList();
                if (list.Any())
                    list.ForEach(x => { Console.WriteLine($"id: {x.Id}   pid: {x.PID}    name: {x.Name}"); });
            }
                
        }
        #endregion

        #region GetBySql
        public void GetBySql(string sql)
        {
            var data = _myDbContext.testCus.FromSqlRaw(sql,8).ToList();
            if (data.Any())
                data.ForEach(x => Console.WriteLine($"pid: {x.name} name: {x.name}"));
        }
        #endregion
    }
}
