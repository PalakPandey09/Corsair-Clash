﻿/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_health_original : MonoBehaviour
{
   
    //script input values for damage
    public float damage = 5;
    public GameObject connectedBar;
    //public BattleManager battleManager;
     //variables for enemy health
    public Image enemy_ship_healthbar;
    public float enemy_ship_health = 150f;
    public float level_1_ship_health = 150f;

    //variables for player units
    public Image healthbar_enemy_unit_1;
    public Image healthbar_enemy_unit_2;
    public Image healthbar_enemy_unit_3;
    public float enemy_unit_1_health = 10f;
    public float enemy_unit_2_health = 10f;
    public float enemy_unit_3_health = 10f;

    public float level_1_unit_health = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy_unit_1_health <= 0)
        {
            BattleManager.instance.numDestroyed++;
            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);
            connectedBar.SetActive(false);
        }
    }

    public void enemy_ship_takedamage_on_collision(Collision collision){

        if(collision.gameObject.tag == "enemy_ship"){
            enemy_ship_health -= damage;
            enemy_ship_healthbar.fillAmount =  enemy_ship_health / level_1_ship_health;
                if(enemy_ship_health <= 0){
                    
                }
        }

    }

    public void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Damage: " + damage + " Health: " + enemy_unit_1_health);
        if(collision.gameObject.CompareTag("Bullet")){
            enemy_unit_1_health -= damage;
            healthbar_enemy_unit_1.fillAmount = enemy_unit_1_health / level_1_unit_health;
        }
        if(collision.gameObject.tag == "enemy_unit_1"){
            enemy_unit_1_health -= damage;
            healthbar_enemy_unit_1.fillAmount = enemy_unit_1_health / level_1_unit_health;
        }
        if(collision.gameObject.tag == "enemy_unit_2"){
            enemy_unit_2_health -= damage;
            healthbar_enemy_unit_2.fillAmount = enemy_unit_2_health / level_1_unit_health;
        }
        if(collision.gameObject.tag == "enemy_unit_3"){
            enemy_unit_3_health -= damage;
            healthbar_enemy_unit_3.fillAmount = enemy_unit_3_health / level_1_unit_health;
        }
    }

}
*/
