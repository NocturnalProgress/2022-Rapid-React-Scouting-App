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
    [SerializeField] GameObject savedDataPrefab;

    private string path;

    private string scoutingDataFolderPath;

    private TextAsset jsonFile;

    [SerializeField] GameObject loadedScoutingDataPrefab;

    [SerializeField] List<Data> loadedScoutingData = new List<Data>();

    [SerializeField] [HideInInspector] List<TextAsset> importedTextAssets = new List<TextAsset>();



    // Scouting data is loaded into "importedTextAssets" list as a TextAsset
    // Finally Scouting Data is added to "loadedScoutingData" for use

    private void Start()
    {
        path = Application.dataPath + "/Resources/TestData/";

        scoutingDataFolderPath = Application.persistentDataPath + "/ScoutingData/";
    }

    //public void LoadSavedData()
    //{
    //    loadedScoutingData.Clear();

    //    foreach (string scoutingDataPath in Directory.GetFiles(path, "*.json"))
    //    {
    //        importedTextAssets.Add(Resources.Load<TextAsset>("TestData/" + Path.GetFileNameWithoutExtension(scoutingDataPath)));
    //    }

    //    for (int i = 0; i < importedTextAssets.Count; i++)
    //    {
    //        var pulledDataFromFile = JsonConvert.DeserializeObject<List<Data>>(importedTextAssets[i].ToString());
    //        for (int j = 0; j < pulledDataFromFile.Count; j++)
    //        {
    //            loadedScoutingData.Add(pulledDataFromFile[j]);
    //        }
    //    }

    //    importedTextAssets.Clear();

    //    PopulateSavedDataScrollView();
    //}

    public void LoadSavedData()
    {
        foreach (string newPath in Directory.GetFiles(scoutingDataFolderPath, "*.json"))
        {
            jsonFile = new TextAsset(File.ReadAllText(newPath));
            //Debug.Log("jsonFile \n" + jsonFile);

            var pulledDataFromFile = JsonConvert.DeserializeObject<List<Data>>(jsonFile.ToString());
            //Debug.Log("pulledDataFromFile: \n" + pulledDataFromFile);

            for (int j = 0; j < pulledDataFromFile.Count; j++)
            {
                loadedScoutingData.Add(pulledDataFromFile[j]);
            }

            //Debug.Log("loadedScoutingData: \n" + loadedScoutingData);
        }

        PopulateSavedDataScrollView();
        //foreach (Data foundScoutingData in loadedScoutingData)
        //{
        //    Debug.Log("foundScoutingData: \n" + foundScoutingData.matchNumber);
        //    Debug.Log("foundScoutingData: \n" + foundScoutingData.teamNumber);

        //}
    }

    private void PopulateSavedDataScrollView()
    {
        for (int g = 0; g < loadedScoutingData.Count; g++)
        {
            GameObject instantiatedSavedData = Instantiate(savedDataPrefab, scrollViewContent.transform, false) as GameObject;
            instantiatedSavedData.transform.Find("SelectScoutingDataButton").GetComponentInChildren<TMP_Text>().text = loadedScoutingData[g].name;
        }
    }
}
