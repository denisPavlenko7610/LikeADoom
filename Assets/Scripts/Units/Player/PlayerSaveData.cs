using LikeADoom.Core.SaveSystem.Interfaces;
using RDTools.DataTypes;
using System;

namespace LikeADoom.Units.Player
{
    [Serializable]
    public class PlayerSaveData : ISavableData
    {
        public SerializedVector3 Position { get; set; }
        public SerializedQuaternion Rotation { get; set; }
        public int CurrentHealth { get; set; }
        public int CurrentArmor { get; set; }
        public int Id { get; set; }

        public PlayerSaveData(int id, SerializedVector3 position, SerializedQuaternion rotation, int currentHealth, int currentArmor)
        {
            Id = id;
            Position = position;
            Rotation = rotation;
            CurrentHealth = currentHealth;
            CurrentArmor = currentArmor;
        }
    }
}