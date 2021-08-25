using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [Header("Event Channels")]
    [SerializeField] private SaveLoadEventChannel SaveLoadEventChannel;

    private void Start()
    {
        SaveLoadEventChannel.OnRequestLoadData += Load;
        SaveLoadEventChannel.OnDataReadyToSave += Save;
    }

    [ContextMenu("Save")]
    private void RequestSave()
    {
        SaveLoadEventChannel.RequestSaveData();
    }

    private void Save()
    {
        var saveData = JsonUtility.ToJson(SaveLoadEventChannel.CurrentSaveData);
        using (StreamWriter streamWriter = new StreamWriter("SaveGame.json"))
        {
            streamWriter.Write(saveData);
        }
    }

    [ContextMenu("Load")]
    private void Load()
    {
        if (File.Exists("SaveGame.json"))
        {
            using (StreamReader streamReader = new StreamReader("SaveGame.json"))
            {
                var json = streamReader.ReadToEnd();
                var saveData = JsonUtility.FromJson<SaveData>(json);
                SaveLoadEventChannel.CurrentSaveData = saveData;
                SaveLoadEventChannel.RaiseDataReadyToLoad();
            }
        }
    }
}
