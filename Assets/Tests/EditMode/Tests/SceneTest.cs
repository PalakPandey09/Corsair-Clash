using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SceneTransitionTest
{
    [UnityTest]
    public IEnumerator SceneTransitionOnTrigger()
    {
        // Load a test scene containing the mySceneManager object.
        yield return SceneManager.LoadSceneAsync("TestScene");

        // Find the mySceneManager script in the scene.
        var sceneManager = GameObject.FindObjectOfType<mySceneManager>();
        Assert.IsNotNull(sceneManager, "mySceneManager not found in the scene.");

        // Set the sceneBuildIndex for the test.
        sceneManager.sceneBuildIndex = 1; // Replace with the desired scene index.

        // Create a test GameObject that simulates a ship.
        GameObject shipObject = new GameObject();
        shipObject.tag = "Ship";

        // Simulate OnTriggerEnter2D by calling the method directly.
        sceneManager.OnTriggerEnter2D(shipObject.GetComponent<Collider2D>());

        // Wait for a short time to allow the scene to load.
        yield return new WaitForSeconds(0.1f);

        // Check if the expected scene is loaded.
        Assert.AreEqual(SceneManager.GetActiveScene().buildIndex, sceneManager.sceneBuildIndex);

        // Clean up.
        Object.Destroy(shipObject);

        // Unload the test scene.
        yield return SceneManager.UnloadSceneAsync("TestScene");
    }
}

