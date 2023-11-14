using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSceneController : MonoBehaviour
{
    //Sets the static type of BattleManager
    public BattleManager battleManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Once the battlemanager has the win condition set to true, changes the scene
        if(battleManager.isWon == 1)
        {
            battleManager.ChangeScene();
        }
    }
}
