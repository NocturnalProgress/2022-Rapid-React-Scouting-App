using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System;
using TMPro;
using System.Data;

[Serializable]
public class SerializeData : MonoBehaviour
{
    [SerializeField] TextAsset jsonFile;
    public Data data;

    public List<Data> allData = new List<Data>();

    public List<Data> autoSavedData = new List<Data>();

    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] TMP_InputField matchNumberInputField;
    [SerializeField] TMP_InputField teamNumberInputField;

    private void Start() // Autosave data starting in 5 seconds and every 10 seconds
    {
        //InvokeRepeating("AutoSaveData", 5f, 10f);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            autoSavedData.Clear();
            autoSavedData.Add(data);
            Debug.Log("Data autosaved");
        }
    }

    //private void AutoSaveData()
    //{
    //    Debug.Log("Data autosaved");
    //}

    public void SaveData()
    {
        allData.Add(data);
        PrepareForNextMatch();
    }

    public void PrepareForNextMatch()
    {
        data.name = "";
        data.teamNumber = "";
        data.matchNumber += 1;
    }

    public void ExportData()
    {
        var save = JsonConvert.SerializeObject(allData, Formatting.Indented);

        int randomNumber = UnityEngine.Random.Range(00000, 99999);

        System.IO.File.WriteAllText(Application.dataPath + "/Resources/TestData/" + randomNumber + ".json", save);
    }

    public void LoadAllData()
    {
        allData = JsonConvert.DeserializeObject<List<Data>>(jsonFile.ToString());
        Debug.Log("List" + allData);
    }

    public void AddNameToData()
    {
        data.name = nameInputField.text;
    }

    public void AddTeamNumberToData()
    {
        data.teamNumber = teamNumberInputField.text;
    }
    public void AddMatchNumberToData()
    {
        data.matchNumber = matchNumberInputField.text;
    }
}