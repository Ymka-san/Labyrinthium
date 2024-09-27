using UnityEngine;

namespace _Project.Develop.Scripts.Character
{
    public interface IControllable
    {
        void Move(Vector3 direction);
        void Jump();
    }
}