using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PauseMenu_BoundaryTest
{
    private PauseMenu pauseMenu;

    [SetUp]
    public void SetUp()
    {
        PauseMenu.GameIsPaused = false;
        pauseMenu = new PauseMenu();
    }

    [UnityTest]
    public IEnumerator PauseMenu_BoundaryTestWithEnumeratorPasses()
    {
        // Assert that Time.timeScale is 1f before calling Pause().
        Assert.AreEqual(1.0f, Time.timeScale);

        // Act
        pauseMenu.Pause();

        // Yield to skip a frame.
        yield return null;

        // Assert that GameIsPaused is True after calling Pause().
        Assert.IsTrue(PauseMenu.GameIsPaused);

        // Assert that Time.timeScale is 0f after calling Pause().
        Assert.AreEqual(0.0f, Time.timeScale);

        // Assert that the pause menu UI is visible after calling Pause().
        Assert.IsTrue(pauseMenu.pauseMenuUI.activeSelf);

        // Act
        pauseMenu.Resume();

        // Yield to skip a frame.
        yield return null;

        // Assert that GameIsPaused is False after calling Resume().
        Assert.IsFalse(PauseMenu.GameIsPaused);

        // Assert that Time.timeScale is 1f after calling Resume().
        Assert.AreEqual(1.0f, Time.timeScale);

        // Assert that the pause menu UI is not visible after calling Resume().
        Assert.IsFalse(pauseMenu.pauseMenuUI.activeSelf);
    }
}
