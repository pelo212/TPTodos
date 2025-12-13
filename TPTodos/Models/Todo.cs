using System.ComponentModel.DataAnnotations;
using TPTodos.Enums;

namespace TPTodos.Models
{
    public class Todo
    {
        public string Libelle { get; set; }

        public string Description { get; set; }

        public DateTime DateLimite { get; set; }
 
        public State Statut { get; set; }
    }
}
