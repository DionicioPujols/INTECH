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
}