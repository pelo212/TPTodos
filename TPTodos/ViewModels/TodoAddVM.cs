using System.ComponentModel.DataAnnotations;
using TPTodos.Enums;

namespace TPTodos.ViewModels
{
    public class TodoAddVM
    {
        [Required]
        public string Libelle { get; set; }
        [Required]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateLimite { get; set; }
        [Required]
        public State Statut { get; set; }  
    }
}
