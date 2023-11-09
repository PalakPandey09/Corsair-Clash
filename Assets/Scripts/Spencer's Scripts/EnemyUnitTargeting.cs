using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitTargeting : MonoBehaviour
{
    public float targetX = 0f;
    public float targetY = 0f;
    private float spawnX = 0;
    private float spawnY = 0;
    private AudioSource audioSource;
    public bool foundTarget = false;
    public Canvas PlaceUnitsCanvas;
    public GameObject[] playerUnits;
    public GameObject PlayerBullet1;
    // Start is called before the first frame update
    void Start()
    {
        BattleManager.instance.numEnemies++;
        audioSource = GetComponent<AudioSource>();
        playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
    }

    // Update is called once per frame
    void Update()
    {
        playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        if(PlaceUnitsCanvas.enabled == false && foundTarget == false) {
            float[] speeds = new float[3] {2.5f, 3.0f, 3.5f};
            float randomSpeed = speeds[Random.Range(0, speeds.Length)];
            int randomTarget = Random.Range(0, playerUnits.Length);
            GameObject pUnit = playerUnits[randomTarget];
            targetX = pUnit.transform.position.x;
            targetY = pUnit.transform.position.y;
            //enemyUnitTargeting.isTargeted = true;
            foundTarget = true;
            InvokeRepeating("FireOnPlayer", randomSpeed, randomSpeed);
            return;
        }
    }
    void FireOnPlayer(){
        audioSource.volume = 0.5f;
        audioSource.Play();
        Debug.Log("Unit: " + this.name + " firing on " + targetX + " ");
        spawnX = this.gameObject.transform.position.x;
        spawnY = this.gameObject.transform.position.y;
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null) {
            bullet.transform.position = new Vector2(this.transform.position.x, this.transform.position.y-0.4f);
            bullet.transform.rotation = Quaternion.Euler(new Vector3(targetX, targetY, 0));
            bullet.SetActive(true);
        }
        //GameObject bullet;
        //bullet = Instantiate(PlayerBullet1, new Vector2(this.transform.position.x, this.transform.position.y-0.4f), Quaternion.Euler(new Vector3(targetX, targetY, 0)));
        bullet.GetComponentInChildren<BulletManager>().enemyX = targetX;
        bullet.GetComponentInChildren<BulletManager>().enemyY = targetY;
        playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        int randomTarget = Random.Range(0, playerUnits.Length);
        GameObject pUnit = playerUnits[randomTarget];
        targetX = pUnit.transform.position.x;
        targetY = pUnit.transform.position.y;
    }
}
