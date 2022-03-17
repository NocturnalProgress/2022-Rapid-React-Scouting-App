using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeleOp : MonoBehaviour
{
    [SerializeField] DataManager dataManager;

    [SerializeField] TMP_Text teleOpHighCounter;
    [SerializeField] TMP_Text teleOpLowCounter;


    public void increaseTeleOpHigh()
    {
        dataManager.data.teleOpHigh += 2;
        teleOpHighCounter.text = dataManager.data.teleOpHigh.ToString();
    }

    public void decreaseTeleOpHigh()
    {
        dataManager.data.teleOpHigh -= 2;

        if (dataManager.data.teleOpHigh < 0)
        {
            dataManager.data.teleOpHigh = 0;
        }

        teleOpHighCounter.text = dataManager.data.teleOpHigh.ToString();
    }

    public void increaseTeleOpLow()
    {
        dataManager.data.teleOpLow += 1;
        teleOpLowCounter.text = dataManager.data.teleOpLow.ToString();
    }

    public void decreaseTeleOpLow()
    {
        dataManager.data.teleOpLow -= 1;

        if (dataManager.data.teleOpLow < 0)
        {
            dataManager.data.teleOpLow = 0;
        }

        teleOpLowCounter.text = dataManager.data.teleOpLow.ToString();
    }
}
