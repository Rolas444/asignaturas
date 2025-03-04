
using DotNetEnv;
using Dapper;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file
Env.Load();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();

// Register Dapper context
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Console.WriteLine($"Connection string: {connectionString}");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");

var connectionString = $"Server={dbHost};Database={dbName};User Id={dbUser};Password={dbPassword};";
Console.WriteLine($"Connection string: {connectionString}");

builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));

// Register AsignaturaService
builder.Services.AddScoped<AsignaturaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
