using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitTargeting: EnemyAI {
   public float targetX = 0f;
   public float targetY = 0f;
   private float spawnX = 0;
   private float spawnY = 0;
   private AudioSource audioSource;
   public AudioClip gunshot;
   public AudioClip boom;
   public int levelOfUnit;
   public bool foundTarget = false;
   public Canvas PlaceUnitsCanvas;
   public GameObject PlayerBullet1;
   // Start is called before the first frame update
   private new void Start() {
        base.Start();
        BattleManager.instance.numEnemies++;
        audioSource = GetComponent<AudioSource>();
   }

   // Update is called once per frame
   void Update() {
      if(PlaceUnitsCanvas.enabled == false && foundTarget == false) {
         //This chooses a random firing speed for each unit
         float[] speeds = new float[3] { 2.5f, 3.0f, 3.5f };
         float randomSpeed = speeds[Random.Range(0, speeds.Length)];
         if(status == Status.Targeting) {
            GameObject pUnit = Target();
            targetX = pUnit.transform.position.x;
            targetY = pUnit.transform.position.y;
         }
         //when a target is found, start firing
         foundTarget = true;
         InvokeRepeating("FireOnPlayer", randomSpeed, randomSpeed);
         return;
      }

      if(status == Status.Die) {
         Destroy(gameObject);
      }
   }

   void FireOnPlayer() {
      //Choose a new player unit to fire on randomly each shot
      GameObject pUnit = Target();
      targetX = pUnit.transform.position.x;
      targetY = pUnit.transform.position.y;
      audioSource.volume = 0.5f;
      float randomChance = Random.Range(0, 100);
      if(randomChance == 99) {
         audioSource.clip = boom;
         audioSource.volume = 0.75f;
      }
      else {
         audioSource.clip = gunshot;
         audioSource.volume = 0.5f;
      }
      audioSource.Play();
      Debug.Log("Unit: " + this.name + " firing on " + targetX + " ");
      //Sets where the bullet instantiated will spawn
      spawnX = this.gameObject.transform.position.x;
      spawnY = this.gameObject.transform.position.y;
      //If there is a bullet in the pool, spawn one below the unit
      GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
      if(bullet != null) {
         if(status ==Status.Attacking) {
            Attack(targetX, targetY, bullet);
         }
      }
      bullet.GetComponentInChildren<BulletManager>().enemyX = targetX;
      bullet.GetComponentInChildren<BulletManager>().enemyY = targetY;
      //Sets the damage and speed of bullet depending on the level
        if(levelOfUnit == 1){
            bullet.GetComponentInChildren<BulletManager>().bulletDamage = 1f;
            bullet.GetComponentInChildren<BulletManager>().bulletSpeed = 3f;
        }
        else if(levelOfUnit == 2){
            bullet.GetComponentInChildren<BulletManager>().bulletDamage = 2f;
            bullet.GetComponentInChildren<BulletManager>().bulletSpeed = 4f;
        }
        else if(levelOfUnit == 3){
            bullet.GetComponentInChildren<BulletManager>().bulletDamage = 3f;
            bullet.GetComponentInChildren<BulletManager>().bulletSpeed = 5f;
        }
        else if(levelOfUnit == 4){
            bullet.GetComponentInChildren<BulletManager>().bulletDamage = 7f;
            bullet.GetComponentInChildren<BulletManager>().bulletSpeed = 2f;
        }
        else if(levelOfUnit == 5){
            bullet.GetComponentInChildren<BulletManager>().bulletDamage = 10f;
            bullet.GetComponentInChildren<BulletManager>().bulletSpeed = 1f;
        }
    }
}