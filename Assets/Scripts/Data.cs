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
    public int autonomousHighScored;
    public int autonomousHighMissed;
    public int autonomousLowScored;
    public int autonomousLowMissed;
    public int teleOpHighScored;
    public int teleOpHighMissed;
    public int teleOpLowScored;
    public int teleOpLowMissed;
    public string climbLevel;
    public string alliancePartner;
    public string drivingEffectiveness;
    public string defenseEffectiveness;
    public string additionalNotes;


    [JsonConstructor]
    public Data(string name, string teamNumber, int matchNumber, string taxi, int autonomousHighScored, int autonomousHighMissed, int autonomousLowScored, int autonomousLowMissed, int teleOpHigh, int teleOpLow, int teleOpHighScored, int teleOpHighMissed, int teleOpLowScored, int teleOpLowMissed, string climbLevel, string alliancePartner, string drivingEffectiveness, string defenseEffectiveness, string additionalNotes)
    {
        this.name = name;
        this.teamNumber = teamNumber;
        this.matchNumber = matchNumber;
        this.taxi = taxi;
        this.autonomousHighScored = autonomousHighScored;
        this.autonomousHighMissed = autonomousHighMissed;
        this.autonomousLowScored = autonomousLowScored;
        this.autonomousLowMissed = autonomousLowMissed;
        this.teleOpHighScored = teleOpHighScored;
        this.teleOpHighMissed = teleOpHighMissed;
        this.teleOpLowScored = teleOpLowScored;
        this.teleOpLowMissed = teleOpLowMissed;
        this.climbLevel = climbLevel;
        this.alliancePartner = alliancePartner;
        this.drivingEffectiveness = drivingEffectiveness;
        this.defenseEffectiveness = defenseEffectiveness;
        this.additionalNotes = additionalNotes;
    }
}