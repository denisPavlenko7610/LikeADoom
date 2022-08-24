using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LikeADoom
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Image _image;

        public void SetValue(int amount, int maxAmount)
        {
            _label.text = amount.ToString();
            _image.fillAmount = (float) amount / maxAmount;
        }
    }
}
