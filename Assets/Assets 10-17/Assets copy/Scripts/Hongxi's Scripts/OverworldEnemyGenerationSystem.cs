using System.Collections.Generic;
using UnityEngine;

public class OverworldEnemyGenerationSystem: MonoBehaviour {
   private static OverworldEnemyGenerationSystem mInstance;

   public OverworldEnemyGenerationSystem Instance {
      get {
         if(mInstance == null) {

            mInstance = new OverworldEnemyGenerationSystem();
         }

         return mInstance;
      }
   }

   private static GameObject enemyShipObject;
   private static GameObject overWorldMap;
   private static Dictionary<Transform, Vector2> allEnemyPosandAttri;

   public static void Generate() {
      foreach(var pa in allEnemyPosandAttri) {

         var temp = Instantiate(enemyShipObject, pa.Key.position, pa.Key.rotation, overWorldMap.transform);

         assignEnemyAttri(temp, pa.Value);
      }
   }

   public static void assignEnemyAttri(GameObject enemyShipUnit, Vector2 attriInterval) {
      //Assign Attributes to all Enemies in every ship
      //Call EnemyList in Ship Class maybe

      //foreach(var e in enemyShipUnit.allUnit) {
      //   e.attri=Random.Range(attriInterval.x, attriInterval.y);
      //}

      Debug.Log("Assign Random Attributes to Enemyies on Ship!");
   }
}
