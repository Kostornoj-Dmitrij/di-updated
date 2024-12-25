using System.Drawing;
using TagsCloudVisualization.ColorGetter;
using TagsCloudVisualization.Properties;
using TagsCloudVisualization.TagLayouters;

namespace TagsCloudVisualization.Visualization;

public class CommonImageDrawer : IImageDrawer
{
    private readonly ImageProperties _imageProperties;
    private readonly IColorGetter _colorGenerator;

    public CommonImageDrawer(ImageProperties imageProperties, IColorGetter colorGenerator)
    {
        _imageProperties = imageProperties;
        _colorGenerator = colorGenerator;
    }

    public Bitmap Draw(IEnumerable<Tag> tags)
    {
        var bitmap = new Bitmap(_imageProperties.Width, _imageProperties.Height);
        var graphics = Graphics.FromImage(bitmap);
        graphics.Clear(_imageProperties.BackgroundColor);

        foreach (var tag in tags)
        {
            var font = new Font(tag.Font, tag.Size);
            var color = new SolidBrush(_colorGenerator.GetColor());
            var rectangle = tag.Rectangle with
            {
                X = tag.Rectangle.X + _imageProperties.Width / 2,
                Y = tag.Rectangle.Y + _imageProperties.Height / 2
            };

            graphics.DrawString(tag.Content, font, color, rectangle);
        }
        return bitmap;
    }
}