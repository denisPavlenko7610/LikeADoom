using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LikeADoom
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;
        [SerializeField] private Image image;

        public void SetValue(int amount, int maxAmount)
        {
            label.text = amount.ToString();
            image.fillAmount = (float) amount / maxAmount;
        }
    }
}
