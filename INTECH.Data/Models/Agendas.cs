using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INTECH.Models;

public class Agendas
{
    [Key]
    public int AgendaId { get; set; }

    public bool IsDeleted { get; set; }
}