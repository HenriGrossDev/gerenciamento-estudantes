using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEstudantes.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
