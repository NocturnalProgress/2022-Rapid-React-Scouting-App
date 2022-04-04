using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ShareScoutingData : MonoBehaviour
{
    public string CSVFilePath;

    public Button fileNameButton;
    public Button shareCSVButton;

    [SerializeField] TMP_Text fileNameButtonText;

    private void Start()
    {
        fileNameButtonText.text = Regex.Match(Path.GetFileName(CSVFilePath), @"\d+").Value + ".csv";
    }

    public void ShareCSVFile()
    {
        StartCoroutine(ShareFile(CSVFilePath));
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
