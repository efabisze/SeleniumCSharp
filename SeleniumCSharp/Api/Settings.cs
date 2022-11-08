public enum Environment
{
    QA,
    Production,
    Hotfix,
    Development
}

public class Settings
{
    public static string QAUrl { get { return "https://reqres.in"; } }

    public static string ProductionUrl { get { return "https://RandomHost"; } }

    public static string HotfixUrl { get { return "https://localhost"; } }

    public static string DevUrl { get { return "https://localhost"; } }
}