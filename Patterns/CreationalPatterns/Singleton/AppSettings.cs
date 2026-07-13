namespace MyTestProject.Patterns.CreationalPatterns.Singleton;
public sealed class AppSettings
{
    private static readonly AppSettings _instance = new();
    public static AppSettings Instance => _instance;
    public string AppName {get;set;} = "My App";
    private AppSettings() {}
}