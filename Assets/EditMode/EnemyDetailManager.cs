/*using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class EnemyOverworldTests
{
    [Test]
    public void PlayerReceivesEnemyShipDetails()
    {
        // Create a GameObject to represent the Enemy Overworld Manager
        GameObject managerObject = new GameObject("EnemyOverworldManager");
        EnemyOverworldManager enemyOverworldManager = managerObject.AddComponent<EnemyOverworldManager>();

        // Create a GameObject to represent the Player
        GameObject playerObject = new GameObject("Player");
        Player player = playerObject.AddComponent<Player>();

        // Simulate the player requesting enemy ship details
        // In this example, we assume the player calls a method on the manager to get details.
        EnemyShipDetails enemyShipDetails = player.GetEnemyShipDetails();

        // Assert that the received details match the expected values
        Assert.IsNotNull(enemyShipDetails); // Ensure we received some details
        Assert.AreEqual("Enemy Ship Name", enemyShipDetails.ShipName);
        Assert.AreEqual(100, enemyShipDetails.ShipHealth);
        Assert.AreEqual(10, enemyShipDetails.ShipDamage);

        // Clean up the test objects
        GameObject.Destroy(managerObject);
        GameObject.Destroy(playerObject);
    }
}*/

