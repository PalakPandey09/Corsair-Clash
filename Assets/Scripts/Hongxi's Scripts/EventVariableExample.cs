using QPFramework;
using UnityEngine;

public class EventVariableExample: MonoBehaviour {
   public EventVariable<int> Age = new EventVariable<int>(10);
   public EventVariable<int> Counter = new EventVariable<int>();

   void Start() {
      Counter.Register(counter => {
         Debug.Log(nameof(counter) + " has change to : " + counter);
      });

      Age.RegisterWithInitValue(age => {
         Debug.Log(nameof(age) + " has changed to : " + age);

         Counter.Value = 10 * age;
      });
   }

   void Update() {
      if(Input.GetMouseButtonDown(0)) {
         Age.Value++;
      }
   }
}
