using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INTECH.Models;

public class Agendas
{
    [Key]
    public int AgendaId { get; set; }

    public bool IsDeleted { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una solicitud")]
    public int SolicitudId { get; set; }

    public string? TecnicoId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public TimeOnly HoraInicio { get; set; } = new TimeOnly(8, 0);

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public TimeOnly HoraFin { get; set; } = new TimeOnly(9, 0);

    [ForeignKey("SolicitudId")]
    [InverseProperty("Agendas")]
    public virtual Solicitudes Solicitud { get; set; } = null!;
}
