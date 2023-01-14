using UnityEngine;
using UnityEngine.SceneManagement;

namespace LikeADoom.Trainee
{
    public class GameLoader : MonoBehaviour
    {
        public const string GameSceneName = "Main";

        public void LoadGame()
        {
            SceneManager.LoadScene(GameSceneName);
        }
    }
}
