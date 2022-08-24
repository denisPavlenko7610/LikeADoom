using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LikeADoom
{
    public class AmmoBar : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;
        [SerializeField] private Image image;

        [Header("Sprites")] 
        [SerializeField] private Sprite CombatShotgun;
        [SerializeField] private Sprite HeavyGun;
        [SerializeField] private Sprite PlasmaRifle;
        [SerializeField] private Sprite RocketLauncher;
        [SerializeField] private Sprite SuperShotgun;
        [SerializeField] private Sprite Ballista;
        [SerializeField] private Sprite Chaingun;
        [SerializeField] private Sprite BFG9000;
        
        private void Start()
        {
            SetWeapon(Weapon.CombatShotgun);
        }

        public void SetWeapon(Weapon weapon)
        {
            image.sprite = weapon switch
            {
                Weapon.CombatShotgun => CombatShotgun,
                Weapon.HeavyGun => HeavyGun,
                Weapon.PlasmaRifle => PlasmaRifle,
                Weapon.RocketLauncher => RocketLauncher,
                Weapon.SuperShotgun => SuperShotgun,
                Weapon.Ballista => Ballista,
                Weapon.Chaingun => Chaingun,
                Weapon.BFG9000 => BFG9000,
                _ => image.sprite
            };
        }
    }
}
