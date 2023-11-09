using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI: MonoBehaviour {
   private enum Status {
      Die = 0,
      Attacking = 1,
      Targeting = 10,
   }
   void Start(){
      status = Status.Attacking;
      Target();
      Attack(target);
      //InvokeRepeating("Attack", 3.0f, 3.0f);
   }
   //public BattleManager battleManager;
   private Status status;
   //Change GameObject to PlayerUnit after PlayerUnit implemented
   public GameObject target= new GameObject();
   public GameObject[] allPlayerUnits;

   // <summary>
   // One of Strategy can be taken by Enemy Unit.
   // Select a player unit as attack target.
   // </summary>
   public void Target() {
      if(target == null && status == Status.Attacking) {

         status = Status.Targeting;

         //Could Add Delay
         
      GameObject playerUnit1 = new GameObject();
      GameObject playerUnit2 = new GameObject();
      playerUnit1.tag = "PlayerUnit";
      playerUnit2.tag = "PlayerUnit";

         allPlayerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");

         if(allPlayerUnits.Length > 0) {
            // target = allPlayerUnits[Random.Range(0, allPlayerUnits.Length+1)];
            // target=playerUnit1;
         }
      }
      return;
   }

   // <summary>
   // One of Strategy can be taken by Enemy Unit.
   // Attack given target variable.
   // </summary>
   // <param name="target"></param>
   private void Attack(GameObject target) {
      if(target != null) {
         //Send Message or Has Reference to Player Unit and call TakeDamage
         Debug.Log(gameObject.name + " EnemyUnit Attack!: " + target.name);
      }
      if(target == null) {
         Debug.Log("No Target");
      }
   }

}