using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using TMPro;

public class LoadScoutingData : MonoBehaviour
{
    [HideInInspector] public Data data;

    [SerializeField] GameObject scrollViewContent;
    [SerializeField] GameObject viewSavedDataPrefab;
    [SerializeField] GameObject savedDataPrefab;
    [SerializeField] GameObject savedDataParent;

    private string uncompiledScoutingDataFolderPath;
    private string compiledScoutingDataFolderPath;

    private TextAsset jsonFile;

    public List<Data> allUncompiledScoutingData = new List<Data>();

    private void Start()
    {
        uncompiledScoutingDataFolderPath = Application.persistentDataPath + "/UncompiledScoutingData/";
        compiledScoutingDataFolderPath = Application.persistentDataPath + "/CompiledScoutingData/";
    }

    public void LoadSavedData()
    {
        if (!Directory.Exists(uncompiledScoutingDataFolderPath))
        {
            Directory.CreateDirectory(uncompiledScoutingDataFolderPath);
        }

        foreach (string newPath in Directory.GetFiles(uncompiledScoutingDataFolderPath, "*.json"))
        {
            jsonFile = new TextAsset(File.ReadAllText(newPath));
            var pulledDataFromFile = JsonConvert.DeserializeObject<List<Data>>(jsonFile.ToString());

            for (int j = 0; j < pulledDataFromFile.Count; j++)
            {
                allUncompiledScoutingData.Add(pulledDataFromFile[j]);
            }

            for (int i = 0; i < allUncompiledScoutingData.Count; i++)
            {
                Debug.Log("foundScoutingData: \n" + allUncompiledScoutingData[i].name + ", " + allUncompiledScoutingData[i].autonomousHigh + ", " + allUncompiledScoutingData[i].matchNumber);
                GameObject instantiatedsavedDataPrefab = Instantiate(savedDataPrefab, savedDataParent.transform, false);
                instantiatedsavedDataPrefab.GetComponent<PopulateScoutingDataPrefabFields>().DataToPopulateWith(allUncompiledScoutingData[i]);
                PopulateSavedDataScrollView(instantiatedsavedDataPrefab);
            }
        }
    }

    public void ExportUncompiledScoutingData()
    {
        if (!Directory.Exists(compiledScoutingDataFolderPath))
        {
            Directory.CreateDirectory(compiledScoutingDataFolderPath);
        }

        var save = JsonConvert.SerializeObject(allUncompiledScoutingData, Formatting.Indented);
        File.WriteAllText(compiledScoutingDataFolderPath + UnityEngine.Random.Range(00000, 99999) + ".json", save);

        //notificationSystem.DataSaveSuccess();
        //ClearAllData();
        allUncompiledScoutingData.Clear();

        Debug.Log("Compiled Data");
    }

    private void PopulateSavedDataScrollView(GameObject savedDataPrefabLink)
    {
        foreach (Transform child in scrollViewContent.transform)
        {
            Destroy(child.gameObject);
        }

        for (int g = 0; g < allUncompiledScoutingData.Count; g++)
        {
            Debug.Log(allUncompiledScoutingData[g]);
            GameObject instantiatedViewSavedData = Instantiate(viewSavedDataPrefab, scrollViewContent.transform, false);
            instantiatedViewSavedData.transform.Find("SelectScoutingDataButton").GetComponentInChildren<TMP_Text>().text = allUncompiledScoutingData[g].name;

            instantiatedViewSavedData.GetComponent<ViewSavedData>().GetSavedDataPrefab(savedDataPrefabLink);
        }
    }
}
