using System.Collections.Generic;
using RPG.FSM;
using UnityEngine;

namespace RPG
{
    public enum FSMState
    {
        Idle,
        Move,
        Attack,
        Die,
        Dance,
        Tlqkf,
        AngGimoDDi,
        Ming
    }

    [CreateAssetMenu(fileName = "EntityStateListSO", menuName = "SO/FSM/EntityStateListSO")]
    public class EntityStateListSO : ScriptableObject
    {
        public List<StateSO> states;
        private Dictionary<FSMState, StateSO> _stateDic;

        public StateSO this[FSMState stateName] => _stateDic.GetValueOrDefault(stateName);
        
        private void OnEnable()
        {
            _stateDic = new Dictionary<FSMState, StateSO>();
            foreach (var state in states)
            {
                _stateDic.Add(state.stateName, state);
            }
        }
    }
}
