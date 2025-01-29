﻿
# HEIC to JPEG and DNG to JPEG Photo Batch Conversion

You can choose which format to convert. 

```
// Convert HEIC to JPEG
// Convert DNG to JPEG
using (MagickImage image = new MagickImage(heicFile))
{
    // Set the output format
    image.Format = MagickFormat.Jpeg;

    // Set JPEG quality to maximum (100)
    image.Quality = 100;

    // Write the output file
    image.Write(outputFilePath);
}
```


### Heic to Jpeg
### Heic to Jpg
### Heic to Png

