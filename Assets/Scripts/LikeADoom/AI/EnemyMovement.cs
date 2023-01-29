using UnityEngine;

namespace LikeADoom
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 10f)] private float _speed;

        public void MoveTo(Transform target)
        {
            transform.LookAt(target);
            Vector3 translation = transform.forward * (Time.deltaTime * _speed);
            transform.Translate(translation, Space.World);
        }
    }
}