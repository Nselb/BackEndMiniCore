using System.ComponentModel.DataAnnotations;

namespace MiniCore.Models
{
    public class PersonasPase
    {
        [Key]
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public int IdPase { get; set; }
        public DateTime FechaCompra { get; set; }
        public int NumeroPases { get; set; }
    }
}
