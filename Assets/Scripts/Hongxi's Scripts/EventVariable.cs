using System;

namespace QPFramework {
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