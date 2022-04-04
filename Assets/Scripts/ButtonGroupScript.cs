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
    [SerializeField] Canvas shareDataCanvas;

    private void Start()
    {
        beforeMatchCanvas.enabled = true;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = false;
        exportDataCanvas.enabled = false;
        shareDataCanvas.enabled = false;
    }

    public void OpenBeforeMatchCanvas()
    {
        beforeMatchCanvas.enabled = true;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = false;
        exportDataCanvas.enabled = false;
        shareDataCanvas.enabled = false;
    }

    public void OpenAutonomousCanvas()
    {
        beforeMatchCanvas.enabled = false;
        autonomousCanvas.enabled = true;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = false;
        exportDataCanvas.enabled = false;
        shareDataCanvas.enabled = false;
    }

    public void OpenTeleOpCanvas()
    {
        beforeMatchCanvas.enabled = false;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = true;
        endGameCanvas.enabled = false;
        exportDataCanvas.enabled = false;
        shareDataCanvas.enabled = false;
    }

    public void OpenEndGameCanvas()
    {
        beforeMatchCanvas.enabled = false;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = true;
        exportDataCanvas.enabled = false;
        shareDataCanvas.enabled = false;
    }

    public void OpenExportDataCanvas()
    {
        beforeMatchCanvas.enabled = false;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = false;
        exportDataCanvas.enabled = true;
        shareDataCanvas.enabled = false;
    }

    public void OpenCompileDataButton()
    {
        beforeMatchCanvas.enabled = false;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = false;
        exportDataCanvas.enabled = false;
        shareDataCanvas.enabled = true;
    }
}