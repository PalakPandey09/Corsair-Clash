using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyAI: UnitAI {
   //public BattleManager battleManager;
   protected Status status;
   //Change GameObject to PlayerUnit after PlayerUnit implemented
   public List<GameObject> allPlayerUnits;

   public void Start() {
      status = Status.Targeting;
      //InvokeRepeating("Attack", 3.0f, 3.0f);
   }

   // <summary>
   // One of Strategy can be taken by Enemy Unit.
   // Find all player units can be attacked.
   // </summary>
   public override GameObject Target() {
      //Could Add Delay

      allPlayerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit").ToList<GameObject>();

      //Only For Test
      if(allPlayerUnits.Count == 0) {
         var playerUnit1 = new GameObject();
         var playerUnit2 = new GameObject();
         playerUnit1.tag = "PlayerUnit";
         playerUnit2.tag = "PlayerUnit";
         allPlayerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit").ToList<GameObject>();
      }

      status = Status.Attacking;

      return allPlayerUnits[Random.Range(0, allPlayerUnits.Count)];
   }

   // <summary>
   // One of Strategy can be taken by Enemy Unit.
   // Attack given target variable.
   // </summary>
   // <param name="target"></param>
   public override void Attack(float targetX, float targetY, GameObject bullet) {
      bullet.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.4f);
      bullet.transform.rotation = Quaternion.Euler(new Vector3(targetX, targetY, 0));
      bullet.SetActive(true);
   }

}