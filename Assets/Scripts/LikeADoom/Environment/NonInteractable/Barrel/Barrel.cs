using LikeADoom.LikeADoom.Environment.NonInteractable.Barel;
using UnityEngine;

namespace LikeADoom.LikeADoom.Environment.NonInteractable.Barrel
{
    public class Barrel : MonoBehaviour
    {
        [SerializeField] private RedBarrel _redBarrel;
        [SerializeField] private DestroyedBarrel _destroyedPrefab;
        private ObjFactory _factory;

        private void OnEnable()
        {
            _redBarrel.onCollision += CreateDestroyedBarrel;
            _factory = new ObjFactory();
        }

        private void OnDisable()
        {
            _redBarrel.onCollision -= CreateDestroyedBarrel;
        }

        private void CreateDestroyedBarrel()
        {
            DestroyedBarrel destroyedBarrel =
                _factory.Create<DestroyedBarrel>(_destroyedPrefab.gameObject, transform.gameObject);
        }
    }
}