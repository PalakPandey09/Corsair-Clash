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
        startX = this.transform.position.x;
        startY = this.transform.position.y;
        this.transform.position = new Vector2(startX, startY);
    }

    // Update is called once per frame
    void Update()
    {
        if(dragging){
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown() {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp() {
        if(onEmptySpace == true){
            dragging = false;
        }
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
