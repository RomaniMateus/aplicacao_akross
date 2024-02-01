using System.ComponentModel.DataAnnotations;

namespace projeto_akross_2.Data.Dtos;

public class CreateColaboradorDto
{
    public string Nome { get; set; }

    public int SquadId { get; set; }
}
