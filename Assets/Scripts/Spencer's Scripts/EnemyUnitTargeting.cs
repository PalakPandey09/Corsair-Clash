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
         float[] speeds = new float[3] { 2.5f, 3.0f, 3.5f };
         float randomSpeed = speeds[Random.Range(0, speeds.Length)];
         if(status == Status.Targeting) {
            GameObject pUnit = Target();
            targetX = pUnit.transform.position.x;
            targetY = pUnit.transform.position.y;
         }
         //enemyUnitTargeting.isTargeted = true;
         foundTarget = true;
         InvokeRepeating("FireOnPlayer", randomSpeed, randomSpeed);
         return;
      }

      if(status == Status.Die) {
         Destroy(gameObject);
      }
   }

   void FireOnPlayer() {
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
      spawnX = this.gameObject.transform.position.x;
      spawnY = this.gameObject.transform.position.y;
      GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
      if(bullet != null) {
         if(status ==Status.Attacking) {
            Attack(targetX, targetY, bullet);
         }
      }
      //GameObject bullet;
      //bullet = Instantiate(PlayerBullet1, new Vector2(this.transform.position.x, this.transform.position.y-0.4f), Quaternion.Euler(new Vector3(targetX, targetY, 0)));
      bullet.GetComponentInChildren<BulletManager>().enemyX = targetX;
      bullet.GetComponentInChildren<BulletManager>().enemyY = targetY;
      GameObject pUnit = Target();
      targetX = pUnit.transform.position.x;
      targetY = pUnit.transform.position.y;
   }
}