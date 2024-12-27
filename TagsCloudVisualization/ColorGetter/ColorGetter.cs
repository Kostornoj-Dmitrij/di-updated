using System.Drawing;
using TagsCloudVisualization.Properties;

namespace TagsCloudVisualization.ColorGetter;

public class ColorGetter : IColorGetter
{
    private readonly ColorGetterProperties _colorGetterProperties;

    public ColorGetter(ColorGetterProperties colorGetterProperties)
    {
        _colorGetterProperties = colorGetterProperties;
    }

    public Color GetColor()
    {
        if (WellKnownColors.Colors.TryGetValue(_colorGetterProperties.ColorName, out var customColor))
        {
            return customColor;
        }

        return Color.FromName(_colorGetterProperties.ColorName);
    }
}