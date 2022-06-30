using External.Mini_First_Person_Controller.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingInteractTrigger : MonoBehaviour
{
    [SerializeField] private int _sceneId;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FirstPersonMovement player))
        {
            Interract(_sceneId, player.gameObject);
        }
    }
    
    private void Interract(int id, GameObject player)
    {
        SceneManager.LoadScene(id);
    }
}
