using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    public PlayerUnitTargeting playerUnitTargeting;
    public GameObject startBattle;
    public bool isBossFight = false;
    public GameObject[] playerUnits;
    public Canvas placeUnits;
    public Canvas endBattle;
    public bool startEnemyFiring = false;
    private int numUnits = 0;
    public int numEnemies = 0;
    private int numChecked = 0;
    public int numDestroyed = 0;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        startBattle.SetActive(false);
        endBattle.enabled = false;
        playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        foreach(GameObject unit in playerUnits){
            numUnits = numUnits + 1; 
        }
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
        if(numEnemies == numDestroyed && isBossFight == false)
        {
            SceneManager.LoadScene("OverworldMapPostBattle");
        }
    }

    public void StartBattle() {
        placeUnits.enabled = false;
        endBattle.enabled = true;
        startEnemyFiring = true;
    }
}
