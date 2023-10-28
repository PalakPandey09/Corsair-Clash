using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
//using UnityEditor;
using UnityEngine.TestTools;

public class HealthStressTest
{
    

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator HealthStressTestWithEnumeratorPasses()
    {
        float spacer = 0.1f;
        int number_of_objects = 5000;
       
        //GameObject health_image = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Health_Bar.prefab");

        GameObject health_image = Resources.Load<GameObject>("Health_Bar");

        for(int i = 0; i < number_of_objects; i++){

            Vector3 randomPosition = new Vector3(Random.Range(-(spacer * i),(spacer * i)),Random.Range((spacer * i),(spacer * i)));    
        
            GameObject health_image_instantiate = GameObject.Instantiate(health_image, randomPosition, Quaternion.identity);

            yield return null;
        }



    }
}
