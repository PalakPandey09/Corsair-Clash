using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitTargeting : MonoBehaviour
{
    public float targetX = 0f;
    public float targetY = 0f;
    
    private int numEnemyUnits = 0;
    private int numCycles = 1;
    private float spawnX = 0;
    private float spawnY = 0;
    public EnemyUnitTargeting enemyUnitTargeting;
    public bool foundTarget = false;
    public Canvas PlaceUnitsCanvas;
    public GameObject[] enemyUnits;
    public GameObject enemyUnit;
    public GameObject PlayerBullet1;
    // Start is called before the first frame update
    void Start()
    {
        enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        enemyUnit = GameObject.FindGameObjectWithTag("EnemyUnit");
        foreach(GameObject eUnit in enemyUnits){
            numEnemyUnits = numEnemyUnits + 1; 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numCycles == numEnemyUnits){
            foreach(GameObject eUnit in enemyUnits){
                enemyUnitTargeting = eUnit.GetComponent<EnemyUnitTargeting> ();
                enemyUnitTargeting.isTargeted = false;
            }
            numCycles = 1;
        }
        //Debug.Log(numCycles);
        //for(int i = 0; i < numEnemyUnits)
        if(PlaceUnitsCanvas.enabled == false && foundTarget == false) {
            foreach (GameObject eUnit in enemyUnits){
                enemyUnitTargeting = eUnit.GetComponent<EnemyUnitTargeting> ();
                if(enemyUnitTargeting.isTargeted == false){
                    float[] speeds = new float[3] {2.5f, 3.0f, 3.5f};
                    float randomSpeed = speeds[Random.Range(0, speeds.Length)];
                    targetX = eUnit.transform.position.x;
                    targetY = eUnit.transform.position.y;
                    enemyUnitTargeting.isTargeted = true;
                    foundTarget = true;
                    InvokeRepeating("FireOnEnemy", randomSpeed, randomSpeed);
                    return;
                }
                if(enemyUnitTargeting.isTargeted == true){
                    numCycles++;
                }
            }
        }        
    }

    void FireOnEnemy(){
        enemyUnitTargeting = null;
        Debug.Log("Unit: " + this.name + " firing on " + targetX + " ");
        spawnX = gameObject.GetComponent<DragNDrop>().startX;
        spawnY = gameObject.GetComponent<DragNDrop>().startY;
        GameObject bullet;
        bullet = Instantiate(PlayerBullet1, new Vector2(this.transform.position.x, this.transform.position.y+0.4f), Quaternion.Euler(new Vector3(targetX, targetY, 0)));
                bullet.GetComponentInChildren<BulletManager>().enemyX = targetX;
                bullet.GetComponentInChildren<BulletManager>().enemyY = targetY;
    }
}

