using UsefullStuff.Common;

namespace TryingZip;

public static class SupportedZipExtensions
{
    public static readonly FileExtension SevenZ = new(new("7z"));
    public static readonly FileExtension IfcZip = new(new("IFCZIP"));
    public static readonly FileExtension Zip = new(new("Zip"));
}