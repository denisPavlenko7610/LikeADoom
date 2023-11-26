using LikeADoom.Constants;
using LikeADoom.Core.SaveSystem.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace LikeADoom.Core.SaveSystem.Formats
{
    public class JSONSaveSystem : ISaveLoadSystem
    {
        bool _useEncryption;
        string _filePath;
        List<ISavable> _savables = new();
        JsonSerializerSettings _settings;
        
        public JSONSaveSystem(bool useEncryption, List<ISavable> savables)
        {
            _useEncryption = useEncryption;
            _savables = savables;
            
            Init();
        }

        void Init()
        {
            _filePath = Path.Combine(Application.persistentDataPath, GameConstants.SaveFilePath);
            _settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto
            };
        }
        
        public void Save()
        {
            Delete();
            var saveData = new SaveData();
            foreach (ISavable savable in _savables)
            {
                saveData.Items.Add(savable.Save());
            }
            
            string json = JsonConvert.SerializeObject(saveData, _settings);

            if (_useEncryption)
            {
                //AES (Advanced Encryption Standard)
                using (Aes aes = Aes.Create())
                {
                    byte[] key = Encoding.UTF8.GetBytes("some_key");
                    aes.Key = key;
                    aes.IV = new byte[16];

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                    byte[] encrypted = encryptor.TransformFinalBlock(Encoding.UTF8.GetBytes(json), 0, json.Length);

                    File.WriteAllBytes(_filePath, encrypted);
                }
            }
            else
            {
                File.WriteAllText(_filePath, json);
            }
            
            Debug.Log("Saved successful");
        }

        public void Load<T>() where T : ISavableData
        {
            if (!File.Exists(_filePath))
                return;
            
            string loadedJson;

            if (_useEncryption)
            {
                using (Aes aes = Aes.Create())
                {
                    byte[] key = Encoding.UTF8.GetBytes("some_key");
                    aes.Key = key;
                    aes.IV = new byte[16];

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    byte[] decrypted = decryptor.TransformFinalBlock(File.ReadAllBytes(_filePath), 0, File.ReadAllBytes(_filePath).Length);

                    loadedJson = Encoding.UTF8.GetString(decrypted);
                }
            }
            else
            {
                loadedJson = File.ReadAllText(_filePath);
            }

            SaveData loadedData = JsonConvert.DeserializeObject<SaveData>(loadedJson, _settings);

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