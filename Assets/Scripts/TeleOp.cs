using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeleOp : MonoBehaviour
{
    [SerializeField] DataManager dataManager;

    [SerializeField] TMP_Text teleOpHighScoredCounter;
    [SerializeField] TMP_Text teleOpHighMissedCounter;
    [SerializeField] TMP_Text teleOpLowScoredCounter;
    [SerializeField] TMP_Text teleOpLowMissedCounter;

    public void IncreaseTeleOpHighScored()
    {
        dataManager.data.teleOpHighScored += 1;
        teleOpHighScoredCounter.text = dataManager.data.teleOpHighScored.ToString();
    }

    public void DecreaseTeleOpHighScored()
    {
        dataManager.data.teleOpHighScored -= 1;

        if (dataManager.data.teleOpHighScored < 0)
        {
            dataManager.data.teleOpHighScored = 0;
        }
        teleOpHighScoredCounter.text = dataManager.data.teleOpHighScored.ToString();

    }

    public void IncreaseTeleOpHighMissed()
    {
        dataManager.data.teleOpHighMissed += 1;
        teleOpHighMissedCounter.text = dataManager.data.teleOpHighMissed.ToString();
    }
    public void DecreaseTeleOpHighMissed()
    {
        dataManager.data.teleOpHighMissed -= 1;

        if (dataManager.data.teleOpHighMissed < 0)
        {
            dataManager.data.teleOpHighMissed = 0;
        }
        teleOpHighMissedCounter.text = dataManager.data.teleOpHighMissed.ToString();

    }

    public void IncreaseTeleOpLowScored()
    {
        dataManager.data.teleOpLowScored += 1;
        teleOpLowScoredCounter.text = dataManager.data.teleOpLowScored.ToString();
    }

    public void DecreaseTeleOpLowScored()
    {
        dataManager.data.teleOpLowScored -= 1;

        if (dataManager.data.teleOpLowScored < 0)
        {
            dataManager.data.teleOpLowScored = 0;
        }
        teleOpLowScoredCounter.text = dataManager.data.teleOpLowScored.ToString();

    }

    public void IncreaseTeleOpLowMissed()
    {
        dataManager.data.teleOpLowMissed += 1;
        teleOpLowMissedCounter.text = dataManager.data.teleOpLowMissed.ToString();
    }

    public void DecreaseTeleOpLowMissed()
    {
        dataManager.data.teleOpLowMissed -= 1;

        if (dataManager.data.teleOpLowMissed < 0)
        {
            dataManager.data.teleOpLowMissed = 0;
        }
        teleOpLowMissedCounter.text = dataManager.data.teleOpLowScored.ToString();

    }
}
