using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBackup : MonoBehaviour
{
    public GameObject canvas;
    // Load the image from prefab folder
    public Image health_bar;
    private float enemy_health;
    private float max_health;
    public int unitLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(true);
        if(BattleManager.instance.isBossFight == false){
            unitLevel = this.gameObject.GetComponent<EnemyUnitTargeting>().levelOfUnit;
            if(unitLevel == 1)
            {
                enemy_health = 10f;
                max_health = 10f;
            }
            else if(unitLevel == 2)
            {
                enemy_health = 15f;
                max_health = 15f;
            }
            else if(unitLevel == 3)
            {
                enemy_health = 20f;
                max_health = 20f;
            }
            else if(unitLevel == 4)
            {
                enemy_health = 25f;
                max_health = 25f;
            }
            else if(unitLevel == 5)
            {
                enemy_health = 30f;
                max_health = 30f;
            }
        }
        else if(BattleManager.instance.isBossFight == true){
            enemy_health = 35f;
            max_health = 35f;
        }

        GameObject newCanvas = Instantiate(canvas) as GameObject;
        //Canvas canvas = gameObject.GetComponent<Canvas>();
        if (newCanvas != null)
        {
            newCanvas.GetComponent<Canvas>().worldCamera = Camera.main;
        }
        if(BattleManager.instance.isBossFight == false){
            newCanvas.GetComponent<Canvas>().sortingLayerID = SortingLayer.NameToID("Above");
            newCanvas.transform.SetParent(this.gameObject.transform, true);
            Image canvas_health_bar = Instantiate(health_bar);
            canvas_health_bar.transform.SetParent(newCanvas.transform, true);
            canvas_health_bar.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            canvas_health_bar.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y+0.5f);
        }
        else{
            newCanvas.GetComponent<Canvas>().sortingLayerID = SortingLayer.NameToID("Above");
            //newCanvas.transform.position = new Vector3(0,0,0);
            newCanvas.transform.SetParent(this.gameObject.transform, true);
            Image canvas_health_bar = Instantiate(health_bar);
            //canvas_health_bar.transform.position = new Vector3(0,0,0);
            canvas_health_bar.transform.SetParent(newCanvas.transform, true);
            if(this.name != "CrabBody"){
                canvas_health_bar.transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
                canvas_health_bar.transform.position = new Vector2(this.gameObject.transform.position.x+0.8f, this.gameObject.transform.position.y+0.5f);
            }
            else{
                canvas_health_bar.transform.localScale = new Vector3(0.4f, 0.5f, 0.4f);
                canvas_health_bar.transform.position = new Vector2(this.gameObject.transform.position.x-1.23f, this.gameObject.transform.position.y-0.8f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //When a unit is defeated, it is destroyed
        if(enemy_health <= 0)
        {
            canvas.SetActive(false);
            BattleManager.instance.numDestroyed++;
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Takes damage and updates the health bar when colliding with a bullet
        if(collision.gameObject.tag == "Bullet"){
            enemy_health -= collision.gameObject.GetComponent<BulletManager>().bulletDamage;
        }
        Image filled_bar = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        filled_bar.fillAmount =  enemy_health / max_health;
    } 
}
