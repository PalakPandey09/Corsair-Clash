using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;

public class TL5HongxiTest: MonoBehaviour {
   public EnemyAI ea;
   public bool assertForSystemBoundary;
   public bool _WARNING_assertForSystemStress;
   public bool assertForAIBoundary;

   public List<GameObject> EnemyShips = new List<GameObject>();

   public GameObject enemyShipParent;

   public void GenerateEnemies() {
      var index = 0;

      for(; index < EnemyShips.Count; index++) {
         if(EnemyShips[index] != null) {
            Instantiate(EnemyShips[index], enemyShipParent.transform);
         }
      }
   }

   [Test]
   public void TestForOverworldGenerateSystem_Boundary() {
      enemyShipParent = new GameObject();
      enemyShipParent.tag = "EnemyShipParent";

      var ship = Resources.Load<GameObject>("TL5/Enemy1Patrol");

      EnemyShips.Add(ship);
      EnemyShips.Add(ship);

      GenerateEnemies();

      Assert.IsTrue(enemyShipParent.transform.childCount > 0);
   }

   [Test]
   public void TestForOverworldGenerateSystem_Stress() {
      enemyShipParent = new GameObject();
      enemyShipParent.tag = "EnemyShipParent";

      var ship = Resources.Load<GameObject>("TL5/Enemy1Patrol");

      EnemyShips.Add(ship);
      EnemyShips.Add(ship);

      for(int i = 0; i < 1000; i++) {
         GenerateEnemies();
      }

      Assert.IsTrue(enemyShipParent.transform.childCount > 1999);
   }

   [Test]
   public void TestEnemeyAI_Boundary() {
      ea = new EnemyAI();

      for(int i = 0; i < 10; i++) {
         var temp = ea.Target();
         Assert.IsTrue(temp != null);
      }
   }
}
