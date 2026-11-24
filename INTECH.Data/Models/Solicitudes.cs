using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INTECH.Models;

public class Solicitudes
{
    [Key]
    public int SolicitudId { get; set; }

    public bool IsDeleted { get; set; }

    public int? ClienteId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [StringLength(150, ErrorMessage = "El cliente no puede superar los 150 caracteres")]
    public string NombreCliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [StringLength(150, ErrorMessage = "El tipo de servicio no puede superar los 150 caracteres")]
    public string TipoServicio { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "El contacto no puede superar los 50 caracteres")]
    public string Contacto { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [StringLength(250, ErrorMessage = "La dirección no puede superar los 250 caracteres")]
    public string Direccion { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public DateTime FechaSolicitud { get; set; } = DateTime.Today;

    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un estado válido")]
    public int EstadoSolicitudId { get; set; } = 1;

    public DateTime? FechaFin { get; set; }

    [StringLength(150, ErrorMessage = "El técnico asignado no puede superar los 150 caracteres")]
    public string TecnicoAsignado { get; set; } = string.Empty;

    [ForeignKey("ClienteId")]
    [InverseProperty("Solicitudes")]
    public virtual Clientes? Cliente { get; set; }

    [ForeignKey("EstadoSolicitudId")]
    [InverseProperty("Solicitudes")]
    public virtual EstadosSolicitudes EstadoSolicitud { get; set; } = null!;
}
