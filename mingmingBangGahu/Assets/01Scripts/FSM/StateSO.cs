using RPG.Animators;
using UnityEngine;

namespace RPG.FSM
{
    [CreateAssetMenu(fileName = "StateSO", menuName = "Scriptable Objects/StateSO")]
    public class StateSO : ScriptableObject
    {
        public FSMState stateName;
        public string className;
        public AnimParamSO animParm;
    }
}
