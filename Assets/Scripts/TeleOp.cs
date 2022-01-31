using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleOp : MonoBehaviour
{
    public Data data;

    public void increaseTeleOpHigh()
    {
        data.teleOpHigh += 2;
    }

    public void decreaseTeleOpHigh()
    {
        data.teleOpHigh -= 2;
    }

    public void increaseTeleOpLow()
    {
        data.teleOpLow += 1;
    }

    public void decreaseTeleOpLow()
    {
        data.teleOpLow -= 1;
    }
}
