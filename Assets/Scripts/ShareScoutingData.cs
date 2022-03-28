using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ShareScoutingData : MonoBehaviour
{
    [SerializeField] GameObject shareDataScrollViewContent;

    private string compiledCSVFolderPath;

    private TextAsset foundCSVFile;

    [SerializeField] List<string> allCompiledCSVFileLocations = new List<string>();

    private void Start()
    {
        compiledCSVFolderPath = Application.persistentDataPath + "/CompiledCSVFiles/";

    }

    public void LoadAllCSVFiles()
    {
        foreach (string newPath in Directory.GetFiles(compiledCSVFolderPath, "*.csv"))
        {
            //foundCSVFile = new TextAsset(File.ReadAllText(newPath));

            allCompiledCSVFileLocations.Add(newPath);
        }
    }


    public void ShareCSVFile()
    {
        StartCoroutine(ShareFile(allCompiledCSVFileLocations[0]));
    }



    private IEnumerator ShareFile(string filePath) // This opens the IOS share menu to allow AirDropping
    {
        yield return new WaitForEndOfFrame();

        new NativeShare().AddFile(filePath)
            .SetSubject("Scouting Data")
            // .SetText("Hello world!")
            // .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();
    }
}
