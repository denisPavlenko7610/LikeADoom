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

        public IBulletBuilder SetIsReleased(bool isReleased)
        {
            CreateIfNull();
            
            _bullet.SetIsReleased(isReleased);
            return this;
        }
        
        public IBullet Build()
        {
            var copyBullet = _bullet;
            _bullet = null;
            return copyBullet;
        }

        public IBulletBuilder SetupBulletPosition(Transform spawnPoint)
        {
            CreateIfNull();
            
            _bullet.SetupBulletPosition(spawnPoint);
            return this;
        }
        
        private void CreateIfNull()
        {
            if (isBulletNull())
            {
                Create();
            }
        }

        private bool isBulletNull() => _bullet == null;
        private IBullet Create() => _bullet = _bulletFactory.Create();
    }
}