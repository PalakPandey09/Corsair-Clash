using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBackup : MonoBehaviour
{
    public GameObject canvas;
    // Load the image from prefab folder
    public Image health_bar;
    private Image connected_bar;
    private float player_health;
    private float max_health;
    public int unitLevel = 5;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(true);
        unitLevel = this.gameObject.GetComponent<PlayerUnitTargeting>().levelOfUnit;
        if(unitLevel == 1)
        {
            player_health = 10f;
            max_health = 10f;
        }
        else if(unitLevel == 2)
        {
            player_health = 15f;
            max_health = 15f;
        }
        else if(unitLevel == 3)
        {
            player_health = 20f;
            max_health = 20f;
        }
        else if(unitLevel == 4)
        {
            player_health = 25f;
            max_health = 25f;
        }
        else if(unitLevel == 5)
        {
            player_health = 30f;
            max_health = 30f;
        }
        GameObject newCanvas = Instantiate(canvas) as GameObject;
        if (newCanvas != null)
        {
            newCanvas.GetComponent<Canvas>().worldCamera = Camera.main;
        }
        newCanvas.transform.SetParent(this.gameObject.transform, true);
        Image canvas_health_bar = Instantiate(health_bar);
        canvas_health_bar.transform.SetParent(newCanvas.transform, true);
        canvas_health_bar.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        canvas_health_bar.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y+0.5f);
        connected_bar = canvas_health_bar;
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the health bar with the player unit every frame.
        connected_bar.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y+0.5f);
        if(player_health <= 0)
        {
            //When a unit is defeated, it is destroyed
            canvas.SetActive(false);
            BattleManager.instance.numPlayersDestroyed++;
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Takes damage and updates the health bar when colliding with a bullet
        if(collision.gameObject.tag == "Bullet")
        {
            player_health -= collision.gameObject.GetComponent<BulletManager>().bulletDamage;
        }
        Image filled_bar = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        filled_bar.fillAmount =  player_health / max_health;
    } 
}
