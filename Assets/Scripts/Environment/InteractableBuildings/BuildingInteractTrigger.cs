using UnityEngine;
using UnityEngine.SceneManagement;
namespace LikeADoom.Environment.InteractableBuildings
{
    public class BuildingInteractTrigger : MonoBehaviour
    {
        [SerializeField] int _sceneId;
        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMovement player))
            {
                LoadBunkerLevel(_sceneId, player.gameObject);
            }
        }
    
        void LoadBunkerLevel(int id, GameObject player)
        {
            SceneManager.LoadScene(id);
        }
    }
}
