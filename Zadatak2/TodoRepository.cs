using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException(String message)
    : base(message)
        {

        }

    }

    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // x ?? y = > if x is not null , expression returns x. Else it will return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                throw new DuplicateTodoItemException("duplicate id");
            }
            else
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }

        }

        public TodoItem Get(Guid todoId)
        {
            TodoItem[] rez = _inMemoryTodoDatabase.Where(i => i.Id == todoId).ToArray();
            return rez[0];
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(x => x.IsCompleted == false).ToList();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(x => x.DateCreated).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(x => x.IsCompleted != false).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(x => filterFunction(x) != false).ToList();
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem todoItem = Get(todoId);
            if (todoItem == null)
            {
                return false;
            }
            return todoItem.MarkAsCompleted();
        }

        public bool Remove(Guid todoId)
        {
            var rez = _inMemoryTodoDatabase.Where(i => i.Id == todoId).ToArray();
            if(rez.Length == 0)
            {
                return false;
            }
            return _inMemoryTodoDatabase.Remove(rez[0]);
        }

        public TodoItem Update(TodoItem todoItem)
        {
            Remove(todoItem.Id);
            return Add(todoItem);
        }
    }
}
