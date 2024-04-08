using UnityEngine;

namespace PragmaTechs.ScriptableObjects.Core
{
    [CreateAssetMenu(fileName = "Int Variable", menuName = "PragmaTechs/Variables/Int Variable", order = 100)]
    public class IntVariable : ScriptableObject
    {
        public int Value = 15;

        public void SetValue(int value)
        {
            Value = value;
        }

        public void SetValue(IntVariable value)
        {
            Value = value.Value;
        }

        public void ApplyChange(int amount)
        {
            Value += amount;
        }

        public void ApplyChange(IntVariable amount)
        {
            Value += amount.Value;
        }
    }
}