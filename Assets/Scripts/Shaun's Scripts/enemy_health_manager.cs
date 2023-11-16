using UnityEngine;
using UnityEngine.UI;

public class enemy_health_manager : MonoBehaviour
{       //canvas for health bar
        public GameObject canvas;
        //health bar
        public Image health_bar;
        private Image connected_bar;
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
           EnemyUnitTargeting playerUnitTargeting= gameObject.GetComponent<EnemyUnitTargeting>();
           unit_levels = playerUnitTargeting.levelOfUnit;
           //switch statement checks for current player health
           //and then assigns its health in accordance to each level
           switch (unit_levels)
           {
                case 1:
                    enemy_health = unit_1;
                    current_level = unit_1;
                    break;
                case 2:
                    enemy_health = unit_2;
                    current_level = unit_2;
                    break;
                case  3:
                    enemy_health = unit_3;
                    current_level = unit_3;
                    break;
                case 4:
                    enemy_health = unit_4;
                    current_level = unit_4;
                    break;
                case 5:
                    enemy_health = unit_5;
                    current_level = unit_5;
                    break;
                default:
                    Debug.Log("Switch does not work");
                    break;
           }
            
        }
    

    public void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Bullet"))
            {
                //takes damage value of collision projectile
                enemy_health -= collision.gameObject.GetComponent<BulletManager>().bulletDamage;
                //updates current health
                Image filled_bar = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
                filled_bar.fillAmount =  enemy_health / current_level;
            }
            else
            {
                Debug.Log("collision does not work");
            }
        }

    
    // awake is called before the first frame update
    void Start()
    {   
        canvas.SetActive(true);
        unit_health();
        //creates canvas
        GameObject newCanvas = Instantiate(canvas);
        if (newCanvas != null)
        {
            newCanvas.GetComponent<Canvas>().worldCamera = Camera.main;
            Debug.Log("new canvas is not null");
        }
        newCanvas.transform.SetParent(gameObject.transform, true);
        //finds position of unit the health bar is attached to
        Debug.Log("4");
        //pulls image prefab 
        Image createImage = Instantiate(health_bar);
        createImage.transform.SetParent(newCanvas.transform, true);
        Debug.Log("1");
        //sets health bar position slightly above its unit
        createImage.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        createImage.transform.localPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y+0.5f);
        connected_bar = createImage;
        Debug.Log("5");
        
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.Log("2");
        //updates position of health bar
        connected_bar.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y+0.5f);
        Debug.Log("3");
        //removes health when unit dies
        if(enemy_health <= 0)
        {
            Debug.Log("enemy health = 0");
            //updates battle manager of enemy death
            BattleManager.instance.numDestroyed++;
            canvas.SetActive(false);
            Destroy(gameObject);
        }
    
            
    }

    
}
