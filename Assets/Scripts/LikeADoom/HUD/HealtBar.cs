using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LikeADoom
{
    public class HealtBar : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;
        [SerializeField] private Image image;

        public void SetValue(int amount, int maxAmount)
        {
            label.text = amount.ToString();
            image.fillAmount =  amount * 1.0f / maxAmount;
        }
    }
}
