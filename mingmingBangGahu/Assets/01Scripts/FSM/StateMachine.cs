using RPG.FSM;
using UnityEngine;

namespace RPG.FSM
{
    public class StateMachine
    {
        public EntityState currentState { get; private set; }

        public void Init(EntityState startState)
        {
            currentState = startState;
            currentState.Enter();
        }

        public void ChangeState(EntityState newState)
        {
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }

        public void UpdateStateMachine()
        {
            currentState.Update();
        }
    }
}
