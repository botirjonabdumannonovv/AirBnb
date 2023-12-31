﻿namespace AirBnb.ServerApp.Infrastructure.Common.Extensions;

public static class FileExtensions
{
    public static string ToUrl(this string path, string? prefix = default) => $"{prefix + "/"}{path.Replace("\\", "/")}";
}