using Microsoft.EntityFrameworkCore;
using GPFCManagementSystem.Models;
using Microsoft.Extensions.DependencyInjection; // Added this to use CreateScope()

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register the database context
builder.Services.AddDbContext<GPFCContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("GPFCContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Initialize the database with seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<GPFCContext>();
    context.Database.EnsureCreated();  // Ensure the database is created
    SeedData.Initialize(services);     // Seed the database
}

app.Run();