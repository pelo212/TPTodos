using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TPTodos.Mappers;
using TPTodos.Models;
using TPTodos.Services;
using TPTodos.ViewModels;

namespace TPTodos.Controllers
{
    public class TodoController : Controller
    {
        ISessionManagerService session;
        public TodoController(ISessionManagerService session)
        {
            this.session = session;
        }
        public IActionResult Index()
        {
            List<Todo> liste = session.get<List<Todo>>("todos", HttpContext);
            ViewBag.Todos = liste;
            ViewBag.count = liste.Count;
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
                
                List<Todo> liste;
                if (HttpContext.Session.GetString("todos") == null)
                {
                    liste = new List<Todo>();
                }
                else
                {
                    liste = session.get<List<Todo>>("todos", HttpContext);
                }
                // Correction : appel de la méthode statique via le nom de la classe
                Todo todo = TodoMapper.GetTodoFromTodoVM(vm);

                
                liste.Add(todo);
                
                session.add("todos",liste, HttpContext);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int index)
        {
            List<Todo> liste = session.get<List<Todo>>("todos", HttpContext);
            if (index < 0 || index >= liste.Count)
            {
                return RedirectToAction("Index");
            }

            // Récupérer la tâche à l'index donné
            Todo todo = liste[index];

            // Convertir le Todo en TodoAddVM pour l'édition
            TodoAddVM vm = TodoMapper.GetTodoVMFromTodo(todo);

            // Passer l'index à la vue par ViewBag pour le conserver
            ViewBag.Index = index;

            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(int index, TodoAddVM vm)
        {
            if (ModelState.IsValid)
            {
                List<Todo> liste = session.get<List<Todo>>("todos", HttpContext);

                if (index >= 0 && index < liste.Count)
                {
                    Todo todoModifie = TodoMapper.GetTodoFromTodoVM(vm);
                    liste[index] = todoModifie;
                    session.add("todos", liste, HttpContext);
                }

                return RedirectToAction("Index");
            }

            ViewBag.Index = index;
            return View(vm);
        }
        public IActionResult Delete(int index)
        {
            List<Todo> liste = session.get<List<Todo>>("todos", HttpContext);

            // Vérifier si l'index est valide
            if (index < 0 || index >= liste.Count)
            {
                return RedirectToAction("Index");
            }

            // Passer la tâche et l'index à la vue
            ViewBag.Index = index;
            return View(liste[index]);
        }

        // POST: DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int index)
        {
            List<Todo> liste = session.get<List<Todo>>("todos", HttpContext);

            // Vérifier si l'index est valide
            if (index >= 0 && index < liste.Count)
            {
                // Supprimer la tâche à l'index donné
                liste.RemoveAt(index);

                // Sauvegarder dans la session
                session.add("todos", liste, HttpContext);
            }

            return RedirectToAction("Index");
        }
    }

}
