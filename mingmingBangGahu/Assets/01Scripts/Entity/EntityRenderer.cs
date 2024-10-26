using System;
using RPG.Animators;
using RPG.Players;
using UnityEngine;

namespace RPG.Entities
{
    public class EntityRenderer : MonoBehaviour, IEntityComponent
    {
        public float FacingDirection { get; private set; } = 1;
        private readonly int _moveHash = Animator.StringToHash("Move");
        private Entity _player;
        private Animator _animator;

        public void Init(Entity entity)
        {
            _player = entity;
            _animator = GetComponent<Animator>();
        }

        public void SetParam(AnimParamSO param, bool value) => _animator.SetBool(param.hashValue, value);
        public void SetParam(AnimParamSO param, float value) => _animator.SetFloat(param.hashValue, value);
        public void SetParam(AnimParamSO param, int value) => _animator.SetInteger(param.hashValue, value);
        public void SetParam(AnimParamSO param) => _animator.SetTrigger(param.hashValue);

        #region FlipControl

        public void Flip()
        {
            FacingDirection *= -1;
            _player.transform.Rotate(0, 180f, 0);
        }

        public void FlipController(float xMove)
        {
            if (Mathf.Abs(FacingDirection + xMove) < 0.5f)
                Flip();
        }

        #endregion
    }
}