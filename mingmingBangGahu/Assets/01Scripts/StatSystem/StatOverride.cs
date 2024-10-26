using System;
using UnityEngine;

namespace RPG.StatsSystem
{
    [Serializable]
    public class StatOverride
    {
        [SerializeField] private StatSO _stat;
        [SerializeField] private bool _isUserOverride;
        [SerializeField] private float _overrideBaseValue;

        public StatOverride(StatSO stat) => _stat = stat;

        public StatSO CreateStat()
        {
            StatSO newStat = _stat.Clone() as StatSO;

            if (_isUserOverride)
            {
                newStat.BaseValue = _overrideBaseValue;
            }
            return newStat;
        }
    }
}
