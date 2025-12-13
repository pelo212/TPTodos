using System.Text.Json;
using TPTodos.Models;

namespace TPTodos.Services
{
    public class SessionManagementService : ISessionManagerService
    {
        public void add(string key,Object obj, HttpContext context)
        {
            string chaine = JsonSerializer.Serialize(obj);
            context.Session.SetString(key, chaine);
        }
        public T get<T>(string key, HttpContext context){
            return JsonSerializer.Deserialize<T>(context.Session.GetString(key)??"[]");
        }
    }
}
