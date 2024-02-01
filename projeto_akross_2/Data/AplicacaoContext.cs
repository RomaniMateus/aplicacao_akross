using Microsoft.EntityFrameworkCore;
using projeto_akross_2.Models;

namespace projeto_akross_2.Data;

public class AplicacaoContext : DbContext
{
    public AplicacaoContext(DbContextOptions<AplicacaoContext> options) : base(options)
    { }

    public DbSet<Colaborador> Colaboradores { get; set; }
    public DbSet<Squad> Squads { get; set; }
}
