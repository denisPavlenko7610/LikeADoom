using RDTools;
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace LikeADoom.Components
{
    public class IdComponent : MonoBehaviour
    {
        
        [field:SerializeField, ReadOnly] public int Id { get; set; }

        void OnValidate()
        {
            if (Id == 0)
            {
                GenerateGuid();
            }
        }
        void GenerateGuid()
        {
            Id = Guid.NewGuid().GetHashCode();
        }
    }
}