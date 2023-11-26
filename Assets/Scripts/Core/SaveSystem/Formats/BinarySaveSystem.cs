using LikeADoom.Constants;
using LikeADoom.Core.SaveSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

namespace LikeADoom.Core.SaveSystem.Formats
{
    public class BinarySaveSystem : ISaveLoadSystem
    {
        bool _useEncryption;
        string _filePath;
        List<ISavable> _savables;
    
        public BinarySaveSystem(bool useEncryption, List<ISavable> savables)
        {
            _useEncryption = useEncryption;
            _savables = savables;
        
            _filePath = Path.Combine(Application.persistentDataPath, GameConstants.SaveFilePath);
        }

        public void Save()
        {
            Delete();
            SaveData saveData = new SaveData();
            foreach (var savable in _savables)
            {
                saveData.Items.Add(savable.Save());
            }

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_filePath, FileMode.Create);

            formatter.Serialize(stream, saveData);
            stream.Close();
            
            Debug.Log("Saved successful");
        }

        public void Load<T>() where T : ISavableData
        {
            if (!File.Exists(_filePath))
                return;
        
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_filePath, FileMode.Open);

            SaveData loadedData = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            if (loadedData == null)
                return;
            
            for (int i = 0; i < loadedData.Items.Count; i++)
            {
                if (_savables.Count == 0)
                    return;
                
                Type loadableType = typeof(T);
                Type savableType = _savables[i].Type();
                Type loadedType = loadedData.Items[i].GetType();
                if (savableType == loadedType && savableType == loadableType)
                {
                    _savables[i].Load(loadedData.Items[i]);
                    break;
                }
            }
        }
        void Delete()
        {
            if (!File.Exists(_filePath))
                return;
            
            File.Delete(_filePath);
            AssetDatabase.Refresh();
        }
        
        [Serializable]
        public class SaveData
        {
            public List<ISavableData> Items = new();
        }
    }
}