using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using ViagemPlanLibrary.Domain.Entities;

namespace ViagemPlanAPI.Infrastructure.Persistence;

public class ViagemPlanDbContext : DbContext
{
    public ViagemPlanDbContext(DbContextOptions<ViagemPlanDbContext> options) : base(options) { }

    public DbSet<Viagem> Viagens { get; set; }
    public DbSet<Reserva> Reserva { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Participantes> Participantes { get; set; }
    public DbSet<PacoteAtividades> PacoteAtividades { get; set; }
    public DbSet<Dinheiro> Dinheiros { get; set; }
    public DbSet<Destino> Destinos { get; set; }
    public DbSet<Atividade> Atividades { get; set; }
    public DbSet<AgrupamentoReservas> AgrupamentoReservas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reserva>()
        .HasOne(r => r.Viagem)
        .WithMany(v => v.AgrupamentoReservas.Reservas) // Ajuste se necessário
        .HasForeignKey(r => r.ViagemId)
        .OnDelete(DeleteBehavior.Cascade);


        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ViagemPlanDbContext).Assembly);

    }
}
