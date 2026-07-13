namespace MyTestProject.Patterns.CreationalPatterns.Builder;

public class Report
{
    public string Title { get; set; } = string.Empty;
    public string Period {get;set;} = string.Empty;
    public bool IncludeCharts {get;set;}
    public bool IncludeSummary {get;set;}
    public string Format {get;set;} = "PDF";
}