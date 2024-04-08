using UnityEngine;

namespace PragmaTechs.ScriptableObjects.Variables
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "PragmaTechs/SO/RangeVariables/IntRange", order = 1)]
    public class IntRange : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public int MinValue;

        public int MaxValue;

        public void SetValueMin(int value)
        {
            MinValue = value;
        }

        public void SetValueMax(int value)
        {
            MaxValue = value;
        }


    }
}