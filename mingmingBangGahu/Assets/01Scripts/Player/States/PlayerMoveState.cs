using RPG.Animators;
using RPG.Entities;
using RPG.FSM;
using UnityEngine;

namespace RPG.Players
{
    public class PlayerMoveState : EntityState
    {
        private Player _player;
        private EntityMover _mover;

        public PlayerMoveState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _player = entity as Player;
            _mover = _player.GetCompo<EntityMover>();
        }

        public override void Update()
        {
            base.Update();
            float xInput = _player.PlayerInput.InputDir.x;

            _mover.SetMovement(xInput);

            if (Mathf.Approximately(xInput, 0))
            {
                _player.ChangeState(_player.playerFSM[FSMState.Idle]);
            }
        }
    }
}
