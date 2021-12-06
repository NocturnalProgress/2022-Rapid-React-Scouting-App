using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Newtonsoft.Json;
using UnityEngine;
using System;

[Serializable]
public class Data
{
    // public string dataName = "Scouting Data";

    public string name;
    public string matchNumber;
    public string teamNumber;

    [JsonConstructor]
    public Data(string name, string matchNumber, string teamNumber)
    {
        this.name = name;
        this.matchNumber = matchNumber;
        this.teamNumber = teamNumber;
    }
}
