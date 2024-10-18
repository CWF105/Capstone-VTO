using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class btnFunctions : MonoBehaviour
{
    public GameObject PenPanel, PenPanel2;
    public GameObject SavePanel;
    public Button SaveBtn, PenBtn;

    void Start() {
        HideUI();
    }

// Show Pen Panel when clicking a button
    public void ShowPenPanel() {
        if (PenPanel.activeSelf) {
            HideUI();
            SaveBtn.interactable = true;
        } else {
            HideUI();
            PenPanel.SetActive(true);
            SaveBtn.interactable = false;
        }
    }
// show pen panel 2 when click edit
    public void ShowPenPanel2() {
        if (PenPanel2.activeSelf) {
            HideUI();
        } else {
            HideUI();
            PenPanel2.SetActive(true);
            SaveBtn.interactable = false;
        }
    }

// Show Save Panel when clicking a button
    public void ShowSavePanel() {
        if (SavePanel.activeSelf) {
            HideUI();
            PenBtn.interactable = true;
        } else {
            HideUI();
            SavePanel.SetActive(true);
            PenBtn.interactable = false;
        }
    }


    private void CloseUI() {
        HideUI();
    }

// Hide all UI panels
    private void HideUI() {
        PenPanel.SetActive(false);
        PenPanel2.SetActive(false);
        SavePanel.SetActive(false);
    }

// save button
    public void saveBTN() {
        
    }

// show keyboard
    public void openKeyboardOnClick(){
        if (Input.GetMouseButtonDown(0)) {
            OpenWindowsKeyboard();
        }
    }

    private void OpenWindowsKeyboard() {
        Process.Start("osk.exe"); 
    }

    public void CloseWindowsKeyboard() {
        Process[] oskProcess = Process.GetProcessesByName("osk");
        foreach (Process p in oskProcess)
        {
            p.Kill();  
        }
    }
}
