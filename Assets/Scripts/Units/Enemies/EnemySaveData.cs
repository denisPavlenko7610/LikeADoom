using LikeADoom.Core.SaveSystem.Interfaces;
using RDTools.DataTypes;
using System;

namespace LikeADoom.Units.Enemies
{
    [Serializable]
    public class EnemySaveData : ISavableData
    {
        public SerializedVector3 Position { get; set; }
        public SerializedQuaternion Rotation { get; set; }
        public int Id { get; set; }

        public EnemySaveData(int id, SerializedVector3 position, SerializedQuaternion rotation)
        {
            Id = id;
            Position = position;
            Rotation = rotation;
        }
    }
}