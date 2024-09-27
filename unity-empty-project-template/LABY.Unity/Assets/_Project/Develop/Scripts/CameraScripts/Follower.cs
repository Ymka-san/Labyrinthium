using UnityEngine;

namespace _Project.Develop.Scripts.CameraScripts
{
    public abstract class Follower : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _smoothing = 1f;
       
        
        
       
        

        protected void Move(float deltaTime)
        {

            var nextPosition = Vector3.Lerp(transform.position, _targetTransform.position + _offset, deltaTime * _smoothing);

            transform.position = nextPosition;
        }

       
       
        }
    }
