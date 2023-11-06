using System.Collections.Generic;
using UnityEngine;

public class OverworldEnemyGenerationSystem: MonoBehaviour {
   private static OverworldEnemyGenerationSystem mInstance;

   public static OverworldEnemyGenerationSystem Instance {
      get {
         if(mInstance == null) {

            mInstance = new OverworldEnemyGenerationSystem();
         }

         return mInstance;
      }
   }

   public GameObject enemyShipObject = new GameObject();
   public GameObject overWorldMap = new GameObject();
   public Dictionary<Vector3, Vector2> allEnemyPosandAttriRange = new Dictionary<Vector3, Vector2>();
   public static List<enemyShipUnit> allEnemyShipUnits = new List<enemyShipUnit>();
   public void Generate() {
      allEnemyPosandAttriRange.Add(new Vector3(1f, 2f, 3f), new Vector2(5f, 6f));
      allEnemyPosandAttriRange.Add(new Vector3(2f, 3f, 4f), new Vector2(6f, 7f));
      allEnemyPosandAttriRange.Add(new Vector3(3f, 4f, 5f), new Vector2(7f, 8f));
      allEnemyShipUnits.Add(new enemyShipUnit {
         allUnits = new List<enemyUnit>() {
            new enemyUnit(),
            new enemyUnit()
         }
      });
      allEnemyShipUnits.Add(new enemyShipUnit {
         allUnits = new List<enemyUnit>(){
            new enemyUnit(),
            new enemyUnit(),
            new enemyUnit()
         }
      });
      allEnemyShipUnits.Add(new enemyShipUnit {
         allUnits = new List<enemyUnit>(){
            new enemyUnit()
         }
      });

      var index = 0;
      foreach(var pa in allEnemyPosandAttriRange) {
         var temp = Instantiate(enemyShipObject, pa.Key, Quaternion.Euler(0, 0, 0), overWorldMap.transform);

         assignEnemyAttri(allEnemyShipUnits[index], pa.Value);
         index++;
      }
   }

   public void assignEnemyAttri(enemyShipUnit enemyShipUnit, Vector2 attriInterval) {
      //Assign Attributes to all Enemies in every ship
      //Call EnemyList in Ship Class maybe

      foreach(var e in enemyShipUnit.allUnits) {
         e.attri = Random.Range(attriInterval.x, attriInterval.y);
      }
   }
   public class enemyShipUnit {
      public List<enemyUnit> allUnits;
   }

   public class enemyUnit {
      public float attri;
   }
}
