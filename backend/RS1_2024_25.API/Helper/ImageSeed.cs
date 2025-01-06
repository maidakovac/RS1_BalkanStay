using System.IO;

namespace RS1_2024_25.API.Helpers
{
    public static class ImageSeeder
    {
        public static byte[] GetImageBytes(string relativePath)
        {
            // Kombinujte trenutni direktorijum sa relativnom putanjom slike
            var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

            // Proverite da li datoteka postoji
            if (!File.Exists(absolutePath))
            {
                throw new FileNotFoundException($"Image not found at path: {absolutePath}");
            }

            // Vratite sadržaj slike kao byte[]
            return File.ReadAllBytes(absolutePath);
        }
    }
}
