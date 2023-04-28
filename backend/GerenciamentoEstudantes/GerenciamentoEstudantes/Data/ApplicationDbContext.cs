using GerenciamentoEstudantes.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEstudantes.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Aluno> Alunos { get; set; }
}
