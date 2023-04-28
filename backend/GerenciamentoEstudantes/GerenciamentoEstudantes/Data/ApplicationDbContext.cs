using GerenciamentoEstudantes.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEstudantes.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Disciplina> Disciplinas { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
