using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
    public class Empleado
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Identificacion { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Nombre { get; set; }

        [Range(0, double.MaxValue)]
        public double HorasTrabajadas { get; set; }

        [Range(0, double.MaxValue)]
        public double SueldoPorHora { get; set; }

        public bool IsActive { get; set; }

    }

}
