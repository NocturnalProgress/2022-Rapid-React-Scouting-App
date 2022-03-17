using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Newtonsoft.Json;
using UnityEngine;
using System;

[Serializable]
public struct Data
{
    public string name;
    public string teamNumber;
    public int matchNumber;
    public string taxi;
    public int autonomousHigh;
    public int autonomousLow;
    public int teleOpHigh;
    public int teleOpLow;
    public string climbLevel;
    public string alliancePartner;
    public string drivingEffectiveness;
    public string defenseEffectiveness;
    public string additionalNotes;


    [JsonConstructor]
    public Data(string name, string teamNumber, int matchNumber, string taxi, int autonomousHigh, int autonomousLow, int teleOpHigh, int teleOpLow, string climbLevel, string alliancePartner, string drivingEffectiveness, string defenseEffectiveness, string additionalNotes)
    {
        this.name = name;
        this.teamNumber = teamNumber;
        this.matchNumber = matchNumber;
        this.taxi = taxi;
        this.autonomousHigh = autonomousHigh;
        this.autonomousLow = autonomousLow;
        this.teleOpHigh = teleOpHigh;
        this.teleOpLow = teleOpLow;
        this.climbLevel = climbLevel;
        this.alliancePartner = alliancePartner;
        this.drivingEffectiveness = drivingEffectiveness;
        this.defenseEffectiveness = defenseEffectiveness;
        this.additionalNotes = additionalNotes;
    }
}