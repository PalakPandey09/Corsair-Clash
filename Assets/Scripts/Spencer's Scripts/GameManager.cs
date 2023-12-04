using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject battleButton;

    //When a player ship collides with an enemy ship, sets the battle button to be active
    void OnCollisionEnter (Collision collision) {
        Debug.Log("Collided With Something");
        if (collision.gameObject.tag == "Enemy" ) {
            Debug.Log("Collided With Enemy");
            battleButton.SetActive(true);
        }
    }
}
