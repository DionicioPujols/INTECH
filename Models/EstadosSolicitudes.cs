using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INTECH.Models;

public class EstadosSolicitudes
{
    [Key]
    public int EstadoSolicitudId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [StringLength(50)]
    public string Nombre { get; set; } = string.Empty;

    [InverseProperty("EstadoSolicitud")]
    public virtual ICollection<Solicitudes> Solicitudes { get; set; } = new List<Solicitudes>();
}
