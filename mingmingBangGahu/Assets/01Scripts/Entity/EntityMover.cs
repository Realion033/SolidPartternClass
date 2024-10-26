using System;
using RPG.Animators;
using RPG.Players;
using UnityEngine;

namespace RPG.Entities
{
    public class EntityMover : MonoBehaviour, IEntityComponent
    {
        [Header("Move stats")]
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private Transform _groundChecker;
        [SerializeField] private LayerMask _whatIsGround;
        [SerializeField] private float _groundCheckWidth, _checkDistance;

        [Header("AnimParam")]
        [SerializeField] private AnimParamSO _moveParam;

        [field: SerializeField] public bool IsGrounded { get; private set; }
        public event Action<bool> OnGroundStateChanged;

        private Rigidbody2D _rbCompo;
        private Entity _player;
        private EntityRenderer _renderer;

        private float _xMovement;

        public void Init(Entity player)
        {
            _player = player;
            _rbCompo = player.GetComponent<Rigidbody2D>();
            _renderer = player.GetCompo<EntityRenderer>();
        }
        public void AddForceToEntity(Vector2 force, ForceMode2D mode = ForceMode2D.Impulse)
        {
            _rbCompo.AddForce(force, mode);
        }

        public void StopImmediately(bool isYAxisToo = false)
        {
            if (isYAxisToo)
            {
                _rbCompo.linearVelocity = Vector2.zero;
            }
            else
            {
                _rbCompo.linearVelocityX = 0;
            }
            _xMovement = 0;
        }

        public void SetMovement(float xMovement) => _xMovement = xMovement;

        private void FixedUpdate()
        {
            CheckGround();
            MoveCharacter();
        }

        private void CheckGround()
        {
            bool before = IsGrounded;
            Vector2 boxSize = new Vector2(_groundCheckWidth, 0.05f);
            IsGrounded = Physics2D.BoxCast(_groundChecker.position, boxSize, 0f,
                Vector2.down, _checkDistance, _whatIsGround);

            if (IsGrounded != before)
            {
                OnGroundStateChanged?.Invoke(IsGrounded);
            }
        }

        private void MoveCharacter()
        {
            _rbCompo.linearVelocityX = _xMovement * _moveSpeed;
            _renderer.FlipController(_xMovement);

            _renderer.SetParam(_moveParam, Mathf.Abs(_xMovement) > 0);
        }

        private void OnDrawGizmos()
        {
            if (_groundChecker == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_groundChecker.position - new Vector3(0, _checkDistance * 0.5f),
                new Vector3(_groundCheckWidth, _checkDistance, 1f));
        }
    }
}