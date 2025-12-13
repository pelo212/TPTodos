using TPTodos.Models;

namespace TPTodos.Services
{
    public interface ISessionManagerService
    {
        public void add(string key,Object obj, HttpContext context);
        public T get<T>(string key, HttpContext context);
    }
}
