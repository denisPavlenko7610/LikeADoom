using LikeADoom.Constants;
using LikeADoom.Core.SaveSystem.Formats;
using LikeADoom.Core.SaveSystem.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LikeADoom.Core.SaveSystem
{
    public enum SaveType
    {
        JSON,
        Binary
    }

    public class SaveSystem : MonoBehaviour, ILoadSystem
    {
        [field:SerializeField] public SaveType SaveType { get; set; }
        [field:SerializeField] public bool UseEncryption { get; private set; }

        readonly List<ISavable> _savables = new();
        ISaveLoadSystem _saveLoadSystem;

        void Start()
        {
            ChooseSaveSystem();
        }

        void Update()
        {
            //Temp solution
            CheckAndSave();
        }
        void CheckAndSave()
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                FindAllSavables();
                ChooseSaveSystem();
                Save();
            }
        }

        void FindAllSavables()
        {
            _savables.Clear();
            _savables.AddRange(FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<ISavable>());
        }

        void ChooseSaveSystem()
        {
            if (_saveLoadSystem != null)
                return;

            _saveLoadSystem = SaveType switch
            {
                SaveType.Binary => new BinarySaveSystem(UseEncryption, _savables),
                SaveType.JSON => new JSONSaveSystem(UseEncryption, _savables),
                _ => new JSONSaveSystem(UseEncryption, _savables)
            };
        }

        void Save()
        {
            PlayerPrefs.SetString(nameof(GameSettings.IsNewGame), "false");
            _saveLoadSystem.Save();
        }

        public void Load<T>() where T : ISavableData
        {
            FindAllSavables();
            _saveLoadSystem.Load<T>();
        }
    }
}
