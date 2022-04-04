using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class LoadScoutingDataTest : MonoBehaviour
{

    [SerializeField] ExportViaCSV exportViaCSV;

    [SerializeField] NotificationSystem notificationSystem;

    [SerializeField] GameObject CSVFileShare;
    [SerializeField] GameObject CSVFileScrollViewContent;

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
        ConvertCompiledDataToCSV();
        notificationSystem.FinishedConvertingCompiledDataToCSV();

        foreach (string uncompiledScoutingDataFilePath in Directory.GetFiles(uncompiledScoutingDataFolderPath, "*.json"))
        {
            File.Delete(uncompiledScoutingDataFilePath);
        }
        foreach (string compiledScoutingDataFilePath in Directory.GetFiles(compiledScoutingDataFolderPath, "*.json"))
        {
            File.Delete(compiledScoutingDataFilePath);
        }

        PopulateCSVFileScrollView();


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
        }
        //notificationSystem.FinishedLoadingUncompiledScoutingData();
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
        }
        //notificationSystem.FinishedLoadingCompiledScoutingData();
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

            allUncompiledScoutingData.Clear();
            //notificationSystem.FinishedCompilingAllScoutingData();
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

            allCompiledScoutingData.Clear();
            //notificationSystem.FinishedConvertingCompiledDataToCSV();
        }
    }

    public void PopulateCSVFileScrollView()
    {
        foreach (Transform child in CSVFileScrollViewContent.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (string CSVFilePath in Directory.GetFiles(compiledCSVFolderPath, "*.csv"))
        {
            GameObject instantiatedCSVFileShare = Instantiate(CSVFileShare, CSVFileScrollViewContent.transform, false);
            ShareScoutingData tempShareScoutingData = instantiatedCSVFileShare.GetComponent<ShareScoutingData>();
            tempShareScoutingData.CSVFilePath = CSVFilePath;
        }
    }
}
