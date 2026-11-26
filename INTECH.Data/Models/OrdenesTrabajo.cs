using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INTECH.Models;

public class OrdenesTrabajo
{
    [Key]
    public int OrdenTrabajoId { get; set; }

    public bool IsDeleted { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una solicitud")]
    public int SolicitudId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public string Tareas { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public string Materiales { get; set; } = string.Empty;

    public string InstruccionesCampo { get; set; } = string.Empty;
}