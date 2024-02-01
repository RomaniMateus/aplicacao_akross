using System.ComponentModel.DataAnnotations;

namespace projeto_akross_2.Models;

public class Squad
{
    [Key]
    [Required]
    public int Id { get; set; }

    public virtual ICollection<Colaborador>? Colaboradores { get; set; }
}
