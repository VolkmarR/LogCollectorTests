using LogCollectorTests;
using LogCollectorTests.Helpers;
using Serilog;

SerilogConfiguration.Execute();

try
{
    var builder = WebApplication.CreateBuilder(args);

    SerilogConfiguration.Execute(builder.Configuration);

    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddTransient<LogDataHelper>();

    builder.Logging.ClearProviders().AddSerilog(Log.Logger);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
    }
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapRazorPages();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
return 0;