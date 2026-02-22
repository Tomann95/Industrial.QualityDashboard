using Industrial.QualityDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Industrial.QualityDashboard.Services;

public class FileWatcherService
{
    private readonly IServiceScopeFactory _scopeFactory;
    // Wklej dokładnie tę linię:
    private readonly string _path = @"C:\Users\User\Desktop\ProjektyCSharp\Industrial.QualityDashboard\Industrial.QualityDashboard\ProductionLogs";

    public FileWatcherService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;

        if (!Directory.Exists(_path)) Directory.CreateDirectory(_path);

        var watcher = new FileSystemWatcher(_path);
        watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size;
        watcher.Created += OnCreated;
        watcher.Filter = "*.txt";
        watcher.EnableRaisingEvents = true;
    }

    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        // Czekamy sekundę na odblokowanie pliku przez Windows
        Thread.Sleep(1000);

        try
        {
            string content = File.ReadAllText(e.FullPath);

            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // POPRAWIONE WYWOŁANIE:
                var processor = new LogProcessor();
                var newReport = processor.ParseLogLine(content);

                if (newReport != null)
                {
                    db.TestReports.Add(newReport);
                    db.SaveChanges();
                    System.Diagnostics.Debug.WriteLine($"Zapisano rekord: {newReport.SerialNumber}");
                }
            }

            // Przenoszenie do podfolderu Processed
            string processedDir = Path.Combine(_path, "Processed");
            if (!Directory.Exists(processedDir)) Directory.CreateDirectory(processedDir);

            string destFile = Path.Combine(processedDir, e.Name ?? "log.txt");
            if (File.Exists(destFile)) File.Delete(destFile);

            File.Move(e.FullPath, destFile);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"BŁĄD: {ex.Message}");
        }
    }
}

