using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class NotificationSystem : MonoBehaviour
{
    [SerializeField] GameObject notificationPrefab;

    private GameObject notification;

    public void DisplayNotificationCanvas(string message)
    {
        notification = Instantiate(notificationPrefab.gameObject, new Vector3(0, 0, 0), transform.rotation) as GameObject;
        notification.transform.SetParent(gameObject.transform, false);
        notification.transform.localScale = new Vector3(1, 1, 1);

        SetNotificationMessage(message);
    }

    public void DataSaveSuccess()
    {
        DisplayNotificationCanvas("Data Saved!");
    }

    public void DataSaveFail()
    {
        DisplayNotificationCanvas("Error: Name is empty!");
    }

    public void DataUploadSuccess()
    {
        DisplayNotificationCanvas("Data Upload Success!");
    }

    public void DataUploadFail(string error)
    {
        DisplayNotificationCanvas("Error Uploading Data: " + error);
    }

    public void NoNetworkAccess()
    {
        DisplayNotificationCanvas("Error: Not connected to internet!");
    }

    public void NoDataToExport()
    {
        DisplayNotificationCanvas("Error: There is no data to export!");
    }

    public void AllDataCleared()
    {
        DisplayNotificationCanvas("All Data Cleared!");
    }

    public void DataExportSuccess()
    {
        DisplayNotificationCanvas("Data Export Success!");
    }

    public void DataExportFailed(Exception error)
    {
        DisplayNotificationCanvas("Error Uploading Data: " + error);
    }


    private void SetNotificationMessage(string message)
    {
        notification.GetComponent<Notification>().notificationMessage.text = message;
    }
}
