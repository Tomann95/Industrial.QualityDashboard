using Industrial.QualityDashboard.Components;
using Industrial.QualityDashboard.Models;
using Industrial.QualityDashboard.Services;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;

QuestPDF.Settings.License = LicenseType.Community;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Prosta rejestracja bazy
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<FileWatcherService>();
builder.Services.AddTransient<LogProcessor>();
builder.Services.AddTransient<PdfService>();
builder.Services.AddSingleton<FileWatcherService>();

var app = builder.Build();

// To musi byæ tutaj, aby FileWatcher ruszy³
app.Services.GetRequiredService<FileWatcherService>();
app.Services.GetRequiredService<FileWatcherService>();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();