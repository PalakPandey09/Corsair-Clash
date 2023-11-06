using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrabManager : MonoBehaviour
{
    public GameObject body;
    public BattleManager battleManager;
    public GameObject[] claws;
    public GameObject bodyHealth;
    private int numClaws = 0;

    // Start is called before the first frame update
    void Start()
    {
        body.SetActive(false);
        bodyHealth.SetActive(false);
        claws = GameObject.FindGameObjectsWithTag("EnemyUnit");
        //Debug.Log(numClaws);
    }

    // Update is called once per frame
    void Update()
    {
        if(battleManager.numDestroyed == 2)
        {
            BodyUp();
        }
        if(battleManager.numDestroyed == 3)
        {
            SceneManager.LoadScene("OverworldMapPostBoss");
        }
    }

    public void BodyUp() {
        body.SetActive(true);
        bodyHealth.SetActive(true);
    }
}
