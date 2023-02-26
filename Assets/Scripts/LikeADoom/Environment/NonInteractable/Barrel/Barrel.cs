using LikeADoom.LikeADoom.Environment.NonInteractable.Barel;
using LikeADoom.LikeADoom.FxSystem;
using UnityEngine;
using Zenject;

namespace LikeADoom.LikeADoom.Environment.NonInteractable.Barrel
{
    public class Barrel : MonoBehaviour
    {
        [SerializeField] private RedBarrel _redBarrel;
        [SerializeField] private DestroyedBarrel _destroyedPrefab;
        [SerializeField] private Transform _explosionFX;

        private ObjFactory _objFactory;
        private FxFactory _fxFactory;

        [Inject]
        private void Construct(ObjFactory objFactory, FxFactory fxFactory)
        {
            _objFactory = objFactory;
            _fxFactory = fxFactory;
        }

        private void OnEnable()
        {
            _redBarrel.onCollision += CreateDestroyedBarrel;
        }

        private void OnDisable()
        {
            _redBarrel.onCollision -= CreateDestroyedBarrel;
        }

        private void CreateDestroyedBarrel()
        {
            _objFactory.Create<DestroyedBarrel>(_destroyedPrefab.gameObject, transform.gameObject);
            _fxFactory.Create<Transform>(_explosionFX.gameObject, transform.gameObject);
        }
    }
}