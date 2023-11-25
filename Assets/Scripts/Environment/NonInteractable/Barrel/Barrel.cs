using LikeADoom.FxSystem;
using UnityEngine;
using Zenject;

namespace LikeADoom.Environment.NonInteractable.Barrel
{
    public class Barrel : MonoBehaviour
    {
        [SerializeField] RedBarrel _redBarrel;
        [SerializeField] DestroyedBarrel _destroyedPrefab;
        [SerializeField] Transform _explosionFX;

        ObjFactory _objFactory;
        FxFactory _fxFactory;

        [Inject]
        void Construct(ObjFactory objFactory, FxFactory fxFactory)
        {
            _objFactory = objFactory;
            _fxFactory = fxFactory;
        }

        void OnEnable()
        {
            _redBarrel.onCollision += CreateDestroyedBarrel;
        }

        void OnDisable()
        {
            _redBarrel.onCollision -= CreateDestroyedBarrel;
        }

        void CreateDestroyedBarrel()
        {
            _objFactory.Create<DestroyedBarrel>(_destroyedPrefab.gameObject, transform.gameObject);
            _fxFactory.Create<Transform>(_explosionFX.gameObject, transform.gameObject);
        }
    }
}