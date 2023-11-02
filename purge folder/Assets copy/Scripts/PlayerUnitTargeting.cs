using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitTargeting : MonoBehaviour
{
    public double targetX = 0;
    public double targetY = 0;
    private int numEnemyUnits = 0;
    private int numCycles = 0;
    public EnemyUnitTargeting enemyUnitTargeting;
    public bool foundTarget = false;
    public Canvas PlaceUnitsCanvas;
    public GameObject[] enemyUnits;
    public GameObject enemyUnit;
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
        }
        numCycles = 0;
        //for(int i = 0; i < numEnemyUnits)
        if(PlaceUnitsCanvas.enabled == false && foundTarget == false) {
            foreach (GameObject eUnit in enemyUnits){
                enemyUnitTargeting = eUnit.GetComponent<EnemyUnitTargeting> ();
                if(enemyUnitTargeting.isTargeted == false){
                    targetX = eUnit.transform.position.x;
                    targetY = eUnit.transform.position.y;
                    enemyUnitTargeting.isTargeted = true;
                    foundTarget = true;
                    InvokeRepeating("FireOnEnemy", 3.0f, 3.0f);
                    return;
                }
                if(enemyUnitTargeting.isTargeted == true){
                    numCycles++;
                }
            }
        }        
    }

    void FireOnEnemy(){
        Debug.Log("Unit: " + this.name + " firing on " + targetX + " ");
    }
}

