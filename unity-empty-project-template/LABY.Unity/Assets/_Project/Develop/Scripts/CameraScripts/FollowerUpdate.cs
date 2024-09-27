using UnityEngine;

namespace _Project.Develop.Scripts.CameraScripts
{
    public class FollowerUpdate : Follower
    {
        private void Update()
        {
            Move(Time.deltaTime);
        }
    }
}