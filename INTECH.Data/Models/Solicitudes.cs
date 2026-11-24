using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INTECH.Models;

public class Solicitudes
{
    [Key]
    public int SolicitudId { get; set; }

    public bool IsDeleted { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un cliente")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [StringLength(150, ErrorMessage = "El tipo de servicio no puede superar los 150 caracteres")]
    public string TipoServicio { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [StringLength(250, ErrorMessage = "La dirección no puede superar los 250 caracteres")]
    public string Direccion { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public DateTime FechaSolicitud { get; set; } = DateTime.Today;

    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un estado")]
    public int EstadoSolicitudId { get; set; } = 1;

    [ForeignKey("ClienteId")]
    [InverseProperty("Solicitudes")]
    public virtual Clientes Cliente { get; set; } = null!;

    [ForeignKey("EstadoSolicitudId")]
    [InverseProperty("Solicitudes")]
    public virtual EstadosSolicitudes EstadoSolicitud { get; set; } = null!;
}
