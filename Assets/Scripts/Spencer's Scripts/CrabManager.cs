using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrabManager : BattleManager
{
    public GameObject body;
    public GameObject[] claws;
    public GameObject bodyHealth;
    
    // Start is called before the first frame update
    void Start()
    {
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
        if(numDestroyed == 2)
        {
            BodyUp();
        }
        if(numDestroyed == 3)
        {
            ChangeScene();
        }
    }

    public void BodyUp() {
        body.SetActive(true);
        bodyHealth.SetActive(true);
    }

    public override void ChangeScene()
    {
        base.ChangeScene();
        SceneManager.LoadScene("OverworldMapPostBoss");
    }
}