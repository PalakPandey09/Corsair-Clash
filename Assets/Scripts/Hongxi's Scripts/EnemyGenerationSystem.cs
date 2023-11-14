using System.Collections.Generic;
using UnityEngine;


public class EnemyGenerationSystem: MonoBehaviour {
   private static EnemyGenerationSystem mInstance;

   public static EnemyGenerationSystem Instance {
      get {
         if(mInstance == null) {

            mInstance = new EnemyGenerationSystem();
         }

         return mInstance;
      }
   }

   public List<GameObject> EnemyShips = new List<GameObject>();

   public GameObject enemyShipParent;

   private void Start() {
      enemyShipParent = GameObject.FindGameObjectWithTag("EnemyShipParent");

      if(enemyShipParent == null) {
         enemyShipParent = new GameObject();
         enemyShipParent.tag = "EnemyShipParent";
      }

      GenerateEnemies();
   }

   public void GenerateEnemies() {
      var index = 0;
      //foreach
      for(; index < EnemyShips.Count; index++) {
         if(EnemyShips[index] != null) {
            Instantiate(EnemyShips[index], enemyShipParent.transform);
         }
      }
   }
}