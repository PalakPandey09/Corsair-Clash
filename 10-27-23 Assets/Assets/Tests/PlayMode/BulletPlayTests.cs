using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BulletPlayTests
{
    public GameObject[] bulletList;
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator BulletPlayTestWithEnumeratorPasses()
    {
        float spacer = 0.1f;
        int bullets = 3000;
        int numPlaced = 0;
        int numRemaining = 0;

        GameObject PlayerBullet1 = Resources.Load<GameObject>("PlayerBullet1");

        for(int i = 0; i < bullets; i++){

            Vector3 randomPosition = new Vector3(Random.Range(-(spacer * i),(spacer * i)),Random.Range((spacer * i),(spacer * i)));    
        
            GameObject bullet_instantiate = GameObject.Instantiate(PlayerBullet1, randomPosition, Quaternion.identity);
            numPlaced++;

            yield return null;
        }
        bulletList = GameObject.FindGameObjectsWithTag("Bullet");
        foreach(GameObject instBullet in bulletList)
        {
            numRemaining++;
        }

        Debug.Log("Number of Bullets Placed: " + numPlaced);
        Debug.Log("Number of Bullets After Collision: " + numRemaining);

        Assert.IsTrue(numRemaining < numPlaced);
    }
}

