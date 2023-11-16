using System.Collections;
using System.Collections.Generic;
using log4net.Core;
using UnityEngine;
using UnityEngine.UI;


public class enemy_health_manager : MonoBehaviour
{     
        //game object the health bar sits on
        public GameObject enemy;
        
        
        //audio source
        private AudioSource audioSource;
        public AudioClip death;
        //health bar
        public Image health_bar;
        //enemy health to be assigned
        private float enemy_health;
        //determines what unit level health is assigned
        private int unit_levels;
        //keeps track current unit level;
        private float current_level;
        //unit health per current unit health
        private float unit_1 = 10f;
        private float unit_2 = 15f;
        private float unit_3 = 20f;
        private float unit_4 = 25f;
        private float unit_5 = 30f;
        
        public void unit_health()
        {  
           //gets unit level from object the script is assigned to 
           EnemyUnitTargeting playerUnitTargeting= enemy.GetComponent<EnemyUnitTargeting>();
           unit_levels = playerUnitTargeting.levelOfUnit;
           //switch statement checks for current player health
           //and then assigns its health in accordance to each level
           switch (unit_levels)
           {
                case ( > 0) when unit_levels == 1:
                    enemy_health = unit_1;
                    current_level = unit_1;
                    break;
                case ( > 0) when unit_levels == 2:
                    enemy_health = unit_2;
                    current_level = unit_2;
                    break;
                case ( > 0) when unit_levels == 3:
                    enemy_health = unit_3;
                    current_level = unit_3;
                    break;
                case ( > 0) when unit_levels == 4:
                    enemy_health = unit_4;
                    current_level = unit_4;
                    break;
                case ( > 0) when unit_levels == 5:
                    enemy_health = unit_5;
                    current_level = unit_5;
                    break;
           }
            
        }
    

    public void OnCollisionEnter2D(Collision2D collision)
        {
        //takes damage value of collision projectile
        enemy_health -= collision.gameObject.GetComponent<BulletManager>().bulletDamage;
        //updates current health
        health_bar.fillAmount =  enemy_health / current_level;
        } 
    
    // Start is called before the first frame update
    void Start()
    {   
        unit_health();
        //finds position of unit the health bar is attached to
        Vector3 localPosition = enemy.transform.localPosition;
        //pulls image prefab from resource folder
        Image createImage = Instantiate(health_bar);
        createImage.transform.SetParent(GameObject.Find("Canvas").transform);
        //GameObject.Find("health_bar").SetActive(true);
        //sets health bar position slightly above its unit
        localPosition.y += 1;
        createImage.transform.localPosition = localPosition;
        createImage.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

    }

    // Update is called once per frame
    void Update()
    {


        //removes health when unit dies
        if(enemy_health <= 0)
        {
            audioSource.clip = death;
            audioSource.Play(); 
            //GameObject.Find("health_bar").SetActive(false);
            BattleManager.instance.numPlayersDestroyed++;
            Destroy(this.gameObject);
        }
            
    }

    
}
