using System.ComponentModel.DataAnnotations;

namespace Pablo_Yanez_Examen1.Models
{
    public class PYanez
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Range(18, 100)]
        public int Edad { get; set; }
        [Range(460, 100000)]
        public decimal Sueldo { get; set; }
        [Required]
        public bool Estado { get; set; }
        [DataType(DataType.Date)]
        public DateTime Registro { get; set; }
        public Celular? celular { get; set; }

    }
}
