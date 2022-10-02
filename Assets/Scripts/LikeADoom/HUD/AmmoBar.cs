using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LikeADoom
{
    public class AmmoBar : MonoBehaviour
    {
        [SerializeField] private TMP_Text _ammoCount;
        [SerializeField] private Image _icon;

        [Header("Sprites")] 
        [SerializeField] private Sprite _combatShotgun;
        [SerializeField] private Sprite _havyGun;
        [SerializeField] private Sprite _plasmaRifle;
        [SerializeField] private Sprite _rocketLauncher;
        [SerializeField] private Sprite _superShotgun;
        [SerializeField] private Sprite _ballista;
        [SerializeField] private Sprite _chaingun;
        [SerializeField] private Sprite _BFG9000;
        
        private void Start()
        {
            SetWeaponSprite(Weapon.CombatShotgun);
        }

        private void SetWeaponSprite(Weapon weapon)
        {
            _icon.sprite = weapon switch
            {
                Weapon.CombatShotgun => _combatShotgun,
                Weapon.HeavyGun => _havyGun,
                Weapon.PlasmaRifle => _plasmaRifle,
                Weapon.RocketLauncher => _rocketLauncher,
                Weapon.SuperShotgun => _superShotgun,
                Weapon.Ballista => _ballista,
                Weapon.Chaingun => _chaingun,
                Weapon.BFG9000 => _BFG9000,
                _ => _icon.sprite
            };
        }
    }
}
