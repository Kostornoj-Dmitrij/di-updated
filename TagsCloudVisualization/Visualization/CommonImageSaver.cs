using System.Drawing;
using System.Drawing.Imaging;
using TagsCloudVisualization.Properties;

namespace TagsCloudVisualization.Visualization;

public class CommonImageSaver : IImageSaver
{
    private readonly SaveProperties _properties;

    public CommonImageSaver(SaveProperties properties)
    {
        _properties = properties;
    }

    public void Save(Bitmap bitmap)
    {
        var filePath = _properties.FilePath;
        var fileName = _properties.FileName;
        var imageFormat = GetImageFormat(_properties.FileFormat);

        if (!Directory.Exists(_properties.FilePath))
        {
            Directory.CreateDirectory(_properties.FilePath);
        }
        bitmap.Save(Path.Combine(filePath, $"{fileName}.{_properties.FileFormat}"), imageFormat);
    }

    private static ImageFormat GetImageFormat(string format)
    {
        try
        {
            var imageFormatConverter = new ImageFormatConverter();
            var imageFormat = imageFormatConverter.ConvertFromString(format);

            if (imageFormat == null)
                throw new ArgumentException($"Can't handle format: {format}");
            return (ImageFormat)imageFormat;
        }
        catch (NotSupportedException)
        {
            throw new NotSupportedException($"File with format {format} doesn't supported");
        }
    }
}