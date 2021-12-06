using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System;
using TMPro;

[Serializable]
public class SerializeData : MonoBehaviour
{
    public Data data;

    public List<Data> allData = new List<Data>();

    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] TMP_InputField matchNumberInputField;
    [SerializeField] TMP_InputField teamNumberInputField;

    public void SaveData()
    {
        allData.Add(data);
    }

    public void ExportData()
    {
        var save = JsonConvert.SerializeObject(allData, Formatting.Indented);

        int randomNumber = UnityEngine.Random.Range(00000, 99999);

        System.IO.File.WriteAllText(Application.dataPath + "/TestData/" + randomNumber + ".json", save);
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