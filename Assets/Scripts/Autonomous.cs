using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Autonomous : MonoBehaviour
{
    [SerializeField] DataManager dataManager;

    [SerializeField] TMP_Text autonomousHighScoredCounter;
    [SerializeField] TMP_Text autonomousHighMissedCounter;
    [SerializeField] TMP_Text autonnomousLowScoredCounter;
    [SerializeField] TMP_Text autonomousLowMissedCounter;

    public void IncreaseAutonomousHighScored()
    {
        dataManager.data.autonomousHighScored += 1;
        autonomousHighScoredCounter.text = dataManager.data.autonomousHighScored.ToString();
    }

    public void DecreaseAutonomousHighScored()
    {
        dataManager.data.autonomousHighScored -= 1;

        if (dataManager.data.autonomousHighScored < 0)
        {
            dataManager.data.autonomousHighScored = 0;
        }
        autonomousHighScoredCounter.text = dataManager.data.autonomousHighScored.ToString();

    }

    public void IncreaseAutonomousHighMissed()
    {
        dataManager.data.autonomousHighMissed += 1;
        autonomousHighMissedCounter.text = dataManager.data.autonomousHighMissed.ToString();
    }
    public void DecreaseAutonomousHighMissed()
    {
        dataManager.data.autonomousHighMissed -= 1;

        if (dataManager.data.autonomousHighMissed < 0)
        {
            dataManager.data.autonomousHighMissed = 0;
        }
        autonomousHighMissedCounter.text = dataManager.data.autonomousHighMissed.ToString();

    }

    public void IncreaseAutonomousLowScored()
    {
        dataManager.data.autonomousLowScored += 1;
        autonnomousLowScoredCounter.text = dataManager.data.autonomousLowScored.ToString();
    }

    public void DecreaseAutonomousLowScored()
    {
        dataManager.data.autonomousLowScored -= 1;

        if (dataManager.data.autonomousLowScored < 0)
        {
            dataManager.data.autonomousLowScored = 0;
        }
        autonnomousLowScoredCounter.text = dataManager.data.autonomousLowScored.ToString();

    }

    public void IncreaseAutonomousLowMissed()
    {
        dataManager.data.autonomousLowMissed += 1;
        autonomousLowMissedCounter.text = dataManager.data.autonomousLowMissed.ToString();
    }

    public void DecreaseAutonomousLowMissed()
    {
        dataManager.data.autonomousLowMissed -= 1;

        if (dataManager.data.autonomousLowMissed < 0)
        {
            dataManager.data.autonomousLowMissed = 0;
        }
        autonomousLowMissedCounter.text = dataManager.data.autonomousLowScored.ToString();

    }
}
