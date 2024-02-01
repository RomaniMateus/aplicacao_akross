namespace projeto_akross_2.Data.Dtos;

public class ReadColaboradorDto
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public ReadSquadDto Squad { get; set; }
}
