using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dailougetrigger : MonoBehaviour
{

    public Dailouge dailouge;

    public void TriggerDailouge()
    {
        FindObjectOfType<DailougeManager>().StartDailouge(dailouge);
    }

}