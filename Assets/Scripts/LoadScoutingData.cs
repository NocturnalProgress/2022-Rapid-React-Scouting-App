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

    [SerializeField] List<Data> loadedScoutingData = new List<Data>();

    [SerializeField] [HideInInspector] List<TextAsset> importedTextAssets = new List<TextAsset>();

    private string path;

    // Scouting data is loaded into "importedTextAssets" list as a TextAsset
    // Finally Scouting Data is added to "loadedScoutingData" for use

    private void Start()
    {
        path = Application.dataPath + "/Resources/TestData/";

    }

    public void LoadSavedData()
    {
        loadedScoutingData.Clear();

        foreach (string scoutingDataPath in Directory.GetFiles(path, "*.json"))
        {
            importedTextAssets.Add(Resources.Load<TextAsset>("TestData/" + Path.GetFileNameWithoutExtension(scoutingDataPath)));
        }

        for (int i = 0; i < importedTextAssets.Count; i++)
        {
            var pulledDataFromFile = JsonConvert.DeserializeObject<List<Data>>(importedTextAssets[i].ToString());
            for (int j = 0; j < pulledDataFromFile.Count; j++)
            {
                loadedScoutingData.Add(pulledDataFromFile[j]);
            }
        }

        importedTextAssets.Clear();

        PopulateSavedDataScrollView();
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
