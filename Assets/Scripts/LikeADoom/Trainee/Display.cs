using UnityEngine;

namespace LikeADoom.Trainee
{
    public class Display : IShow
    {
        public void ShowHelloWorld()
        {
            Debug.Log("Hello, World!");
        }
    }
}