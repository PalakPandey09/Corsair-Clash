using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ShipMovementTest
{
    [UnityTest]
    public IEnumerator ShipMovesWhenInputIsGiven()
    {
        // Create a new GameObject and add the ShipMovement script to it.
        GameObject shipObject = new GameObject();
        shipObject.AddComponent<ShipMovement>();

        // Get a reference to the ShipMovement script attached to the GameObject.
        ShipMovement shipMovement = shipObject.GetComponent<ShipMovement>();

        // Simulate the ship's movement by setting the move input.
        shipMovement.move = 1f;

        // Call the MovePlayer method (you may need to make it public for testing).
        shipMovement.MovePlayer();

        // Wait for a short time to allow FixedUpdate to execute.
        yield return new WaitForSeconds(0.1f);

        // Check if the ship's velocity has changed as expected.
        Assert.IsTrue(shipMovement.ship.velocity.x > 0);

        // Clean up.
        Object.Destroy(shipObject);
    }
}
