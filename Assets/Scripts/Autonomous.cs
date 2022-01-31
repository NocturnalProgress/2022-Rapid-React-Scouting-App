using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autonomous : MonoBehaviour
{
    public Data data;

    public void increaseAutonomousHigh()
    {
        data.autonomousHigh += 4;
    }

    public void decreaseAutonomousHigh()
    {
        data.autonomousHigh -= 4;
    }

    public void increaseAutonomousLow()
    {
        data.autonomousLow += 2;
    }

    public void decreaseAutonomousLow()
    {
        data.autonomousLow += 2;
    }
}
