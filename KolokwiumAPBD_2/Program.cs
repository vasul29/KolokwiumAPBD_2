using KolokwiumAPBD_2.Data;
using KolokwiumAPBD_2.Services;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumAPBD_2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
        });
        
        builder.Services.AddTransient<IDbService, DbService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}