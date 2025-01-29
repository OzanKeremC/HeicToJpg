// Directory containing HEIC images
using ImageMagick;

string inputDirectory = @"C:\Images\HeicAndRaw";
// Directory to save converted JPEG images
string outputDirectory = @"C:\Images\Jpeg";

// Ensure the output directory exists
Directory.CreateDirectory(outputDirectory);

// Process each image file (both HEIC and DNG)
foreach (string imageFile in Directory.GetFiles(inputDirectory, "*.*"))
{
    string extension = Path.GetExtension(imageFile).ToLower();

    // Process only HEIC or DNG files
    if (extension == ".heic" || extension == ".dng")
    {
        // Generate the output file path
        string outputFilePath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(imageFile) + ".jpg");

        // Skip conversion if the output file already exists
        if (File.Exists(outputFilePath))
        {
            Console.WriteLine($"Skipped (already converted): {imageFile}");
            continue;
        }

        try
        {
            // Convert HEIC or DNG to JPEG
            using (MagickImage image = new MagickImage(imageFile))
            {
                // Set the output format
                image.Format = MagickFormat.Jpeg;

                // Set JPEG quality to maximum (100)
                image.Quality = 100;

                // Write the output file
                image.Write(outputFilePath);
            }

            Console.WriteLine($"Converted: {imageFile} -> {outputFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to convert {imageFile}: {ex.Message}");
        }
    }
}

Console.WriteLine("Batch conversion complete.");