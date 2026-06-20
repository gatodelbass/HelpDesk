using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "el titulo es requerido")]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "el titulo es requerido")]
        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string Estado { get; set; } = "Abierto";

        public string Prioridad { get; set; } = "Baja";

    }
}
