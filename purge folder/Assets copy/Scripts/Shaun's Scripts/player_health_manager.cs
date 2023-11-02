using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_health : MonoBehaviour
{  
    //player loss boolean
    private bool player_is_sunk = false;
    //script input values for damage
    public float damage;
    
     //variables for player health
    public Image player_ship_healthbar;
    public float player_ship_health = 150f;
    private float level_1_ship_health = 150f;

    //variables for player units
    public Image healthbar_player_unit_1;
    public Image healthbar_player_unit_2;
    public Image healthbar_player_unit_3;
    public float player_unit_1_health = 10f;
    public float player_unit_2_health = 10f;
    public float player_unit_3_health = 10f;

    private float level_1_unit_health = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void player_ship_takedamage_on_collision(Collision collision){

        if(collision.gameObject.tag == "player_ship"){
        player_ship_health -= damage;
        player_ship_healthbar.fillAmount =  player_ship_health / level_1_ship_health;
            if(player_ship_health <= 0){
                player_is_sunk = true;
            }
        }

    }

    public void player_units_takedamage_on_collision(Collision collision){
        if(collision.gameObject.tag == "player_unit_1"){
            player_unit_1_health -= damage;
            healthbar_player_unit_1.fillAmount = player_unit_1_health / level_1_unit_health;
        }
        if(collision.gameObject.tag == "player_unit_2"){
            player_unit_1_health -= damage;
            healthbar_player_unit_2.fillAmount = player_unit_2_health / level_1_unit_health;
        }
        if(collision.gameObject.tag == "player_unit_3"){
            player_unit_1_health -= damage;
            healthbar_player_unit_3.fillAmount = player_unit_3_health / level_1_unit_health;
        }
    }

}
