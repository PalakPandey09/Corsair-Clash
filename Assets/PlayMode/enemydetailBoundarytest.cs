/*using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class EnemyOverworldTests
{
    [Test]
    public void PlayerReceivesEnemyShipDetails_BoundaryTest()
    {
        // Create a GameObject to represent the Enemy Overworld Manager
        GameObject managerObject = new GameObject("EnemyOverworldManager");
        EnemyOverworldManager enemyOverworldManager = managerObject.AddComponent<EnemyOverworldManager>();

        // Create a GameObject to represent the Player
        GameObject playerObject = new GameObject("Player");
        Player player = playerObject.AddComponent<Player>();

        // Simulate the player requesting details for a large number of enemy ships
        const int numShips = 10000;
        for (int i = 0; i < numShips; i++)
        {
            EnemyShipDetails enemyShipDetails = player.GetEnemyShipDetails();
            Assert.IsNotNull(enemyShipDetails); // Ensure we received some details
        }

        // Clean up the test objects
        GameObject.Destroy(managerObject);
        GameObject.Destroy(playerObject);
    }
}*/
