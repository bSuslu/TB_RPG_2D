using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace TB_RPG_2D.DataService
{
    public class JsonDataService : IDataService
    {
        public bool SaveData<T>(string relativePath, T data)
        {
            string path = Application.persistentDataPath + "/" + relativePath;
            try
            {
                string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(path, jsonString);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Unable to save data due to: {e.Message} {e.StackTrace}");
                return false;
            }
        }

        public T LoadData<T>(string relativePath)
        {
            string path = Application.persistentDataPath + "/" + relativePath;

            if (!File.Exists(path))
            {
                Debug.LogWarning($"Unable to load data due to: {path} not found.");
                throw new FileNotFoundException($"{path} not exist.");
            }

            try
            {
                T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
                return data;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load data due to: {e.Message} {e.StackTrace}");
                throw e;
            }
        }
    }
    
}