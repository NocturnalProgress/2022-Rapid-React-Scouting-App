using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ExportViaCSV : MonoBehaviour
{
    [SerializeField] NotificationSystem notificationSystem;

    private string CSVFilePath;

    private void Start()
    {
        CreateNewCSVFile();
    }

    public void GetDataToExport(Data importedData)
    {
        CheckFolderExistence("/CompiledScoutingData");
        CheckFolderExistence("/UncompiledScoutingData");

        CheckFileExistence();
        CreateCSVTitles();
        WriteToCSV(importedData.name, importedData.teamNumber, importedData.matchNumber.ToString(), importedData.taxi, importedData.autonomousHigh.ToString(), importedData.autonomousLow.ToString(), importedData.teleOpHigh.ToString(), importedData.teleOpLow.ToString(), importedData.climbLevel, importedData.alliancePartner, importedData.drivingEffectiveness, importedData.defenseEffectiveness, importedData.additionalNotes);
    }

    private void CheckFolderExistence(string folderLocation)
    {
        if (!Directory.Exists(Application.persistentDataPath + folderLocation))
        {
            Directory.CreateDirectory(Application.persistentDataPath + folderLocation);
        }
    }

    private void CheckFileExistence()
    {
        if (!File.Exists(CSVFilePath))
        {
            CreateNewCSVFile();
        }
    }

    private void CreateNewCSVFile()
    {
        CSVFilePath = Application.persistentDataPath + "/UncompiledScoutingData/UncompiledScoutingData_" + UnityEngine.Random.Range(00000, 99999) + ".csv";
    }

    private void CreateCSVTitles()
    {
        if (!File.Exists(CSVFilePath)) //Include titles if Saved_data.csv does not exist
        {
            try
            {
                using (StreamWriter file = new StreamWriter(CSVFilePath, true))
                {
                    file.WriteLine("Name" + "," + "Team Number" + "," + "Match Number" + "," + "Did The Team Taxi?" + "," + "Autonomous High" + "," + "Autonomous Low" + "," + "TeleOp High" + "," + "TeleOp Low" + "," + "Climb Level" + "," + "Alliance Partner" + "," + "Driving Effectiveness" + "," + "Defense Effectiveness" + "," + "Additional Notes");
                    file.Close();
                }

            }
            catch (Exception error)
            {
                Debug.Log("Create Titles Failed: " + error);
            }
        }
    }

    private void WriteToCSV(string name, string teamNumber, string matchNumber, string taxi, string autonomousHigh, string autonomousLow, string teleOpHigh, string teleOpLow, string climbLevel, string alliancePartner, string drivingEffectiveness, string defenseEffectiveness, string additionalNotes)
    {
        try
        {
            using (StreamWriter file = new StreamWriter(CSVFilePath, true))
            {
                file.WriteLine(name + "," + teamNumber + "," + matchNumber + "," + taxi + "," + autonomousHigh + "," + autonomousLow + "," + teleOpHigh + "," + teleOpLow + "," + climbLevel + "," + alliancePartner + "," + drivingEffectiveness + "," + defenseEffectiveness + "," + additionalNotes.Replace("\n", "; ").Replace("\r", "; "));
                file.Close();
            }
        }
        catch (Exception error)
        {
            notificationSystem.DataExportFailed(error);
        }
    }
}