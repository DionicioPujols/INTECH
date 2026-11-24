using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INTECH.Models;

public class TelefonosClientes
{
    [Key]
    public int TelefonoClienteId { get; set; }

    public bool IsDeleted { get; set; }

    public int ClienteId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [StringLength(12, ErrorMessage = "El teléfono no puede superar los 12 caracteres")]
    public string Numero { get; set; } = string.Empty;

    public bool EsPrincipal { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("TelefonosClientes")]
    public virtual Clientes Cliente { get; set; } = null!;
}
