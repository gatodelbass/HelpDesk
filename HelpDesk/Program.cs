using HelpDesk.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbConnection>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    
);


string connectionString = "Server=localhost\\SQLEXPRESS;Database=HelpDeskDb;User ID=elgato;Password=Engel1979*;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True";

Console.WriteLine("🔄 Attempting to connect to local SQL Server Express...");

// 2. Wrap the connection in a using block to ensure proper disposal
using (SqlConnection connection = new SqlConnection(connectionString))
{
    try
    {
        // 3. Try to open the connection
        connection.Open();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("✅ Connection successful! jojoj");
        Console.ResetColor();

        // Optional: Print server version to confirm the connection details
        Console.WriteLine($"Server Version: {connection.ServerVersion}");
    }
    catch (SqlException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("❌ Connection failed!");
        Console.ResetColor();

        // 4. Print the exact error details to help with debugging
        Console.WriteLine($"Error Message: {ex.Message}");
        Console.WriteLine($"Error Number: {ex.Number}");
    }

}

// Add services to the container.
builder.Services.AddControllersWithViews();

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
