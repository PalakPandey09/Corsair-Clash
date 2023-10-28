using UnityEngine;
using UnityEngine.Assertions;

public class TestBox: MonoBehaviour {
   public EnemyAI ea;

   public bool assertForSystemBoundary;
   public bool _WARNING_assertForSystemStress;
   public bool assertForAIBoundary;

   void Update() {
      if(assertForSystemBoundary) {
         assertForSystemBoundary = !assertForSystemBoundary;
         TestForOverworldGenerateSystem_Boundary();
      }

      if(_WARNING_assertForSystemStress) {
         _WARNING_assertForSystemStress = !_WARNING_assertForSystemStress;
         TestForOverworldGenerateSystem_Stress();
      }

      if(assertForAIBoundary) {
         assertForAIBoundary = !assertForAIBoundary;
         TestEnemeyAI_Boundary();
      }
   }

   private void TestForOverworldGenerateSystem_Boundary() {
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

   private void TestForOverworldGenerateSystem_Stress() {
      for(int i = 0; i < 1000; i++) {
         OverworldEnemyGenerationSystem.Instance.Generate();
      }
      Assert.IsTrue(OverworldEnemyGenerationSystem.allEnemyShipUnits.Count > 2999);
   }


   private void TestEnemeyAI_Boundary() {
      for(int i=0; i < 10; i++) {
         ea.Target();

         Assert.IsTrue(ea.allPlayerUnits!=null);
      }
   }
}