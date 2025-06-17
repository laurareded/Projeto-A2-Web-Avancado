using Microsoft.EntityFrameworkCore;
using DracarysAPI.Models;

namespace DracarysAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) {}

    public DbSet<Casa> Casas { get; set; }
    public DbSet<Personagem> Personagens { get; set; }
    public DbSet<Dragao> Dragoes { get; set; }
}