namespace AoC2021.Day20
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var image = new Image(false);
            string? algorithm = null;
            using (var reader = new StreamReader(args[0]))
            {
                algorithm = reader.ReadLine();
                reader.ReadLine();
                var y = 0;
                for (var line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    for (int x = 0; x < line.Length; x++)
                    {
                        image.SetPixel(x, y, line[x] == '#');
                    }

                    y++;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                image = Enhance(image, algorithm!);
            }

            Console.WriteLine($"Part 1: {image.LitCount}");
            for (int i = 2; i < 50; i++)
            {
                image = Enhance(image, algorithm!);
            }

            Console.WriteLine($"Part 2: {image.LitCount}");
        }

        public static Image Enhance(Image image, string algorithm)
        {
            var invert = algorithm[0] == '#' &&
                algorithm[algorithm.Length - 1] == '.' &&
                !image.Inverted;
            var enhanced = new Image(invert);
            for (int y = image.MinY - 1; y <= image.MaxY + 1; y++)
            {
                for (int x = image.MinX - 1; x <= image.MaxX + 1; x++)
                {
                    var index = 0;
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            index <<= 1;
                            if (image.IsLit(x + dx, y + dy))
                            {
                                index += 1;
                            }
                        }
                    }

                    enhanced.SetPixel(x, y, algorithm[index] == '#');
                }
            }

            return enhanced;
        }
    }
}
