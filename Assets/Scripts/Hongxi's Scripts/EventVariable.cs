using System;

namespace QPFramework {
   /// <summary>
   /// A simple responsible variable
   /// </summary>
   /// the purpose and character of your use - School Learning
   /// the nature of the copyrighted work - Opensource MIT
   /// the amount and substantiality of the portion taken - Small Utility Part
   /// the effect of use upon the potential market - No Competition
   /// <typeparam name="T"></typeparam>
   public class EventVariable<T> {
      public EventVariable(T defaultValue = default(T)) {
         mValue = defaultValue;
      }

      private T mValue = default(T);

      public T Value {
         get {
            return mValue;
         }
         set {
            if(value == null && mValue == null)
               return;
            if(value != null && value.Equals(mValue))
               return;

            mValue = value;
            mOnValueChanged?.Invoke(value);
         }
      }

      private Action<T> mOnValueChanged = (v) => { };

      public void Register(Action<T> onValueChanged) {
         mOnValueChanged += onValueChanged;
      }

      public void RegisterWithInitValue(Action<T> onValueChanged) {
         onValueChanged(mValue);
         Register(onValueChanged);
      }

      public static implicit operator T(EventVariable<T> property) {
         return property.Value;
      }

      public override string ToString() {
         return Value.ToString();

      }

      public void UnRegister(Action<T> onValueChanged) {
         mOnValueChanged -= onValueChanged;
      }
   }
}