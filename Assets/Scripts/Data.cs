using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Newtonsoft.Json;
using UnityEngine;
using System;

[Serializable]
public struct Data
{
    // public string dataName = "Scouting Data";

    public string name;
    public string matchNumber;
    public string teamNumber;
    public int autonomousHigh;
    public int autonomousLow;
    public int teleOpHigh;
    public int teleOpLow;

    [JsonConstructor]
    public Data(string name, string matchNumber, string teamNumber, int autonomousHigh, int autonomousLow, int teleOpHigh, int teleOpLow)
    {
        this.name = name;
        this.matchNumber = matchNumber;
        this.teamNumber = teamNumber;
        this.autonomousHigh = autonomousHigh;
        this.autonomousLow = autonomousLow;
        this.teleOpHigh = teleOpHigh;
        this.teleOpLow = teleOpLow;
    }
}