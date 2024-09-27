using UnityEngine;

public class BlockBulletRotation : MonoBehaviour
{
   

  
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        // Блокируем вращение по осям X и Z
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
    }
}
