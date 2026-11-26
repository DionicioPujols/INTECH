using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INTECH.Models;

public class Historiales
{
    [Key]
    public int HistorialId { get; set; }

    public bool IsDeleted { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una solicitud")]
    public int SolicitudId { get; set; }

    public string? TecnicoId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public DateTime FechaFinalizacion { get; set; } = DateTime.Today;

    [ForeignKey("SolicitudId")]
    [InverseProperty("Historiales")]
    public virtual Solicitudes Solicitud { get; set; } = null!;

    [InverseProperty("Historial")]
    public virtual ICollection<HistorialesDetalle> HistorialesDetalle { get; set; } = new List<HistorialesDetalle>();
}
