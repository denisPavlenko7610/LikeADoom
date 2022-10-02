using LikeADoom;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingInteractTrigger : MonoBehaviour
{
    [SerializeField] private int _sceneId;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            LoadBunkerLevel(_sceneId, player.gameObject);
        }
    }
    
    private void LoadBunkerLevel(int id, GameObject player)
    {
        SceneManager.LoadScene(id);
    }
}
