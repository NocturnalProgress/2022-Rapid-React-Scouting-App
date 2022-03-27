using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopulateScoutingDataPrefabFields : MonoBehaviour
{
    [SerializeField] TMP_InputField scouterNameInputField;
    [SerializeField] TMP_InputField teamNumberInputField;
    [SerializeField] TMP_InputField matchNumberInputField;
    [SerializeField] TMP_InputField taxiInputField;
    [SerializeField] TMP_InputField autonomousHighInputField;
    [SerializeField] TMP_InputField autonomousLowInputField;
    [SerializeField] TMP_InputField teleOpHighInputField;
    [SerializeField] TMP_InputField teleOpLowInputField;
    [SerializeField] TMP_InputField climbLevelInputField;
    [SerializeField] TMP_InputField alliancePartnerInputField;
    [SerializeField] TMP_InputField drivingEffectivenessInputField;
    [SerializeField] TMP_InputField defenseEffectivenessInputField;
    [SerializeField] TMP_InputField additionalNotesInputField;

    [SerializeField] List<Data> scoutingDataToUse = new List<Data>();


    public void DataToPopulateWith(Data dataToUse)
    {
        scoutingDataToUse.Add(dataToUse);
        scouterNameInputField.text = scoutingDataToUse[0].name;
        teamNumberInputField.text = scoutingDataToUse[0].teamNumber;
        matchNumberInputField.text = scoutingDataToUse[0].matchNumber.ToString();
        taxiInputField.text = scoutingDataToUse[0].taxi;
        autonomousHighInputField.text = scoutingDataToUse[0].autonomousHigh.ToString();
        autonomousLowInputField.text = scoutingDataToUse[0].autonomousLow.ToString();
        teleOpHighInputField.text = scoutingDataToUse[0].teleOpHigh.ToString();
        teleOpLowInputField.text = scoutingDataToUse[0].teleOpLow.ToString();
        climbLevelInputField.text = scoutingDataToUse[0].climbLevel;
        alliancePartnerInputField.text = scoutingDataToUse[0].alliancePartner;
        drivingEffectivenessInputField.text = scoutingDataToUse[0].drivingEffectiveness;
        defenseEffectivenessInputField.text = scoutingDataToUse[0].defenseEffectiveness;
        additionalNotesInputField.text = scoutingDataToUse[0].additionalNotes;
    }

    public void CloseScoutingDataDisplay()
    {
        gameObject.SetActive(false);
    }
}