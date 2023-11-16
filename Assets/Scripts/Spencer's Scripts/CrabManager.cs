using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class is a Sub Class of BattleManager
public class CrabManager : BattleManager
{
    public GameObject body;
    public GameObject[] claws;
    public GameObject bodyHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        //Sets the claws to be active and the body to be hidden
        body.SetActive(false);
        bodyHealth.SetActive(false);
        startBattle.SetActive(false);
        endBattle.enabled = false;
        playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        foreach(GameObject unit in playerUnits){
            numUnits = numUnits + 1; 
        }
        claws = GameObject.FindGameObjectsWithTag("EnemyUnit");
    }

    // Update is called once per frame
    void Update()
    {
        numChecked = 0;
        foreach(GameObject unit in playerUnits){
            if(unit.transform.position.x < 4){
                numChecked = numChecked + 1;
            }
        }
        if(numChecked == numUnits) {
            startBattle.SetActive(true);
        }
        if(numChecked != numUnits) {
            startBattle.SetActive(false);
        }
        //Once the claws are destroyed, activate the body
        if(numDestroyed == 2)
        {
            BodyUp();
        }
        //Once the body is destroyed, sets the win condition to true.
        if(numDestroyed == 3)
        {
            isWon = 1;
        }
    }

    public void BodyUp() {
        body.SetActive(true);
        bodyHealth.SetActive(true);
    }

    //This method overrides the BattleManager change scene to be the Overworld Map after the boss battle.
    public override void ChangeScene()
    {
        base.ChangeScene();
        SceneManager.LoadScene("postcrabfinalscene");
    }
}