using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipControls : MonoBehaviour
{
    Rigidbody2D rb2d;
    private Vector2 movementVector;
    public float maxSpeed = 10;
    public float rotationSpeed = 100;
    public GameObject battleButton;
    public GameObject victoryText;
    public GameObject chest;

    // Start is called before the first frame update
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if(GameObject.FindGameObjectWithTag("AIController") != null) {
            if(!GameObject.FindGameObjectWithTag("AIController").GetComponent<AIDemoController>().isIdle) {
                battleButton.SetActive(false);
            }
        }
    }

    //When the OnMoveBody event is invoked, sets the movementVector to the input values from PlayerInput
    public void HandleMoveShip(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }

    // Update is called once per frame
    private void Update()
    {
        //Sets the forward movement
        rb2d.velocity = (Vector2)transform.up * movementVector.y * maxSpeed * Time.fixedDeltaTime;
        //Sets the rotational movement
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        //If the player collides with an enemy, sets the battle button to active
        if(other.gameObject.CompareTag("Enemy")) {
            battleButton.SetActive(true);
        }
        //If the player collides with the dock, starts the crab fight
        if(other.gameObject.CompareTag("Finish")) {
            SceneManager.LoadScene("CrabFight");
        }
    }
}
