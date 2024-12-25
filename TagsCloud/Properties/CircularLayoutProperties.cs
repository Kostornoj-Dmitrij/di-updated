namespace TagsCloudVisualization.Properties;

public class CircularLayoutProperties
{
    public double AngleIncreasingStep { get; }
    public int RadiusIncreasingStep { get; }

    public CircularLayoutProperties(double angleIncreasingStep = Math.PI / 180, int radiusIncreasingStep = 1)
    {
        AngleIncreasingStep = angleIncreasingStep;
        RadiusIncreasingStep = radiusIncreasingStep;
    }
}