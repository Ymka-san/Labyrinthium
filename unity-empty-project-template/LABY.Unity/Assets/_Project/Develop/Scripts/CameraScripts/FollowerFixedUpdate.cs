using UnityEngine;

namespace _Project.Develop.Scripts.CameraScripts
{
    public class FollowerFixedUpdate : Follower
    {
        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
        }
    }
}