using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using TMPro;

public class LoadScoutingDataTest : MonoBehaviour
{

    [SerializeField] ExportViaCSV exportViaCSV;

    [SerializeField] NotificationSystem notificationSystem;

    [SerializeField] GameObject uncompiledDataScrollViewContent;
    [SerializeField] GameObject compiledDataScrollViewContent;
    [SerializeField] GameObject viewSavedDataPrefab;
    [SerializeField] GameObject savedDataPrefab;
    [SerializeField] GameObject savedDataParent;

    private string uncompiledScoutingDataFolderPath;
    private string compiledScoutingDataFolderPath;
    private string compiledCSVFolderPath;

    private TextAsset jsonFile;

    [SerializeField] List<Data> allUncompiledScoutingData = new List<Data>();

    [SerializeField] List<Data> allCompiledScoutingData = new List<Data>();

    private void Start()
    {
        uncompiledScoutingDataFolderPath = Application.persistentDataPath + "/UncompiledScoutingData/";
        compiledScoutingDataFolderPath = Application.persistentDataPath + "/CompiledScoutingData/";
        compiledCSVFolderPath = Application.persistentDataPath + "/CompiledCSVFiles/";
    }

    public void EasyLoadAllScoutingData()
    {
        LoadUncompiledScoutingData();
        ExportUncompiledScoutingData();
        LoadCompiledScoutingData();
    }

    public void LoadUncompiledScoutingData() // Need to check if directory contains files
    {
        // Get file name from button then add it to the compiledScoutingDataFolderPath

        if (!Directory.Exists(uncompiledScoutingDataFolderPath))
        {
            Directory.CreateDirectory(uncompiledScoutingDataFolderPath);
        }
        allUncompiledScoutingData.Clear();

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
                //Debug.Log("foundScoutingData: \n" + allUncompiledScoutingData[i].name + ", " + allUncompiledScoutingData[i].autonomousHigh + ", " + allUncompiledScoutingData[i].matchNumber);
                GameObject instantiatedsavedDataPrefab = Instantiate(savedDataPrefab, savedDataParent.transform, false);
                instantiatedsavedDataPrefab.GetComponent<PopulateScoutingDataPrefabFields>().DataToPopulateWith(allUncompiledScoutingData[i]);
                //PopulateSavedDataScrollView(instantiatedsavedDataPrefab);
            }
        }
        notificationSystem.FinishedLoadingUncompiledScoutingData();
    }

    public void LoadScoutingData(string folderPath, List<Data> scoutingDataList)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        scoutingDataList.Clear();

        foreach (string newPath in Directory.GetFiles(folderPath, "*.json"))
        {
            jsonFile = new TextAsset(File.ReadAllText(newPath));
            var pulledDataFromFile = JsonConvert.DeserializeObject<List<Data>>(jsonFile.ToString());
        }
    }

    public void LoadCompiledScoutingData()
    {
        if (!Directory.Exists(compiledScoutingDataFolderPath))
        {
            Directory.CreateDirectory(compiledScoutingDataFolderPath);
        }
        allCompiledScoutingData.Clear();

        foreach (string newPath in Directory.GetFiles(compiledScoutingDataFolderPath, "*.json"))
        {
            jsonFile = new TextAsset(File.ReadAllText(newPath));
            var pulledDataFromFile = JsonConvert.DeserializeObject<List<Data>>(jsonFile.ToString());

            for (int j = 0; j < pulledDataFromFile.Count; j++)
            {
                allCompiledScoutingData.Add(pulledDataFromFile[j]);
            }

            for (int i = 0; i < allCompiledScoutingData.Count; i++)
            {
                //Debug.Log("foundScoutingData: \n" + allUncompiledScoutingData[i].name + ", " + allUncompiledScoutingData[i].autonomousHigh + ", " + allUncompiledScoutingData[i].matchNumber);
                GameObject instantiatedsavedDataPrefab = Instantiate(savedDataPrefab, savedDataParent.transform, false);
                instantiatedsavedDataPrefab.GetComponent<PopulateScoutingDataPrefabFields>().DataToPopulateWith(allCompiledScoutingData[i]);
                //PopulateSavedDataScrollView(instantiatedsavedDataPrefab);
            }
        }
        notificationSystem.FinishedLoadingCompiledScoutingData();
    }

    public void ExportUncompiledScoutingData()
    {
        if (allUncompiledScoutingData.Count == 0)
        {
            notificationSystem.NoUncompiledDataFound();
        }
        else
        {
            if (!Directory.Exists(compiledScoutingDataFolderPath))
            {
                Directory.CreateDirectory(compiledScoutingDataFolderPath);
            }

            var save = JsonConvert.SerializeObject(allUncompiledScoutingData, Formatting.Indented);
            File.WriteAllText(compiledScoutingDataFolderPath + UnityEngine.Random.Range(00000, 99999) + ".json", save);

            //foreach (Transform child in uncompiledDataScrollViewContent.transform)
            //{
            //    Destroy(child.gameObject);
            //}

            allUncompiledScoutingData.Clear();
            notificationSystem.FinishedCompilingAllScoutingData();
        }
    }

    public void ConvertCompiledDataToCSV()
    {
        if (allCompiledScoutingData.Count == 0)
        {
            notificationSystem.NoCompiledDataFound();
        }
        else
        {
            if (!Directory.Exists(compiledCSVFolderPath))
            {
                Directory.CreateDirectory(compiledCSVFolderPath);
            }

            for (int i = 0; i < allCompiledScoutingData.Count; i++)
            {
                exportViaCSV.GetDataToExport(allCompiledScoutingData[i]);
            }

            //foreach (Transform child in compiledDataScrollViewContent.transform)
            //{
            //    Destroy(child.gameObject);
            //}

            allCompiledScoutingData.Clear();
            notificationSystem.FinishedConvertingCompiledDataToCSV();
        }
    }

    private void PopulateSavedDataScrollView(GameObject savedDataPrefabLink)
    {
        foreach (Transform child in uncompiledDataScrollViewContent.transform)
        {
            Destroy(child.gameObject);
        }

        for (int g = 0; g < allUncompiledScoutingData.Count; g++)
        {
            Debug.Log(allUncompiledScoutingData[g]);
            GameObject instantiatedViewSavedData = Instantiate(viewSavedDataPrefab, uncompiledDataScrollViewContent.transform, false);
            instantiatedViewSavedData.transform.Find("SelectScoutingDataButton").GetComponentInChildren<TMP_Text>().text = allUncompiledScoutingData[g].name;

            instantiatedViewSavedData.GetComponent<ViewSavedData>().GetSavedDataPrefab(savedDataPrefabLink);
        }
    }
}
