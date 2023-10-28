using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        if(target.position.x > -1.66 && target.position.x < 24.66){
            transform.position = new Vector3(target.position.x, transform.position.y, -10);
        }
    }
}
