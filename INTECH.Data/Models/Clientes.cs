using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INTECH.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }

    public bool IsDeleted { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [StringLength(150, ErrorMessage = "El nombre no puede superar los 150 caracteres")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [EmailAddress(ErrorMessage = "Introduzca un correo electrónico válido")]
    [StringLength(150, ErrorMessage = "El correo no puede superar los 150 caracteres")]
    public string Correo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [StringLength(13, ErrorMessage = "El RNC o la cédula no puede superar los 13 caracteres")]
    public string RncCedula { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [StringLength(250, ErrorMessage = "La dirección no puede superar los 250 caracteres")]
    public string Direccion { get; set; } = string.Empty;

    [InverseProperty("Cliente")]
    public virtual ICollection<Solicitudes> Solicitudes { get; set; } = new List<Solicitudes>();

    [InverseProperty("Cliente")]
    public virtual ICollection<TelefonosClientes> TelefonosClientes { get; set; } = new List<TelefonosClientes>();
}
