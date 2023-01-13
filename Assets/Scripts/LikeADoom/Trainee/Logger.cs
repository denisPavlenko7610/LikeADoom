using UnityEngine;

namespace LikeADoom.Trainee
{
    public class Logger : MonoBehaviour
    {
        private IShow _logDisplay;

        private void Awake()
        {
            _logDisplay = new Display();
        }

        public void Log()
        {
            _logDisplay.ShowHelloWorld();
        }
    }
}
