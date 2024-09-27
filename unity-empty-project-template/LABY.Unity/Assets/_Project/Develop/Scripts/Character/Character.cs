using UnityEngine;

namespace _Project.Develop.Scripts.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour, IControllable
    {
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private Transform _groundCheckerPivot;
        [SerializeField] private float _checkGroundRadius;
        [SerializeField] private float _jumpHeight = 3f;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _gravity = -9.81f;
        private CharacterController _controller;
        private float _velocity;
        private Vector3 _moveDirection;
        private bool _isGrounded;
        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            _isGrounded = IsOnTheGround();
            
            if (_isGrounded && _velocity < 0)
            {
                _velocity = -2;
            }

            MoveInternal();
            DoGravity();
        }

       

        private bool IsOnTheGround()
        {
            bool result = Physics.CheckSphere(_groundCheckerPivot.position, _checkGroundRadius, _groundMask);

            return result;
        }
        public void Move(Vector3 direction)
        {
            _moveDirection = direction;
           
            
        }
        
        

        public void Jump()
        {
            if (_isGrounded)
            {
                _velocity = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            }
            
        }
        
        private void MoveInternal(){
            _controller.Move(_moveDirection * _speed * Time.fixedDeltaTime);
        }

        private void DoGravity()
        {
            _velocity += _gravity * Time.fixedDeltaTime;
            
            _controller.Move(Vector3.up * _velocity * Time.fixedDeltaTime);
        }
    
    }
}
