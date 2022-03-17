using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ViewSavedData : MonoBehaviour
{
    public GameObject savedDataPrefabLink;


    public void GetSavedDataPrefab(GameObject prefabLink)
    {
        savedDataPrefabLink = prefabLink;
    }

    public void OpenSavedData()
    {
        savedDataPrefabLink.SetActive(true);
    }
}