using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PauseMenuStressTest
{
    private PauseMenu pauseMenu;

    [SetUp]
    public void SetUp()
    {
        pauseMenu = new PauseMenu();
    }

    [UnityTest]
    public IEnumerator PauseMenuStressTestWithEnumeratorPasses()
    {
        // Act
        for (int i = 0; i < 1000; i++)
        {
            pauseMenu.Resume();
            yield return null;
            pauseMenu.Pause();
            yield return null;
            
        }

        // Assert
        Assert.IsFalse(PauseMenu.GameIsPaused);
    }
}
