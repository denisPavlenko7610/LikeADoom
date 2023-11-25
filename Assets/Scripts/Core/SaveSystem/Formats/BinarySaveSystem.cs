using LikeADoom.Core.SaveSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace LikeADoom.Core.SaveSystem.Formats
{
    public class BinarySaveSystem : ISaveLoadSystem
    {
        bool _useEncryption;
        readonly string _fileName;
        readonly string _filePath;
        List<ISavable> _savables;
    
        public BinarySaveSystem(bool useEncryption, string fileName, List<ISavable> savables)
        {
            _useEncryption = useEncryption;
            _fileName = fileName;
            _savables = savables;
        
            _filePath += Path.Combine(Application.persistentDataPath, _fileName);
        }

        public void Save()
        {
            SaveData saveData = new SaveData();
            foreach (var saveable in _savables)
            {
                saveData.Items.Add(saveable.Save());
            }

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_filePath, FileMode.Create);

            formatter.Serialize(stream, saveData);
            stream.Close();
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
                
                Type t1 = _savables[i].Type();
                Type t2 = loadedData.Items[i].GetType();
                if (t1 != t2)
                    continue;
                
                _savables[i].Load(loadedData.Items[i]);
                break;
            }
        }
        
        [Serializable]
        public class SaveData
        {
            public List<ISavableData> Items = new();
        }
    }
}