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
        StartCoroutine(Post(importedData.name, importedData.teamNumber, importedData.matchNumber.ToString(), importedData.taxi,
            importedData.autonomousHighScored.ToString(), importedData.autonomousHighMissed.ToString(),
            importedData.autonomousLowScored.ToString(), importedData.autonomousLowMissed.ToString(),
            importedData.teleOpHighScored.ToString(), importedData.teleOpHighMissed.ToString(),
            importedData.teleOpLowScored.ToString(), importedData.teleOpLowMissed.ToString(),
            importedData.climbLevel, importedData.alliancePartner, importedData.drivingEffectiveness,
            importedData.defenseEffectiveness, importedData.additionalNotes));
        notificationSystem.DataUploadSuccess();
    }

    private IEnumerator Post(string name, string teamNumber, string matchNumber, string taxi, string autonomousHighScored, string autonomousHighMissed, string autonomousLowScored, string autonomousLowMissed, string teleOpHighScored, string teleOpHighMissed, string teleOpLowScored, string teleOpLowMissed, string climbLevel, string alliancePartner, string drivingEffectiveness, string defenseEffectiveness, string additionalNotes)
    {
        WWWForm form = new WWWForm(); // This fills out the form input fields
        form.AddField("entry.1317882528", name);
        form.AddField("entry.1858266580", teamNumber);
        form.AddField("entry.1505419592", matchNumber);
        form.AddField("entry.728185797", taxi);
        form.AddField("entry.11060155", autonomousHighScored);
        form.AddField("entry.450539814", autonomousHighMissed);
        form.AddField("entry.1924468322", autonomousLowScored);
        form.AddField("entry.1231967687", autonomousLowMissed);
        form.AddField("entry.1071090911", teleOpHighScored);
        form.AddField("entry.1632037445", teleOpHighMissed);
        form.AddField("entry.938731060", teleOpLowScored);
        form.AddField("entry.1637358504", teleOpLowMissed);
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
            // Data upload success
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