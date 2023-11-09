using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitTargeting : MonoBehaviour
{
    public float targetX = 0f;
    public float targetY = 0f;
    private float spawnX = 0;
    private float spawnY = 0;
    public EnemyUnitTargeting enemyUnitTargeting;
    private AudioSource audioSource;
    public bool foundTarget = false;
    public Canvas PlaceUnitsCanvas;
    public GameObject[] enemyUnits;
    public GameObject PlayerBullet1;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
    }

    // Update is called once per frame
    void Update()
    {
        enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        if(PlaceUnitsCanvas.enabled == false && foundTarget == false) {
            float[] speeds = new float[3] {2.5f, 3.0f, 3.5f};
            float randomSpeed = speeds[Random.Range(0, speeds.Length)];
            int randomTarget = Random.Range(0, enemyUnits.Length);
            GameObject eUnit = enemyUnits[randomTarget];
            targetX = eUnit.transform.position.x;
            targetY = eUnit.transform.position.y;
            //enemyUnitTargeting.isTargeted = true;
            foundTarget = true;
            InvokeRepeating("FireOnEnemy", randomSpeed, randomSpeed);
            return;
        }
    }     

    void FireOnEnemy(){
        //enemyUnitTargeting = null;
        audioSource.volume = 0.5f;
        audioSource.Play();
        Debug.Log("Unit: " + this.name + " firing on " + targetX + " ");
        spawnX = gameObject.GetComponent<DragNDrop>().startX;
        spawnY = gameObject.GetComponent<DragNDrop>().startY;
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(); 
        if (bullet != null) {
            bullet.transform.position = new Vector2(this.transform.position.x, this.transform.position.y+0.4f);
            bullet.transform.rotation = Quaternion.Euler(new Vector3(targetX, targetY, 0));
            bullet.SetActive(true);
        }
        //GameObject bullet;
        //bullet = Instantiate(PlayerBullet1, new Vector2(this.transform.position.x, this.transform.position.y+0.4f), Quaternion.Euler(new Vector3(targetX, targetY, 0)));
        bullet.GetComponentInChildren<BulletManager>().enemyX = targetX;
        bullet.GetComponentInChildren<BulletManager>().enemyY = targetY;
        enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        int randomTarget = Random.Range(0, enemyUnits.Length);
        GameObject eUnit = enemyUnits[randomTarget];
        targetX = eUnit.transform.position.x;
        targetY = eUnit.transform.position.y;
    }
}

