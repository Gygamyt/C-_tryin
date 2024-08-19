using System.Collections;

namespace TestFramework.Utils;

public class GeneratorOfRandomThings
{
    private static readonly string[] Words =
    [
        "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog",
        "hello", "world", "csharp", "programming", "language", "random", "sentence",
        "example", "generate", "text", "simple", "method", "code", "sample", "words"
    ];

    private static readonly Random Random = new();

    public static string GenerateSentence(int wordCount)
    {
        if (wordCount <= 0) {
            throw new ArgumentException("Word count must be greater than 0");
        }
        
        var sentenceWords = new List<string>();
        for (var i = 0; i < wordCount; i++)
        {
            var word = Words[Random.Next(Words.Length)];
            sentenceWords.Add(word);
        }

        var sentence = string.Join(" ", sentenceWords) + ".";
        
        return $"{char.ToUpper(sentence[0])}{sentence[1..]}";
    }
}