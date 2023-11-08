using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitTargeting : MonoBehaviour
{
    public bool isTargeted = false;
    // Start is called before the first frame update
    void Start()
    {
        BattleManager.instance.numEnemies++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
