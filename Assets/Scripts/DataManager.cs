using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Newtonsoft.Json;
using System;
using TMPro;
using System.IO;

//[Serializable]
//public class SendDataEvent : UnityEvent<List<Data>> { }

//[Serializable]
//public class ExportDataEvent : UnityEvent<List<Data>> { }

[Serializable]
public class DataManager : MonoBehaviour
{
    //[SerializeField] SendDataEvent sendDataEvent;

    [SerializeField] NotificationSystem notificationSystem;

    [SerializeField] SendData sendData;

    [SerializeField] ExportViaCSV exportViaCSV;

    public Data data;

    public List<Data> allData = new List<Data>();

    public List<Data> autoSavedData = new List<Data>();

    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] TMP_InputField matchNumberInputField;
    [SerializeField] TMP_InputField teamNumberInputField;
    [SerializeField] TMP_InputField additionalNotesInputField;

    [SerializeField] TMP_Dropdown taxiDropdown;
    [SerializeField] TMP_Dropdown climbLevelDropdown;
    [SerializeField] TMP_Dropdown drivingEffectivenessDropdown;
    [SerializeField] TMP_Dropdown defenseEffectivenessDropdown;
    [SerializeField] TMP_Dropdown alliancePartnerDropdown;

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
        autonomousHighCounter.text = data.autonomousHigh.ToString();
        autonomousLowCounter.text = data.autonomousLow.ToString();

        scoutingDataFolderPath = Application.persistentDataPath + "/UncompiledJsonScoutingData/";
    }

    public void SaveData() // Export via Forms
    {
        if (nameInputField.text == "")
        {
            notificationSystem.DataSaveFail();
        }
        else
        {
            allData.Add(data);
            notificationSystem.DataSaveSuccess();
            PrepareForNextMatch();
        }
    }

    public void ExportDataToJSON()
    {
        if (Directory.Exists(scoutingDataFolderPath))
        {
            var save = JsonConvert.SerializeObject(allData, Formatting.Indented);
            File.WriteAllText(scoutingDataFolderPath + UnityEngine.Random.Range(00000, 99999) + ".json", save);

            notificationSystem.DataSaveSuccess();
            ClearAllData();
        }
        else
        {
            Directory.CreateDirectory(scoutingDataFolderPath);
        }
    }

    public void ExportDataToCSV() // Export via CSV
    {
        if (allData.Count == 0)
        {
            notificationSystem.NoDataToExport();
        }
        else
        {
            for (int i = 0; i < allData.Count; i++)
            {
                exportViaCSV.GetDataToExport(allData[i]);
            }
            ClearAllData();
        }
    }

    public void SendDataToForms()
    {
        //sendData.GetDataToSend(allData);
        //sendDataEvent.Invoke(allData);

        if (allData.Count == 0)
        {
            notificationSystem.NoDataToExport();
        }
        else
        {
            for (int i = 0; i < allData.Count; i++)
            {
                sendData.GetDataToSend(allData[i]);
            }
            ClearAllData();
        }
    }

    public void PrepareForNextMatch()
    {
        data.name = "";
        nameInputField.text = "";
        data.teamNumber = "";
        teamNumberInputField.text = "";
        matchNumberInputField.text = "";
        data.taxi = "No";
        taxiDropdown.value = 0;
        data.autonomousHigh = 0;
        data.autonomousLow = 0;
        data.teleOpHigh = 0;
        data.teleOpLow = 0;
        autonomousHighCounter.text = 0.ToString();
        autonomousLowCounter.text = 0.ToString();
        teleOpHighCounter.text = 0.ToString();
        teleOpLowCounter.text = 0.ToString();
        data.climbLevel = 0.ToString();
        climbLevelDropdown.value = 0;
        alliancePartnerDropdown.value = 0;
        data.alliancePartner = alliancePartnerDropdown.options[alliancePartnerDropdown.value].text;
        data.drivingEffectiveness = 0.ToString();
        drivingEffectivenessDropdown.value = 0;
        data.defenseEffectiveness = 0.ToString();
        defenseEffectivenessDropdown.value = 0;
        data.additionalNotes = "";
        additionalNotesInputField.text = "";
    }

    public void ClearAllData()
    {
        allData.Clear();

        data.name = "";
        nameInputField.text = "";
        data.teamNumber = "";
        teamNumberInputField.text = "";
        matchNumberInputField.text = "";
        data.taxi = "No";
        taxiDropdown.value = 0;
        data.autonomousHigh = 0;
        data.autonomousLow = 0;
        data.teleOpHigh = 0;
        data.teleOpLow = 0;
        autonomousHighCounter.text = 0.ToString();
        autonomousLowCounter.text = 0.ToString();
        teleOpHighCounter.text = 0.ToString();
        teleOpLowCounter.text = 0.ToString();
        data.climbLevel = 0.ToString();
        data.alliancePartner = alliancePartnerDropdown.options[alliancePartnerDropdown.value].text;
        climbLevelDropdown.value = 0;
        alliancePartnerDropdown.value = 0;
        data.drivingEffectiveness = 0.ToString();
        drivingEffectivenessDropdown.value = 0;
        data.defenseEffectiveness = 0.ToString();
        defenseEffectivenessDropdown.value = 0;
        data.additionalNotes = "";
        additionalNotesInputField.text = "";

        notificationSystem.AllDataCleared();
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
        if (!string.IsNullOrWhiteSpace(matchNumberInputField.text))
        {
            data.matchNumber = Convert.ToInt32(matchNumberInputField.text);
        }
    }

    public void AddTaxiToData()
    {
        data.taxi = taxiDropdown.options[taxiDropdown.value].text;
    }

    public void AddAlliancePartnerToData()
    {
        data.alliancePartner = alliancePartnerDropdown.options[alliancePartnerDropdown.value].text;
    }

    public void AddClimbLevelToData()
    {
        data.climbLevel = climbLevelDropdown.options[climbLevelDropdown.value].text;
    }

    public void AddDrivingEffectivenessToData()
    {
        data.drivingEffectiveness = drivingEffectivenessDropdown.options[drivingEffectivenessDropdown.value].text;
    }

    public void AddDefenseEffectivenessToData()
    {
        data.defenseEffectiveness = defenseEffectivenessDropdown.options[defenseEffectivenessDropdown.value].text;
    }

    public void AddAdditionalNotesToData()
    {
        data.additionalNotes = additionalNotesInputField.text;
    }
}