using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Autonomous : MonoBehaviour
{
    [SerializeField] SerializeData serializeData;

    [SerializeField] TMP_Text autonomousHighCounter;
    [SerializeField] TMP_Text autonomousLowCounter;


    public void increaseAutonomousHigh()
    {
        serializeData.data.autonomousHigh += 4;
        autonomousHighCounter.text = serializeData.data.autonomousHigh.ToString();
    }

    public void decreaseAutonomousHigh()
    {
        serializeData.data.autonomousHigh -= 4;
        autonomousHighCounter.text = serializeData.data.autonomousHigh.ToString();
    }

    public void increaseAutonomousLow()
    {
        serializeData.data.autonomousLow += 2;
        autonomousLowCounter.text = serializeData.data.autonomousLow.ToString();
    }

    public void decreaseAutonomousLow()
    {
        serializeData.data.autonomousLow += 2;
        autonomousLowCounter.text = serializeData.data.autonomousLow.ToString();

    }
}
