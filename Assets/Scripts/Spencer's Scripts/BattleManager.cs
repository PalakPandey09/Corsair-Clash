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
    public int numUnits = 0;
    public int numEnemies = 0;
    public int numChecked = 0;
    public int numDestroyed = 0;
    public int numPlayersDestroyed = 0;
    public int isWon = 0;
    public int isLost = 0;
    private void Awake()
    {
        //Makes sure only one instance is active
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Activates the place units menu
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
        //Once all player units are set, it sets the start battle button to active
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
        //If all enemies are destroyed before the player units are, sets the win condition to true.
        if(numEnemies == numDestroyed && isBossFight == false)
        {
            isWon = 1;
        }
        //If all player units are destroyed before the enemy units are, quits the application.
        if(numUnits == numPlayersDestroyed)
        {
            Application.Quit();
        }
    }

    public void StartBattle() {
        Debug.Log("Starting Battle");
        placeUnits.enabled = false;
        endBattle.enabled = true;
        startEnemyFiring = true;
    }
    //This virtual method has a base scene change of the overworld map after a battle
    public virtual void ChangeScene()
    {
        SceneManager.LoadScene("OverworldMapPostBattle");
    }
}


