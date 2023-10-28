using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject battleButton;

    // Start is called before the first frame update
    void Start()
    {
        battleButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision collision) {
        Debug.Log("Collided With Something");
        if (collision.gameObject.tag == "Enemy" ) {
            Debug.Log("Collided With Enemy");
            battleButton.SetActive(true);
        }
    }
}
