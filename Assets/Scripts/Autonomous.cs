using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Autonomous : MonoBehaviour
{
    [SerializeField] DataManager dataManager;

    [SerializeField] TMP_Text autonomousHighCounter;
    [SerializeField] TMP_Text autonomousLowCounter;

    public void increaseAutonomousHigh()
    {
        dataManager.data.autonomousHigh += 4;
        autonomousHighCounter.text = dataManager.data.autonomousHigh.ToString();
    }

    public void decreaseAutonomousHigh()
    {
        dataManager.data.autonomousHigh -= 4;

        if (dataManager.data.autonomousHigh < 0)
        {
            dataManager.data.autonomousHigh = 0;
        }

        autonomousHighCounter.text = dataManager.data.autonomousHigh.ToString();
    }

    public void increaseAutonomousLow()
    {
        dataManager.data.autonomousLow += 2;
        autonomousLowCounter.text = dataManager.data.autonomousLow.ToString();
    }

    public void decreaseAutonomousLow()
    {
        dataManager.data.autonomousLow -= 2;

        if (dataManager.data.autonomousLow < 0)
        {
            dataManager.data.autonomousLow = 0;
        }

        autonomousLowCounter.text = dataManager.data.autonomousLow.ToString();
    }
}
