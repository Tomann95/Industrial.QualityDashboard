namespace Industrial.QualityDashboard.Models;

public class TestReport
{
    public int Id { get; set; }
    public string SerialNumber { get; set; } = string.Empty;
    public string StationName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty; // PASS / FAIL
    public string? FailureStep { get; set; }
    public double DurationSeconds { get; set; }
    public DateTime ExecutionTime { get; set; }
    public string TesterName { get; set; } = "System";
}
