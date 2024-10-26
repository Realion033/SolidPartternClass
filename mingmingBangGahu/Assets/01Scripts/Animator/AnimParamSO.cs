using UnityEngine;

namespace RPG.Animators
{
    [CreateAssetMenu(fileName = "AnimParamSO", menuName = "Scriptable Objects/Anim/AnimParamSO")]
    public class AnimParamSO : ScriptableObject
    {
        public enum ParamType
        {
            Boolen,
            Float,
            Integer,
            Trigger
        }

        public string paramName;
        public ParamType paramType;
        public int hashValue;

        private void OnValidate()
        {
            hashValue = Animator.StringToHash(paramName);
        }
    }
}
