using UnityEngine;

namespace LikeADoom.Shooting.BulletBuilder
{
    public class BulletBuilder : IBulletBuilder
    {
        private IBullet _bullet;
        private IBulletFactory _bulletFactory;

        public BulletBuilder(IBulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }

        public IObjectBuilder<IBullet> At(Transform transform)
        {
            _bullet ??= _bulletFactory.Create();
            _bullet.SetPosition(transform.position)
                .SetRotation(transform.rotation)
                .Enable();
            
            return this;
        }

        public IBullet Build()
        {
            var copyBullet = _bullet;
            _bullet = null;
            return copyBullet;
        }
    }
}