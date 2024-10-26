using System;
using System.Collections.Generic;
using RPG.Entities;
using RPG.FSM;
using UnityEditor.PackageManager;
using UnityEngine;

namespace RPG.Players
{
    public class Player : Entity
    {
        public EntityStateListSO playerFSM;

        [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }

        private StateMachine _stateMachine;
        private Dictionary<StateSO, EntityState> _stateDictionary;


        [SerializeField] private float _jumpPower = 12f;
        [SerializeField] private int _jumpCount = 2;

        [SerializeField] private int _currentJumpCount = 0;
        private EntityMover _mover;

        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new StateMachine();
            _stateDictionary = new Dictionary<StateSO, EntityState>();

            foreach (StateSO state in playerFSM.states)
            {
                try
                {
                    Type t = Type.GetType(state.className);
                    var playerState = Activator.CreateInstance(t, this, state.animParm) as EntityState;
                    _stateDictionary.Add(state, playerState);
                }
                catch (Exception ex)
                {
                    Debug.LogError($"{state.className} loading Error, Message : {ex.Message}");
                }
            }
        }

        private void Start()
        {
            _stateMachine.Init(GetState(playerFSM[FSMState.Idle]));
        }

        public void ChangeState(StateSO newState) => _stateMachine.ChangeState(GetState(newState));
        private EntityState GetState(StateSO stateSo) => _stateDictionary.GetValueOrDefault(stateSo);

        private void Update()
        {
            _stateMachine.UpdateStateMachine();
        }
    }
}