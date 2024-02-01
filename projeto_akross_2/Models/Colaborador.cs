using System.ComponentModel.DataAnnotations;

namespace projeto_akross_2.Models;

public class Colaborador
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo 'nome' é obrigatório")]
    public string Nome { get; set; }

    [Required]
    public int SquadId { get; set; }
    public virtual Squad Squad { get; set; }

}
