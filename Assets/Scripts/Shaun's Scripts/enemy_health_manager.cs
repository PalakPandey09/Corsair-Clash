using System.Collections;
using System.Collections.Generic;
using log4net.Core;
using UnityEngine;
using UnityEngine.UI;

public class enemy_health_manager : MonoBehaviour
{
    //class that creates enemies with their level appropriate health bars
    public class enemy_health_bar
    {   
        //audio source
        private AudioSource audioSource;
        //establishes the canvas that the image will fill
        private GameObject canvas;
        // Load the image from prefab folder
        Image health_bar = Resources.Load("Assets/Resources/health_bar.prefab") as Image;
        
        
        //enemy health to be assigned
        private float enemy_health;
        //determines what unit level health is assigned
        public int unit_levels;
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
            //creates a canvas, then loads the health_bar to it.
            GameObject newCanvas = Instantiate(canvas) as GameObject;
            Image canvas_health_bar = Instantiate(health_bar);
            canvas_health_bar.transform.SetParent(newCanvas.transform, true);
            
            //removes health when unit dies
            if(enemy_health <= 0)
            {
                audioSource.Play();
                canvas.SetActive(false);
            }
            
        }
         
        public void OnCollisionEnter2D(Collision2D collision)
        {
            //takes damage value of collision projectile
            enemy_health -= collision.gameObject.GetComponent<BulletManager>().bulletDamage;
            //updates current health
            health_bar.fillAmount =  enemy_health / current_level;
        }   
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
