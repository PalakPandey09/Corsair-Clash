using UnityEngine;
using NUnit.Framework;

public class TL5HongxiTest: MonoBehaviour {
   public EnemyAI ea;
   public bool assertForSystemBoundary;
   public bool _WARNING_assertForSystemStress;
   public bool assertForAIBoundary;

   [Test]
   public void TestForOverworldGenerateSystem_Boundary() {
      OverworldEnemyGenerationSystem.Instance.Generate();
      var index = 0;
      foreach(var s in OverworldEnemyGenerationSystem.Instance.overWorldMap.transform) {
         var shipUnit = (GameObject)s;
         var shipPos = shipUnit.transform.position;
         if(OverworldEnemyGenerationSystem.Instance.allEnemyPosandAttriRange.TryGetValue(shipPos, out Vector2 range)) {
            foreach(var u in OverworldEnemyGenerationSystem.allEnemyShipUnits[index].allUnits) {
               Assert.IsTrue(u.attri >= range.x && u.attri <= range.y);
            }
         }
      }
   }

   [Test]
   public void TestForOverworldGenerateSystem_Stress() {
      for(int i = 0; i < 1000; i++) {
         OverworldEnemyGenerationSystem.Instance.Generate();
      }
      Assert.IsTrue(OverworldEnemyGenerationSystem.allEnemyShipUnits.Count > 2999);
   }

   [Test]
   public void TestEnemeyAI_Boundary() {
      ea = new EnemyAI();
      
      for(int i = 0; i < 10; i++) {
         ea.Target();
         Assert.IsTrue(ea.target != null);
      }
   }
}