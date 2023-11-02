using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        battleButton.SetActive(false);
        victoryText.SetActive(false);
        chest.SetActive(true);
    }

    public void HandleMoveShip(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }

    // Update is called once per frame
    private void Update()
    {
        rb2d.velocity = (Vector2)transform.up * movementVector.y * maxSpeed * Time.fixedDeltaTime;
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collided with Something");
        if(other.gameObject.CompareTag("Enemy")) {
            battleButton.SetActive(true);
        }
        if(other.gameObject.CompareTag("Finish")) {
            victoryText.SetActive(true);
            chest.SetActive(false);
        }
    }
}
