using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization.Readers;

namespace TagsCloudVisualizationTests;

public class ReadersShould
{
    [Test]
    public void ReadText_TxtFile_ReturnWordsInFile()
    {
        var reader = new TxtReader();

        var words = reader.Read("Files/txtFile.txt");

        words.Should().BeEquivalentTo(["Солнце", "светило", "Ярко", "Наступил", "ДЕНЬ"]);
    }

    [Test]
    public void ReadText_DocFile_ReturnWordsInFile()
    {
        var reader = new DocReader();

        var words = reader.Read("Files/docFile.doc");

        words.Should().BeEquivalentTo(["Солнце", "светило", "Ярко", "Наступил", "ДЕНЬ"]);
    }

    [Test]
    public void ReadText_DocxFile_ReturnWordsInFile()
    {
        var reader = new DocxReader();

        var words = reader.Read("Files/docxFile.docx");

        words.Should().BeEquivalentTo(["Солнце", "светило", "Ярко", "Наступил", "ДЕНЬ"]);
    }
}