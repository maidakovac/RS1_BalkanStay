
namespace RS1_2024_25.API.Data.Models
{
    public static class ImageSeeder
    {
        public static string GetImagePath(string filePath)
        {
            return filePath; // ✅ Return file path instead of byte[]
        }

        internal static string GetImageBytes(string v)
        {
            return v;
        }
    }
}
