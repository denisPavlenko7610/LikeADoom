using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LikeADoom.HUD
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] TMP_Text _label;
        [SerializeField] Image _image;

        public void SetValue(int amount, int maxAmount)
        {
            _label.text = amount.ToString();
            _image.fillAmount = (float) amount / maxAmount;
        }
    }
}
