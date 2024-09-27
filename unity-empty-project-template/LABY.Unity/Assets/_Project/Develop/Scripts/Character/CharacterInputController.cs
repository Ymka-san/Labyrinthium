using System;
using UnityEngine;

namespace _Project.Develop.Scripts.Character
{
    public class CharacterInputController : MonoBehaviour
    {
       
        private IControllable _controllable;

        private void Awake()
        {
            _controllable = GetComponent<IControllable>();
            
            if (_controllable == null)
            {
                throw new Exception("There's no IControllable component on the object");
            }
        }

        private void Update()
        {
            ReadMove();
            ReadJump();
        }

        private void ReadMove()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var direction = new Vector3(horizontal, 0f, vertical);
            
            _controllable.Move(direction);
        }

        private void ReadJump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _controllable.Jump();
            }
        }
    }
}