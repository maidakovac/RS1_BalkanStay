using System.IO;

namespace RS1_2024_25.API.Helpers
{
    public static class FileHelper
    {
        public static byte[] ConvertImageToByteArray(string folderPath, string fileName)
        {
            string fullPath = Path.Combine(folderPath, fileName);
            return File.Exists(fullPath) ? File.ReadAllBytes(fullPath) : new byte[0];
        }
    }
}
