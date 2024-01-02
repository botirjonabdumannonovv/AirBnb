using AirBnb.ServerApp.Domain.Enums;

namespace AirBnb.ServerApp.Infrastructure.StorageFiles.Settings;

/// <summary>
/// Represents storage file location settings
/// </summary>
public class StorageFileLocationSettings
{
    /// <summary>
    /// Gets the storage file location
    /// </summary>
    public StorageFileType StorageFileType { get; init; }

    /// <summary>
    /// Gets the folder path
    /// </summary>
    public string FolderPath { get; init; } = default!;
}