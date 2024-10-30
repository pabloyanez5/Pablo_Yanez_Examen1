using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pablo_Yanez_Examen1.Models
{
    public class Celular
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Modelo { get; set; }
        [Range(2000,2024)]
        public int Año { get; set; }
        [Range(100,3000)]
        public decimal Precio { get; set; }
        public int PYanezId { get; set; }
        [ForeignKey("PYanezId")]
        public PYanez pYanez { get; set; }

    }
}
