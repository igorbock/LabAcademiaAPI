namespace LabAcademiaAPI.Context;

public class LabAcademiaContext : DbContext
{
    public string? C_ConnectionString { get; set; }

    public LabAcademiaContext(string p_ConnectionString)
    {
        C_ConnectionString = p_ConnectionString;
    }

    public LabAcademiaContext(DbContextOptions<LabAcademiaContext> p_Options) : base(p_Options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UsuariosTreinos>(ent =>
        {
            ent.HasKey(a => new { a.CodigoTreino, a.CodigoUsuario });
        });
    }

    public DbSet<Treino> Treinos { get; set; }
    public DbSet<Exercicio> Exercicios { get; set; }
    public DbSet<Historico> Historicos { get; set; }
    public DbSet<UsuariosTreinos> UsuariosTreinos { get; set; }
}
