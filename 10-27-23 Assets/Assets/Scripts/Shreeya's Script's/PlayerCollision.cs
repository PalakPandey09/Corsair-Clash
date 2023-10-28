using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
     void OnCollisionEnter (Collision collision) {
        Debug.Log("Collided With Something");
        if (collision.gameObject.tag == "Enemy" ) {
            Debug.Log("Collided With Enemy");
        }
     }
}
