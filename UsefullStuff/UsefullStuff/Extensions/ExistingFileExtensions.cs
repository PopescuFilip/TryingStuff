using UsefullStuff.Common;
using UsefullStuff.IOModels;

namespace UsefullStuff.Extensions;

public static class ExistingFileExtensions
{
    public static string GetName(this ExistingFile existingFile) =>
        Path.GetFileNameWithoutExtension(existingFile.FilePath);

    public static FileExtension GetExtension(this ExistingFile existingFile) =>
        new((NonEmptyString)Path.GetExtension(existingFile.FilePath));
}