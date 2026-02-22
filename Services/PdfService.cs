using Industrial.QualityDashboard.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Industrial.QualityDashboard.Services;

public class PdfService
{
    public byte[] GenerateTestReport(TestReport report)
    {
        // Upewnij się, że licencja jest ustawiona w Program.cs
        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(1, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(11).FontFamily(Fonts.SegoeUI));

                page.Header().Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        // Nowy neutralny tytuł
                        col.Item().Text("INDUSTRIAL QUALITY SYSTEMS").FontSize(20).SemiBold().FontColor("#2c3e50");
                        col.Item().Text($"Report ID: #QC-{report.Id:D4}").FontSize(10).Italic();
                    });

                    row.RelativeItem().AlignRight().Column(col =>
                    {
                        col.Item().Text("IQD SOLUTIONS INC.").FontSize(14).Bold(); // Nowy branding
                        col.Item().Text(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    });
                });

                page.Content().PaddingVertical(20).Column(col =>
                {
                    col.Spacing(10);
                    col.Item().Background("#F0F2F5").Padding(10).Row(row =>
                    {
                        row.RelativeItem().Text(t => { t.Span("Serial Number: ").Bold(); t.Span(report.SerialNumber); });
                        row.RelativeItem().Text(t => { t.Span("Station: ").Bold(); t.Span(report.StationName); });
                    });

                    var statusColor = report.Status == "PASS" ? Colors.Green.Medium : Colors.Red.Medium;
                    col.Item().PaddingTop(10).Border(1).BorderColor(statusColor).Row(row =>
                    {
                        row.RelativeItem().Padding(15).Column(innerCol => {
                            innerCol.Item().Text("TEST RESULT").FontSize(10).SemiBold();
                            innerCol.Item().Text(report.Status).FontSize(30).Bold().FontColor(statusColor);
                        });
                        row.RelativeItem().Background(statusColor).Padding(15).Column(innerCol => {
                            innerCol.Item().Text("DURATION").FontSize(10).SemiBold().FontColor(Colors.White);
                            innerCol.Item().Text($"{report.DurationSeconds} s.").FontSize(22).Bold().FontColor(Colors.White);
                        });
                    });
                });

                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Automated Quality Report | ");
                    x.Span("Industrial Quality Dashboard").Bold();
                    x.Span(" | Page ");
                    x.CurrentPageNumber();
                });
            });
        }).GeneratePdf();
    }
}