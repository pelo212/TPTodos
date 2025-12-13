using TPTodos.Models;
using TPTodos.ViewModels;

namespace TPTodos.Mappers
{
    public class TodoMapper
    {
        public static Todo GetTodoFromTodoVM(TodoAddVM vm)
        {
            Todo todo = new Todo();
            todo.Libelle = vm.Libelle;
            todo.Description = vm.Description;
            todo.DateLimite = vm.DateLimite;
            todo.Statut = vm.Statut;
            return todo;
        }
        public static TodoAddVM GetTodoVMFromTodo(Todo todo)
        {
            return new TodoAddVM
            {
                Libelle = todo.Libelle,
                Description = todo.Description,
                DateLimite = todo.DateLimite,
                Statut = todo.Statut
            };
        }
    }
}
