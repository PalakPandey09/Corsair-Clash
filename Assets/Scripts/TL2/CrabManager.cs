using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabManager : MonoBehaviour
{
    public GameObject body;
    public GameObject[] claws;
    public GameObject bodyHealth;
    private int numClaws = 0;

    // Start is called before the first frame update
    void Start()
    {
        body.SetActive(false);
        bodyHealth.SetActive(false);
        claws = GameObject.FindGameObjectsWithTag("EnemyUnit");
        
        foreach(GameObject claw in claws){
            numClaws = numClaws + 1; 
        }
        Debug.Log(numClaws);
    }

    // Update is called once per frame
    void Update()
    {
        numClaws = 0;
        foreach(GameObject claw in claws){
            numClaws++;
        }
        if(numClaws == 0)
        {
            BodyUp();
        }
    }

    public void BodyUp() {
        body.SetActive(true);
        bodyHealth.SetActive(true);
    }
}
