using UnityEngine;

namespace PragmaTechs.ScriptableObjects.Variables
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "PragmaTechs/SO/RangeVariables/FloatRange", order = 1)]
    public class FloatRange : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public float MinValue;

        public float MaxValue;

        public void SetValueMin(float value)
        {
            MinValue = value;
        }

        public void SetValueMax(float value)
        {
            MaxValue = value;
        }
    }
}