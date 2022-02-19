using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using TMPro;
using System.IO;

[Serializable]
public class SerializeData : MonoBehaviour
{
    [SerializeField] TextAsset jsonFile;
    public Data data;

    public Data testData;

    public List<Data> allData = new List<Data>();

    public List<Data> autoSavedData = new List<Data>();

    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] TMP_InputField matchNumberInputField;
    [SerializeField] TMP_InputField teamNumberInputField;

    [SerializeField] TMP_Dropdown taxiDropdown;

    [SerializeField] TMP_Text autonomousHighCounter;
    [SerializeField] TMP_Text autonomousLowCounter;

    [SerializeField] TMP_Text teleOpHighCounter;
    [SerializeField] TMP_Text teleOpLowCounter;

    [SerializeField] GameObject scrollViewContent;
    [SerializeField] GameObject savedDataPrefab;

    private string scoutingDataFolderPath;

    private void Start() // Autosave data starting in 5 seconds and every 10 seconds
    {
        PrepareForNextMatch();
        //InvokeRepeating("AutoSaveData", 5f, 10f);
        autonomousHighCounter.text = data.autonomousHigh.ToString();
        autonomousLowCounter.text = data.autonomousLow.ToString();
        // teleOpHighCounter.text = data.teleOpHigh.ToString();
        // teleOpLowCounter.text = data.teleOpLow.ToString();

        scoutingDataFolderPath = Application.persistentDataPath + "/ScoutingData/";
        Debug.Log(scoutingDataFolderPath);
    }

    //private void OnApplicationFocus(bool focus)
    //{
    //    if (!focus)
    //    {
    //        autoSavedData.Clear();
    //        autoSavedData.Add(data);
    //        Debug.Log("Data autosaved");
    //    }
    //}

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
        data.taxi = "No";
        data.autonomousHigh = 0;
        data.autonomousLow = 0;
        data.teleOpHigh = 0;
        data.teleOpLow = 0;
        autonomousHighCounter.text = 0.ToString();
        autonomousLowCounter.text = 0.ToString();
        teleOpHighCounter.text = 0.ToString();
        teleOpLowCounter.text = 0.ToString();
    }

    public void ExportData()
    {
        if (Directory.Exists(scoutingDataFolderPath))
        {
            //Debug.Log("Folder exists. Saving data...");

            var save = JsonConvert.SerializeObject(allData, Formatting.Indented);

            int randomNumber = UnityEngine.Random.Range(00000, 99999);

            File.WriteAllText(scoutingDataFolderPath + randomNumber + ".json", save);
        }
        else
        {
            //Debug.Log("Folder does not exist. Creating directory...");

            Directory.CreateDirectory(scoutingDataFolderPath);
        }
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

    public void AddTaxiToData()
    {
        data.taxi = taxiDropdown.options[taxiDropdown.value].text;
    }
}