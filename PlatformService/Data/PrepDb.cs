using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopilation(IApplicationBuilder app, bool isProduction)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                ApplyMigrationsAndSeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProduction);
            }
        }

        private static void ApplyMigrationsAndSeedData(AppDbContext context, bool isProduction)
        {
            ApplyMigrationIfInProduction(context, isProduction);
            SeedPlatformDataIfNoneExist(context);
        }

        private static void ApplyMigrationIfInProduction(AppDbContext context, bool isProduction)
        {
            if (!isProduction)
                return;

            Console.WriteLine("---> Attempting to apply migration...");
            try
            {
                context.Database.Migrate();
                Console.WriteLine("---> Migration applied successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"---> Could not run migration: {ex.Message}");
            }
        }

        private static void SeedPlatformDataIfNoneExist(AppDbContext context)
        {
            if (context.Platforms.Any())
            {
                Console.WriteLine("--> We already have data");
                return;
            }

            Console.WriteLine("--> Seeding Data...");
            var platforms = new[]
            {
            new Platform { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
            new Platform { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
            new Platform { Name = "Kubernetes", Publisher = "Cloud Native Computing", Cost = "Free" }
        };

            context.Platforms.AddRange(platforms);
            context.SaveChanges();
            Console.WriteLine("--> Data seeded successfully");
        }
    }

}
















public static class PrepDb
{
    public static void PrepPopilation(IApplicationBuilder app, bool isProd)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
        }
    }

    private static void SeedData(AppDbContext context, bool isProd)
    {
        if (isProd)
        {
            Console.WriteLine("---> Attempting to apply migration...");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"---> Could not run migration: {ex.Message}");
            }
        }

        if (!context.Platforms.Any())
        {
            Console.WriteLine("--> Seeding Data...");

            context.Platforms.AddRange(
                new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                new Platform() { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
                new Platform() { Name = "Kubernetes", Publisher = "Cloud Nativ Computing", Cost = "Free" }
            );

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("--> We alerady have data");
        }
    }
}