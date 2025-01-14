using System;
using System.Collections.Generic;

class Test
{
    static void Main()
    {
        bool firstImage = true;

        while (true)
        {
            // Read the number of scanlines for the current image
            int n = int.Parse(Console.ReadLine());
            if (n == 0)
            {
                break;  // End of input
            }

            if (!firstImage)
            {
                Console.WriteLine();  // Print a blank line between images
            }
            firstImage = false;

            // Process the image
            bool errorOccurred = false;
            List<string> decodedImage = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] parts = line.Split(' ');

                // The first part is the pixel type ('#' or '.')
                char currentPixel = parts[0][0];
                List<int> runs = new List<int>();

                // Parse the subsequent numbers
                for (int j = 1; j < parts.Length; j++)
                {
                    runs.Add(int.Parse(parts[j]));
                }

                // Now, expand the runs and check for error
                StringBuilder decodedLine = new StringBuilder();
                int totalPixels = 0;
                foreach (int run in runs)
                {
                    decodedLine.Append(new string(currentPixel, run));
                    totalPixels += run;
                    currentPixel = currentPixel == '.' ? '#' : '.';  // Alternate pixel type
                }

                // Check for any errors in the scanline
                if (totalPixels != 35)  // 35 is the expected number of pixels in a scanline
                {
                    Console.WriteLine("Error decoding image");
                    errorOccurred = true;
                    break;
                }

                decodedImage.Add(decodedLine.ToString());
            }

            // If there was no error, print the decoded image
            if (!errorOccurred)
            {
                foreach (var line in decodedImage)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
