using System.Drawing;

namespace TagsCloudVisualization.Properties;

public class ImageProperties
{
    public int Width { get; }
    public int Height { get; }
    public Color BackgroundColor { get; }

    public ImageProperties(int width, int height, string colorName)
    {
        Width = width;
        Height = height;
        BackgroundColor = Color.FromName(colorName);
    }
}