using System.ComponentModel.DataAnnotations;

namespace MiniCore.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
