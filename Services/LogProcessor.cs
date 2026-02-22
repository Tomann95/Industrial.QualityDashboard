using Industrial.QualityDashboard.Models;
using System.Globalization;

namespace Industrial.QualityDashboard.Services;

public class LogProcessor
{
    
    public TestReport ParseLogLine(string rawData)
    {
        try
        {
            // Oczekiwany format: SN:IQD-2026-003;Result:FAIL;Station:Vision_Check;Duration:12.5;Tester:Jan Kowalski
            var parts = rawData.Split(';');

            return new TestReport
            {
                
                SerialNumber = parts[0].Split(':')[1].Trim(),
                Status = parts[1].Split(':')[1].Trim(),
                StationName = parts[2].Split(':')[1].Trim(),

                
                DurationSeconds = double.Parse(parts[3].Split(':')[1].Trim().Replace(",", "."), CultureInfo.InvariantCulture),

                
                TesterName = parts.Length > 4 ? parts[4].Split(':')[1].Trim() : "Operator_A",

                ExecutionTime = DateTime.Now
            };
        }
        catch (Exception ex)
        {
            
            System.Diagnostics.Debug.WriteLine($"Błąd parsowania logu: {ex.Message}");
            return null;
        }
    }
}
