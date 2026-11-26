using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INTECH.Models;

public class HistorialesDetalle
{
    [Key]
    public int DetalleId { get; set; }

    public int HistorialId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public string Descripcion { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [ForeignKey("HistorialId")]
    [InverseProperty("HistorialesDetalle")]
    public virtual Historiales Historial { get; set; } = null!;
}
