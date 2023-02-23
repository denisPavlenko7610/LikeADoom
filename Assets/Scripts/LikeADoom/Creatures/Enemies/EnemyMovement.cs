using UnityEngine;

namespace LikeADoom
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 10f)] private float _speed;
        [SerializeField, Range(1f, 5f)] private float _hoverHeight;
        [SerializeField, Range(0.01f, 0.5f)] private float _correctionDelta;
        [SerializeField] private Transform _hoverCheckStart;
        [SerializeField] private LayerMask _groundMask;

        private const float MaxHoverRayDistance = 100f;

        public void HoverTo(Transform target)
        {
            transform.LookAt(target);

            Vector3 translation = transform.forward * (Time.deltaTime * _speed);
            
            RaycastHit[] results = new RaycastHit[1];

            Ray ray = new Ray(_hoverCheckStart.position, Vector3.down);
            int hits = Physics.RaycastNonAlloc(ray, results, MaxHoverRayDistance, _groundMask);
            if (hits != 0)
            {
                foreach (var raycastHit in results)
                {
                    if (raycastHit.distance < _hoverHeight - _correctionDelta)
                    {
                        translation.y = _speed * Time.deltaTime;
                    }
                    else if (raycastHit.distance > _hoverHeight + _correctionDelta)
                    {
                        translation.y = -_speed * Time.deltaTime;
                    }
                    else
                    {
                        translation.y = 0;
                    }
                }
            }

            transform.Translate(translation, Space.World);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Vector3 hoverStart = _hoverCheckStart.position;
            Vector3 hoverEnd = hoverStart + Vector3.down * _hoverHeight;

            Gizmos.DrawLine(hoverStart, hoverEnd);
        }
#endif
    }
}