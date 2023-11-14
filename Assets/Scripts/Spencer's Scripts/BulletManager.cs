using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float bulletDamage = 0;
    public float bulletSpeed = 1;
    public Vector2 projectileDirection;
    public float enemyX = 0;
    public float enemyY = 0;

    void Awake () 
    {
        
    }

    void Update ()
    {
        //Moves towards the target direction in the Targeting script
        projectileDirection = new Vector2(enemyX, enemyY);
        transform.position = Vector2.MoveTowards(transform.position, projectileDirection, bulletSpeed * Time.deltaTime);
        if(this.gameObject.transform.position.x == enemyX && this.gameObject.transform.position.y == enemyY)
        {
            //Destroys the bullet if it has reached it's target without colliding with anything
            this.gameObject.SetActive(false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
       //Destroyes the bullet when it collides with something
       this.gameObject.SetActive(false);
    }
}
