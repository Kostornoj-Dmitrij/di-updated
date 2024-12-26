using System.Drawing;

namespace TagsCloudVisualization.TagLayouters;

public class Tag
{
    public string Content { get; }
    public int Size { get; }
    public Rectangle Rectangle { get; }
    public FontFamily Font { get; }

    public Tag(string content, int size, Rectangle rectangle, FontFamily font)
    {
        Content = content;
        Size = size;
        Rectangle = rectangle;
        Font = font;
    }
}