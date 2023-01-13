using UnityEngine;

namespace LikeADoom
{
    public class PlayerArmsOverlay : MonoBehaviour
    {
        [SerializeField] private Material material;

        private void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Graphics.Blit(src, dest, material);
        }
    }
}
