namespace AirBnb.Server.Api.Extentions;

public static class FileExtentions
{
    public static string ToUrl(this string path, string? prefix = default) =>
        $"{prefix + "/"}{path.Replace("\\", "/")}";
}