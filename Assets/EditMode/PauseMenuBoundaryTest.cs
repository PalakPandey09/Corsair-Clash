using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PauseMenuBoundaryTest
{
    private PauseMenu pauseMenu;

    [SetUp]
    public void SetUp()
    {
        pauseMenu = new PauseMenu();
    }

    [Test]

    //This test ensures that the Resume() method does not cause any errors when the pauseMenuUI object is null.
    public void PauseMenuResumeWithNullPauseMenuUI()
    {
        // Arrange
        pauseMenu.pauseMenuUI = null;

        // Act
        pauseMenu.Resume();

        // Assert
        Assert.IsTrue(Time.timeScale == 1f);
        Assert.IsFalse(PauseMenu.GameIsPaused);
    }

    [Test]
    //This test ensures that the Pause() method does not cause any errors when the pauseMenuUI object is null.
    public void PauseMenuPauseWithNullPauseMenuUI()
    {
        // Arrange
        pauseMenu.pauseMenuUI = null;

        // Act
        pauseMenu.Pause();

        // Assert
        Assert.IsTrue(Time.timeScale == 0f);
        Assert.IsTrue(PauseMenu.GameIsPaused);
    }
}
