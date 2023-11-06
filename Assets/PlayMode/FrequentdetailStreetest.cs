/*using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class EnemyOverworldTests
{
    [UnityTest]
    public IEnumerator PlayerReceivesEnemyShipDetails_StressTest()
    {
        // Create a GameObject to represent the Enemy Overworld Manager
        GameObject managerObject = new GameObject("EnemyOverworldManager");
        EnemyOverworldManager enemyOverworldManager = managerObject.AddComponent<EnemyOverworldManager>();

        // Create a GameObject to represent the Player
        GameObject playerObject = new GameObject("Player");
        Player player = playerObject.AddComponent<Player>();

        // Simulate the player continuously requesting enemy ship details in a loop
        const int numIterations = 10000;
        for (int i = 0; i < numIterations; i++)
        {
            EnemyShipDetails enemyShipDetails = player.GetEnemyShipDetails();
            Assert.IsNotNull(enemyShipDetails); // Ensure we received some details
            yield return null; // Yield to allow other Unity processes to run
        }

        // Clean up the test objects
        GameObject.Destroy(managerObject);
        GameObject.Destroy(playerObject);
    }
}*/
