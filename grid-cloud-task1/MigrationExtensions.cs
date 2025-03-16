using grid_cloud_task1.Database;
using Microsoft.EntityFrameworkCore;

public static class MigrationExtensions
{
    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
        return app;
    }
}