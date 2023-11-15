using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    private bool dragging = false;
    private bool onEmptySpace = false;
    private Vector3 offset;
    public float startX = 0;
    public float startY = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Sets the initial position values to snap back to if not placed on an empty space
        startX = this.transform.position.x;
        startY = this.transform.position.y;
        this.transform.position = new Vector2(startX, startY);
    }

    // Update is called once per frame
    void Update()
    {
        //If the unit is being dragged, follow the mouse
        if(dragging){
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    //When the mouse is down on the unit, set dragging to true
    private void OnMouseDown() {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp() {
        //If the unit is on an empty space when the mouse is released, leave it there
        if(onEmptySpace == true){
            dragging = false;
        }
        //If the unit is not on an empty space when the mouse is released, snap back to the initial position
        else {
            this.transform.position = new Vector2(startX, startY);
            dragging = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("PlayerEmptySpace")) {
            onEmptySpace = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        onEmptySpace = false;
    }
}
