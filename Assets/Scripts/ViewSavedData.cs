﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ViewSavedData : MonoBehaviour
{
    public GameObject savedDataPrefabLink;

    [SerializeField] Button shareScoutingDataButton;

    private string compiledCSVFolderPath;

    private void Start()
    {
        compiledCSVFolderPath = Application.persistentDataPath + "/CompiledCSVFiles/";
    }

    public void GetSavedDataPrefab(GameObject prefabLink)
    {
        savedDataPrefabLink = prefabLink;
    }

    public void OpenSavedData()
    {
        savedDataPrefabLink.SetActive(true);
    }

    public void ShareCSVFile()
    {
        StartCoroutine(ShareFile(compiledCSVFolderPath + shareScoutingDataButton.name));
    }

    private IEnumerator ShareFile(string filePath) // This opens the IOS share menu to allow AirDropping
    {
        yield return new WaitForEndOfFrame();

        // Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        // ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        // ss.Apply();

        // string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        // File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        // Destroy(ss);

        new NativeShare().AddFile(filePath)
            .SetSubject("Scouting Data")
            // .SetText("Hello world!")
            // .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();

        // Share on WhatsApp only, if installed (Android only)
        //if( NativeShare.TargetExists( "com.whatsapp" ) )
        //	new NativeShare().AddFile( filePath ).AddTarget( "com.whatsapp" ).Share();
    }
}