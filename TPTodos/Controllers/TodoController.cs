using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TPTodos.Filter;
using TPTodos.Mappers;
using TPTodos.Models;
using TPTodos.Services;
using TPTodos.ViewModels;

namespace TPTodos.Controllers
{
    [AuthFilter]
    [ThemeFilter]
    public class TodoController : Controller
    {
        ISessionManagerService session;
        public TodoController(ISessionManagerService session)
        {
            this.session = session;
        }
        
        public IActionResult Index()
        {
            List<Todo> Todos = session.get<List<Todo>>("todos", HttpContext);
            ViewBag.Todos = Todos;
            ViewBag.count = Todos.Count;
            return View();
        }


        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(TodoAddVM vm)
        {
            if (ModelState.IsValid)
            {
                
                List<Todo> Todos;
                if (HttpContext.Session.GetString("todos") == null)
                {
                    Todos = new List<Todo>();
                }
                else
                {
                    Todos = session.get<List<Todo>>("todos", HttpContext);
                }
                Todo todo = TodoMapper.GetTodoFromTodoVM(vm);


                Todos.Add(todo);
                
                session.add("todos", Todos, HttpContext);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int index)
        {
            List<Todo> Todos = session.get<List<Todo>>("todos", HttpContext);
            if (index < 0 || index >= Todos.Count)
            {
                return RedirectToAction("Index");
            }
            Todo todo = Todos[index];
            TodoAddVM vm = TodoMapper.GetTodoVMFromTodo(todo);
            ViewBag.Index = index;

            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(int index, TodoAddVM vm)
        {
            if (ModelState.IsValid)
            {
                List<Todo> Todos = session.get<List<Todo>>("todos", HttpContext);
                if (index >= 0 && index < Todos.Count)
                {
                    Todo todoModifie = TodoMapper.GetTodoFromTodoVM(vm);
                    Todos[index] = todoModifie;
                    session.add("todos", Todos, HttpContext);
                }
                return RedirectToAction("Index");
            }
            ViewBag.Index = index;
            return View(vm);
        }
        public IActionResult Delete(int index)
        {
            List<Todo> Todos = session.get<List<Todo>>("todos", HttpContext);
            if (index < 0 || index >= Todos.Count)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Index = index;
            return View(Todos[index]);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int index)
        {
            List<Todo> Todos = session.get<List<Todo>>("todos", HttpContext);
            if (index >= 0 && index < Todos.Count)
            {
                Todos.RemoveAt(index);

                session.add("todos", Todos, HttpContext);
            }

            return RedirectToAction("Index");
        }
    }

}
