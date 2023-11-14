using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAI : MonoBehaviour {
   protected enum Status {
      Die = 0,
      Attacking = 1,
      Targeting = 10,
   }

   public virtual GameObject Target() {
      Debug.Log("Try to target at Hostile Unit.");

      return new GameObject();
   }

   public virtual void Attack(float targetX, float targetY, GameObject bullet) {
      Debug.Log("Attack Enemy at:("+targetX+", "+targetY+") with "+bullet);
   }

   public static void Die() {
      Debug.Log("This Unit is Dead.");
   }

}
