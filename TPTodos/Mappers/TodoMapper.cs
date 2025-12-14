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
            TodoAddVM vm = new TodoAddVM();
                vm.Libelle = todo.Libelle;
                vm.Description = todo.Description;
                vm.DateLimite = todo.DateLimite;
                vm.Statut = todo.Statut;
                return vm;
        }
        }
    }
