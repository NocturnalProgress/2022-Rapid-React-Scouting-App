using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeleOp : MonoBehaviour
{
    [SerializeField] SerializeData serializeData;

    [SerializeField] TMP_Text teleOpHighCounter;
    [SerializeField] TMP_Text teleOpLowCounter;


    public void increaseTeleOpHigh()
    {
        serializeData.data.teleOpHigh += 4;
        teleOpHighCounter.text = serializeData.data.teleOpHigh.ToString();
    }

    public void decreaseTeleOpHigh()
    {
        serializeData.data.teleOpHigh -= 4;
        teleOpHighCounter.text = serializeData.data.teleOpHigh.ToString();
    }

    public void increaseTeleOpLow()
    {
        serializeData.data.teleOpLow += 2;
        teleOpLowCounter.text = serializeData.data.teleOpLow.ToString();
    }

    public void decreaseTeleOpLow()
    {
        serializeData.data.teleOpLow += 2;
        teleOpLowCounter.text = serializeData.data.teleOpLow.ToString();

    }
}
