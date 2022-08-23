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
        [SerializeField] private Sprite pistol;
        [SerializeField] private Sprite machineGun;

        private void Start()
        {
            SetWeapon(Weapon.Pistol);
        }

        public void SetWeapon(Weapon weapon)
        {
            image.sprite = weapon switch
            {
                Weapon.Pistol => pistol,
                Weapon.MachineGun => machineGun,
                _ => image.sprite
            };
        }
    }
}
