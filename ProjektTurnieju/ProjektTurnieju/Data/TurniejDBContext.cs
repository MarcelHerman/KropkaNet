using ProjektTurnieju.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjektTurnieju.Data;
public class TurniejDBContext : DbContext
{
    public DbSet<Uzytkownik> Uzytkownicy { get; set; }
    public DbSet<Druzyna> Druzyny { get;set; }
    public DbSet<Ogloszenie> Ogloszenia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjektTurnieju;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<ProjektTurnieju.Models.Turniej> Turniej { get; set; } = default!;

}
