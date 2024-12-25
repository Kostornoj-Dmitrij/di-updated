using System.Text.RegularExpressions;

namespace TagsCloudVisualization.Readers;

public class WordsGetter
{
    public static List<string> GetWords(IEnumerable<string> paragraphsOfText)
    {
        var words = new List<string>();

        foreach (var paragraph in paragraphsOfText)
        {
            var paragraphWords = Regex.Matches(paragraph, @"\b[a-zA-Zа-яА-Я]+\b")
                .Select(word => word.Value);

            words.AddRange(paragraphWords);
        }

        return words;
    }
}