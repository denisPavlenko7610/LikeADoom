using LikeADoom.Bullet;
using LikeADoom.Bullet.BulletFactory;
using LikeADoom.ObjectCreation;
using LikeADoom.Units.Player.Health;
using UnityEngine;

namespace LikeADoom.Units.Player.PlayerShoot.Weapon
{
    public class WeaponControl : MonoBehaviour
    {
        [SerializeField] GameObject _prefab;
        [SerializeField] Transform _parent;
        [SerializeField] Transform _spawnPoint;
        [SerializeField] Transform _cameraTransform;

        // This can all be set by the weapon's type
        [SerializeField, Range(5, 50)] int _ammoCount;
        [SerializeField, Range(1, 100)] float _bulletSpeed;
        [SerializeField] bool _canSpamShoot;

        // Extract to a separate component later
        [SerializeField] Transform _meleeHitPoint;
        [SerializeField] Vector3 _meleeHitExtents;
        [SerializeField] int _meleeHitDamage;

        [SerializeField] GunView _view;

        bool _isShootAnimationPlaying;
        bool _isAmmoClipInserted;
        bool _isReloadAnimationPlaying;
        bool _isMeleeHitAnimationPlaying;
        Gun _gun;

        void Awake()
        {
            BulletFactory factory = new(_prefab, _parent, _spawnPoint, _cameraTransform);
            Pool<IBullet> pool = new(factory, _spawnPoint, maxSize: _ammoCount);
            Shooting shooting = new(pool);
            
            _gun = new Gun(shooting, Enums.Weapon.BFG9000, _ammoCount, _bulletSpeed);

            _view.ShootAnimationAmmoClipInserted += OnAmmoClipInserted;
            _view.ShootAnimationEnd += OnShootAnimationEnd;
            _view.ReloadAnimationEnd += OnReloadAnimationEnd;
            _view.HitAnimationHit += OnMeleeHit;
            _view.HitAnimationEnd += OnMeleeHitAnimationEnd;
        }

        void OnDestroy()
        {
            _view.ShootAnimationAmmoClipInserted -= OnAmmoClipInserted;
            _view.ShootAnimationEnd -= OnShootAnimationEnd;
            _view.ReloadAnimationEnd -= OnReloadAnimationEnd;
            _view.HitAnimationHit -= OnMeleeHit;
            _view.HitAnimationEnd -= OnMeleeHitAnimationEnd;
        }

        bool CanShoot => 
            _gun.CanShoot && 
            !_isReloadAnimationPlaying &&
            !_isMeleeHitAnimationPlaying &&
            (!_isShootAnimationPlaying || _canSpamShoot);

        bool CanMeleeHit =>
            !_isMeleeHitAnimationPlaying &&
            !_isShootAnimationPlaying ||
            (_isReloadAnimationPlaying && _isAmmoClipInserted);

        bool CanReload =>
            !_isMeleeHitAnimationPlaying;

        public void Shoot()
        {
            if (!CanShoot)
                return;
            
            _gun.Shoot();
            _view.PlayShootAnimation();
            _view.ShowAmmoLeft(_gun.AmmoLeft);
            
            ResetState();
            _isShootAnimationPlaying = true;
        }

        public void Reload()
        {
            if (!CanReload)
                return;
            
            _view.PlayReloadAnimation();
            
            ResetState();
            _isReloadAnimationPlaying = true;
        }

        public void MeleeHit()
        {
            if (!CanMeleeHit)
                return;
            
            _view.PlayHitAnimation();

            ResetState();
            _isMeleeHitAnimationPlaying = true;
        }

        void OnAmmoClipInserted()
        {
            _gun.Reload();
            _view.ShowAmmoLeft(_gun.AmmoLeft);
            
            _isAmmoClipInserted = true;
        }

        void OnMeleeHit()
        {
            const int collidersNum = 10;
            Collider[] colliders = new Collider[collidersNum];
            int numColliders = Physics.OverlapBoxNonAlloc(_meleeHitPoint.position, _meleeHitExtents, colliders);

            for (int i = 0; i < numColliders; i++)
            {
                Collider c = colliders[i];
                if (c.TryGetComponent(out IDamageable damageable) && 
                    damageable is not PlayerHealth)
                {
                    damageable.TakeDamage(_meleeHitDamage);
                }
            }
        }
        
        void OnReloadAnimationEnd() => ResetState();
        void OnShootAnimationEnd() => ResetState();
        void OnMeleeHitAnimationEnd() => ResetState();

        void ResetState()
        {
            _isReloadAnimationPlaying = false;
            _isShootAnimationPlaying = false;
            _isMeleeHitAnimationPlaying = false;
            _isAmmoClipInserted = false;
        }

#if UNITY_EDITOR
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_meleeHitPoint.position, _meleeHitExtents);
        }
#endif
    }
}