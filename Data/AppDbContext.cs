namespace ComandsService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(opt)
        {
        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilde modelBuilde)
        {
            modelBuilde
                .Entity<Platfrom>()
                .HasMany(p => p.Commands)
                .WithOne(p => p.Platform!)
                .HasForeignKey(p => p.PlatformId);

            modelBuilde
                .Entity<Comands>()
                .HasMany(p => p.Platforms)
                .WithMany(p => p.Commands)
                .HasForeignKey(p => p.PlatformId);
        }
    }
}