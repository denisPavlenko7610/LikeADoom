using LikeADoom.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LikeADoom.HUD
{
    public class AmmoBar : MonoBehaviour
    {
        [SerializeField] TMP_Text _ammoCount;
        [SerializeField] Image _icon;

        [Header("Sprites")] 
        [SerializeField] Sprite _combatShotgun;
        [SerializeField] Sprite _havyGun;
        [SerializeField] Sprite _plasmaRifle;
        [SerializeField] Sprite _rocketLauncher;
        [SerializeField] Sprite _superShotgun;
        [SerializeField] Sprite _ballista;
        [SerializeField] Sprite _chaingun;
        [SerializeField] Sprite _BFG9000;
        
        void Start()
        {
            SetWeaponSprite(Weapon.CombatShotgun);
        }

        void SetWeaponSprite(Weapon weapon)
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

        public void ShowCount(int count)
        {
            _ammoCount.text = $"{count}";
        }
    }
}
