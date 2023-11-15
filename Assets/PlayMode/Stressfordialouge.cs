using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class DialogueManagerTests
{
    [Test]
    public void TestStressTestDialogueManager()
    {
        // Arrange
        DailougeManager dialogueManager = new GameObject().AddComponent<DailougeManager>();
        Dailouge dialogue = new Dailouge
        {
            name = "TestNPC",
            sentences = new string[10000] // Simulate a large number of sentences
        };

        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            dialogue.sentences[i] = $"Test Sentence {i}";
        }

        // Act
        System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();

        dialogueManager.StartDailouge(dialogue);

        // Assert
        stopwatch.Stop();
        long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

        // Output results to the console
        Debug.Log($"Test took {elapsedMilliseconds} milliseconds.");

        // Adjust the threshold based on the acceptable performance in your specific case
        Assert.LessOrEqual(elapsedMilliseconds, 1000, $"DialogueManager took too long to process sentences. Elapsed time: {elapsedMilliseconds} milliseconds.");
    }
}
