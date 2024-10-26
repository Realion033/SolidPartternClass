using RPG.Animators;
using RPG.Entities;
using RPG.FSM;
using UnityEngine;

namespace RPG.Players
{
    public class PlayerIdleState : EntityState
    {
        private Player _player;
        private EntityMover _mover;

        public PlayerIdleState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _player = entity as Player;
            _mover = _player.GetCompo<EntityMover>();
        }

        public override void Enter()
        {
            base.Enter();
            _mover.StopImmediately();
        }

        public override void Update()
        {
            base.Update();
            float xInput = _player.PlayerInput.InputDir.x;

            if (Mathf.Abs(xInput) > 0)
            {
                _player.ChangeState(_player.playerFSM[FSMState.Move]);
            }
        }
    }
}
