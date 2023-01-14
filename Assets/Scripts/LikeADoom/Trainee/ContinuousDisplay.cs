using System.Collections;
using UnityEngine;

namespace LikeADoom.Trainee
{
    public class ContinuousDisplay : MonoBehaviour
    {
        [SerializeField] private Logger logger;

        private IEnumerator Start()
        {
            while (true)
            {
                logger.Log();
                yield return new WaitForSeconds(3);
            }
        }
    }
}