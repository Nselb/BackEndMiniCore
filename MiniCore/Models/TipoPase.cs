using System.ComponentModel.DataAnnotations;

namespace MiniCore.Models
{
    public class TipoPase
    {
        [Key]
        public int Id { get; set; }
        public string Tipo { get; set; }
        public Decimal Cupo { get; set; }
        public int Pases { get; set; }
        public Decimal CostoPases { get; set; }
    }
}
