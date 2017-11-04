using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2.Tests
{
    [TestClass()]
    public class TodoRepositoryTests
    {

        [TestMethod()]
        public void AddTest()
        {
            TodoRepository repository = new TodoRepository();

            TodoItem first = new TodoItem("Faks");
            Assert.AreEqual(repository.Add(first), first);
           
        }

        [TestMethod()]
        public void GetTest()
        {
            TodoRepository repository = new TodoRepository();

            TodoItem first = new TodoItem("Faks");
            TodoItem second = new TodoItem("Skola");
            TodoItem third = new TodoItem("Vrtic");

            repository.Add(first);
            repository.Add(second);
            repository.Add(third);

            Assert.AreEqual(repository.Get(second.Id), second);
        }

        [TestMethod()]
        public void GetActiveTest()
        {
            TodoRepository repository = new TodoRepository();

            TodoItem first = new TodoItem("Faks");
            TodoItem second = new TodoItem("Skola");
            TodoItem third = new TodoItem("Vrtic");

            first.MarkAsCompleted();

            repository.Add(first);
            repository.Add(second);
            repository.Add(third);

            Assert.IsTrue(repository.GetActive().Contains(second));
        }

        [TestMethod()]
        public void GetAllTest()
        {
            TodoRepository repository = new TodoRepository();

            TodoItem first = new TodoItem("Faks");
            TodoItem second = new TodoItem("Skola");
            TodoItem third = new TodoItem("Vrtic");
            
            repository.Add(first);
            repository.Add(second);
            repository.Add(third);

            CollectionAssert.AreEqual(repository.GetAll().ToArray(), new TodoItem[] {first, second, third});
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            TodoRepository repository = new TodoRepository();

            TodoItem first = new TodoItem("Faks");
            TodoItem second = new TodoItem("Skola");
            TodoItem third = new TodoItem("Vrtic");

            first.MarkAsCompleted();
            third.MarkAsCompleted();

            repository.Add(first);
            repository.Add(second);
            repository.Add(third);

            CollectionAssert.AreEqual(repository.GetCompleted().ToArray(), new TodoItem[] { first, third });
        }

        [TestMethod()]
        public void GetFilteredTest()
        {
            TodoRepository repository = new TodoRepository();

            TodoItem first = new TodoItem("Faks");
            TodoItem second = new TodoItem("Skola");
            TodoItem third = new TodoItem("Vrtic");

            repository.Add(first);
            repository.Add(second);
            repository.Add(third);

            List<TodoItem> novi = repository.GetFiltered(i => i.Text == "Faks");

  

            Assert.AreEqual(repository.GetFiltered(i => i.Text == "Faks").ToArray()[0], first);
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            TodoRepository repository = new TodoRepository();

            TodoItem first = new TodoItem("Faks");
            TodoItem second = new TodoItem("Skola");
            TodoItem third = new TodoItem("Vrtic");

            first.MarkAsCompleted();

            Assert.IsNull(second.DateCompleted);
            Assert.IsTrue(third.MarkAsCompleted());
        }

        [TestMethod()]
        public void RemoveTest()
        {
            TodoRepository repository = new TodoRepository();

            TodoItem first = new TodoItem("Faks");
            TodoItem second = new TodoItem("Skola");
            TodoItem third = new TodoItem("Vrtic");

            repository.Add(first);
            repository.Add(second);
            repository.Add(third);

            Assert.IsTrue(repository.Remove(first.Id));
            Assert.IsFalse(repository.Remove(first.Id));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            TodoRepository repository = new TodoRepository();

            TodoItem first = new TodoItem("Faks");
            TodoItem second = new TodoItem("Skola");
            TodoItem third = new TodoItem("Vrtic");

            repository.Add(first);
            repository.Add(second);
            repository.Add(third);

            Assert.IsNull(first.DateCompleted);
            Assert.IsTrue(first.MarkAsCompleted());
            Assert.IsNotNull(first.DateCompleted);

            Assert.AreEqual(first.DateCompleted, repository.Get(first.Id).DateCompleted);

            Assert.AreEqual(repository.Update(first), first);
                        
        }
    }
}