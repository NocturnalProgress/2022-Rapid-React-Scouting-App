using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendData : MonoBehaviour
{

    [SerializeField] List<Data> importedData;

    [SerializeField] EventsManager eventsManager;
    [SerializeField] NotificationSystem notificationSystem;

    private string googleFormURL = "https://docs.google.com/forms/d/e/1FAIpQLSc6KLQsCMLp5Xx1DS94gG3NAMscN73mQkQTjwUGaAh2aDuXLQ/formResponse";


    private void Start()
    {
        if (!ConnectedToInternet())
        {
            notificationSystem.NoNetworkAccess();
        }
    }

    public void GetDataToSend(Data importedData)
    {
        //importedData.Clear();
        //importedData = importedData;

        StartCoroutine(Post(importedData.name, importedData.teamNumber, importedData.matchNumber.ToString(), importedData.taxi, importedData.autonomousHigh.ToString(), importedData.autonomousLow.ToString(), importedData.teleOpHigh.ToString(), importedData.teleOpLow.ToString(), importedData.climbLevel, importedData.alliancePartner, importedData.drivingEffectiveness, importedData.defenseEffectiveness, importedData.additionalNotes));
    }

    //public void GetDataToSend(List<Data> importedData)
    //{
    //    Debug.Log("importedData.Count before clear: " + importedData.Count);
    //    //importedData.Clear();
    //    //importedData = importedData;
    //    Debug.Log("importedData.Count after clear: " + importedData.Count);


    //    for (int count = 0; count < importedData.Count; count++)
    //    {
    //        StartCoroutine(Post(importedData[count].name, importedData[count].teamNumber, importedData[count].matchNumber.ToString(), importedData[count].taxi, importedData[count].autonomousHigh.ToString(), importedData[count].autonomousLow.ToString(), importedData[count].teleOpHigh.ToString(), importedData[count].teleOpLow.ToString(), importedData[count].climbLevel, importedData[count].drivingEffectiveness, importedData[count].defenseEffectiveness, importedData[count].additionalNotes));
    //    }
    //}

    private IEnumerator Post(string name, string teamNumber, string matchNumber, string taxi, string autonomousHigh, string autonomousLow, string teleOpHigh, string teleOpLow, string climbLevel, string alliancePartner, string drivingEffectiveness, string defenseEffectiveness, string additionalNotes)
    {
        WWWForm form = new WWWForm(); // This fills out the form input fields
        form.AddField("entry.1317882528", name);
        form.AddField("entry.1858266580", teamNumber);
        form.AddField("entry.1505419592", matchNumber);
        form.AddField("entry.728185797", taxi);
        form.AddField("entry.11060155", autonomousHigh);
        form.AddField("entry.450539814", autonomousLow);
        form.AddField("entry.1924468322", teleOpHigh);
        form.AddField("entry.1071090911", teleOpLow);
        form.AddField("entry.680301956", climbLevel);
        form.AddField("entry.984116978", alliancePartner);
        form.AddField("entry.232468374", drivingEffectiveness);
        form.AddField("entry.1464493210", defenseEffectiveness);
        form.AddField("entry.1605875202", additionalNotes);


        UnityWebRequest www = UnityWebRequest.Post(googleFormURL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError) // Displays error via notification system
        {
            notificationSystem.DataUploadFail(www.error);
        }
        else
        {
            notificationSystem.DataUploadSuccess();
        }
    }

    public bool ConnectedToInternet() // This checks if the app is able to connect to google forms
    {
        UnityWebRequest request = new UnityWebRequest("https://www.google.com/forms/about/");
        if (request.error != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void ClearImportedData()
    {
        importedData.Clear();
    }
}