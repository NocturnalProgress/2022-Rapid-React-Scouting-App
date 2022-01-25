using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroupScript : MonoBehaviour
{
    [SerializeField] Canvas beforeMatchCanvas;
    [SerializeField] Canvas autonomousCanvas;
    [SerializeField] Canvas teleOpCanvas;
    [SerializeField] Canvas endGameCanvas;
    [SerializeField] Canvas exportDataCanvas;
    [SerializeField] Canvas settingsCanvas;

    private void Start()
    {
        beforeMatchCanvas.enabled = true;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = false;
        exportDataCanvas.enabled = false;
        settingsCanvas.enabled = false;
    }

    public void OpenBeforeMatchCanvas()
    {
        beforeMatchCanvas.enabled = true;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = false;
        exportDataCanvas.enabled = false;
        settingsCanvas.enabled = false;
    }

    public void OpenAutonomousCanvas()
    {
        beforeMatchCanvas.enabled = false;
        autonomousCanvas.enabled = true;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = false;
        exportDataCanvas.enabled = false;
        settingsCanvas.enabled = false;
    }

    public void OpenTeleOpCanvas()
    {
        beforeMatchCanvas.enabled = false;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = true;
        endGameCanvas.enabled = false;
        exportDataCanvas.enabled = false;
        settingsCanvas.enabled = false;
    }

    public void OpenEndGameCanvas()
    {
        beforeMatchCanvas.enabled = false;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = true;
        exportDataCanvas.enabled = false;
        settingsCanvas.enabled = false;
    }

    public void OpenExportDataCanvas()
    {
        beforeMatchCanvas.enabled = false;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = false;
        exportDataCanvas.enabled = true;
        settingsCanvas.enabled = false;
    }

    public void OpenSettingsCanvas()
    {
        beforeMatchCanvas.enabled = false;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = false;
        exportDataCanvas.enabled = false;
        settingsCanvas.enabled = true;
    }
}