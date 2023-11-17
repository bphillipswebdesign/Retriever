using Serilog;
using Serilog.Events;
using Serilog.Ui.MsSqlServerProvider;
using Serilog.Ui.Web;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(o => o.AddPolicy(name: "CorsPolicy", builder => {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin();
        }));

        builder.Services.AddSignalR();

        //FOR SERILOG PLUMBING
        //Get connection string from appsettings/json ConnectionsStrings object, Database key
        string connectionString = builder.Configuration.GetConnectionString("Database");
        //add serilog to app
        builder.Services.AddSerilogUi(options =>
        {
            //use db from connection string, table Logs
            options.UseSqlServer(connectionString, "Logs");
        });

        var app = builder.Build();

        //make route .../logs show logs ui
        app.UseSerilogUi(options =>
        {
            options.RoutePrefix = "logs";
        });

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        //necessary to use wwwroot as source of images for webUI
        app.UseStaticFiles();
        app.UseCors("CorsPolicy");

        app.UseAuthorization();

        app.MapControllers().RequireCors("CorsPolicy");

        app.Run();
    }
}