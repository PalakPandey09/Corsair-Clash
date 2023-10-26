using UnityEngine;

public class EnemyActivation : MonoBehaviour
{
    public GameObject enemy; // Reference to the enemy GameObject

    void Start()
    {
        // condition to determine when to activate the enemy
        bool shouldActivateEnemy = true; //

        if (shouldActivateEnemy)
        {
            // Activate the enemy
            enemy.SetActive(true);

            // Log a message to the console for debugging purposes
            Debug.Log("Enemy activated on the world map.");
        }
    }
}
