namespace MyTestProject.Patterns.CreationalPatterns.Builder;

public class ReportBuilder
{
    private Report _report = new();

    public ReportBuilder WithTitle(string title)
    {
        _report.Title = title;
        return this;
    }

    public ReportBuilder WithPeriod(string period)
    {
        _report.Period = period;
        return this;
    }

    public ReportBuilder IncludeCharts()
    {
        _report.IncludeCharts = true;
        return this;
    }

    public ReportBuilder IncludeSummary()
    {
        _report.IncludeSummary = true;
        return this;
    }

    public ReportBuilder WithFormat(string format)
    {
        _report.Format = format;
        return this;
    }

    public Report Build()
    {
        return _report;
    }
}